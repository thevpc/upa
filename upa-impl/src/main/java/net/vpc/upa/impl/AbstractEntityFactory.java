package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.util.CastConverter;
import net.vpc.upa.impl.util.ConvertedList;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.ManyToOneType;

import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/28/12 12:45 AM
 */
public abstract class AbstractEntityFactory implements EntityFactory {

    @Override
    public Document objectToDocument(Object object, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds) {
        Document r = createDocument();
        Document allFieldsDocument = objectToDocument(object,ignoreUnspecified);
        if(fields==null || fields.isEmpty()){
            r.setAll(r);
            return r;
        }else {
            for (String k : fields) {
                r.setObject(k, allFieldsDocument.getObject(k));
            }
            if(ensureIncludeIds) {
                for (Field o : getEntity().getIdFields()) {
                    String idname = o.getName();
                    if (!r.isSet(idname)) {
                        r.setObject(idname, allFieldsDocument.getObject(idname));
                    }
                }
            }
            return r;
        }
    }
    protected abstract Entity getEntity();

    @Override
    public <R> R idToObject(Object id) throws UPAException {
        if (id == null) {
            return null;
        }
        Entity entity = getEntity();
        R r = createObject();
        Document ur = objectToDocument(r, true);
        List<Field> primaryFields = entity.getIdFields();
        if (id == null) {
            for (Field aF : primaryFields) {
                ur.setObject(aF.getName(), null);
            }
        } else {
            Object[] uk = entity.getBuilder().getKey(id).getValue();
            for (int i = 0; i < primaryFields.size(); i++) {
                Object value = uk[i];
                ur.setObject(primaryFields.get(i).getName(), value);
            }
        }
        return r;
    }

    @Override
    public Document idToDocument(Object id) throws UPAException {
        if (id == null) {
            return null;
        }
        Entity entity = getEntity();
        Document ur = createDocument();
        List<Field> primaryFields = entity.getIdFields();
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
        if (object instanceof Document) {
            return documentToId((Document) object);
        }
        Entity entity = getEntity();
        List<Field> f = entity.getIdFields();
        Object[] rawKey = new Object[f.size()];
        for (int i = 0; i < rawKey.length; i++) {
            final Field field = f.get(i);
            final String name = field.getName();
            if(!entity.getPlatformBeanType().isDefaultValue(object,name)){
                rawKey[i] = getProperty(object, name);
            }else {
                return null;
            }
        }
        return entity.getBuilder().createId(rawKey);
    }

