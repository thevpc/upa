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
     */
    public class NoSuchPersistenceUnitException : Net.Vpc.Upa.Exceptions.PersistenceUnitException {

        public NoSuchPersistenceUnitException(string name)  : this(name, null){

        }

        public NoSuchPersistenceUnitException(string name, System.Exception cause)  : base(cause, new Net.Vpc.Upa.Types.I18NString("NoSuchPersistenceUnitException"), name){

        }
    }
}
