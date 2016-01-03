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
    public class DefaultEntityUpdateOperation : Net.Vpc.Upa.Persistence.EntityUpdateOperation {

        private static readonly Net.Vpc.Upa.Filters.FieldFilter UPDATE = Net.Vpc.Upa.Filters.Fields.ByModifiersAllOf(Net.Vpc.Upa.FieldModifier.UPDATE);

        public virtual int Update(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Record updates, Net.Vpc.Upa.Expressions.Expression condition) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.Update u = new Net.Vpc.Upa.Expressions.Update().Entity(entity.GetName());
            foreach (string fieldName in updates.KeySet()) {
                Net.Vpc.Upa.Field f = entity.FindField(fieldName);
                if (f != null && UPDATE.Accept(f)) {
                    object @value = updates.GetObject<object>(fieldName);
                    if ((f.GetDataType() is Net.Vpc.Upa.Types.EntityType)) {
                        Net.Vpc.Upa.Types.EntityType e = (Net.Vpc.Upa.Types.EntityType) f.GetDataType();
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
                                u.Set(fk.GetName(), new Net.Vpc.Upa.Expressions.Param(fk.GetName(), k == null ? null : k.GetObjectAt(x)));
                                x++;
                            }
                        }
                    } else {
                        Net.Vpc.Upa.Expressions.Expression expression = (@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)((Net.Vpc.Upa.Expressions.Expression) @value)) : new Net.Vpc.Upa.Expressions.Param(null, @value);
                        u.Set(fieldName, expression);
                    }
                }
            }
            u.Where(condition);
            return context.GetPersistenceStore().ExecuteUpdate(u, context);
        }

        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Update query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
