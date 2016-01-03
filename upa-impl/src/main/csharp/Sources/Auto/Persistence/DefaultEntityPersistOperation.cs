/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:09 AM
     */
    public class DefaultEntityPersistOperation : Net.Vpc.Upa.Persistence.EntityPersistOperation {

        public virtual void Insert(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Record originalRecord, Net.Vpc.Upa.Record record, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Insert insert = new Net.Vpc.Upa.Expressions.Insert().Into(entity.GetName());
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in record.ToMap()) {
                object @value = (entry).Value;
                string key = (entry).Key;
                Net.Vpc.Upa.Field field = entity.FindField(key);
                //should process specific entity fields
                if ((field.GetDataType() is Net.Vpc.Upa.Types.EntityType)) {
                    Net.Vpc.Upa.Types.EntityType e = (Net.Vpc.Upa.Types.EntityType) field.GetDataType();
                    if (e.IsUpdatable()) {
                        Net.Vpc.Upa.Entity masterEntity = context.GetPersistenceUnit().GetEntity(e.GetReferencedEntityName());
                        Net.Vpc.Upa.Key k = null;
                        if (@value is Net.Vpc.Upa.Record) {
                            k = masterEntity.GetBuilder().RecordToKey((Net.Vpc.Upa.Record) @value);
                        } else {
                            k = masterEntity.GetBuilder().EntityToKey(@value);
                        }
                        int x = 0;
                        foreach (Net.Vpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                            insert.Set(fk.GetName(), new Net.Vpc.Upa.Expressions.Param(fk.GetName(), k.GetObjectAt(x)));
                            x++;
                        }
                    }
                } else {
                    Net.Vpc.Upa.Expressions.Expression valueExpression = (@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)((Net.Vpc.Upa.Expressions.Expression) @value)) : new Net.Vpc.Upa.Expressions.Param(field.GetName(), @value);
                    insert.Set(key, valueExpression);
                }
            }
            context.GetPersistenceStore().ExecuteUpdate(insert, context);
        }

        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Insert query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
