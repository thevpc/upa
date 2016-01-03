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
    public class IdentityCharArrayEncoder : Net.Vpc.Upa.Types.CharArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.IdentityCharArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.IdentityCharArrayEncoder();

        public virtual char[] Encode(object o) {
            return (char[]) o;
        }

        public virtual object Decode(char[] bytes) {
            return (char[]) bytes;
        }
    }
}
