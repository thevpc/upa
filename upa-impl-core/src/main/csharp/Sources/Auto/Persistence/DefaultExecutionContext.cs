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


    public class DefaultExecutionContext : Net.TheVpc.Upa.Impl.DefaultProperties, Net.TheVpc.Upa.Persistence.EntityExecutionContext {

        private Net.TheVpc.Upa.Persistence.ContextOperation contextOperation;

        private Net.TheVpc.Upa.Entity currentEntity;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private System.Collections.Generic.IDictionary<string , object> values;

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.Parameter> generatedValues = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Persistence.Parameter>();

        private System.Collections.Generic.IDictionary<string , object> hints;

        public DefaultExecutionContext() {
        }

        public virtual void InitPersistenceUnit(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore, Net.TheVpc.Upa.Persistence.ContextOperation contextOperation) {
            this.persistenceUnit = persistenceUnit;
            this.contextOperation = contextOperation;
            this.persistenceStore = persistenceStore;
        }


        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }


        public virtual Net.TheVpc.Upa.Persistence.UConnection GetConnection() {
            return GetPersistenceUnit().GetConnection();
        }


        public virtual Net.TheVpc.Upa.Session GetSession() {
            return GetPersistenceUnit().GetCurrentSession();
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return currentEntity;
        }


        public virtual void InitEntity(Net.TheVpc.Upa.Entity currentEntity, Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager) {
            this.currentEntity = currentEntity;
            this.entityOperationManager = entityOperationManager;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetValues() {
            if (this.values == null) {
                values = new System.Collections.Generic.Dictionary<string , object>();
            }
            return values;
        }

        public virtual Net.TheVpc.Upa.Persistence.PersistenceStore GetPersistenceStore() {
            return persistenceStore;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityOperationManager GetEntityOperationManager() {
            return entityOperationManager;
        }


        public virtual Net.TheVpc.Upa.Persistence.ContextOperation GetOperation() {
            return contextOperation;
        }

        public virtual void AddGeneratedValue(string name, Net.TheVpc.Upa.Types.DataType type) {
            if (generatedValues.ContainsKey(name)) {
                throw new System.ArgumentException ("GeneratedValue already exists " + name);
            }
            generatedValues[name]=new Net.TheVpc.Upa.Persistence.DefaultParameter(name, null, new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(type));
        }

        public virtual void RemoveGeneratedValue(Net.TheVpc.Upa.Persistence.Parameter parameter) {
            generatedValues.Remove(parameter.GetName());
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> GetGeneratedValues() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.Parameter>((generatedValues).Values);
        }


        public virtual Net.TheVpc.Upa.Persistence.Parameter GetGeneratedValue(string name) {
            return Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Persistence.Parameter>(generatedValues,name);
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }

        public virtual object GetHint(string hintName) {
            return hints == null ? null : Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
        }

        public virtual object GetHint(string hintName, object defaultValue) {
            object c = hints == null ? null : Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
            return c == null ? defaultValue : c;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExecutionContext ResetHints() {
            if (hints != null) {
                hints.Clear();
            }
            hints = null;
            return this;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExecutionContext SetHint(string name, object @value) {
            if (@value == null) {
                if (hints != null) {
                    hints.Remove(name);
                }
            } else {
                if (hints == null) {
                    hints = new System.Collections.Generic.Dictionary<string , object>();
                }
                hints[name]=@value;
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExecutionContext SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            if (hints != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> e in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(hints)) {
                    SetHint((e).Key, (e).Value);
                }
            }
            return this;
        }
    }
}
