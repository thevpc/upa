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



namespace Net.Vpc.Upa.Exceptions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/7/12 9:27 PM
     */
    public class InvocationException : Net.Vpc.Upa.Exceptions.UPAException {

        public InvocationException(System.Exception throwable)  : base((throwable is Net.Vpc.Upa.Exceptions.InvocationException) ? (throwable).InnerException : throwable, new Net.Vpc.Upa.Types.I18NString("InvocationException")){

            if (throwable == null) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("InvalidInvocationException");
            }
        }
    }
}
