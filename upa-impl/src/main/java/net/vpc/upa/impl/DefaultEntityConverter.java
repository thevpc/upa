package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.expressions.IdEnumerationExpression;
import net.vpc.upa.expressions.IdExpression;
import net.vpc.upa.impl.util.CastConverter;
import net.vpc.upa.impl.util.ConvertedList;

import java.util.List;
import java.util.Map;
import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.types.EntityType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 12:45 AM
 */
public class DefaultEntityConverter implements EntityConverter {

    private Entity entity;

    public DefaultEntityConverter(Entity entity) {
        this.entity = entity;
    }

    @Override
    public <R> R idToEntity(Object k) throws UPAException {
        if (k == null) {
            return null;
        }
        R r = entity.getBuilder().createObject();
        Record ur = entityToRecord(r, true);
        List<Field> primaryFields = entity.getPrimaryFields();
        if (k == null) {
            for (Field aF : primaryFields) {
                ur.setObject(aF.getName(), null);
            }
        } else {
            Object[] uk = entity.getBuilder().getKey(k).getValue();
            for (int i = 0; i < primaryFields.size(); i++) {
                ur.setObject(primaryFields.get(i).getName(), uk[i]);
            }
        }
        return r;
    }

    @Override
    public Record idToRecord(Object k) throws UPAException {
        if (k == null) {
            return null;
        }
        Record ur = entity.getBuilder().createRecord();
        List<Field> primaryFields = entity.getPrimaryFields();
//        if (k == null) {
//            for (Field aF : primaryFields) {
//                ur.setObject(aF.getName(), null);
//            }
//        } else {
        Object[] uk = entity.getBuilder().getKey(k).getValue();
        for (int i = 0; i < primaryFields.size(); i++) {
            ur.setObject(primaryFields.get(i).getName(), uk[i]);
        }
//        }
        return ur;
    }

    @Override
    public Object entityToId(Object r) throws UPAException {
        if (r == null) {
            return null;
        }
        return recordToId(entityToRecord(r, true));
    }

    @Override
    public Object recordToId(Record record) throws UPAException {
        if (record == null) {
            return null;
        }
        List<Field> f = entity.getPrimaryFields();
        Object[] rawKey = new Object[f.size()];
        for (int i = 0; i < rawKey.length; i++) {
            final Field field = f.get(i);
            final String name = field.getName();
            if (record.isSet(name)) {
                rawKey[i] = record.getObject(name);
            } else {
                return null;
            }
        }
        return entity.getBuilder().createId(rawKey);
    }

    @Override
    public Key entityToKey(Object r) throws UPAException {
        if (r == null) {
            return null;
        }
        return recordToKey(entityToRecord(r, true));
    }

    @Override
    public Key recordToKey(Record record) throws UPAException {
        if (record == null) {
            return null;
        }
        List<Field> f = entity.getPrimaryFields();
        Object[] rawKey = new Object[f.size()];
        for (int i = 0; i < rawKey.length; i++) {
            final Field field = f.get(i);
            final String name = field.getName();
            if (record.isSet(name)) {
                rawKey[i] = record.getObject(name);
            } else {
                return entity.getBuilder().createKey((Object[]) null);
            }
        }
        return entity.getBuilder().createKey(rawKey);
    }

    @Override
    public Object keyToEntity(Key uk) throws UPAException {
        if (uk == null) {
            return null;
        }
        return entity.getBuilder().getEntity(keyToRecord(uk));
    }

    @Override
    public Record keyToRecord(Key k) throws UPAException {
        if (k == null) {
            return null;
        }
        Record ur = entity.getBuilder().createRecord();
        List<Field> primaryFields = entity.getPrimaryFields();
        if (k == null) {
            for (Field aF : primaryFields) {
                ur.setObject(aF.getName(), null);
            }
        } else {
            Object[] uk = k.getValue();
            for (int i = 0; i < primaryFields.size(); i++) {
                ur.setObject(primaryFields.get(i).getName(), uk[i]);
            }
        }
        return ur;
    }

    @Override
    public Key idToKey(Object entityId) throws UPAException {
        if (entityId == null) {
            return null;
        }
        return entity.getBuilder().getKey(entityId);
    }

    @Override
    public Object keyToId(Key uk) throws UPAException {
        if (uk == null) {
            return null;
        }
        return entity.getBuilder().getId(uk);
    }

    public Record entityToRecord(Object entityValue) throws UPAException {
        return entityToRecord(entityValue, false);
    }

    public Record entityToRecord(Object entityValue, boolean ignoreUnspecified) throws UPAException {
        if (entityValue == null) {
            return null;
        }
        return entity.getBuilder().getRecord(entityValue, ignoreUnspecified);
    }

    public Object getMainProperty(Object entityValue) throws UPAException {
        return getProperty(entityValue, entity.getMainField().getName());
    }

//    public Object entityToProperty(Object entityValue, String propertyName) throws UPAException {
//        return entityToProperty(entityValue, propertyName, false);
//    }
//
//    public Object entityToProperty(Object entityValue, String propertyName, boolean ignoreUnspecified) throws UPAException {
//        Record rec = entityToRecord(entityValue, ignoreUnspecified);
//        return rec == null ? null : rec.getObject(propertyName);
//    }
    @Override
    public <R> R recordToEntity(Record ur) throws UPAException {
        if (ur == null) {
            return null;
        }
        return entity.getBuilder().getEntity(ur);
    }

