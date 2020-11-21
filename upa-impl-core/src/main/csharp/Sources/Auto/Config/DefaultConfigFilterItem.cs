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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultConfigFilterItem {

        private Net.TheVpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter typeFilter;

        private Net.TheVpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter libFilter;

        public DefaultConfigFilterItem(Net.TheVpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter libFilter, Net.TheVpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter typeFilter) {
            this.typeFilter = typeFilter;
            this.libFilter = libFilter;
        }

        public virtual Net.TheVpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter GetTypeFilter() {
            return typeFilter;
        }

        public virtual Net.TheVpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter GetLibFilter() {
            return libFilter;
        }
    }
}
