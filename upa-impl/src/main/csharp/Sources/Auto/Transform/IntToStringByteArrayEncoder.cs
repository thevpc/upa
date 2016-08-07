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



namespace Net.Vpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class IntToStringByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.IntToStringByteArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.IntToStringByteArrayEncoder();

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Text.Encoding.UTF8.GetBytes(System.Convert.ToString(System.Convert.ToInt32(((object) o))));
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToInt32(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