    public void setRecordId(Record r, Object id) throws UPAException {
        List<Field> f = entity.getPrimaryFields();
        if (id == null) {
            for (Field aF : f) {
                r.remove(aF.getName());
            }
            return;
        }
        Object[] uk = idToKey(id).getValue();
        if (f.size() > 0) {
            if (uk.length != f.size()) {
                throw new RuntimeException("key " + id + " could not denote for entity " + entity.getName() + " ; got " + uk.length + " elements instread of " + f.size());
            }
            for (int i = 0; i < f.size(); i++) {
                r.setObject(f.get(i).getName(), uk[i]);
            }
        }
    }

    public void setProperty(Object entityObject, String property, Object value) throws UPAException {
        entity.getBuilder().setProperty(entityObject, property, value);
    }

    public Object getProperty(Object entityObject, String property) throws UPAException {
        return entity.getBuilder().getProperty(entityObject, property);
    }

    public void setEntityId(Object entity, Object id) throws UPAException {
        setRecordId(entityToRecord(entity, true), id);
    }

    public Expression entityToExpression(Object obj, boolean ignoreUnspecified, String entityAlias) throws UPAException {
        return recordToExpression(entityToRecord(obj, ignoreUnspecified), entityAlias);
    }

    public Expression recordToExpression(Record record, String entityAlias) throws UPAException {
        if (record == null) {
            return null;
        }
        Expression a = null;
        for (Map.Entry<String, Object> entry : record.toMap().entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            Field field = entity.getField(key);
            if (!field.isUnspecifiedValue(value)) {
                Expression e = null;
                Var p = new Var(Strings.isNullOrEmpty(entityAlias) ? entity.getName() : entityAlias);
                switch (field.getSearchOperator()) {
                    case DEFAULT:
                    case EQ: {
                        if (field.getDataType() instanceof EntityType) {
                            EntityType et = (EntityType) field.getDataType();
                            Key foreignKey = et.getRelationship().getTargetRole().getEntity().getBuilder().entityToKey(value);
                            Expression b = null;
                            int i = 0;
                            for (Field df : et.getRelationship().getSourceRole().getFields()) {
                                e = new Equals(new Var((Var) p.copy(), df.getName()), ExpressionFactory.toLiteral(foreignKey.getObjectAt(i)));
                                b = b == null ? b : new And(b, e);
                                i++;
                            }
                        } else {
                            e = new Equals(new Var(p, key), ExpressionFactory.toLiteral(value));
                        }
                        break;
                    }
                    case NE: {
                        e = new Different(new Var(p, key), ExpressionFactory.toLiteral(value));
                        break;
                    }
                    case GT: {
                        e = new GreaterThan(new Var(p, key), ExpressionFactory.toLiteral(value));
                        break;
                    }
                    case GTE: {
                        e = new GreaterEqualThan(new Var(p, key), ExpressionFactory.toLiteral(value));
                        break;
                    }
                    case LT: {
                        e = new LessThan(new Var(p, key), ExpressionFactory.toLiteral(value));
                        break;
                    }
                    case LTE: {
                        e = new LessEqualThan(new Var(p, key), ExpressionFactory.toLiteral(value));
                        break;
                    }
                    case CONTAINS: {
                        e = new Like(new Var(p, key), ExpressionFactory.toLiteral("%" + value + "%"));
                        break;
                    }
                    case STARTS_WITH: {
                        e = new Like(new Var(p, key), ExpressionFactory.toLiteral(value + "%"));
                        break;
                    }
                    case ENDS_WITH: {
                        e = new Like(new Var(p, key), ExpressionFactory.toLiteral("%" + value));
                        break;
                    }
                }
                if (e != null) {
                    a = a == null ? e : new And(a, e);
                }
            }
        }
        return a;
    }

//    public Expression idToExpression(Object key) throws UPAException {
//        return idToExpression(key, null);
//    }
    public Expression idToExpression(Object key, String entityAlias) {
        if (key == null) {
            return null;
        }
        //        keyExpression.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
        return new IdExpression(entity, key, entityAlias);
    }

    public Expression keyToExpression(Key key, String entityAlias) {
        Object id = keyToId(key);
        return idToExpression(id, entityAlias);
    }

    public <K> Expression idListToExpression(List<K> idList, String entityAlias) {
        List<Object> convertedList = new ConvertedList<K, Object>(idList, new CastConverter<K, Object>());

        //        keyEnumerationExpression.setClientProperty(EXPRESSION_SURELY_EXISTS,keys.size() > 0);
        return new IdEnumerationExpression(
                convertedList, entityAlias == null ? null : new Var(entityAlias));
    }

    @Override
    public Expression keyListToExpression(List<Key> keyList, String alias) throws UPAException {
        List<Object> list = new ConvertedList<Key, Object>(keyList, new KeyToIdConverter<Object>(entity));
        return idListToExpression(list, alias
        );
    }
}
