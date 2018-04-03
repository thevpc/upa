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



namespace Net.Vpc.Upa.Types
{



    public partial class FileData {



        protected internal byte[] data;

        protected internal string sourceName;

        public FileData(string sourceName, byte[] data) {
            this.sourceName = sourceName;
            this.data = data != null ? data : new byte[0];
        }



        public FileData(System.IO.Stream inputStream) {
            Load(null, inputStream);
        }



        public FileData(string url) {
            Load(GetURLName(url), Net.Vpc.Upa.FwkConvertUtils.OpenURLStream(url));
        }

        public virtual byte[] GetData() {
            return data;
        }











        public virtual long Size() {
            return data != null ? ((long)(data.Length)) : -1L;
        }

        public virtual string GetSourceName() {
            return sourceName;
        }

        public virtual string GetFileType() {
            return sourceName == null ? null : GetFileExtension(sourceName);
        }

        private static string GetFileExtension(string fileName) {
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

        private string GetURLName(string url) {
            string p = Net.Vpc.Upa.FwkConvertUtils.GetURLPath(url);
            int slash = p.LastIndexOf('/');
            if (slash < 0) {
                slash = p.LastIndexOf(':');
            }
            return slash == 0 ? p : p.Substring(slash);
        }
    }
}
