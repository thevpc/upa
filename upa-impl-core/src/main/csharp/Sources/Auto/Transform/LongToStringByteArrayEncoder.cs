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



namespace Net.TheVpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class LongToStringByteArrayEncoder : Net.TheVpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.TheVpc.Upa.Impl.Transform.LongToStringByteArrayEncoder INSTANCE = new Net.TheVpc.Upa.Impl.Transform.LongToStringByteArrayEncoder();

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
            return System.Convert.ToInt64(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
