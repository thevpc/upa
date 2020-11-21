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
    public class ChainByteArrayEncoder : Net.TheVpc.Upa.Types.ByteArrayEncoder {

        private Net.TheVpc.Upa.Types.ByteArrayEncoder a;

        private Net.TheVpc.Upa.Types.ByteArrayEncoder b;

        public ChainByteArrayEncoder(Net.TheVpc.Upa.Types.ByteArrayEncoder a, Net.TheVpc.Upa.Types.ByteArrayEncoder b) {
            this.a = a;
            this.b = b;
        }

        public virtual byte[] Encode(object bytes) {
            return b.Encode(a.Encode(bytes));
        }

        public virtual object Decode(byte[] @value) {
            return a.Decode((byte[]) b.Decode(@value));
        }
    }
}
