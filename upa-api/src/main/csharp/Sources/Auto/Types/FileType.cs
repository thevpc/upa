/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Types
{


    /**
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class FileType : Net.TheVpc.Upa.Types.LOBType {


        public static readonly Net.TheVpc.Upa.Types.FileType DEFAULT = new Net.TheVpc.Upa.Types.FileType("FILE", null, null, true);

        private int? maxSize;

        private string[] extensions;

        public FileType(string name, bool nullable)  : this(name, -1, null, nullable){

        }

        public FileType(string name, int? maxSize, string[] extensions, bool nullable)  : base(name, typeof(Net.TheVpc.Upa.Types.FileData), nullable){

            this.maxSize = maxSize;
            this.extensions = extensions;
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is Net.TheVpc.Upa.Types.FileData)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value, maxSize);
            }
            Net.TheVpc.Upa.Types.FileData fileData = ((Net.TheVpc.Upa.Types.FileData) @value);
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
                    throw new Net.TheVpc.Upa.Types.ConstraintsException("FileBadExtension", name, description, @value, fileExt);
                }
            }
            if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((Net.TheVpc.Upa.Types.FileData) @value).Size()) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("FileSizeTooBig", name, description, @value, maxSize);
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


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
            if (maxSize != null) {
                d.GetProperties()["maxSize"]=System.Convert.ToString(maxSize);
            }
            if (extensions != null) {
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                for (int i = 0; i < extensions.Length; i++) {
                    if (i > 0) {
                        s.Append(",");
                    }
                    string extension = extensions[i];
                    s.Append(extension);
                }
                d.GetProperties()["extensions"]=System.Convert.ToString(s);
            }
            return d;
        }
    }
}
