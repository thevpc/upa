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
    public class UPAContextConfig {

        public static readonly int XML_ORDER = System.Int32.MaxValue;

        public const int BOOT_TYPE_ORDER = 999999999;

        private bool? autoScan;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceGroupConfig> persistenceGroups = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.PersistenceGroupConfig>(2);

        private System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>(2);

        private System.Collections.Generic.IDictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();

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

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , object> properties) {
            this.properties = properties;
        }

        internal static string Trim(string s) {
            if (s == null) {
                s = "";
            }
            s = s.Trim();
            return s;
        }
    }
}
