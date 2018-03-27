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
    public class Base64Encoder : Net.Vpc.Upa.Types.StringEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.Base64Encoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.Base64Encoder();

        public virtual string Encode(byte[] bytes) {
            return Net.Vpc.Upa.Impl.Util.Base64.Encode(bytes);
        }

        public virtual byte[] Decode(string @value) {
            return Net.Vpc.Upa.Impl.Util.Base64.Decode(@value);
        }


        public override string ToString() {
            return "Base64StringEncoder";
        }
    }
}
