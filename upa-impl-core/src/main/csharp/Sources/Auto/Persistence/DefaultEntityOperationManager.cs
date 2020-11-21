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
     * @creationdate 8/30/12 1:19 AM
     */
    public class DefaultEntityOperationManager : Net.TheVpc.Upa.Persistence.EntityOperationManager {

        private Net.TheVpc.Upa.Persistence.EntityPersistOperation persistencePersistAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityPersistOperation();

        private Net.TheVpc.Upa.Persistence.EntityUpdateOperation persistenceUpdateAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityUpdateOperation();

        private Net.TheVpc.Upa.Persistence.EntityRemoveOperation persistenceDeleteAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityRemoveOperation();

        private Net.TheVpc.Upa.Persistence.EntityFindOperation persistenceFindAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityFindOperation();

        private Net.TheVpc.Upa.Persistence.EntityResetOperation persistenceResetAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityResetOperation();

        private Net.TheVpc.Upa.Persistence.EntityClearOperation persistenceClearAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityClearOperation();

        private Net.TheVpc.Upa.Persistence.EntityInitializeOperation persistenceInitializeAction = new Net.TheVpc.Upa.Impl.Persistence.DefaultEntityInitializeOperation();

        private Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.TheVpc.Upa.Entity entity;

        public virtual void Init(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore) {
            this.entity = entity;
            this.persistenceStore = persistenceStore;
        }


        public virtual Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore() {
            return persistenceStore;
        }


        public virtual void SetPersistOperation(Net.TheVpc.Upa.Persistence.EntityPersistOperation operation) {
            this.persistencePersistAction = operation;
        }


        public virtual Net.TheVpc.Upa.Persistence.EntityPersistOperation GetPersistOperation() {
            return persistencePersistAction;
        }


        public virtual void SetUpdateOperation(Net.TheVpc.Upa.Persistence.EntityUpdateOperation operation) {
            this.persistenceUpdateAction = operation;
        }


        public virtual Net.TheVpc.Upa.Persistence.EntityUpdateOperation GetUpdateOperation() {
            return persistenceUpdateAction;
        }


        public virtual void SetRemoveOperation(Net.TheVpc.Upa.Persistence.EntityRemoveOperation operation) {
            this.persistenceDeleteAction = operation;
        }


        public virtual Net.TheVpc.Upa.Persistence.EntityRemoveOperation GetRemoveOperation() {
            return persistenceDeleteAction;
        }


        public virtual void SetFindOperation(Net.TheVpc.Upa.Persistence.EntityFindOperation operation) {
            this.persistenceFindAction = operation;
        }


        public virtual Net.TheVpc.Upa.Persistence.EntityFindOperation GetFindOperation() {
            return persistenceFindAction;
        }


        public virtual void SetResetOperation(Net.TheVpc.Upa.Persistence.EntityResetOperation operation) {
            this.persistenceResetAction = operation;
        }


        public virtual Net.TheVpc.Upa.Persistence.EntityResetOperation GetResetOperation() {
            return this.persistenceResetAction;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityClearOperation GetClearOperation() {
            return persistenceClearAction;
        }

        public virtual void SetClearOperation(Net.TheVpc.Upa.Persistence.EntityClearOperation operation) {
            this.persistenceClearAction = operation;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityInitializeOperation GetInitializeOperation() {
            return persistenceInitializeAction;
        }

        public virtual void SetInitOperation(Net.TheVpc.Upa.Persistence.EntityInitializeOperation operation) {
            this.persistenceInitializeAction = operation;
        }
    }
}
