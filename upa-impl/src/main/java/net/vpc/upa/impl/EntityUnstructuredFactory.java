package net.vpc.upa.impl;

import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntityUnstructuredFactory extends AbstractEntityFactory {

    public EntityUnstructuredFactory() {
    }

    public Record createRecord() {
        return new DefaultRecord();
    }

    public <R> R createObject() {
        //double cast is needed in c#
        return (R) (Object)new DefaultRecord();
    }

    public <R> Record getRecord(R entity, boolean ignoreUnspecified) {
        //double cast is needed in c#
        return (Record) (Object)entity;
    }

    @Override
    public <R> R getEntity(Record unstructuredRecord) {
        return (R) unstructuredRecord;
    }

    public void setProperty(Object entityObject, String property, Object value) throws UPAException {
        ((Record) entityObject).setObject(property, value);
    }

    public Object getProperty(Object entityObject, String property) throws UPAException {
        return ((Record) entityObject).getObject(property);
    }

}
