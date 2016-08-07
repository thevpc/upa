package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Insert;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.persistence.EntityPersistOperation;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Map;
import net.vpc.upa.Field;
import net.vpc.upa.Key;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.Query;
import net.vpc.upa.types.ManyToOneType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/30/12 1:09 AM
 */
public class DefaultEntityPersistOperation implements EntityPersistOperation {

//    private static final FieldFilter INSERT = Fields.byModifiersAllOf(FieldModifier.INSERT);
//    private static final FieldFilter INSERT_NON_NULLABLE = new AbstractFieldFilter() {
//        @Override
//        public boolean acceptDynamic() throws UPAException {
//            return false;
//        }
//
//        @Override
//        public boolean accept(Field f) throws UPAException {
//            return f.getModifiers().contains(FieldModifier.INSERT)
//                    && !f.getModifiers().contains(FieldModifier.ID)
//                    && !f.getDataType().isNullable();
//        }
//    };
//    private static final FieldFilter INSERT_WITH_DEFAULT_VALUE = new AbstractFieldFilter() {
//        @Override
//        public boolean acceptDynamic() throws UPAException {
//            return false;
//        }
//
//        @Override
//        public boolean accept(Field f) throws UPAException {
//            FlagSet<FieldModifier> effectiveModifiers = f.getModifiers();
//            return effectiveModifiers.contains(FieldModifier.INSERT)
//                    && !effectiveModifiers.contains(FieldModifier.ID)
//                    && !effectiveModifiers.contains(FieldModifier.INSERT_SEQUENCE)
//                    //                    && f.getDefaultObject() != null
//                    ;
//        }
//    };
    public void insert(Entity entity, Record originalRecord, Record record, EntityExecutionContext context) throws UPAException {
        PersistenceUnit pu = context.getPersistenceUnit();
        Insert insert = new Insert().into(entity.getName());
        for (Map.Entry<String, Object> entry : record.entrySet()) {
            Object value = entry.getValue();
            String key = entry.getKey();
            Field field = entity.findField(key);
            //should process specific entity fields
            if ((field.getDataType() instanceof ManyToOneType)) {
                ManyToOneType e = (ManyToOneType) field.getDataType();
                if (e.isUpdatable()) {
                    Entity masterEntity = pu.getEntity(e.getTargetEntityName());
                    Key k = null;
                    if (value instanceof Record) {
                        k = masterEntity.getBuilder().recordToKey((Record) value);
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
                Expression valueExpression = (value instanceof Expression) ? (Expression) value : new Param(field.getName(), value);
                insert.set(key, valueExpression);
            }
        }
        context.getPersistenceStore().createQuery(insert, context).executeNonQuery();
    }

    public Query createQuery(Entity e, Insert query, EntityExecutionContext context) throws UPAException {
        return context.getPersistenceStore().createQuery(e, query, context);
    }
}
