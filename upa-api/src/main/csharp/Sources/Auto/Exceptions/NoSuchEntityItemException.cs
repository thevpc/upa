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
     */
    public class NoSuchEntityItemException : Net.Vpc.Upa.Exceptions.EntityException {

        public NoSuchEntityItemException(string name)  : this(name, null){

        }

        public NoSuchEntityItemException(string name, System.Exception cause)  : base(cause, new Net.Vpc.Upa.Types.I18NString("NoSuchEntityItem"), name){

        }
    }
}
