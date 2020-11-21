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



namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/7/13 2:24 AM
     */
    public class PersistenceGroupElement {

        internal string name;

        internal Net.TheVpc.Upa.Impl.Config.ContextElement parent;

        internal bool autoScan = true;

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Property> properties = new System.Collections.Generic.List<Net.TheVpc.Upa.Property>();

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.ScanElement> scanElements = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.ScanElement>();

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement> persistenceUnitElements = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement>();

        public virtual void AddScanElement(Net.TheVpc.Upa.Impl.Config.ScanElement e) {
            scanElements.Add(e);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.ScanElement> GetScanElements() {
            return scanElements;
        }

        public virtual Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement GetOrAddPersistenceUnitElement(string name) {
            Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement v = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement>(persistenceUnitElements,name);
            if (v == null) {
                v = new Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement();
                v.name = name;
                v.parent = this;
                persistenceUnitElements[name]=v;
            }
            return v;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement> GetPersistenceUnitElements() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.PersistenceUnitElement>((persistenceUnitElements).Values);
        }
    }
}
