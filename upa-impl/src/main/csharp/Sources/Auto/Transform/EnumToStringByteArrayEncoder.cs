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
    public class EnumToStringByteArrayEncoder : Net.Vpc.Upa.Types.ByteArrayEncoder {

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Transform.EnumToStringByteArrayEncoder)).FullName);

        private System.Type enumClass;

        public EnumToStringByteArrayEncoder(System.Type enumClass) {
            this.enumClass = enumClass;
        }

        public virtual byte[] Encode(object o) {
            if (o == null) {
                return null;
            }
            return System.Convert.ToString(o).GetBytes();
        }

        public virtual object Decode(byte[] bytes) {
            if (bytes == null) {
                return null;
            }
            string sval = System.Text.Encoding.Default.GetString(bytes);
            if (sval.Length==0) {
                return null;
            }
            try {
                return System.Enum.Parse(enumClass,sval);
            } catch (System.ArgumentException  ex) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to parse" + sval + " as enum " + (enumClass).FullName,ex));
                return null;
            }
        }
    }
}
