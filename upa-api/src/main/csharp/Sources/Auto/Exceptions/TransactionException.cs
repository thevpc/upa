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
     * @creationdate 9/16/12 5:08 PM
     */
    public class TransactionException : Net.TheVpc.Upa.Exceptions.UPAException {

        public TransactionException() {
        }

        public TransactionException(string message, params object [] parameters)  : base(message, parameters){

        }

        public TransactionException(Net.TheVpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public TransactionException(System.Exception cause, Net.TheVpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }
    }
}
