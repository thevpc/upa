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
    public class PlainStringEncoder : Net.Vpc.Upa.Types.StringEncoder {

        public static readonly Net.Vpc.Upa.Impl.Transform.PlainStringEncoder INSTANCE = new Net.Vpc.Upa.Impl.Transform.PlainStringEncoder();

        public virtual string Encode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            return System.Text.Encoding.Default.GetString(bytes);
        }

        public virtual byte[] Decode(string @value) {
            if (@value == null) {
                return null;
            }
            return System.Text.Encoding.UTF8.GetBytes(@value);
        }


        public override string ToString() {
            return "PlainStringEncoder";
        }
    }
}
