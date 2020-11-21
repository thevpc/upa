/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Persistence
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:14 AM
     */
    public interface EntityOperationManager {

         Net.TheVpc.Upa.Persistence.EntityRemoveOperation GetRemoveOperation();

         void SetRemoveOperation(Net.TheVpc.Upa.Persistence.EntityRemoveOperation operation);

         Net.TheVpc.Upa.Persistence.EntityUpdateOperation GetUpdateOperation();

         void SetUpdateOperation(Net.TheVpc.Upa.Persistence.EntityUpdateOperation operation);

         Net.TheVpc.Upa.Persistence.EntityPersistOperation GetPersistOperation();

         void SetPersistOperation(Net.TheVpc.Upa.Persistence.EntityPersistOperation operation);

         Net.TheVpc.Upa.Persistence.EntityFindOperation GetFindOperation();

         void SetFindOperation(Net.TheVpc.Upa.Persistence.EntityFindOperation operation);

         Net.TheVpc.Upa.Persistence.EntityResetOperation GetResetOperation();

         void SetResetOperation(Net.TheVpc.Upa.Persistence.EntityResetOperation operation);

         Net.TheVpc.Upa.Persistence.EntityClearOperation GetClearOperation();

         void SetClearOperation(Net.TheVpc.Upa.Persistence.EntityClearOperation operation);

         Net.TheVpc.Upa.Persistence.EntityInitializeOperation GetInitializeOperation();

         void SetInitOperation(Net.TheVpc.Upa.Persistence.EntityInitializeOperation operation);

         Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore();
    }
}
