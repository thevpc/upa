package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntitySubclassUnstructuredFactory extends AbstractEntityFactory {

    private Entity entity;
    private Class recordType;
    private ObjectFactory objectFactory;

    public EntitySubclassUnstructuredFactory(Class recordType,ObjectFactory objectFactory,Entity entity) {
        this.recordType = recordType;
        this.objectFactory = objectFactory;
        this.entity = entity;
    }

    public Record createRecord() {
        return (Record) objectFactory.createObject(recordType);
    }

    public <R> R createObject() {
        return (R) createRecord();
    }

    public Record getRecord(Object object, boolean ignoreUnspecified) {
        return (Record) object;
    }


    @Override
    public <R> R getEntity(Record record) {
        if (recordType.isInstance(record)) {
            return (R) record;
        } else {
            R ur = (R) createRecord();
            ((Record) ur).setAll(record);
            return ur;
        }
    }

    public void setProperty(Object object, String property, Object value) throws UPAException {
        ((Record) object).setObject(property, value);
    }

    public Object getProperty(Object object, String property) throws UPAException {
        return ((Record) object).getObject(property);
    }

    @Override
    protected Entity getEntity() {
        return entity;
    }
}
