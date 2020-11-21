package net.thevpc.upa.impl;

import net.thevpc.upa.Action;
import net.thevpc.upa.Entity;
import net.thevpc.upa.QueryBuilder;
import net.thevpc.upa.VoidAction;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.impl.upql.util.UPQLUtils;
import net.thevpc.upa.types.DateTime;
import net.thevpc.upa.impl.sysentities.PrivateSequence;
import net.thevpc.upa.expressions.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 11:59 PM
 */
public class EntitySequenceManager implements SequenceManager {

    private Entity entity;

    public EntitySequenceManager(Entity entity) {
        this.entity = entity;
    }

    public synchronized PrivateSequence getOrCreateSequence(String name, String pattern, int initialValue, int increment) throws UPAException {
//        System.out.println(">>>>>>>>>>>>>>>>>>> getOrCreateSequence("+name+","+pattern+")");
        PrivateSequence r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getFirstResultOrNull();
        if (r == null) {
            r = createSequence(name, pattern, initialValue, increment);
            //r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getFirstResultOrNull();
        }
        return r;
    }

    @Override
    public synchronized PrivateSequence createSequence(String name, String pattern, int initialValue, int increment) throws UPAException {
        if (increment == 0) {
            throw new IllegalUPAArgumentException("increment zero");
        }
        final PrivateSequence r = entity.getBuilder().createObject();
        r.setName(name);
        r.setGroup(pattern);
        r.setLocked(false);
        r.setValue(initialValue);
        r.setIncrement(increment);
        entity.getPersistenceUnit().invokePrivileged(new CreateSequenceAction(r));
        return r;
//        System.out.println(">>>>>>>>>>>>>>>>>>> createSequence(" + name + "," + pattern + ")");
    }

    @Override
    public PrivateSequence getSequence(String name, String pattern) throws UPAException {
        PrivateSequence r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getFirstResultOrNull();
        if (r == null) {
            throw new UPAException("Sequence " + pattern + " not found");
        }
        return r;
    }

    @Override
    public boolean isLocked(String name, String pattern) throws UPAException {
        PrivateSequence r = getSequence(name, pattern);
        return (r.isLocked());
    }

    @Override
    public boolean isLockedBySelf(String name, String pattern) throws UPAException {
        return isLockedBy(name, pattern, entity.getPersistenceUnit().getUserPrincipal().getName());
    }

    @Override
    public boolean isLockedBy(String name, String pattern, String user) throws UPAException {
        PrivateSequence r = getSequence(name, pattern);
        return (r.isLocked() && r.getLockUserId().equals(user));
    }

    @Override
    public synchronized int lockValue(final String name, final String pattern) throws UPAException {
        final PrivateSequence r = getSequence(name, pattern);
        if (r.isLocked()) {
            throw new UPAException("Already locked");
        }
        r.setLocked(true);
        r.setLockUserId(entity.getPersistenceUnit().getUserPrincipal().getName());
        r.setLockDate(new DateTime());
        entity.getPersistenceUnit().invokePrivileged(new LockValueAction(r, name, pattern));
        return r.getValue();
    }

    @Override
    public synchronized int getCurrentValue(String name, String pattern) throws UPAException {
        PrivateSequence r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getFirstResultOrNull();
        if (r == null) {
            return -1;
        }
        return r.getValue();
    }

//    @Override
//    public synchronized int nextValue(String name, String pattern) throws UPAException {
//        return nextValue0(name, pattern, 0, 0, false);
//    }
    @Override
    public synchronized int nextValue(String name, String pattern, int initialValue, int increment) throws UPAException {
        return nextValue0(name, pattern, initialValue, increment, true);
    }

    public final int nextValue0(String name, String pattern, int initialValue, int increment, boolean autoCreate) throws UPAException {

        PrivateSequence r = autoCreate ? getOrCreateSequence(name, pattern, initialValue, increment) : getSequence(name, pattern);
        if (r.isLocked() && !r.getLockUserId().equals(entity.getPersistenceUnit().getUserPrincipal().getName())) {
            throw new UPAException("Already locked");
        }
        int v = r.getValue();
        r.setValue(v + r.getIncrement());
        r.setLocked(false);
        r.setLockUserId(null);
        r.setLockDate(null);
        Expression idToExpression = entity.getBuilder().idToExpression(entity.createId(name, pattern), UPQLUtils.THIS);
        final And condition = new And(idToExpression.copy(), new Or(
                new Different(new Var(new Var(UPQLUtils.THIS), "locked"), Literal.TRUE),
                new Equals(new Var(new Var(UPQLUtils.THIS), "lockUserId"),
                        new Param("lockUserId", entity.getPersistenceUnit().getUserPrincipal().getName()))));
        Integer ii = entity.getPersistenceUnit().invokePrivileged(new NextValueAction(condition));
        if (ii != null) {
            return ii.intValue();
        }
        //not found !
        //check if problem of locking
        if (entity.getEntityCount(new And(idToExpression.copy(), new Equals(new Var(new Var(UPQLUtils.THIS), "locked"), Literal.TRUE))) > 0) {
            throw new UPAException("Already locked");
        }
        throw new UPAException("Unexpected error");
    }

    @Override
    public synchronized int unlock(String name, final String pattern) throws UPAException {
        final PrivateSequence r = getSequence(name, pattern);
        if (!r.isLocked()) {
            throw new UPAException("not locked");
        }
        if (!r.getLockUserId().equals(entity.getPersistenceUnit().getUserPrincipal().getName())) {
            throw new UPAException("locked by others");
        }
        int v = r.getValue();
        r.setLocked(false);
        r.setLockUserId(null);
        r.setLockDate(null);
        entity.getPersistenceUnit().invokePrivileged(new UnlockAction(r, pattern));
        return v;
    }

    private class UnlockAction implements VoidAction {

        private final PrivateSequence r;
        private final String pattern;

        public UnlockAction(PrivateSequence r, String pattern) {
            this.r = r;
            this.pattern = pattern;
        }

        @Override
        public void run() {
            entity.createUpdateQuery().setValues(r).byId(entity.createId(pattern));
        }
    }

    private class NextValueAction implements Action<Integer> {

        private final And condition;

        public NextValueAction(And condition) {
            this.condition = condition;
        }

        @Override
        public Integer run() {
            QueryBuilder q = null;
            try {
                q = entity.createQueryBuilder().byExpression(condition);
                q.setUpdatable(true);
                int oldValue;
                for (PrivateSequence s : q.<PrivateSequence>getResultList()) {
                    oldValue = s.getValue();
                    s.setValue(oldValue + s.getIncrement());
                    q.updateCurrent();
//                System.out.println(">>>>>>>>>>>>>>>>>>> nextValue(" + name + "," + pattern + ") =>> "+oldValue);
return oldValue;
                }
            } finally {
                if (q != null) {
                    q.close();
                }
            }
            return null;
        }
    }

    private class LockValueAction implements VoidAction {

        private final PrivateSequence r;
        private final String name;
        private final String pattern;

        public LockValueAction(PrivateSequence r, String name, String pattern) {
            this.r = r;
            this.name = name;
            this.pattern = pattern;
        }

        @Override
        public void run() {
            entity.createUpdateQuery().setValues(r).byId(entity.createId(name, pattern));
        }
    }

    private class CreateSequenceAction implements VoidAction {

        private final PrivateSequence r;

        public CreateSequenceAction(PrivateSequence r) {
            this.r = r;
        }

        @Override
        public void run() {
            entity.persist(r);
        }
    }
}
