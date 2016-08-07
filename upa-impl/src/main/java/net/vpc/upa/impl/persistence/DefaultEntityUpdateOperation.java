package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.util.filters.Fields2;
import net.vpc.upa.persistence.EntityUpdateOperation;import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.ManyToOneType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityUpdateOperation implements EntityUpdateOperation {

    public int update(Entity entity, EntityExecutionContext context, Record updates, Expression condition) throws UPAException {
        Update u = new Update().entity(entity.getName());
        for (String fieldName : updates.keySet()) {
            Field f = entity.findField(fieldName);
            if (f != null && Fields2.UPDATE.accept(f)) {
                Object value = updates.getObject(fieldName);
                if ((f.getDataType() instanceof ManyToOneType)) {
                    ManyToOneType e = (ManyToOneType) f.getDataType();
                    if (e.isUpdatable()) {
                        Entity masterEntity = context.getPersistenceUnit().getEntity(e.getTargetEntityName());
                        EntityBuilder mbuilder = masterEntity.getBuilder();
                        if(value instanceof Expression){
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
                                        svalue.getField(0).setExpression(new Var((Var) svalue.getField(0).getExpression(), fid.getName()));
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

                        }else {

                            Key k = null;
                            if (value instanceof Record) {
                                k = mbuilder.recordToKey((Record) value);
                            } else {
                                k = mbuilder.objectToKey(value);
                            }
                            int x = 0;
                            for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                                u.set(fk.getName(), new Param(fk.getName(), k == null ? null : k.getObjectAt(x)));
                                x++;
                            }
                        }
                    }
                } else {
                    Expression expression = (value instanceof Expression) ? (Expression) value : new Param(null, value);
                    u.set(fieldName, expression);
                }
            }
        }
        u.where(condition);
        return context.getPersistenceStore().createQuery(u, context).executeNonQuery();
    }

    public Query createQuery(Entity e, Update query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
