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



namespace Net.Vpc.Upa.Types
{


    /**
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class FileType : Net.Vpc.Upa.Types.LOBType {


        public static readonly Net.Vpc.Upa.Types.FileType DEFAULT = new Net.Vpc.Upa.Types.FileType("FILE", null, null, true);

        private int? maxSize;

        private string[] extensions;

        public FileType(string name, bool nullable)  : this(name, -1, null, nullable){

        }

        public FileType(string name, int? maxSize, string[] extensions, bool nullable)  : base(name, typeof(Net.Vpc.Upa.Types.FileData), nullable){

            this.maxSize = maxSize;
            this.extensions = extensions;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            Net.Vpc.Upa.Types.FileData fileData = ((Net.Vpc.Upa.Types.FileData) @value);
            string fileName = fileData.GetSourceName();
            if (extensions != null && extensions.Length != 0 && fileName != null) {
                bool ok = false;
                string fileExt = __getFileExtension(fileName).ToLower();
                foreach (string extension in extensions) {
                    if (extension.ToLower().Equals(fileExt)) {
                        ok = true;
                        break;
                    }
                }
                if (!ok) {
                    throw new Net.Vpc.Upa.Types.ConstraintsException("FileBadExtension", name, description, @value, fileExt);
                }
            }
            if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((Net.Vpc.Upa.Types.FileData) @value).Size()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("FileSizeTooBig", name, description, @value, maxSize);
            }
        }

        public virtual void SetExtensions(string[] extensions) {
            this.extensions = extensions;
        }

        public virtual string[] GetExtensions() {
            return extensions;
        }

        public virtual int? GetMaxSize() {
            return maxSize;
        }

        public virtual void SetMaxSize(int? maxSize) {
            this.maxSize = maxSize;
        }

        private static string __getFileExtension(string fileName) {
            int x = fileName.LastIndexOf('.');
            if (x > 0) {
                if (x + 1 < (fileName).Length) {
                    return fileName.Substring(x + 1);
                } else {
                    return "";
                }
            } else {
                return "";
            }
        }
    }
}
