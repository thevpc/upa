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
     * @creationdate 8/30/12 1:19 AM
     */
    public class DefaultEntityOperationManager : Net.Vpc.Upa.Persistence.EntityOperationManager {

        private Net.Vpc.Upa.Persistence.EntityPersistOperation persistencePersistAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityPersistOperation();

        private Net.Vpc.Upa.Persistence.EntityUpdateOperation persistenceUpdateAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityUpdateOperation();

        private Net.Vpc.Upa.Persistence.EntityRemoveOperation persistenceDeleteAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityRemoveOperation();

        private Net.Vpc.Upa.Persistence.EntityFindOperation persistenceFindAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityFindOperation();

        private Net.Vpc.Upa.Persistence.EntityResetOperation persistenceResetAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityResetOperation();

        private Net.Vpc.Upa.Persistence.EntityClearOperation persistenceClearAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityClearOperation();

        private Net.Vpc.Upa.Persistence.EntityInitializeOperation persistenceInitializeAction = new Net.Vpc.Upa.Impl.Persistence.DefaultEntityInitializeOperation();

        private Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.Vpc.Upa.Entity entity;

        public virtual void Init(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore) {
            this.entity = entity;
            this.persistenceStore = persistenceStore;
        }


        public virtual Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore() {
            return persistenceStore;
        }


        public virtual void SetPersistOperation(Net.Vpc.Upa.Persistence.EntityPersistOperation operation) {
            this.persistencePersistAction = operation;
        }


        public virtual Net.Vpc.Upa.Persistence.EntityPersistOperation GetPersistOperation() {
            return persistencePersistAction;
        }


        public virtual void SetUpdateOperation(Net.Vpc.Upa.Persistence.EntityUpdateOperation operation) {
            this.persistenceUpdateAction = operation;
        }


        public virtual Net.Vpc.Upa.Persistence.EntityUpdateOperation GetUpdateOperation() {
            return persistenceUpdateAction;
        }


        public virtual void SetRemoveOperation(Net.Vpc.Upa.Persistence.EntityRemoveOperation operation) {
            this.persistenceDeleteAction = operation;
        }


        public virtual Net.Vpc.Upa.Persistence.EntityRemoveOperation GetRemoveOperation() {
            return persistenceDeleteAction;
        }


        public virtual void SetFindOperation(Net.Vpc.Upa.Persistence.EntityFindOperation operation) {
            this.persistenceFindAction = operation;
        }


        public virtual Net.Vpc.Upa.Persistence.EntityFindOperation GetFindOperation() {
            return persistenceFindAction;
        }


        public virtual void SetResetOperation(Net.Vpc.Upa.Persistence.EntityResetOperation operation) {
            this.persistenceResetAction = operation;
        }


        public virtual Net.Vpc.Upa.Persistence.EntityResetOperation GetResetOperation() {
            return this.persistenceResetAction;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityClearOperation GetClearOperation() {
            return persistenceClearAction;
        }

        public virtual void SetClearOperation(Net.Vpc.Upa.Persistence.EntityClearOperation operation) {
            this.persistenceClearAction = operation;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityInitializeOperation GetInitializeOperation() {
            return persistenceInitializeAction;
        }

        public virtual void SetInitOperation(Net.Vpc.Upa.Persistence.EntityInitializeOperation operation) {
            this.persistenceInitializeAction = operation;
        }
    }
}
