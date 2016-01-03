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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultImportExportManager : Net.Vpc.Upa.Bulk.ImportExportManager {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.ObjectFactory factory;

        private Net.Vpc.Upa.Bulk.ParseFormatManager parseFormatManager;

        public virtual Net.Vpc.Upa.ObjectFactory GetFactory() {
            return factory == null ? persistenceUnit.GetFactory() : factory;
        }

        public virtual void SetFactory(Net.Vpc.Upa.ObjectFactory factory) {
            this.factory = factory;
            if (parseFormatManager != null) {
                parseFormatManager.SetFactory(GetFactory());
            }
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthParser CreateTextFixedWidthParser(object source) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateTextFixedWidthParser(source);
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVParser CreateTextCSVParser(object source) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateTextCSVParser(source);
        }

        public virtual Net.Vpc.Upa.Bulk.SheetParser CreateSheetParser(object source) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateSheetParser(source);
        }

        public virtual Net.Vpc.Upa.Bulk.XmlParser CreateXmlParser(object source) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateXmlParser(source);
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthFormatter CreateTextFixedWidthFormatter(object target) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateTextFixedWidthFormatter(target);
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter CreateTextCSVFormatter(object target) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateTextCSVFormatter(target);
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter CreateSheetFormatter(object target) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateSheetFormatter(target);
        }

        public virtual Net.Vpc.Upa.Bulk.XmlFormatter CreateXmlFormatter(object target) /* throws System.IO.IOException */  {
            return parseFormatManager.CreateXmlFormatter(target);
        }

        public virtual void ImportEntity(System.Type entityType, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config) {
            ImportEntity(persistenceUnit.GetEntity(entityType), dataIterator, config);
        }

        public virtual void ImportEntity(string entityName, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config) {
            ImportEntity(persistenceUnit.GetEntity(entityName), dataIterator, config);
        }

        public virtual void ImportEntity(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Bulk.DataReader dataIterator, Net.Vpc.Upa.Bulk.ImportDataConfig config) {
            Net.Vpc.Upa.Bulk.ImportDataManager m = GetFactory().CreateObject<Net.Vpc.Upa.Bulk.ImportDataManager>(typeof(Net.Vpc.Upa.Bulk.ImportDataManager));
            m.ImportEntity(entity, dataIterator, config);
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void SetPersistenceUnit(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            parseFormatManager = persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.Bulk.ParseFormatManager>(typeof(Net.Vpc.Upa.Bulk.ParseFormatManager));
            parseFormatManager.SetFactory(GetFactory());
        }
    }
}
