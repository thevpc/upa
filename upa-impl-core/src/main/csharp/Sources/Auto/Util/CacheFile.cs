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



namespace Net.TheVpc.Upa.Impl.Util
{



    public partial class CacheFile : Net.TheVpc.Upa.Closeable {

        private int status;

        private static object START_FILE = "net.thevpc.lib.pheromone.ariana.io.CacheFile.START";

        private static object END_FILE = "net.thevpc.lib.pheromone.ariana.io.CacheFile.END";

        private object lastExtractedObject;

        private bool objectRead;

        private bool empty;







        public CacheFile() {
            empty = true;
        }













        public virtual object Read() /* throws Net.TheVpc.Upa.Impl.Util.CacheException */  {
            if (objectRead) {
                HasNext();
            }
            if (END_FILE.Equals(lastExtractedObject)) {
                throw new Net.TheVpc.Upa.Impl.Util.CacheException("End Of Cache File Reached");
            } else {
                objectRead = true;
                return lastExtractedObject;
            }
        }

        public virtual bool IsReading() {
            return status == 2;
        }

        public virtual bool IsWriting() {
            return status == 1;
        }

        public virtual bool IsEmpty() {
            return empty;
        }
    }
}
