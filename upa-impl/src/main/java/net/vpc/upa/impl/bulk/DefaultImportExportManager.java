/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import java.io.IOException;
import net.vpc.upa.Entity;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.bulk.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultImportExportManager implements ImportExportManager {

    private PersistenceUnit persistenceUnit;
    private ObjectFactory factory;
    private ParseFormatManager parseFormatManager;

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

    public void importEntity(Class entityType, DataReader dataIterator, ImportDataConfig config) {
        importEntity(persistenceUnit.getEntity(entityType), dataIterator, config);
    }

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
}
