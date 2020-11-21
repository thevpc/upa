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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FixedDBConfigModel : Net.TheVpc.Upa.Persistence.DBConfigModel {

        private string connectionString;

        public FixedDBConfigModel(string connectionString) {
            this.connectionString = connectionString;
        }

        public virtual string GetConnectionString() {
            return connectionString;
        }

        public virtual string[] GetConnectionStringArray() {
            return new string[] { connectionString };
        }

        public virtual void SetConnectionString(string adapter) {
        }

        public virtual void SetConnectionStringArray(string[] adapters) {
        }
    }
}
