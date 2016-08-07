using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Net.Vpc.Upa.Impl.Util
{


    public partial class CacheFile{

        private BinaryFormatter streamFormatter = new BinaryFormatter();

        private Stream inputStream;

        private Stream outputStream;

        private FileInfo file;

        public virtual FileInfo GetFile() {
            if (file == null) {
                file = new FileInfo(System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "-cache.tmp");
            }
            return file;
        }

        public virtual void Write(System.Object o) /* throws Net.Vpc.Upa.Impl.Util.CacheException */  {
            if (!IsWriting()) {
                SetWriting();
            }
            empty = false;
            streamFormatter.Serialize(outputStream, o);
        }

        private void SetWriting() /* throws Net.Vpc.Upa.Impl.Util.CacheException */  {
            if (outputStream != null)
            {
                outputStream.Close();
            }
            outputStream = File.Create(GetFile().FullName);
            streamFormatter.Serialize(outputStream, START_FILE);
            status = 1;
        }

        public void Close() /* throws Net.Vpc.Upa.Impl.Util.CacheException */  {
            try {
                if (IsWriting()) {
                    streamFormatter.Serialize(outputStream, END_FILE);
                    outputStream.Close();
                    outputStream = null;
                } else if (IsReading()) {
                    inputStream.Close();
                    inputStream = null;
                }
                status = 0;
            } catch (System.IO.IOException e) {
                throw ;
            }
        }

        public virtual bool HasNext() /* throws Net.Vpc.Upa.Impl.Util.CacheException */  {
            if (empty) {
                return false;
            }
            if (!IsReading()) {
                SetReading();
            }
            if (objectRead) {
                lastExtractedObject = streamFormatter.Deserialize(inputStream);
                objectRead = false;
            }
            return !END_FILE.Equals(lastExtractedObject);
        }

        private void SetReading() /* throws Net.Vpc.Upa.Impl.Util.CacheException */  {
            status = 2;
            System.Object o = null;
            inputStream = File.OpenRead(GetFile().FullName);
            o = streamFormatter.Deserialize(inputStream);
            if (!START_FILE.Equals(o)) {
                throw new Net.Vpc.Upa.Impl.Util.CacheException("Bad cache file");
            } else {
                objectRead = true;
                return;
            }
        }
    }
}
