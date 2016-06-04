package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public class EntityUnstructuredFactory extends AbstractEntityFactory {
    private Entity entity;
    public EntityUnstructuredFactory(Entity entity) {
        this.entity=entity;
    }

    public Record createRecord() {
        return new DefaultRecord();
    }

    public <R> R createObject() {
        //double cast is needed in c#
        return (R) (Object)new DefaultRecord();
    }

    public Record getRecord(Object object, boolean ignoreUnspecified) {
        return (Record) object;
    }

    @Override
    public <R> R getEntity(Record record) {
        return (R) record;
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