    @Override
    public Object documentToId(Document document) throws UPAException {
        if (document == null) {
            return null;
        }
        Entity entity = getEntity();
        List<Field> f = entity.getIdFields();
        Object[] rawKey = new Object[f.size()];
        for (int i = 0; i < rawKey.length; i++) {
            final Field field = f.get(i);
            final String name = field.getName();
            if (document.isSet(name)) {
                rawKey[i] = document.getObject(name);
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
        if (object instanceof Document) {
            return documentToKey((Document) object);
        }
        Entity entity = getEntity();
        List<Field> f = entity.getIdFields();
        Object[] rawKey = new Object[f.size()];
        for (int i = 0; i < rawKey.length; i++) {
            final Field field = f.get(i);
            final String name = field.getName();
            if(!entity.getPlatformBeanType().isDefaultValue(object,name)){
                rawKey[i] = getProperty(object, name);
            }else {
                return null;
            }
        }
        return entity.getBuilder().createKey(rawKey);
    }

    @Override
    public Key documentToKey(Document document) throws UPAException {
        if (document == null) {
            return null;
        }
        Entity entity = getEntity();
        List<Field> f = entity.getIdFields();
        Object[] rawKey = new Object[f.size()];
        for (int i = 0; i < rawKey.length; i++) {
            final Field field = f.get(i);
            final String name = field.getName();
            if (document.isSet(name)) {
                rawKey[i] = document.getObject(name);
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
        return objectToDocument(keyToDocument(key));
    }

    @Override
    public Document keyToDocument(Key key) throws UPAException {
        if (key == null) {
            return null;
        }
        Document ur = createDocument();
        List<Field> primaryFields = getEntity().getIdFields();
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
        return getEntity().getBuilder().getKey(id);
    }

    @Override
    public Object keyToId(Key documentKey) throws UPAException {
        if (documentKey == null) {
            return null;
        }
        return getEntity().getBuilder().getId(documentKey);
    }

    public Document objectToDocument(Object object) throws UPAException {
        return objectToDocument(object, false);
    }

    public Object getMainProperty(Object object) throws UPAException {
        Field mf = getEntity().getMainField();
        Object v = getProperty(object, mf.getName());
        Relationship manyToOneRelationship = mf.getManyToOneRelationship();
        if(v!=null && manyToOneRelationship!=null && !UPAUtils.isSimpleFieldType(v.getClass())){
            Entity t = manyToOneRelationship.getTargetEntity();
            return t.getMainFieldValue(v);
        }
        return v;
    }

    //    public Object entityToProperty(Object entityValue, String propertyName) throws UPAException {
//        return entityToProperty(entityValue, propertyName, false);
//    }
//
//    public Object entityToProperty(Object entityValue, String propertyName, boolean ignoreUnspecified) throws UPAException {
//        Document rec = objectToDocument(entityValue, ignoreUnspecified);
//        return rec == null ? null : rec.getObject(propertyName);
//    }

    public void setDocmentId(Document document, Object id) throws UPAException {
        List<Field> f = getEntity().getIdFields();
        if (id == null) {
            for (Field aF : f) {
                document.remove(aF.getName());
            }
            return;
        }
        Object[] uk = idToKey(id).getValue();
        if (f.size() > 0) {
            if (uk.length != f.size()) {
                throw new RuntimeException("key " + id + " could not denote for entity " + getEntity().getName() + " ; got " + uk.length + " elements instread of " + f.size());
            }
            for (int i = 0; i < f.size(); i++) {
                document.setObject(f.get(i).getName(), uk[i]);
            }
        }
    }

    public void setObjectId(Object object, Object id) throws UPAException {
        setDocmentId(objectToDocument(object, true), id);
    }

    public Expression objectToExpression(Object object, boolean ignoreUnspecified, String alias) throws UPAException {
        return documentToExpression(objectToDocument(object, ignoreUnspecified), alias);
    }

    public Expression documentToExpression(Document document, String alias) throws UPAException {
        if (document == null) {
            return null;
        }
        Expression a = null;
        for (Map.Entry<String, Object> entry : document.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            Field field = getEntity().getField(key);
            if (!field.isUnspecifiedValue(value)) {
                Expression e = null;
                Var p = new Var(StringUtils.isNullOrEmpty(alias) ? getEntity().getName() : alias);
                switch (field.getSearchOperator()) {
                    case DEFAULT:
                    case EQ: {
                        Relationship manyToOneRelationship = field.getManyToOneRelationship();
                        if (manyToOneRelationship!=null) {
                            Key foreignKey = manyToOneRelationship.getTargetRole().getEntity().getBuilder().objectToKey(value);
                            Expression b = null;
                            int i = 0;
                            for (Field df : manyToOneRelationship.getSourceRole().getFields()) {
                                e = new Equals(new Var((Var) p.copy(), df.getName()), ExpressionFactory.toLiteral(foreignKey.getObjectAt(i)));
                                b = b == null ? e : new And(b, e);
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
//        if (id == null) {//TODO TAHA
//            return null;
//        }
//        keyExpression.setClientProperty(EXPRESSION_SURELY_EXISTS, true);
        return new IdExpression(getEntity(), id, entityAlias);
    }

    @Override
    public Expression objectToIdExpression(Object entityOrDocument, String alias) throws UPAException {
        if(entityOrDocument==null){
            return null;
        }
        Document r = null;
        if(entityOrDocument instanceof Document){
            r=(Document)entityOrDocument;
        }
        r = objectToDocument(entityOrDocument);
        Key k = documentToKey(r);
        return keyToExpression(k, alias);
    }



    public Expression keyToExpression(Key documentKey, String entityAlias) {
        Object id = keyToId(documentKey);
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
        List<Object> list = new ConvertedList<Key, Object>(keyList, new KeyToIdConverter<Object>(getEntity()));
        return idListToExpression(list, alias
        );
    }
}
