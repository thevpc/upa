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
     * @creationdate 1/7/13 2:24 AM
     */
    public class PersistenceGroupElement {

        internal string name;

        internal Net.Vpc.Upa.Impl.Config.ContextElement parent;

        internal bool autoScan = true;

        internal System.Collections.Generic.IList<Net.Vpc.Upa.Property> properties = new System.Collections.Generic.List<Net.Vpc.Upa.Property>();

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.ScanElement> scanElements = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.ScanElement>();

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.PersistenceUnitElement> persistenceUnitElements = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Config.PersistenceUnitElement>();

        public virtual void AddScanElement(Net.Vpc.Upa.Impl.Config.ScanElement e) {
            scanElements.Add(e);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.ScanElement> GetScanElements() {
            return scanElements;
        }

        public virtual Net.Vpc.Upa.Impl.Config.PersistenceUnitElement GetOrAddPersistenceUnitElement(string name) {
            Net.Vpc.Upa.Impl.Config.PersistenceUnitElement v = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Config.PersistenceUnitElement>(persistenceUnitElements,name);
            if (v == null) {
                v = new Net.Vpc.Upa.Impl.Config.PersistenceUnitElement();
                v.name = name;
                v.parent = this;
                persistenceUnitElements[name]=v;
            }
            return v;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.PersistenceUnitElement> GetPersistenceUnitElements() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.PersistenceUnitElement>((persistenceUnitElements).Values);
        }
    }
}
