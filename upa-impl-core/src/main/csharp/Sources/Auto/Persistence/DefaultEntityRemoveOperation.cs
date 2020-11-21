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
    public class DefaultEntityRemoveOperation : Net.TheVpc.Upa.Persistence.EntityRemoveOperation {


        public virtual int Delete(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Expressions.Expression condition, bool recurse, Net.TheVpc.Upa.RemoveTrace deleteInfo) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entity.GetShield().IsTransient()) {
                return 0;
            }
            Net.TheVpc.Upa.Expressions.Delete stmt = (new Net.TheVpc.Upa.Expressions.Delete()).From(entity.GetName()).Where(condition);
            return context.GetPersistenceStore().CreateQuery(stmt, context).ExecuteNonQuery();
        }

        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity e, Net.TheVpc.Upa.Expressions.Delete query, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return context.GetPersistenceStore().CreateQuery(e, query, context);
        }
    }
}
