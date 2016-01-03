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
    public class DefaultEntityClearOperation : Net.Vpc.Upa.Persistence.EntityClearOperation {


        public virtual int Clear(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (entity.GetShield().IsTransient()) {
                return 0;
            }
            Net.Vpc.Upa.Expressions.Delete stmt = (new Net.Vpc.Upa.Expressions.Delete()).From(entity.GetName());
            return context.GetPersistenceStore().ExecuteUpdate(stmt, context);
        }
    }
}
