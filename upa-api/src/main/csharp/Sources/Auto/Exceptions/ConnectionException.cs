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
    public class ConnectionException : Net.Vpc.Upa.Exceptions.UPAException {

        public ConnectionException() {
        }

        public ConnectionException(string message, params object [] parameters)  : base(message, parameters){

        }

        public ConnectionException(Net.Vpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public ConnectionException(System.Exception cause, Net.Vpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }
    }
}
