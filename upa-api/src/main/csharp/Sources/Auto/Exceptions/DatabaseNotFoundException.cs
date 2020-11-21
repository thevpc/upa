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
    public class DatabaseNotFoundException : Net.TheVpc.Upa.Exceptions.PersistenceUnitException {

        private string database;

        public DatabaseNotFoundException() {
        }

        public DatabaseNotFoundException(System.Exception cause, string database)  : base(cause, new Net.TheVpc.Upa.Types.I18NString("DatabaseNotFoundException")){

            this.database = database;
        }

        public virtual string GetDatabase() {
            return database;
        }
    }
}
