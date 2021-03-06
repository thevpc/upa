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
    public class ChainCharArrayEncoder : Net.TheVpc.Upa.Types.CharArrayEncoder {

        private Net.TheVpc.Upa.Types.CharArrayEncoder a;

        private Net.TheVpc.Upa.Types.CharArrayEncoder b;

        public ChainCharArrayEncoder(Net.TheVpc.Upa.Types.CharArrayEncoder a, Net.TheVpc.Upa.Types.CharArrayEncoder b) {
            this.a = a;
            this.b = b;
        }

        public virtual char[] Encode(object bytes) {
            return b.Encode(a.Encode(bytes));
        }

        public virtual object Decode(char[] @value) {
            return a.Decode((char[]) b.Decode(@value));
        }
    }
}
