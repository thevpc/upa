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



namespace Net.Vpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ImportExportManager : Net.Vpc.Upa.Bulk.ParseFormatManager {

         Net.Vpc.Upa.Bulk.DataRowConverter CreateEntityConverter(string entityName, Net.Vpc.Upa.Filters.FieldFilter filter);

         void ImportEntity(string entityName, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config);

         void ImportObjectById(string entityName, int sourceId, Net.Vpc.Upa.PersistenceUnit source, Net.Vpc.Upa.Bulk.ImportPersistenceUnitListener listener);

         void ImportEntity(string entityName, Net.Vpc.Upa.PersistenceUnit source, bool deleteExisting, Net.Vpc.Upa.Bulk.ImportPersistenceUnitListener listener);

         void ImportEntities(Net.Vpc.Upa.PersistenceUnit source, Net.Vpc.Upa.Filters.EntityFilter filter, bool deleteExisting, Net.Vpc.Upa.Bulk.ImportPersistenceUnitListener listener);
    }
}
