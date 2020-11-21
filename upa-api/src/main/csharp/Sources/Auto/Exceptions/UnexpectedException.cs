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
    public class UnexpectedException : Net.TheVpc.Upa.Exceptions.UPAException {

        public UnexpectedException(string message)  : base((System.Exception) null, new Net.TheVpc.Upa.Types.I18NString("UnexpectedException"), message){

        }

        public UnexpectedException(string message, System.Exception throwable)  : base(throwable, new Net.TheVpc.Upa.Types.I18NString("UnexpectedException"), message){

        }

        public UnexpectedException(System.Exception throwable)  : base(throwable, new Net.TheVpc.Upa.Types.I18NString("UnexpectedException")){

        }
    }
}
