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
    public class StringToCharArrayEncoder : Net.TheVpc.Upa.Types.CharArrayEncoder {

        public static readonly Net.TheVpc.Upa.Impl.Transform.StringToCharArrayEncoder INSTANCE = new Net.TheVpc.Upa.Impl.Transform.StringToCharArrayEncoder();

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
