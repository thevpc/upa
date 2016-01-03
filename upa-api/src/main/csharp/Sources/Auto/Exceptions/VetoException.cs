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
     * @creationdate 9/7/12 9:27 PM
     */
    public class VetoException : Net.Vpc.Upa.Exceptions.UPAException {

        public VetoException() {
        }

        public VetoException(string message, params object [] parameters)  : base(message, parameters){

        }

        public VetoException(Net.Vpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public VetoException(System.Exception cause, Net.Vpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }
    }
}
