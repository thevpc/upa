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

         void ImportEntity(System.Type entityType, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config);

         void ImportEntity(string entityName, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config);
    }
}
