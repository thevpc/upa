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
import net.vpc.upa.impl.util.UPAUtils;
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
    public <R> R idToObject(Object id) throws UPAException {
        if (id == null) {
            return null;
        }
        R r = entity.getBuilder().createObject();
        Record ur = objectToRecord(r, true);
        List<Field> primaryFields = entity.getPrimaryFields();
        if (id == null) {
            for (Field aF : primaryFields) {
                ur.setObject(aF.getName(), null);
            }
        } else {
            Object[] uk = entity.getBuilder().getKey(id).getValue();
            for (int i = 0; i < primaryFields.size(); i++) {
                ur.setObject(primaryFields.get(i).getName(), uk[i]);
            }
        }
        return r;
    }

    @Override
    public Record idToRecord(Object id) throws UPAException {
        if (id == null) {
            return null;
        }
        Record ur = entity.getBuilder().createRecord();
        List<Field> primaryFields = entity.getPrimaryFields();
//        if (k == null) {
//            for (Field aF : primaryFields) {
//                ur.setObject(aF.getName(), null);
//            }
//        } else {
        Object[] uk = entity.getBuilder().getKey(id).getValue();
        for (int i = 0; i < primaryFields.size(); i++) {
            ur.setObject(primaryFields.get(i).getName(), uk[i]);
        }
//        }
        return ur;
    }

    @Override
    public Object objectToId(Object object) throws UPAException {
        if (object == null) {
            return null;
        }
        return recordToId(objectToRecord(object, true));
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
    public Key objectToKey(Object object) throws UPAException {
        if (object == null) {
            return null;
        }
        return recordToKey(objectToRecord(object, true));
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
    public Object keyToObject(Key key) throws UPAException {
        if (key == null) {
            return null;
        }
        return entity.getBuilder().getEntity(keyToRecord(key));
    }

    @Override
    public Record keyToRecord(Key key) throws UPAException {
        if (key == null) {
            return null;
        }
        Record ur = entity.getBuilder().createRecord();
        List<Field> primaryFields = entity.getPrimaryFields();
        if (key == null) {
            for (Field aF : primaryFields) {
                ur.setObject(aF.getName(), null);
            }
        } else {
            Object[] uk = key.getValue();
            for (int i = 0; i < primaryFields.size(); i++) {
                ur.setObject(primaryFields.get(i).getName(), uk[i]);
            }
        }
        return ur;
    }

    @Override
    public Key idToKey(Object id) throws UPAException {
        if (id == null) {
            return null;
        }
        return entity.getBuilder().getKey(id);
    }

    @Override
    public Object keyToId(Key uk) throws UPAException {
        if (uk == null) {
            return null;
        }
        return entity.getBuilder().getId(uk);
    }

    public Record objectToRecord(Object object) throws UPAException {
        return objectToRecord(object, false);
    }

    public Record objectToRecord(Object object, boolean ignoreUnspecified) throws UPAException {
        if (object == null) {
            return null;
        }
        return entity.getBuilder().getRecord(object, ignoreUnspecified);
    }

    public Object getMainProperty(Object object) throws UPAException {
        Field mf = entity.getMainField();
        Object v = getProperty(object, mf.getName());
        if(v!=null && mf.getDataType() instanceof EntityType && !UPAUtils.isSimpleFieldType(v.getClass())){
            Entity t = ((EntityType)mf.getDataType()).getRelationship().getTargetEntity();
            return t.getMainFieldValue(v);
        }
        return v;
    }

//    public Object entityToProperty(Object entityValue, String propertyName) throws UPAException {
//        return entityToProperty(entityValue, propertyName, false);
//    }
//
//    public Object entityToProperty(Object entityValue, String propertyName, boolean ignoreUnspecified) throws UPAException {
//        Record rec = objectToRecord(entityValue, ignoreUnspecified);
//        return rec == null ? null : rec.getObject(propertyName);
//    }
    @Override
    public <R> R recordToObject(Record record) throws UPAException {
        if (record == null) {
            return null;
        }
        return entity.getBuilder().getEntity(record);
    }

    public void setRecordId(Record record, Object id) throws UPAException {
        List<Field> f = entity.getPrimaryFields();
        if (id == null) {
            for (Field aF : f) {
                record.remove(aF.getName());
            }
            return;
        }
        Object[] uk = idToKey(id).getValue();
        if (f.size() > 0) {
            if (uk.length != f.size()) {
                throw new RuntimeException("key " + id + " could not denote for entity " + entity.getName() + " ; got " + uk.length + " elements instread of " + f.size());
            }
            for (int i = 0; i < f.size(); i++) {
                record.setObject(f.get(i).getName(), uk[i]);
            }
        }
    }

    public void setProperty(Object object, String property, Object value) throws UPAException {
        entity.getBuilder().setProperty(object, property, value);
    }

    public Object getProperty(Object object, String property) throws UPAException {
        return entity.getBuilder().getProperty(object, property);
    }

    public void setObjectId(Object object, Object id) throws UPAException {
        setRecordId(objectToRecord(object, true), id);
    }

    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException {
        return recordToExpression(objectToRecord(object, ignoreUnspecified), alias);
    }

    public Expression recordToExpression(Record record, String alias) throws UPAException {
        if (record == null) {
            return null;
        }
        Expression a = null;
        for (Map.Entry<String, Object> entry : record.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            Field field = entity.getField(key);
            if (!field.isUnspecifiedValue(value)) {
                Expression e = null;
                Var p = new Var(Strings.isNullOrEmpty(alias) ? entity.getName() : alias);
                switch (field.getSearchOperator()) {
                    case DEFAULT:
                    case EQ: {
                        if (field.getDataType() instanceof EntityType) {
                            EntityType et = (EntityType) field.getDataType();
                            Key foreignKey = et.getRelationship().getTargetRole().getEntity().getBuilder().objectToKey(value);
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
    public Expression idToExpression(Object id, String entityAlias) {
        if (id == null) {
            return null;
        }
        //        keyExpression.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
        return new IdExpression(entity, id, entityAlias);
    }

    @Override
    public Expression objectToIdExpression(Object entityOrRecord, String alias) throws UPAException {
        if(entityOrRecord==null){
            return null;
        }
        Record r = null;
        if(entityOrRecord instanceof Record){
            r=(Record)entityOrRecord;
        }
        r = objectToRecord(entityOrRecord);
        Key k = recordToKey(r);
        return keyToExpression(k, alias);
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
