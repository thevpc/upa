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
    public class IdentityByteArrayEncoder : Net.TheVpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.TheVpc.Upa.Impl.Transform.IdentityByteArrayEncoder INSTANCE = new Net.TheVpc.Upa.Impl.Transform.IdentityByteArrayEncoder();

        public virtual byte[] Encode(object o) {
            return (byte[]) o;
        }

        public virtual object Decode(byte[] bytes) {
            return (byte[]) bytes;
        }


        public override string ToString() {
            return "IdentityByteArrayEncoder";
        }
    }
}
