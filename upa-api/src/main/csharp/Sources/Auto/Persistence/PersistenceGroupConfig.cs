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



namespace Net.Vpc.Upa.Persistence
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class PersistenceGroupConfig {

        private int configOrder;

        private string name;

        private bool? autoScan;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> persistenceUnits = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>(2);

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>(2);

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

        public PersistenceGroupConfig() {
        }

        public virtual int GetConfigOrder() {
            return configOrder;
        }

        public virtual void SetConfigOrder(int configOrder) {
            this.configOrder = configOrder;
        }

        public virtual bool? GetAutoScan() {
            return autoScan;
        }

        public virtual void SetAutoScan(bool? autoScan) {
            this.autoScan = autoScan;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> GetFilters() {
            return filters;
        }

        public virtual void SetFilters(System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters) {
            this.filters = filters;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , object> properties) {
            this.properties = properties;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> GetPersistenceUnits() {
            return persistenceUnits;
        }

        public virtual void SetPersistenceUnits(System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> persistenceUnits) {
            this.persistenceUnits = persistenceUnits;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> GetContextAnnotationStrategyFilters() {
            return filters;
        }

        public virtual void SetContextAnnotationStrategyFilters(System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters) {
            this.filters = filters == null ? new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>() : new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>(filters);
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceUnitConfig GetPersistenceUnit(string name, bool create, int configOrder) {
            foreach (Net.Vpc.Upa.Persistence.PersistenceUnitConfig persistenceGroup in persistenceUnits) {
                if (Net.Vpc.Upa.Persistence.UPAContextConfig.Trim(persistenceGroup.GetName()).Equals(Net.Vpc.Upa.Persistence.UPAContextConfig.Trim(name))) {
                    return persistenceGroup;
                }
            }
            if (create) {
                Net.Vpc.Upa.Persistence.PersistenceUnitConfig p = new Net.Vpc.Upa.Persistence.PersistenceUnitConfig();
                p.SetConfigOrder(configOrder);
                persistenceUnits.Add(p);
                return p;
            }
            return null;
        }


        public override string ToString() {
            return "PersistenceGroupConfig{" + "name=" + name + ", persistenceUnits=" + persistenceUnits + ", filters=" + filters + ", properties=" + properties + '}';
        }
    }
}
