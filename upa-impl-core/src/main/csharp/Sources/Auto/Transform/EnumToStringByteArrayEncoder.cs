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
    public class EnumToStringByteArrayEncoder : Net.TheVpc.Upa.Types.ByteArrayEncoder {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Transform.EnumToStringByteArrayEncoder)).FullName);

        private System.Type enumClass;

        public EnumToStringByteArrayEncoder(System.Type enumClass) {
            this.enumClass = enumClass;
        }

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Text.Encoding.UTF8.GetBytes(System.Convert.ToString(o));
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            string sval = System.Text.Encoding.Default.GetString(bytes);
            if ((sval.Length==0)) {
                return null;
            }
            try {
                return System.Enum.Parse(enumClass,sval);
            } catch (System.ArgumentException  ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to parse" + sval + " as enum " + (enumClass).FullName,ex));
                return null;
            }
        }
    }
}
