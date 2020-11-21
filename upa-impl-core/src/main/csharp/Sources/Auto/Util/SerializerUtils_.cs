using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Net.TheVpc.Upa.Impl.Util
{


    public class SerializerUtils{
        public static object GetObjectFromSerializedForm(byte[] bytes) {
            BinaryFormatter streamFormatter = new BinaryFormatter();
            return streamFormatter.Deserialize(new MemoryStream(bytes));
        }

        public static byte[] GetSerializedFormOf(object @object) {
            BinaryFormatter streamFormatter = new BinaryFormatter();
            MemoryStream ms=new MemoryStream();
            streamFormatter.Serialize(ms,@object);
            return ms.ToArray();
        }

        public static object GetObjectFromSerializedForm(Stream bytes) {
            BinaryFormatter streamFormatter = new BinaryFormatter();
            return streamFormatter.Deserialize(bytes);
        }
    }
}
