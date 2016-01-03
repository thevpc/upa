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
     * @author vpc
     */
    public class ClassPathRoot : System.Collections.Generic.IEnumerable<Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource> {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Util.Classpath.ClassPathRoot)).FullName);

        private string url;

        private string folder;

        private static string ToURL(string file) {
            try {
                return ((file));
            } catch (System.Exception ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                throw new System.ArgumentException ("IllegalArgumentException", ex);
            }
        }



        public ClassPathRoot(string url) {
            this.url = url;
            if ("file".Equals(Net.Vpc.Upa.Impl.FwkConvertUtils.GetURLProtocol(url))) {
                string f2;
                try {
                    f2 = ((url));
                    if (System.IO.Directory.Exists(f2)) {
                        folder = f2;
                    }
                } catch (System.Exception ex) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                }
            }
        }

        public virtual System.Collections.Generic.IEnumerator<Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource> Iterator() {
            if (folder != null) {
                return new Net.Vpc.Upa.Impl.Util.Classpath.FolderClassPathRootIterator(folder);
            }
            try {
                return new Net.Vpc.Upa.Impl.Util.Classpath.URLClassPathRootIterator(url);
            } catch (System.IO.IOException ex) {
                throw new System.Exception("RuntimeException", ex);
            }
        }

        public virtual Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource Find(string path) /* throws System.IO.IOException */  {
            if (folder != null) {
                string f = Net.Vpc.Upa.Impl.FwkConvertUtils.ConcatFilePath(folder, path);
                if (f.Exists()) {
                    return new Net.Vpc.Upa.Impl.Util.Classpath.FileClassPathResource(path, f);
                }
                return null;
            }
            foreach (Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource r in this) {
                if (r.GetPath().Equals(path)) {
                    return r;
                }
            }
            return null;
        }

        public virtual bool Contains(string path) /* throws System.IO.IOException */  {
            if (folder != null) {
                string f = Net.Vpc.Upa.Impl.FwkConvertUtils.ConcatFilePath(folder, path);
                if (f.Exists()) {
                    return true;
                }
                return false;
            }
            Java.Util.Jar.JarInputStream jar = null;
            try {
                jar = new Java.Util.Jar.JarInputStream(Net.Vpc.Upa.Impl.FwkConvertUtils.OpenURLStream(url));
                Java.Util.Zip.ZipEntry nextEntry;
                while ((nextEntry = jar.GetNextEntry()) != null) {
                    string path2 = nextEntry.GetName();
                    if (path2.Equals(path)) {
                        return true;
                    }
                }
            } finally {
                if (jar != null) {
                    jar.Close();
                }
            }
            return false;
        }
    }
}
