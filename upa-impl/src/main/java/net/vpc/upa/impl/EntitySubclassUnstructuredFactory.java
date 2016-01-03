package net.vpc.upa.impl;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntitySubclassUnstructuredFactory extends AbstractEntityFactory {

    private Class recordType;
    private ObjectFactory objectFactory;

    public EntitySubclassUnstructuredFactory(Class recordType,ObjectFactory objectFactory) {
        this.recordType = recordType;
        this.objectFactory = objectFactory;
    }

    public Record createRecord() {
        return (Record) objectFactory.createObject(recordType);
    }

    public <R> R createObject() {
        return (R) createRecord();
    }

    public <R> Record getRecord(R entity, boolean ignoreUnspecified) {
        return (Record) entity;
    }

    @Override
    public <R> R getEntity(Record unstructuredRecord) {
        if (recordType.isInstance(unstructuredRecord)) {
            return (R) unstructuredRecord;
        } else {
            R ur = (R) createRecord();
            ((Record) ur).setAll(unstructuredRecord);
            return ur;
        }
    }

    public void setProperty(Object entityObject, String property, Object value) throws UPAException {
        ((Record) entityObject).setObject(property, value);
    }

    public Object getProperty(Object entityObject, String property) throws UPAException {
        return ((Record) entityObject).getObject(property);
    }
}
