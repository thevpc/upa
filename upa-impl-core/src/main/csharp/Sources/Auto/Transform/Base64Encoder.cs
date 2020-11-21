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
    public class Base64Encoder : Net.TheVpc.Upa.Types.StringEncoder {

        public static readonly Net.TheVpc.Upa.Impl.Transform.Base64Encoder INSTANCE = new Net.TheVpc.Upa.Impl.Transform.Base64Encoder();

        public virtual string Encode(byte[] bytes) {
            return Net.TheVpc.Upa.Impl.Util.Base64.Encode(bytes);
        }

        public virtual byte[] Decode(string @value) {
            return Net.TheVpc.Upa.Impl.Util.Base64.Decode(@value);
        }


        public override string ToString() {
            return "Base64StringEncoder";
        }
    }
}
