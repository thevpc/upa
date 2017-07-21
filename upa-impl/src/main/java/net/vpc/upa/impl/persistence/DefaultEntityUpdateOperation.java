package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.uql.util.UQLUtils;
import net.vpc.upa.impl.util.filters.FieldFilters2;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.EntityUpdateOperation;
import net.vpc.upa.types.ManyToOneType;

import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityUpdateOperation implements EntityUpdateOperation {
    boolean globalEnableSimpleUpdateCache=false;
    private <T> T get(String name, Entity entity, EntityExecutionContext context) {
        return (T) context.getConnection().getProperty("DefaultEntityUpdateOperation." + entity.getName() + "." + name);
    }

    private void set(String name, Object value, Entity entity, EntityExecutionContext context) {
        context.getConnection().setProperty("DefaultEntityUpdateOperation." + entity.getName() + "." + name, value);
    }

    public int update(Entity entity, EntityExecutionContext context, Document updates, Expression condition) throws UPAException {
        if(globalEnableSimpleUpdateCache) {
            String updateOneCacheId = createUpdateOneCacheId(updates, condition);
            UpdateOneCache cache = get("UpdateOneCache", entity, context);
            Query query = null;
            if (cache == null) {
                cache = new UpdateOneCache(updateOneCacheId);
                query = createQueryAndCheckReuse(entity, context, updates, condition, cache);
                set("UpdateOneCache", cache, entity, context);
            } else {
                query = updateUsingCache(entity, context, updates, condition, cache.query);
            }
            return query.executeNonQuery();
        }
        return createQueryAndCheckReuse(entity, context, updates, condition, null).executeNonQuery();
    }

    private static String createUpdateOneCacheId(Document updates, Expression condition){
        HashSet<String> keys=new HashSet<String>();
        for (Map.Entry<String, Object> e : updates.entrySet()) {
            Object v = e.getValue();
            if(v!=null && !(v instanceof Param) && v instanceof Expression){
                return null;
            }
            keys.add(e.getKey());
        }
        if(!(condition instanceof IdExpression)){
            return null;
        }
        String id=keys.toString();
        return id;
    }

    private static class UpdateOneCache{
        String id;
        boolean enabled;
        Query query;

        public UpdateOneCache(String id) {
            this.id = id;
        }
    }

    public Query createQueryAndCheckReuse(Entity entity, EntityExecutionContext context, Document updates, Expression condition, UpdateOneCache cache) throws UPAException {
        boolean enableCache = true;
        Update u = new Update().entity(entity.getName());
        for (String fieldName : updates.keySet()) {
            Field f = entity.findField(fieldName);
            if (f != null && FieldFilters2.UPDATE.accept(f)) {
                Object value = updates.getObject(fieldName);
                if ((f.getDataType() instanceof ManyToOneType)) {
                    ManyToOneType e = (ManyToOneType) f.getDataType();
                    if (e.isUpdatable()) {
                        String rname = e.getName()+"_";
                        Entity masterEntity = context.getPersistenceUnit().getEntity(e.getTargetEntityName());
                        EntityBuilder mbuilder = masterEntity.getBuilder();
                        if (value instanceof Expression) {
                            Expression evalue;
                            java.util.List<Field> sfields = e.getRelationship().getSourceRole().getFields();
                            java.util.List<Field> tfields = e.getRelationship().getTargetRole().getFields();
                            for (int i = 0; i < sfields.size(); i++) {
                                Field fk = sfields.get(i);
                                Field fid = tfields.get(i);
                                evalue = ((Expression) value).copy();
                                evalue = context.getPersistenceUnit().getExpressionManager().parseExpression(evalue);
                                if (evalue instanceof Select) {
                                    Select svalue = (Select) evalue;
                                    if (svalue.countFields() != 1) {
                                        throw new RuntimeException("Invalid Expression " + svalue + " as formula for field " + f.getAbsoluteName());
                                    }
                                    if (svalue.getField(0).getExpression() instanceof Var) {
                                        svalue.getField(0).setExpression(new Var(svalue.getField(0).getExpression(), fid.getName()));
                                    } else {
                                        throw new RuntimeException("Invalid Expression " + svalue + " as formula for field " + f.getAbsoluteName());
                                    }
                                } else if (evalue instanceof Var) {
                                    evalue = (new Var((Var) evalue, fk.getName()));
                                } else if (evalue instanceof Param) {
                                    //okkay
                                } else if (evalue instanceof Literal) {
                                    //okkay
                                } else {
                                    throw new RuntimeException("Invalid Expression " + evalue + " as formula for field " + f.getAbsoluteName());
                                }
                                u.set(fk.getName(), evalue);
                            }
                        } else {
                            Key k = null;
                            if (value instanceof Document) {
                                k = mbuilder.documentToKey((Document) value);
                            } else {
                                k = mbuilder.objectToKey(value);
                            }
                            int x = 0;
                            for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                                u.set(fk.getName(), new Param(rname+fk.getName(), k == null ? null : k.getObjectAt(x)));
                                x++;
                            }
                        }
                    }
                } else {
                    if(value ==null || !(value instanceof Expression)){
                        u.set(fieldName, new Param(fieldName, value));
                    }else if(value instanceof Param){
                        u.set(fieldName, (Param)value);
                    }else {
                        enableCache = false;
                        u.set(fieldName, (Expression) value);
                    }
                }
            }
        }
        if (condition instanceof IdExpression) {
            IdExpression idc = (IdExpression) condition;
            if (idc.getEntity() == null) {
                idc.setEntity(entity);
            }
            u.where(UQLUtils.expandIdExpression("upa_id", idc));
        } else {
            enableCache = false;
            u.where(condition);
        }
        Query query = context.getPersistenceStore().createQuery(u, context);
        if (enableCache && cache != null) {
            cache.enabled=enableCache;
            cache.query=query;
        }
        return query;
    }

    public Query updateUsingCache(Entity entity, EntityExecutionContext context, Document updates, Expression condition, Query query) throws UPAException {
        IdExpression idc = (IdExpression) condition;
        List<Field> idFields = entity.getIdFields();
        Object newId = idc.getId();
        if (idFields.size() == 1) {
            query.setParameter("upa_id1", newId);
        } else {
            Object[] newIdArr = (Object[]) newId;
            int idIndex = 1;
            for (Field field : idFields) {
                query.setParameter("upa_id" + idIndex, newIdArr[idIndex]);
                idIndex++;
            }
        }
        for (String fieldName : updates.keySet()) {
            Field f = entity.findField(fieldName);
            if (f != null && FieldFilters2.UPDATE.accept(f)) {
                Object value = updates.getObject(fieldName);
                if ((f.getDataType() instanceof ManyToOneType)) {
                    ManyToOneType e = (ManyToOneType) f.getDataType();
                    if (e.isUpdatable()) {
                        String rname = e.getName()+"_";
                        Entity masterEntity = context.getPersistenceUnit().getEntity(e.getTargetEntityName());
                        EntityBuilder mbuilder = masterEntity.getBuilder();
                        if (value instanceof Expression) {
                            Expression evalue;
                            java.util.List<Field> sfields = e.getRelationship().getSourceRole().getFields();
                            java.util.List<Field> tfields = e.getRelationship().getTargetRole().getFields();
                            for (int i = 0; i < sfields.size(); i++) {
                                Field fk = sfields.get(i);
                                Field fid = tfields.get(i);
                                evalue = ((Expression) value).copy();
                                evalue = context.getPersistenceUnit().getExpressionManager().parseExpression(evalue);
                                if (evalue instanceof Select) {
                                    Select svalue = (Select) evalue;
                                    if (svalue.countFields() != 1) {
                                        throw new RuntimeException("Invalid Expression " + svalue + " as formula for field " + f.getAbsoluteName());
                                    }
                                    if (svalue.getField(0).getExpression() instanceof Var) {
                                        svalue.getField(0).setExpression(new Var(svalue.getField(0).getExpression(), fid.getName()));
                                    } else {
                                        throw new RuntimeException("Invalid Expression " + svalue + " as formula for field " + f.getAbsoluteName());
                                    }
                                } else if (evalue instanceof Var) {
                                    evalue = (new Var((Var) evalue, fk.getName()));
                                } else if (evalue instanceof Param) {
                                    //okkay
                                } else if (evalue instanceof Literal) {
                                    //okkay
                                } else {
                                    throw new RuntimeException("Invalid Expression " + evalue + " as formula for field " + f.getAbsoluteName());
                                }
                                query.setParameter(fk.getName(), evalue);
                            }
                        } else {
                            Key k = null;
                            if (value instanceof Document) {
                                k = mbuilder.documentToKey((Document) value);
                            } else {
                                k = mbuilder.objectToKey(value);
                            }
                            int x = 0;
                            for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                                query.setParameter(fk.getName(), new Param(rname+"_"+fk.getName(), k == null ? null : k.getObjectAt(x)));
                                x++;
                            }
                        }
                    }
                } else {
                    query.setParameter(fieldName, value);
                }
            }
        }
        return query;
    }

    public Query createQuery(Entity e, Update query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
