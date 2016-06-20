package net.vpc.upa.impl;

import net.vpc.upa.types.DateTime;
import net.vpc.upa.Entity;
import net.vpc.upa.QueryBuilder;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;

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
        PrivateSequence r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getEntity();
        if (r == null) {
            createSequence(name, pattern, initialValue, increment);
            r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getEntity();
        }
        return r;
    }

    @Override
    public synchronized void createSequence(String name, String pattern, int initialValue, int increment) throws UPAException {
        if (increment == 0) {
            throw new IllegalArgumentException("increment zero");
        }
        final PrivateSequence r = (PrivateSequence) entity.getBuilder().createObject();
        r.setName(name);
        r.setGroup(pattern);
        r.setLocked(false);
        r.setValue(initialValue);
        r.setIncrement(increment);
        entity.persist(r);
//        System.out.println(">>>>>>>>>>>>>>>>>>> createSequence(" + name + "," + pattern + ")");
    }

    @Override
    public PrivateSequence getSequence(String name, String pattern) throws UPAException {
        PrivateSequence r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getEntity();
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
    public synchronized int lockValue(String name, String pattern) throws UPAException {
        PrivateSequence r = getSequence(name, pattern);
        if (r.isLocked()) {
            throw new UPAException("Already locked");
        }
        r.setLocked(true);
        r.setLockUserId(entity.getPersistenceUnit().getUserPrincipal().getName());
        r.setLockDate(new DateTime());
        entity.createUpdateQuery().setValues(r).byId(entity.createId(name, pattern));
        return r.getValue();
    }

    @Override
    public synchronized int getCurrentValue(String name, String pattern) throws UPAException {
        PrivateSequence r = entity.createQueryBuilder().byId(entity.createId(name, pattern)).getEntity();
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
        return nextValue0(name, pattern, initialValue, increment,true);
    }

    public final int nextValue0(String name, String pattern, int initialValue, int increment, boolean autoCreate) throws UPAException {
        
        PrivateSequence r = autoCreate ? getOrCreateSequence(name, pattern, initialValue, increment) : getSequence(name, pattern);
        if (r.isLocked() && !r.getLockUserId().equals(entity.getPersistenceUnit().getUserPrincipal().getName())) {
            throw new UPAException("Already locked");
        }
        final int v = r.getValue();
        r.setValue(v + r.getIncrement());
        r.setLocked(false);
        r.setLockUserId(null);
        r.setLockDate(null);
        Expression idToExpression = entity.getBuilder().idToExpression(entity.createId(name, pattern),entity.getName());
        And condition = new And(idToExpression, new Or(
                new Different(new Var(new Var(entity.getName()),"locked"), Literal.TRUE),
                new Equals(new Var(new Var(entity.getName()),"lockUserId"), new Param("lockUserId", entity.getPersistenceUnit().getUserPrincipal().getName()))));
        QueryBuilder q = null;
        try {
            q = entity.createQueryBuilder().byExpression(condition);
            q.setUpdatable(true);
            int oldValue;
            for (PrivateSequence s : q.<PrivateSequence>getEntityList()) {
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
        //not found !
        //check if problem of locking
        if (entity.getEntityCount(new And(idToExpression, new Equals(new Var("locked"), Literal.TRUE))) > 0) {
            throw new UPAException("Already locked");
        }
        throw new UPAException("Unexpected error");
    }

    @Override
    public synchronized int unlock(String name, String pattern) throws UPAException {
        PrivateSequence r = getSequence(name, pattern);
        if (!r.isLocked()) {
            throw new UPAException("not locked");
        }
        if (!r.getLockUserId().equals(entity.getPersistenceUnit().getUserPrincipal().getName())) {
            throw new UPAException("locked by others");
        }
        final int v = r.getValue();
        r.setLocked(false);
        r.setLockUserId(null);
        r.setLockDate(null);
        entity.createUpdateQuery().setValues(r).byId(entity.createId(pattern));
        return v;
    }
}
