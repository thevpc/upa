package net.vpc.upa.impl;

import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;

import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/27/12 1:51 AM
 */
public interface EntityFactory {

    public Record createRecord();

    public <R> R createObject();

    public Record getRecord(Object object);

    public Record getRecord(Object object, boolean ignoreUnspecified);

    public Record getRecord(Object object, Set<String> fields, boolean ignoreUnspecified, boolean ensureIncludeIds);

    public <R> R getEntity(Record record);

    public void setProperty(Object object, String property, Object value) throws UPAException;

    public Object getProperty(Object object, String property) throws UPAException;

}
