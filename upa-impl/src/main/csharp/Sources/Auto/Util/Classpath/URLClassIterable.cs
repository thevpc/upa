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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 1:00 PM
     */

    public partial class URLClassIterable : System.Collections.Generic.IEnumerable<System.Type> {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable)).FullName);

        public string[] urls;

        public Net.Vpc.Upa.Impl.Util.Classpath.ClassPathFilter configFilter;

        public Net.Vpc.Upa.Impl.Util.Classpath.ClassFilter classFilter;

        public int nameStrategyModelConfigOrder = System.Int32.MinValue;



        public URLClassIterable(string[] urls, Net.Vpc.Upa.Impl.Util.Classpath.ClassPathFilter configFilter, Net.Vpc.Upa.Impl.Util.Classpath.ClassFilter classFilter) {
            this.urls = urls;
            this.configFilter = configFilter;
            this.classFilter = classFilter;
        }

        public virtual System.Collections.Generic.IEnumerator<System.Type> Iterator() {
            return new Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterableIterator(this);
        }

        internal virtual System.Type ConfigureClassURL(string src, string path) /* throws System.Exception */  {
            if (path.StartsWith("/")) {
                path = path.Substring(1);
            }
            //        URL url = contextClassLoader.getResource(path);
            if (path.EndsWith(".class")) {
                string cls = path.Substring(0, (path).Length - (".class").Length).Replace('/', '.');
                string pck = null;
                int endIndex = cls.LastIndexOf('.');
                if (endIndex > 0) {
                    pck = cls.Substring(0, endIndex);
                }
                int dollar = cls.IndexOf('$');
                bool anonymousClass = false;
                bool innerClass = false;
                if (dollar >= 0) {
                    innerClass = true;
                    //special class
                    if (dollar + 1 < (cls).Length) {
                        string subName = cls.Substring(dollar + 1);
                        if (subName != null && (subName).Length > 0 && char.IsDigit(subName[0])) {
                            anonymousClass = true;
                        }
                    }
                }
                if (!anonymousClass) {
                    if (configFilter.AcceptClassName(src, cls)) {
                        System.Type aClass = null;
                        try {
                            aClass = System.Type.GetType(cls, false, contextClassLoader);
                        } catch (System.Exception e) {
                            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to load class {0} for UPA configuration. Ignored",null,cls));
                        }
                        if (aClass != null) {
                            if (configFilter.AcceptClass(src, cls, aClass)) {
                                if (classFilter == null || classFilter.Accept(aClass)) {
                                    return (aClass);
                                }
                            }
                        }
                    } else {
                    }
                }
            }
            //                      System.out.println(path);
            //                      System.out.println("\tSOURCE  " + src);
            //                      System.out.println("\tSYS URL " + sysURL);
            //                      System.out.println("\tAPP URL " + url);
            //                      System.out.println("\tPKG   " + (pck==null?"":Package.getPackage(pck)));
            //                      System.out.println("\tCLASS " + Class.forName(cls,false,contextClassLoader));
            return null;
        }
    }
}
