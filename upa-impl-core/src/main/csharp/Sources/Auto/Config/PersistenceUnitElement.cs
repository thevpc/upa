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
    public class PersistenceUnitElement {

        internal string name;

        internal Net.TheVpc.Upa.Impl.Config.PersistenceGroupElement parent;

        internal bool start = true;

        internal bool autoScan = true;

        internal bool hasConfigElement;

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.ConnectionElement> connectionElements = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.ConnectionElement>();

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.ConnectionElement> rootConnectionElements = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.ConnectionElement>();

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Property> properties = new System.Collections.Generic.List<Net.TheVpc.Upa.Property>();

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.ScanElement> scanElements = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Config.ScanElement>();

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Config.ScanElement> GetScanElements() {
            return scanElements;
        }
    }
}
