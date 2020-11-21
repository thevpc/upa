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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:09 AM
     */
    public class DefaultEntityPersistOperation : Net.TheVpc.Upa.Persistence.EntityPersistOperation {

        public virtual void Insert(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Record originalRecord, Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceUnit pu = context.GetPersistenceUnit();
            Net.TheVpc.Upa.Expressions.Insert insert = new Net.TheVpc.Upa.Expressions.Insert().Into(entity.GetName());
            foreach (System.Collections.Generic.KeyValuePair<string , object> entry in record.EntrySet()) {
                object @value = (entry).Value;
                string key = (entry).Key;
                Net.TheVpc.Upa.Field field = entity.FindField(key);
                //should process specific entity fields
                if ((field.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType)) {
                    Net.TheVpc.Upa.Types.ManyToOneType e = (Net.TheVpc.Upa.Types.ManyToOneType) field.GetDataType();
                    if (e.IsUpdatable()) {
                        Net.TheVpc.Upa.Entity masterEntity = pu.GetEntity(e.GetTargetEntityName());
                        Net.TheVpc.Upa.Key k = null;
                        if (@value is Net.TheVpc.Upa.Record) {
                            k = masterEntity.GetBuilder().RecordToKey((Net.TheVpc.Upa.Record) @value);
                        } else {
                            k = masterEntity.GetBuilder().ObjectToKey(@value);
                        }
                        int x = 0;
                        foreach (Net.TheVpc.Upa.Field fk in e.GetRelationship().GetSourceRole().GetFields()) {
                            insert.Set(fk.GetName(), new Net.TheVpc.Upa.Expressions.Param(fk.GetName(), k.GetObjectAt(x)));
                            x++;
                        }
                    }
                } else {
                    Net.TheVpc.Upa.Expressions.Expression valueExpression = (@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)((Net.TheVpc.Upa.Expressions.Expression) @value)) : new Net.TheVpc.Upa.Expressions.Param(field.GetName(), @value);
                    insert.Set(key, valueExpression);
                }
            }
            context.GetPersistenceStore().CreateQuery(insert, context).ExecuteNonQuery();
        }

        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity e, Net.TheVpc.Upa.Expressions.Insert query, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
