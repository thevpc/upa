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
    public class FolderClassPathRootIterator : System.Collections.Generic.IEnumerator<Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource> {

        private string root;

        private Net.Vpc.Upa.Impl.Util.Classpath.FileClassPathResource last;

        private System.Collections.Generic.Stack<string> stack = new System.Collections.Generic.Stack<string>();

        public FolderClassPathRootIterator(string root) {
            this.root = root;
            string[] f = System.IO.Directory.GetFileSystemEntries(root);
            if (f != null) {
                for (int i = f.Length - 1; i >= 0; i--) {
                    string file = f[i];
                    stack.Push(file);
                }
            }
        }

        public virtual bool HasNext() {
            return !(stack.Count==0);
        }

        public virtual Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource Next() {
            string r = stack.Pop();
            if (System.IO.Directory.Exists(r)) {
                string[] f = System.IO.Directory.GetFileSystemEntries(r);
                if (f != null) {
                    for (int i = f.Length - 1; i >= 0; i--) {
                        string file = f[i];
                        stack.Push(file);
                    }
                }
                string p = (r).Substring(((root)).Length + 1).Replace("\\", "/");
                return last = new Net.Vpc.Upa.Impl.Util.Classpath.FileClassPathResource(p + "/", r);
            } else {
                string p = (r).Substring(((root)).Length + 1).Replace("\\", "/");
                return last = new Net.Vpc.Upa.Impl.Util.Classpath.FileClassPathResource(p, r);
            }
        }

        public virtual void Remove() {
            //should remove last
            throw new System.Exception("Not supported.");
        }
    }
}
