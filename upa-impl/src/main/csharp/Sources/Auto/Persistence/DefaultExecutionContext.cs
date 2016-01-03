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


    public class DefaultExecutionContext : Net.Vpc.Upa.Impl.DefaultProperties, Net.Vpc.Upa.Persistence.EntityExecutionContext {

        private Net.Vpc.Upa.Persistence.ContextOperation contextOperation;

        private Net.Vpc.Upa.Entity currentEntity;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private System.Collections.Generic.IDictionary<string , object> values;

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Persistence.Parameter> generatedValues = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Persistence.Parameter>();

        public DefaultExecutionContext() {
        }

        public virtual void InitPersistenceUnit(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore, Net.Vpc.Upa.Persistence.ContextOperation contextOperation) {
            this.persistenceUnit = persistenceUnit;
            this.contextOperation = contextOperation;
            this.persistenceStore = persistenceStore;
        }


        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return currentEntity;
        }


        public virtual void InitEntity(Net.Vpc.Upa.Entity currentEntity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager) {
            this.currentEntity = currentEntity;
            this.entityOperationManager = entityOperationManager;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetValues() {
            if (this.values == null) {
                values = new System.Collections.Generic.Dictionary<string , object>();
            }
            return values;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceStore() {
            return persistenceStore;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager() {
            return entityOperationManager;
        }


        public virtual Net.Vpc.Upa.Persistence.ContextOperation GetOperation() {
            return contextOperation;
        }

        public virtual void AddGeneratedValue(string name, Net.Vpc.Upa.Types.DataType type) {
            if (generatedValues.ContainsKey(name)) {
                throw new System.ArgumentException ("GeneratedValue already exists " + name);
            }
            generatedValues[name]=new Net.Vpc.Upa.Persistence.DefaultParameter(name, null, new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(type));
        }

        public virtual void RemoveGeneratedValue(Net.Vpc.Upa.Persistence.Parameter parameter) {
            generatedValues.Remove(parameter.GetName());
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> GetGeneratedValues() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.Parameter>((generatedValues).Values);
        }


        public virtual Net.Vpc.Upa.Persistence.Parameter GetGeneratedValue(string name) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Persistence.Parameter>(generatedValues,name);
        }
    }
}
