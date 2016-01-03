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
     * @author vpc
     */
    public class LongToStringByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.LongToStringByteArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.LongToStringByteArrayEncoder();

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Convert.ToString(System.Convert.ToInt32(((object) o))).GetBytes();
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToInt64(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
