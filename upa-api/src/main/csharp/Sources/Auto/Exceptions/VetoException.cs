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
     * @creationdate 9/7/12 9:27 PM
     */
    public class VetoException : Net.TheVpc.Upa.Exceptions.UPAException {

        public VetoException() {
        }

        public VetoException(string message, params object [] parameters)  : base(message, parameters){

        }

        public VetoException(Net.TheVpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public VetoException(System.Exception cause, Net.TheVpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }
    }
}
