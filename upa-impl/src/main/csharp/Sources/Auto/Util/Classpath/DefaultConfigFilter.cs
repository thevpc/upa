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



namespace Net.Vpc.Upa.Impl.Util.Classpath
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultConfigFilter : Net.Vpc.Upa.Impl.Util.Classpath.ClassPathFilter {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.Classpath.DefaultConfigFilter)).FullName);

        private bool emptyResult = false;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem> items = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem>();

        private System.Collections.Generic.IDictionary<string , System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem>> cache = new System.Collections.Generic.Dictionary<string , System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem>>();



        public DefaultConfigFilter(Net.Vpc.Upa.Config.ScanFilter[] filterList) {
            //always add upa classes
            Add(new Net.Vpc.Upa.Config.ScanFilter("", "net.vpc.upa.**", true, System.Int32.MinValue));
            foreach (Net.Vpc.Upa.Config.ScanFilter filter in filterList) {
                Add(filter);
            }
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem> GetDefaultConfigFilterItem(string url) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem> found = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem>>(cache,url);
            if (found == null) {
                found = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem>();
                foreach (Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem defaultConfigFilterItem in items) {
                    if (defaultConfigFilterItem.GetLibFilter().Accept(url)) {
                        Net.Vpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter p = defaultConfigFilterItem.GetTypeFilter();
                        if (p.GetUserPatterns().Length == 0) {
                            found.Add(defaultConfigFilterItem);
                        } else {
                            foreach (string pattern in p.GetUserPatterns()) {
                                System.Text.StringBuilder prefix = new System.Text.StringBuilder();
                                char[] patternCharArray = pattern.ToCharArray();
                                int x = 0;
                                bool exitWhile = false;
                                while (!exitWhile && x < patternCharArray.Length) {
                                    char c = patternCharArray[x];
                                    switch(c) {
                                        case '*':
                                        case '?':
                                            {
                                                if ((prefix).Length > 0 && prefix.ToString().EndsWith(".")) {
                                                } else {
                                                    while ((prefix).Length > 0 && !prefix.ToString().EndsWith(".")) {
                                                        prefix.Remove((prefix).Length - 1, 1);
                                                    }
                                                }
                                                exitWhile = true;
                                                break;
                                            }
                                        default:
                                            {
                                                prefix.Append(patternCharArray[x]);
                                                break;
                                            }
                                    }
                                    x++;
                                }
                                if ((prefix).Length > 0) {
                                    string rr = prefix.ToString().Replace('.', '/');
                                    Net.Vpc.Upa.Impl.Util.Classpath.ClassPathRoot cr = new Net.Vpc.Upa.Impl.Util.Classpath.ClassPathRoot(url);
                                    try {
                                        if (cr.Contains(rr)) {
                                            found.Add(defaultConfigFilterItem);
                                            break;
                                        }
                                    } catch (System.Exception e) {
                                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,e));
                                    }
                                } else {
                                    found.Add(defaultConfigFilterItem);
                                    break;
                                }
                            }
                        }
                    }
                }
                cache[url]=found;
            }
            return found;
        }

        public virtual bool AcceptLibrary(string url) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem> found = GetDefaultConfigFilterItem(url);
            if ((found).Count == 0) {
                if ((items).Count == 0) {
                    return emptyResult;
                }
                return false;
            }
            return true;
        }

        public virtual bool AcceptClassName(string url, string className) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem> item = GetDefaultConfigFilterItem(url);
            foreach (Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem y in item) {
                if (y.GetTypeFilter().Accept(className)) {
                    return true;
                }
            }
            if ((items).Count == 0) {
                return emptyResult;
            }
            return false;
        }

        public virtual bool AcceptClass(string url, string className, System.Type type) {
            return true;
        }

        private void Add(Net.Vpc.Upa.Config.ScanFilter filter) {
            Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem defaultConfigFilterItem = new Net.Vpc.Upa.Impl.Config.DefaultConfigFilterItem(new Net.Vpc.Upa.Impl.Util.Classpath.PatternListLibNameFilter(new string[] { filter.GetLibs() }), new Net.Vpc.Upa.Impl.Util.Classpath.PatternListClassNameFilter(new string[] { filter.GetTypes() }));
            items.Add(defaultConfigFilterItem);
        }
    }
}
