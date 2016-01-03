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
    public class FloatToStringByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.FloatToStringByteArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.FloatToStringByteArrayEncoder();

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Convert.ToString(System.Convert.ToSingle(((object) o))).GetBytes();
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToSingle(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
