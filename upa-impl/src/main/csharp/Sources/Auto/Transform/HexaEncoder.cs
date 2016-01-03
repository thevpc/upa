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
    public class HexaEncoder : Net.Vpc.Upa.Types.StringEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.HexaEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.HexaEncoder();

        public virtual string Encode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return Net.Vpc.Upa.Impl.Util.Strings.ToHexString(bytes);
        }

        public virtual byte[] Decode(string @value) {
            if (@value == null) {
                return null;
            }
            return Net.Vpc.Upa.Impl.Util.Strings.ParseHexString(@value);
        }


        public override string ToString() {
            return "HexadecimalStringEncoder";
        }
    }
}
