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
    public class InvocationException : Net.TheVpc.Upa.Exceptions.UPAException {

        public InvocationException(System.Exception throwable)  : base((throwable is Net.TheVpc.Upa.Exceptions.InvocationException) ? (throwable).InnerException : throwable, new Net.TheVpc.Upa.Types.I18NString("InvocationException")){

            if (throwable == null) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("InvalidInvocationException");
            }
        }
    }
}
