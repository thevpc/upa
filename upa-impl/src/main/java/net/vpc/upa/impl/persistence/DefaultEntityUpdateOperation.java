package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.FieldModifier;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.expressions.Update;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.Fields;
import net.vpc.upa.persistence.EntityUpdateOperation;import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.EntityType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityUpdateOperation implements EntityUpdateOperation {

    private static final FieldFilter UPDATE = Fields.byModifiersAllOf(FieldModifier.UPDATE);

    public int update(Entity entity, EntityExecutionContext context, Record updates, Expression condition) throws UPAException {
        Update u = new Update().entity(entity.getName());
        for (String fieldName : updates.keySet()) {
            Field f = entity.findField(fieldName);
            if (f != null && UPDATE.accept(f)) {
                Object value = updates.getObject(fieldName);
                if ((f.getDataType() instanceof EntityType)) {
                    EntityType e = (EntityType) f.getDataType();
                    if (e.isUpdatable()) {
                        Entity masterEntity = context.getPersistenceUnit().getEntity(e.getReferencedEntityName());
                        Key k = null;
                        if (value instanceof Record) {
                            k = masterEntity.getBuilder().recordToKey((Record) value);
                        } else {
                            k = masterEntity.getBuilder().objectToKey(value);
                        }
                        int x = 0;
                        for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                            u.set(fk.getName(), new Param(fk.getName(), k == null ? null : k.getObjectAt(x)));
                            x++;
                        }
                    }
                } else {
                    Expression expression = (value instanceof Expression) ? (Expression) value : new Param(null, value);
                    u.set(fieldName, expression);
                }
            }
        }
        u.where(condition);
        return context.getPersistenceStore().executeUpdate(u, context);
    }

    public Query createQuery(Entity e, Update query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
