/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Exceptions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class UPAException : System.Exception {

        private Net.Vpc.Upa.Types.I18NString messageId;

        private object[] parameters;

        public UPAException()  : this("UPAException"){

        }

        public UPAException(string message, params object [] parameters)  : this(new Net.Vpc.Upa.Types.I18NString(message), parameters){

        }

        public UPAException(Net.Vpc.Upa.Types.I18NString message, params object [] parameters)  : this(null, message, parameters){

        }

        public UPAException(System.Exception cause)  : this(cause, new Net.Vpc.Upa.Types.I18NString(cause.ToString())){

        }

        public UPAException(System.Exception cause, Net.Vpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(BuildMessage(messageId, parameters), cause){

            this.messageId = messageId;
            this.parameters = parameters;
        }

        public virtual Net.Vpc.Upa.Types.I18NString GetMessageId() {
            return messageId;
        }

        public virtual object[] GetParameters() {
            return parameters;
        }

        private static string BuildMessage(Net.Vpc.Upa.Types.I18NString messageId, params object [] parameters) {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            string m0 = null;
            if (messageId != null) {
                if ((messageId.GetKeys()).Count > 0) {
                    m0 = messageId.GetKey(0);
                } else {
                    m0 = messageId.ToString();
                }
            } else {
                m0 = "UPAException";
            }
            b.Append(m0);
            if (parameters.Length > 0) {
                b.Append("(");
                for (int i = 0; i < parameters.Length; i++) {
                    if (i > 0) {
                        b.Append(",");
                    }
                    m0 = null;
                    if (parameters[i] != null && parameters[i] is Net.Vpc.Upa.Types.I18NString) {
                        Net.Vpc.Upa.Types.I18NString messageId2 = (Net.Vpc.Upa.Types.I18NString) parameters[i];
                        if ((messageId2.GetKeys()).Count > 0) {
                            m0 = messageId2.GetKey(0);
                        } else {
                            m0 = messageId2.ToString();
                        }
                    } else {
                        m0 = System.Convert.ToString(parameters[i]);
                    }
                    b.Append(m0);
                }
                b.Append(")");
            }
            return b.ToString();
        }
    }
}
