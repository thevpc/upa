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
    public class LongToStringCharArrayEncoder : Net.Vpc.Upa.Types.CharArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.LongToStringCharArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.LongToStringCharArrayEncoder();

        public virtual char[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Convert.ToString(System.Convert.ToInt32(((object) o))).ToCharArray();
        }

        public virtual object Decode(char[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Convert.ToInt64(new string(bytes));
        }
    }
}
