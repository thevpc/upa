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
    public class ChainByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        private Net.Vpc.Upa.Types.ByteArrayEncoder a;

        private Net.Vpc.Upa.Types.ByteArrayEncoder b;

        public ChainByteArrayEncoder(Net.Vpc.Upa.Types.ByteArrayEncoder a, Net.Vpc.Upa.Types.ByteArrayEncoder b) {
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
