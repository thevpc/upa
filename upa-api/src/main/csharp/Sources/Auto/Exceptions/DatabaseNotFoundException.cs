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
    public class DatabaseNotFoundException : Net.Vpc.Upa.Exceptions.PersistenceUnitException {

        private string database;

        public DatabaseNotFoundException() {
        }

        public DatabaseNotFoundException(System.Exception cause, string database)  : base(cause, new Net.Vpc.Upa.Types.I18NString("DatabaseNotFoundException")){

            this.database = database;
        }

        public virtual string GetDatabase() {
            return database;
        }
    }
}
