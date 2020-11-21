package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.*;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.Insert;
import net.thevpc.upa.expressions.Param;
import net.thevpc.upa.impl.BeanAdapterDocument;
import net.thevpc.upa.impl.ext.QueryExt;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.EntityPersistOperation;
import net.thevpc.upa.types.ManyToOneType;
import net.thevpc.upa.types.OneToOneType;
import net.thevpc.upa.types.RelationDataType;

import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityPersistOperation implements EntityPersistOperation {
    private <T> T get(String name, Entity entity, EntityExecutionContext context){
        return (T)context.getConnection().getProperty("DefaultEntityPersistOperation."+entity.getName()+"."+name);
    }
    private void set(String name,Object value,Entity entity,EntityExecutionContext context){
        context.getConnection().setProperty("DefaultEntityPersistOperation."+entity.getName()+"."+name,value);
    }

    public void insert(Entity entity, Document originalDocument, Document document, EntityExecutionContext context) throws UPAException {
        PersistenceUnit pu = context.getPersistenceUnit();
        QueryExt query=get("query",entity,context);
        Boolean noCache=get("noCache",entity,context);
        if (query == null || (noCache!=null && noCache) || !(originalDocument instanceof BeanAdapterDocument)) {
            Insert insert = new Insert().into(entity.getName());
            for (Map.Entry<String, Object> entry : document.entrySet()) {
                Object value = entry.getValue();
                String key = entry.getKey();
                Field field = entity.findField(key);
                //should process specific entity fields
                if (field.isManyToOne() || field.isOneToOne()) {
                    RelationDataType e = (RelationDataType) field.getDataType();
                    if (e.isUpdatable()) {
                        String targetEntityName=
                                (e instanceof ManyToOneType)?((ManyToOneType) e).getTargetEntityName():
                                        ((OneToOneType) e).getTargetEntityName();

                        Entity masterEntity = pu.getEntity(targetEntityName);
                        Key k = null;
                        if (value instanceof Document) {
                            k = masterEntity.getBuilder().documentToKey((Document) value);
                        } else {
                            k = masterEntity.getBuilder().objectToKey(value);
                        }
                        int x = 0;
                        for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                            insert.set(fk.getName(), new Param(fk.getName(), k.getObjectAt(x)));
                            x++;
                        }
                    }
                } else {
                    if (value == null || !(value instanceof Expression)) {
                        insert.set(key, new Param(field.getName(), value));
                    } else if (value instanceof Param) {
                        insert.set(key, (Expression) value);
                    } else {
                        set("noCache",true,entity,context);
                        insert.set(key, (Expression) value);
                    }
                }
            }
            query = (QueryExt) context.getPersistenceStore().createQuery(insert, context);
            set("query",query,entity,context);
        } else {
            for (Map.Entry<String, Object> entry : document.entrySet()) {
                Object value = entry.getValue();
                String key = entry.getKey();
                Field field = entity.findField(key);
                //should process specific entity fields
                if (field.isManyToOne() || field.isOneToOne()) {
                    RelationDataType e = (RelationDataType) field.getDataType();
                    if (e.isUpdatable()) {
                        String targetEntityName=
                                (e instanceof ManyToOneType)?((ManyToOneType) e).getTargetEntityName():
                                        ((OneToOneType) e).getTargetEntityName();
                        Entity masterEntity = pu.getEntity(targetEntityName);
                        Key k = null;
                        if (value instanceof Document) {
                            k = masterEntity.getBuilder().documentToKey((Document) value);
                        } else {
                            k = masterEntity.getBuilder().objectToKey(value);
                        }
                        int x = 0;
                        for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                            query.setParameter(fk.getName(), k.getObjectAt(x));
                            x++;
                        }
                    }
                } else {
                    if (value == null || !(value instanceof Expression)) {
                        query.setParameter(field.getName(), value);
                    } else if (value instanceof Param) {
                        query.setParameter(field.getName(), ((Param)value).getValue());
                    } else {
                        throw new IllegalUPAArgumentException("Unexpected Expression " + value);
                    }
                }
            }
            query.setContext(context);
        }
        query.executeNonQuery();
    }

    public Query createQuery(Entity e, Insert query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
