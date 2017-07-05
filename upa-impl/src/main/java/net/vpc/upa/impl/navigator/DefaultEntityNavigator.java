package net.vpc.upa.impl.navigator;

import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.EntityNavigator;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;

import java.util.List;

public class DefaultEntityNavigator implements EntityNavigator {
    protected Entity entity;

    public DefaultEntityNavigator(Entity entity) {
        this.entity = entity;
    }

    public Entity getEntity() {
        return entity;
    }

    public Object getNextKey(Object id)
            throws UPAException {
        return id == null ? getFirstKey() : getNavigateKey(entity, id, '>');
    }

    public Object getFirstKey()
            throws UPAException {
        return getNavigateKey(entity, null, '<');
    }

    public Object getLastKey()
            throws UPAException {
        return getNavigateKey(entity, null, '>');
    }

    public Object getPreviousKey(Object id)
            throws UPAException {
        return id == null ? getFirstKey() : getNavigateKey(entity, id, '<');
    }

    private Object getNavigateKey(Entity entity, Object id, char operator)
            throws UPAException {
        List<Field> pk = entity.getIdFields();
        if (pk.size() == 1) {
            Select s = new Select().from(entity.getName());
            s.from(entity.getName());
            String fieldName = pk.get(0).getName();
            if (id != null) {
                Object[] value = entity.getBuilder().idToKey(id).getValue();
                if (operator == '<') {
                    s.field(new Max(new Var(fieldName)), "next");
                    s.setWhere(new LessThan(new Var(fieldName), new Param(null, value[0])));
                } else if (operator == '>') {
                    s.field(new Min(new Var(fieldName)), "next");
                    s.setWhere(new GreaterThan(new Var(fieldName), new Param(null, value[0])));
                } else {
                    throw new RuntimeException("WouldNeverBeThrownException");
                }
            } else {
                if (operator == '<') {
                    s.field(new Min(new Var(fieldName)), "next");
                } else if (operator == '>') {
                    s.field(new Max(new Var(fieldName)), "next");
                } else {
                    throw new RuntimeException("WouldNeverBeThrownException");
                }
            }
            Document next = entity.getPersistenceUnit().createQuery(s).getDocument();
            if (next != null) {
                Object o = next.getObject("next");
                if (o != null) {
                    return entity.createId(o);
                }
            }
            return null;
        } else {

            Object[] v;
            Select sb = new Select();
            sb.top(1);

            for (Field aPk : pk) {
                sb.field(new Var(aPk.getName()));
            }

            sb.from(entity.getName());
            if (id != null) {
                Object[] value = entity.getBuilder().idToKey(id).getValue();
                Expression or = null;
                for (int i = 0; i < pk.size(); i++) {
                    Field pki = pk.get(i);
                    Expression a = null;
                    for (int j = 0; j < i; j++) {
                        Field pkj = pk.get(j);
                        Expression e = (new Equals(new Var(pkj.getName()), (new Param(null, value[j]))));
                        a = (a == null) ? e : new And(a, e);
                    }
                    Expression e2 = new LessThan(new Var(pki.getName()), new Param(null, value[i]));
                    a = (a == null) ? e2 : new And(a, e2);
                    or = or == null ? a : new Or(or, a);
                }
                sb.setWhere(or);
            }
            for (Field aPk : pk) {
                sb.orderBy(new Var(aPk.getName()), operator == '>');
            }
            Document r = entity.getPersistenceUnit().createQuery(sb).getDocument();
            if (r != null) {
                Object[] k = new Object[pk.size()];
                for (int i = 0; i < k.length; i++) {
                    k[i] = r.getObject(pk.get(i).getName());
                }
                return entity.createId(k);
            }
        }
        return null;
    }

    public Object getNewKey() throws UPAException {
        return null;
    }
}
