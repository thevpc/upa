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
    public class DoubleToStringCharArrayEncoder : Net.Vpc.Upa.Types.CharArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.DoubleToStringCharArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.DoubleToStringCharArrayEncoder();

        public virtual char[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Convert.ToString(System.Convert.ToDouble(((object) o))).ToCharArray();
        }

        public virtual object Decode(char[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToDouble(new string(bytes));
        }
    }
}
