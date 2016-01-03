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
     * @creationdate 9/24/12 3:01 AM
     */
    public class URLScanSource : Net.Vpc.Upa.Impl.Config.BaseScanSource {

        private Net.Vpc.Upa.Config.ScanFilter[] filters;

        private string[] urls;

        private bool noIgnore;

        public URLScanSource(string[] urls, Net.Vpc.Upa.Config.ScanFilter[] filters, bool noIgnore) {
            this.urls = urls;
            this.noIgnore = noIgnore;
            this.filters = filters == null ? new Net.Vpc.Upa.Config.ScanFilter[0] : filters;
        }

        public override bool IsNoIgnore() {
            return noIgnore;
        }

        public virtual string[] GetUrls() {
            return urls;
        }

        public virtual Net.Vpc.Upa.Config.ScanFilter[] GetFilters() {
            return filters;
        }


        public override string ToString() {
            return (GetType()).Name + "{" + System.Convert.ToString(urls) + "," + System.Convert.ToString(filters) + "}";
        }


        public override System.Collections.Generic.IEnumerable<System.Type> ToIterable(object context) {
            return new Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable(GetUrls(), new Net.Vpc.Upa.Impl.Util.Classpath.DefaultConfigFilter(GetFilters()), null);
        }
    }
}
