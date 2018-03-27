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
    public class IdentityByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.IdentityByteArrayEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.IdentityByteArrayEncoder();

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
