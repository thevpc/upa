package net.vpc.upa.impl;

import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface EntityFactory {

    public Record createRecord();

    public <R> R createObject();

    public <R> Record getRecord(R entity);

    public <R> Record getRecord(R entity, boolean ignoreUnspecified);

    public <R> R getEntity(Record unstructuredRecord);

    public void setProperty(Object entityObject, String property, Object value) throws UPAException;

    public Object getProperty(Object entityObject, String property) throws UPAException;

}
