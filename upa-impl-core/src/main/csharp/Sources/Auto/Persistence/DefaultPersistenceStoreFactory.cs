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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultPersistenceStoreFactory : Net.TheVpc.Upa.Persistence.PersistenceStoreFactory {

        static DefaultPersistenceStoreFactory(){
        }

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Persistence.DatabaseProduct , System.Type> puStoresByDialect = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Persistence.DatabaseProduct , System.Type>();

        public DefaultPersistenceStoreFactory() {
            
            
            
        }

        private void SetDialectPersistenceUnitManager(Net.TheVpc.Upa.Persistence.DatabaseProduct databaseProduct, System.Type type) {
            puStoresByDialect[databaseProduct]=type;
        }

        private System.Type GetDialectPersistenceUnitManager(Net.TheVpc.Upa.Persistence.DatabaseProduct dialect) {
            System.Type type = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Persistence.DatabaseProduct,System.Type>(puStoresByDialect,dialect);
            if (type == null) {
                throw new System.Exception("Dialect " + dialect + " is not supported");
            }
            return type;
        }

        public virtual Net.TheVpc.Upa.Persistence.PersistenceStore CreatePersistenceStore(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.TheVpc.Upa.ObjectFactory factory, Net.TheVpc.Upa.Properties parameters) {
            return factory.CreateObject<Net.TheVpc.Upa.Persistence.PersistenceStore>(GetDialectPersistenceUnitManager(connectionProfile.GetDatabaseProduct()));
        }
    }
}
