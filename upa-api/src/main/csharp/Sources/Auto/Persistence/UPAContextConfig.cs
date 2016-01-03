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
    public class UPAContextConfig {

        public static readonly int XML_ORDER = System.Int32.MaxValue;

        private bool? autoScan;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceGroupConfig> persistenceGroups = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.PersistenceGroupConfig>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();

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

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceGroupConfig> GetPersistenceGroups() {
            return persistenceGroups;
        }

        public virtual void SetPersistenceGroups(System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceGroupConfig> persistenceGroups) {
            this.persistenceGroups = persistenceGroups;
        }


        public override string ToString() {
            return "UPAContextConfig{" + "persistenceGroups=" + persistenceGroups + ", filters=" + filters + '}';
        }
    }
}
