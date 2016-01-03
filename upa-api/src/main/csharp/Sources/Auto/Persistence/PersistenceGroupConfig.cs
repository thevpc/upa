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
     *
     * @author vpc
     */
    public class PersistenceGroupConfig {

        private int configOrder;

        private string name;

        private bool? autoScan;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceUnitConfig> persistenceUnits = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.PersistenceUnitConfig>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

        public PersistenceGroupConfig(int configOrder) {
            this.configOrder = configOrder;
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


        public override string ToString() {
            return "PersistenceGroupConfig{" + "name=" + name + ", persistenceUnits=" + persistenceUnits + ", filters=" + filters + ", properties=" + properties + '}';
        }
    }
}
