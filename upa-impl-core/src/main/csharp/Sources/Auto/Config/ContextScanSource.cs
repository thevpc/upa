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
namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/24/12 3:01 AM
     */
    public class ContextScanSource : Net.TheVpc.Upa.Impl.Config.BaseScanSource {

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
            System.Collections.Generic.IList<Net.TheVpc.Upa.Config.ScanFilter> _filters = new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>();
            if (context is Net.TheVpc.Upa.UPAContext) {
                Net.TheVpc.Upa.UPAContext pg = (Net.TheVpc.Upa.UPAContext) context;
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(_filters, new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>(pg.GetContextAnnotationStrategyFilters()));
            } else if (context is Net.TheVpc.Upa.PersistenceGroup) {
                Net.TheVpc.Upa.PersistenceGroup pg = (Net.TheVpc.Upa.PersistenceGroup) context;
                foreach (Net.TheVpc.Upa.Config.ScanFilter filter in pg.GetContext().GetContextAnnotationStrategyFilters()) {
                    if (filter.IsPropagate()) {
                        _filters.Add(filter);
                    }
                }
                Net.TheVpc.Upa.Impl.FwkConvertUtils.ListAddRange(_filters, new System.Collections.Generic.List<Net.TheVpc.Upa.Config.ScanFilter>(pg.GetContextAnnotationStrategyFilters()));
            } else if (context is Net.TheVpc.Upa.PersistenceUnit) {
                Net.TheVpc.Upa.PersistenceUnit pu = (Net.TheVpc.Upa.PersistenceUnit) context;
                foreach (Net.TheVpc.Upa.Config.ScanFilter filter in pu.GetPersistenceGroup().GetContext().GetContextAnnotationStrategyFilters()) {
                    if (filter.IsPropagate()) {
                        _filters.Add(filter);
                    }
                }
                foreach (Net.TheVpc.Upa.Config.ScanFilter filter in pu.GetPersistenceGroup().GetContextAnnotationStrategyFilters()) {
                    if (filter.IsPropagate()) {
                        _filters.Add(filter);
                    }
                }
                foreach (Net.TheVpc.Upa.Config.ScanFilter filter in pu.GetContextAnnotationStrategyFilters()) {
                    _filters.Add(filter);
                }
            } else {
                throw new System.ArgumentException ("Unsupported context " + context);
            }
            return new Net.TheVpc.Upa.Impl.Util.Classpath.URLClassIterable(Net.TheVpc.Upa.Impl.Util.Classpath.ClassPathUtils.ResolveClassPathLibs(), new Net.TheVpc.Upa.Impl.Util.Classpath.DefaultConfigFilter(_filters.ToArray()), null);
        }
    }
}
