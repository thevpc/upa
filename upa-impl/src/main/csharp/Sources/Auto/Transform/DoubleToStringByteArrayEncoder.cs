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
    public class DoubleToStringByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder();

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Convert.ToString(System.Convert.ToDouble(((object) o))).GetBytes();
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToDouble(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
