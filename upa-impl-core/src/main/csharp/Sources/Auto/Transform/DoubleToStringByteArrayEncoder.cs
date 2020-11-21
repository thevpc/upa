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
    public class DoubleToStringByteArrayEncoder : Net.TheVpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.TheVpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder INSTANCE = new Net.TheVpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder();

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Text.Encoding.UTF8.GetBytes(System.Convert.ToString(System.Convert.ToDouble(((object) o))));
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToDouble(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
