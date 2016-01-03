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
    public class StringToCharArrayEncoder : Net.Vpc.Upa.Types.CharArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.StringToCharArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.StringToCharArrayEncoder();

        public virtual char[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return (((string) o)).ToCharArray();
        }

        public virtual object Decode(char[] bytes) {
            if (bytes == null) {
                return null;
            }
            return new string(bytes);
        }
    }
}
