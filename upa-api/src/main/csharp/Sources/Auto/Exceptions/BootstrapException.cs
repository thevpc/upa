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
    public class BootstrapException : Net.Vpc.Upa.Exceptions.UPAException {

        public BootstrapException()  : this(null){

        }

        public BootstrapException(string message)  : this(message, null){

        }

        public BootstrapException(string message, System.Exception throwable)  : base(throwable, new Net.Vpc.Upa.Types.I18NString("IllegalArgumentException"), message){

        }
    }
}
