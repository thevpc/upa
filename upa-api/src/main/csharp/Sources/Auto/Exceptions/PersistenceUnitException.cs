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
    public class PersistenceUnitException : Net.TheVpc.Upa.Exceptions.UPAException {

        public PersistenceUnitException() {
        }

        public PersistenceUnitException(string message, params object [] parameters)  : base(message, parameters){

        }

        public PersistenceUnitException(Net.TheVpc.Upa.Types.I18NString message, params object [] parameters)  : base(message, parameters){

        }

        public PersistenceUnitException(System.Exception cause, Net.TheVpc.Upa.Types.I18NString messageId, params object [] parameters)  : base(cause, messageId, parameters){

        }
    }
}
