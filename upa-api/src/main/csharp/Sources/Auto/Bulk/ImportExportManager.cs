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



namespace Net.TheVpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ImportExportManager : Net.TheVpc.Upa.Bulk.ParseFormatManager {

         Net.TheVpc.Upa.Bulk.DataRowConverter CreateEntityConverter(string entityName, Net.TheVpc.Upa.Filters.FieldFilter filter);

         void ImportEntity(string entityName, Net.TheVpc.Upa.Bulk.DataReader dataIterator, Net.TheVpc.Upa.Bulk.ImportDataConfig config);

         void ImportObjectById(string entityName, int sourceId, Net.TheVpc.Upa.PersistenceUnit source, Net.TheVpc.Upa.Bulk.ImportPersistenceUnitListener listener);

         void ImportEntity(string entityName, Net.TheVpc.Upa.PersistenceUnit source, bool deleteExisting, Net.TheVpc.Upa.Bulk.ImportPersistenceUnitListener listener);

         void ImportEntities(Net.TheVpc.Upa.PersistenceUnit source, Net.TheVpc.Upa.Filters.EntityFilter filter, bool deleteExisting, Net.TheVpc.Upa.Bulk.ImportPersistenceUnitListener listener);
    }
}
