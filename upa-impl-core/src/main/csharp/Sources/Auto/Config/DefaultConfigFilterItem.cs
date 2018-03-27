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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultConfigFilterItem {

        private Net.Vpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter typeFilter;

        private Net.Vpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter libFilter;

        public DefaultConfigFilterItem(Net.Vpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter libFilter, Net.Vpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter typeFilter) {
            this.typeFilter = typeFilter;
            this.libFilter = libFilter;
        }

        public virtual Net.Vpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter GetTypeFilter() {
            return typeFilter;
        }

        public virtual Net.Vpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter GetLibFilter() {
            return libFilter;
        }
    }
}
