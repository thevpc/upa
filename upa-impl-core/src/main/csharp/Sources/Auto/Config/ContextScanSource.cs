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
namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/24/12 3:01 AM
     */
    public class ContextScanSource : Net.Vpc.Upa.Impl.Config.BaseScanSource {

        private bool noIgnore;

        public ContextScanSource(bool noIgnore) {
            this.noIgnore = noIgnore;
        }

        public override bool IsNoIgnore() {
            return noIgnore;
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder((GetType()).Name);
            s.Append("[noIgnore=");
            s.Append(noIgnore);
            s.Append("]");
            return s.ToString();
        }


        public override System.Collections.Generic.IEnumerable<System.Type> ToIterable(object context) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Config.ScanFilter> _filters = new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>();
            if (context is Net.Vpc.Upa.UPAContext) {
                Net.Vpc.Upa.UPAContext pg = (Net.Vpc.Upa.UPAContext) context;
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(_filters, new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>(pg.GetContextAnnotationStrategyFilters()));
            } else if (context is Net.Vpc.Upa.PersistenceGroup) {
                Net.Vpc.Upa.PersistenceGroup pg = (Net.Vpc.Upa.PersistenceGroup) context;
                foreach (Net.Vpc.Upa.Config.ScanFilter filter in pg.GetContext().GetContextAnnotationStrategyFilters()) {
                    if (filter.IsPropagate()) {
                        _filters.Add(filter);
                    }
                }
                Net.Vpc.Upa.Impl.FwkConvertUtils.ListAddRange(_filters, new System.Collections.Generic.List<Net.Vpc.Upa.Config.ScanFilter>(pg.GetContextAnnotationStrategyFilters()));
            } else if (context is Net.Vpc.Upa.PersistenceUnit) {
                Net.Vpc.Upa.PersistenceUnit pu = (Net.Vpc.Upa.PersistenceUnit) context;
                foreach (Net.Vpc.Upa.Config.ScanFilter filter in pu.GetPersistenceGroup().GetContext().GetContextAnnotationStrategyFilters()) {
                    if (filter.IsPropagate()) {
                        _filters.Add(filter);
                    }
                }
                foreach (Net.Vpc.Upa.Config.ScanFilter filter in pu.GetPersistenceGroup().GetContextAnnotationStrategyFilters()) {
                    if (filter.IsPropagate()) {
                        _filters.Add(filter);
                    }
                }
                foreach (Net.Vpc.Upa.Config.ScanFilter filter in pu.GetContextAnnotationStrategyFilters()) {
                    _filters.Add(filter);
                }
            } else {
                throw new System.ArgumentException ("Unsupported context " + context);
            }
            return new Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable(Net.Vpc.Upa.Impl.Util.Classpath.ClassPathUtils.ResolveClassPathLibs(), new Net.Vpc.Upa.Impl.Util.Classpath.DefaultConfigFilter(_filters.ToArray()), null);
        }
    }
}
