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
    public class IdentityCharArrayEncoder : Net.TheVpc.Upa.Types.CharArrayEncoder {

        public static readonly Net.TheVpc.Upa.Impl.Transform.IdentityCharArrayEncoder INSTANCE = new Net.TheVpc.Upa.Impl.Transform.IdentityCharArrayEncoder();

        public virtual char[] Encode(object o) {
            return (char[]) o;
        }

        public virtual object Decode(char[] bytes) {
            return (char[]) bytes;
        }
    }
}
