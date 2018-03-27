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
    public class URLClassPathRootIterator : System.Collections.Generic.IEnumerator<Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource> {

        private string url;





        public URLClassPathRootIterator(string url) {
            this.url = url;
        }

        public virtual bool HasNext() {
            return false;
        }

        public virtual Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource Next() {
            return null;
        }

        public virtual void Remove() {
            throw new System.Exception("Not supported.");
        }


    }
}
