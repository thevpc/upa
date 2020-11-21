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
    public class DefaultEntityClearOperation : Net.TheVpc.Upa.Persistence.EntityClearOperation {


        public virtual int Clear(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (entity.GetShield().IsTransient()) {
                return 0;
            }
            Net.TheVpc.Upa.Expressions.Delete stmt = (new Net.TheVpc.Upa.Expressions.Delete()).From(entity.GetName());
            return context.GetPersistenceStore().CreateQuery(stmt, context).ExecuteNonQuery();
        }
    }
}
