/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import java.io.IOException;
import java.util.List;

import net.vpc.upa.*;
import net.vpc.upa.bulk.*;
import net.vpc.upa.filters.EntityFilter;
import net.vpc.upa.bulk.ImportPersistenceUnitListener;
import net.vpc.upa.filters.FieldFilter;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultImportExportManager implements ImportExportManager {

    private PersistenceUnit persistenceUnit;
    private ObjectFactory factory;
    private ParseFormatManager parseFormatManager;
    private PersistenceUnitImporter persistenceUnitImporter = new PersistenceUnitImporter();

    public ObjectFactory getFactory() {
        return factory == null ? persistenceUnit.getFactory() : factory;
    }

    public void setFactory(ObjectFactory factory) {
        this.factory = factory;
        if (parseFormatManager != null) {
            parseFormatManager.setFactory(getFactory());
        }
    }

    public TextFixedWidthParser createTextFixedWidthParser(Object source) throws IOException {
        return parseFormatManager.createTextFixedWidthParser(source);
    }

    public TextCSVParser createTextCSVParser(Object source) throws IOException {
        return parseFormatManager.createTextCSVParser(source);
    }

    public SheetParser createSheetParser(Object source) throws IOException {
        return parseFormatManager.createSheetParser(source);
    }

    public XmlParser createXmlParser(Object source) throws IOException {
        return parseFormatManager.createXmlParser(source);
    }

    public TextFixedWidthFormatter createTextFixedWidthFormatter(Object target) throws IOException {
        return parseFormatManager.createTextFixedWidthFormatter(target);
    }

    public TextCSVFormatter createTextCSVFormatter(Object target) throws IOException {
        return parseFormatManager.createTextCSVFormatter(target);
    }

    public SheetFormatter createSheetFormatter(Object target) throws IOException {
        return parseFormatManager.createSheetFormatter(target);
    }

    public XmlFormatter createXmlFormatter(Object target) throws IOException {
        return parseFormatManager.createXmlFormatter(target);
    }

//    public void importEntity(Class entityType, DataReader dataIterator, ImportDataConfig config) {
//        importEntity(persistenceUnit.getEntity(entityType), dataIterator, config);
//    }

    public void importEntity(String entityName, DataReader dataIterator, ImportDataConfig config) {
        importEntity(persistenceUnit.getEntity(entityName), dataIterator, config);
    }

    public void importEntity(Entity entity, DataReader dataIterator, ImportDataConfig config) {
        ImportDataManager m = getFactory().createObject(ImportDataManager.class);
        m.importEntity(entity, dataIterator, config);
    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public void setPersistenceUnit(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
        parseFormatManager = persistenceUnit.getFactory().createObject(ParseFormatManager.class);
        parseFormatManager.setFactory(getFactory());
    }

    public void importObjectById(String entityName, int sourceId, PersistenceUnit source, ImportPersistenceUnitListener listener) {
        persistenceUnitImporter.importObjectById(source, persistenceUnit, entityName, sourceId, listener);
    }

    public void importEntity(String entityName, PersistenceUnit source, boolean deleteExisting, ImportPersistenceUnitListener listener) {
        persistenceUnitImporter.importEntity(source, persistenceUnit, entityName, deleteExisting,listener);
    }

    public void importEntities(PersistenceUnit source, EntityFilter filter, boolean deleteExisting, ImportPersistenceUnitListener listener) {
        persistenceUnitImporter.importEntities(source, persistenceUnit, filter, deleteExisting,listener);
    }

    @Override
    public DataRowConverter createEntityConverter(final String entityName, final FieldFilter filter) {
        final PersistenceUnit persistenceUnit=this.persistenceUnit;
        return new EntityDataRowConverter(persistenceUnit.getEntity(entityName), filter);
    }

    private static class EntityDataRowConverter implements DataRowConverter {
        private DataColumn[] columns;
        private List<Field> fields;
        private Entity entity;

        public EntityDataRowConverter(Entity entity, FieldFilter filter) {
            this.entity=entity;
            fields = entity.getFields(filter);
            columns = new DataColumn[fields.size()];
            for (int i = 0; i < columns.length; i++) {
                Field field = fields.get(i);
                DataColumn cc = new DataColumn(i, field.getName());
                cc.setDataType(field.getDataType());
                //should call i18n
                cc.setTitle(field.getName());
                cc.setTitle(field.getName());
                columns[i] = cc;

            }
        }

        @Override
        public DataColumn[] getColumns() {
            return columns;
        }

        @Override
        public Object[] objectToRow(Object o) {
            Record record = entity.getBuilder().objectToRecord(o, false);
            Object[] vals=new Object[columns.length];
            for (int i = 0; i < vals.length; i++) {
                vals[i]=record.getObject(fields.get(i).getName());
            }
            return vals;
        }
    }
}
