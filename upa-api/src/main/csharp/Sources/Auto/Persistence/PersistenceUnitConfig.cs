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



using System.Linq;
namespace Net.Vpc.Upa.Persistence
{


    /**
     *
     * @author vpc
     */
    public class PersistenceUnitConfig {

        private int configOrder;

        private string name;

        private string persistenceGroup;

        private Net.Vpc.Upa.Persistence.PersistenceNameConfig model;

        private bool? autoStart;

        private bool? autoScan;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> rootConnections = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.ConnectionConfig>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> connections = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.ConnectionConfig>();

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

        private readonly System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();

        public PersistenceUnitConfig() {
        }

        public virtual int GetConfigOrder() {
            return configOrder;
        }

        public virtual void SetConfigOrder(int configOrder) {
            this.configOrder = configOrder;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual string GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual void SetPersistenceGroup(string persistenceGroup) {
            this.persistenceGroup = persistenceGroup;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceNameConfig GetModel() {
            return model;
        }

        public virtual void SetModel(Net.Vpc.Upa.Persistence.PersistenceNameConfig model) {
            this.model = model;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , object> properties) {
            this.properties = properties;
        }

        public virtual bool? GetAutoStart() {
            return autoStart;
        }

        public virtual void SetAutoStart(bool? autoStart) {
            this.autoStart = autoStart;
        }

        public virtual bool? GetAutoScan() {
            return autoScan;
        }

        public virtual void SetAutoScan(bool? autoScan) {
            this.autoScan = autoScan;
        }

        public virtual void SetContextAnnotationStrategyFilters(System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters) {
            this.filters.Clear();
            if (filters != null) {
                Net.Vpc.Upa.FwkConvertUtils.ListAddRange(this.filters, filters);
            }
        }

        public virtual void AddContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Add(filter);
        }

        public virtual void RemoveContextAnnotationStrategyFilter(Net.Vpc.Upa.Config.ScanFilter filter) {
            filters.Remove(filter);
        }

        public virtual Net.Vpc.Upa.Config.ScanFilter[] GetFilters() {
            return filters.ToArray();
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> GetRootConnections() {
            return rootConnections;
        }

        public virtual void SetRootConnections(System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> rootConnections) {
            this.rootConnections = rootConnections;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> GetConnections() {
            return connections;
        }

        public virtual void SetConnections(System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionConfig> connections) {
            this.connections = connections;
        }


        public override string ToString() {
            return "PersistenceUnitConfig{" + "name=" + name + ", persistenceGroup=" + persistenceGroup + ", model=" + model + ", autoStart=" + autoStart + ", rootConnections=" + rootConnections + ", connections=" + connections + ", properties=" + properties + ", filters=" + filters + '}';
        }
    }
}
