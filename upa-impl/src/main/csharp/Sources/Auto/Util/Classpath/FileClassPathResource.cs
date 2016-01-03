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
    public class FileClassPathResource : Net.Vpc.Upa.Impl.Util.Classpath.ClassPathResource {

        private string path;

        private string file;

        public FileClassPathResource(string path, string file) {
            this.file = file;
            this.path = path;
        }

        public virtual System.IO.Stream Open() /* throws System.IO.IOException */  {
            return new System.IO.FileStream(file,System.IO.FileMode.Open);
        }

        public virtual string GetPath() {
            return path;
        }


        public override string ToString() {
            return path;
        }
    }
}
