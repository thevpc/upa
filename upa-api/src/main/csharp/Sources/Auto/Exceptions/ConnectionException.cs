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



namespace Net.TheVpc.Upa.Exceptions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ConnectionException : Net.TheVpc.Upa.Exceptions.UPAException {

        public ConnectionException() {
        }

        public ConnectionException(string message, params object [] parameters)  : base(message, parameters){

        }

        public ConnectionException(Net.TheVpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public ConnectionException(System.Exception cause, Net.TheVpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }
    }
}
