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
    public class DefaultEntityRemoveOperation : Net.Vpc.Upa.Persistence.EntityRemoveOperation {


        public virtual int Delete(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Expressions.Expression condition, bool recurse, Net.Vpc.Upa.RemoveTrace deleteInfo) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entity.GetShield().IsTransient()) {
                return 0;
            }
            Net.Vpc.Upa.Expressions.Delete stmt = (new Net.Vpc.Upa.Expressions.Delete()).From(entity.GetName()).Where(condition);
            return context.GetPersistenceStore().CreateQuery(stmt, context).ExecuteNonQuery();
        }

        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Delete query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
