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
     * @author taha.bensalah@gmail.com
     */
    internal class URLClassIterableIterator : System.Collections.Generic.IEnumerator<System.Type> {

        private readonly Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable outer;

        private System.Type nextType;

        private int urlIndex = 0;

        private System.Collections.Generic.IEnumerator<Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource> classPathResources;

        public URLClassIterableIterator(Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable outer) {
            this.outer = outer;
        }

        public virtual bool HasNext() {
            while (urlIndex < outer.urls.Length) {
                string jarURL = outer.urls[urlIndex];
                if (classPathResources == null) {
                    if (outer.configFilter.AcceptLibrary(jarURL)) {
                        Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable.log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("configuration from  url : {0}",null,jarURL));
                        classPathResources = new Net.Vpc.Upa.Impl.Util.Classpath.ClassPathRoot(jarURL).GetEnumerator();
                    } else {
                        urlIndex++;
                        Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable.log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("ignoring  configuration from url : {0}",null,jarURL));
                        continue;
                    }
                }
                if (classPathResources.MoveNext()) {
                    System.Type c = null;
                    try {
                        Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource cr = (classPathResources).Current;
                        c = outer.ConfigureClassURL(jarURL, cr.GetPath());
                    } catch (System.Exception ex) {
                        Net.Vpc.Upa.Impl.Util.Classpath.URLClassIterable.log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                    if (c != null) {
                        nextType = c;
                        return true;
                    }
                } else {
                    classPathResources = null;
                    urlIndex++;
                }
            }
            classPathResources = null;
            return false;
        }

        public virtual System.Type Next() {
            return nextType;
        }
    }
}
