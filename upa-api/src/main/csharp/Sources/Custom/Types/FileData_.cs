
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Net.Vpc.Upa.Types{
    public partial class FileData {

        /*
        public FileData(String file) {
            Load(file, new FileStream(file,FileMode.Open));
        }
        */

        [MethodImpl(MethodImplOptions.Synchronized)]
            private void Load(string src, Stream inputStream) {
                if (inputStream == null) {
                    data = null;
                    sourceName = src;
                } else {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        inputStream.CopyTo(ms);
                        data= ms.ToArray();
                    }
                    inputStream.Read(data,0,data.Length);
                    sourceName = src;
                }
            }

            public void Save(Stream outputStream) {
                outputStream.Write(GetData(),0,GetData().Length);
            }

            public void Save(string file) {
                new FileInfo(file).Directory.Create();
                Save(new FileStream(file,FileMode.Open));
            }
    }
}