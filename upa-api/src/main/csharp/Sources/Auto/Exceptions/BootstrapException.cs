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
    public class BootstrapException : Net.TheVpc.Upa.Exceptions.UPAException {

        public BootstrapException()  : this(null){

        }

        public BootstrapException(string message)  : this(message, null){

        }

        public BootstrapException(string message, System.Exception throwable)  : base(throwable, new Net.TheVpc.Upa.Types.I18NString("BootstrapException"), message){

        }
    }
}
