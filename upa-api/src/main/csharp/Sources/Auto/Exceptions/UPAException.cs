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
            b.Append(messageId == null ? "UPAException" : messageId.ToString());
            if (parameters.Length > 0) {
                b.Append("(");
                for (int i = 0; i < parameters.Length; i++) {
                    if (i > 0) {
                        b.Append(",");
                    }
                    b.Append(parameters[i]);
                }
                b.Append(")");
            }
            return b.ToString();
        }
    }
}
