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



namespace Net.Vpc.Upa.Persistence
{

    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 1:14 AM
     */
    public interface EntityOperationManager {

         Net.Vpc.Upa.Persistence.EntityRemoveOperation GetRemoveOperation();

         void SetRemoveOperation(Net.Vpc.Upa.Persistence.EntityRemoveOperation operation);

         Net.Vpc.Upa.Persistence.EntityUpdateOperation GetUpdateOperation();

         void SetUpdateOperation(Net.Vpc.Upa.Persistence.EntityUpdateOperation operation);

         Net.Vpc.Upa.Persistence.EntityPersistOperation GetPersistOperation();

         void SetPersistOperation(Net.Vpc.Upa.Persistence.EntityPersistOperation operation);

         Net.Vpc.Upa.Persistence.EntityFindOperation GetFindOperation();

         void SetFindOperation(Net.Vpc.Upa.Persistence.EntityFindOperation operation);

         Net.Vpc.Upa.Persistence.EntityResetOperation GetResetOperation();

         void SetResetOperation(Net.Vpc.Upa.Persistence.EntityResetOperation operation);

         Net.Vpc.Upa.Persistence.EntityClearOperation GetClearOperation();

         void SetClearOperation(Net.Vpc.Upa.Persistence.EntityClearOperation operation);

         Net.Vpc.Upa.Persistence.EntityInitializeOperation GetInitializeOperation();

         void SetInitOperation(Net.Vpc.Upa.Persistence.EntityInitializeOperation operation);

         Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore();
    }
}
