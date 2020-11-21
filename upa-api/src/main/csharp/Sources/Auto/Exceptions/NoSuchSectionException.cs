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
    public class NoSuchSectionException : Net.TheVpc.Upa.Exceptions.PersistenceUnitException {

        public NoSuchSectionException(string name)  : this(name, null){

        }

        public NoSuchSectionException(string name, System.Exception cause)  : base(cause, new Net.TheVpc.Upa.Types.I18NString("NoSuchSectionException"), name){

        }
    }
}
