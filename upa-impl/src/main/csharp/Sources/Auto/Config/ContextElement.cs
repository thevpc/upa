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



namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/7/13 2:22 AM
     */
    public class ContextElement {

        internal bool autoScan = true;

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.PersistenceGroupElement> persistenceGroups = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.PersistenceGroupElement>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.ScanElement> scanElements = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.ScanElement>();

        public virtual void AddScanElement(Net.Vpc.Upa.Impl.Config.ScanElement e) {
            scanElements.Add(e);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.ScanElement> GetScanElements() {
            return scanElements;
        }

        public virtual void AddPersistenceGroupElement(Net.Vpc.Upa.Impl.Config.PersistenceGroupElement e) {
            persistenceGroups[e.name]=e;
            e.parent = this;
        }

        public virtual Net.Vpc.Upa.Impl.Config.PersistenceGroupElement GetPersistenceGroupElement(string name) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.PersistenceGroupElement>(persistenceGroups,name);
        }

        public virtual Net.Vpc.Upa.Impl.Config.PersistenceGroupElement GetOrAddPersistenceGroupElement(string name) {
            Net.Vpc.Upa.Impl.Config.PersistenceGroupElement v = GetPersistenceGroupElement(name);
            if (v == null) {
                v = new Net.Vpc.Upa.Impl.Config.PersistenceGroupElement();
                v.name = name;
                v.parent = this;
                persistenceGroups[name]=v;
            }
            return v;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.PersistenceGroupElement> GetPersistenceGroupElements() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.PersistenceGroupElement>((persistenceGroups).Values);
        }
    }
}
