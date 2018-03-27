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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultPersistenceStoreFactory : Net.Vpc.Upa.Persistence.PersistenceStoreFactory {

        static DefaultPersistenceStoreFactory(){
        }

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.Persistence.DatabaseProduct , System.Type> puStoresByDialect = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Persistence.DatabaseProduct , System.Type>();

        public DefaultPersistenceStoreFactory() {
            
            
            
        }

        private void SetDialectPersistenceUnitManager(Net.Vpc.Upa.Persistence.DatabaseProduct databaseProduct, System.Type type) {
            puStoresByDialect[databaseProduct]=type;
        }

        private System.Type GetDialectPersistenceUnitManager(Net.Vpc.Upa.Persistence.DatabaseProduct dialect) {
            System.Type type = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Persistence.DatabaseProduct,System.Type>(puStoresByDialect,dialect);
            if (type == null) {
                throw new System.Exception("Dialect " + dialect + " is not supported");
            }
            return type;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceStore CreatePersistenceStore(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.Vpc.Upa.ObjectFactory factory, Net.Vpc.Upa.Properties parameters) {
            return factory.CreateObject<Net.Vpc.Upa.Persistence.PersistenceStore>(GetDialectPersistenceUnitManager(connectionProfile.GetDatabaseProduct()));
        }
    }
}
