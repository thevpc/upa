package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;

import java.beans.PropertyChangeListener;
import java.util.Map;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/3/12 1:19 AM
 */
public class DefaultQualifiedRecord extends AbstractRecord implements QualifiedRecord {
    private Entity entity;
    private Record record;

    public DefaultQualifiedRecord(Entity entity) throws UPAException {
        this(entity, entity.getBuilder().createRecord());
    }

    public DefaultQualifiedRecord(Entity entity, Record record) {
        this.entity = entity;
        this.record = record;
    }

    public Entity getEntity() {
        return entity;
    }

    public Record getRecord() {
        return record;
    }

    public String getRecordName() {
        return getRecord().getObject(getEntity().getMainField().getName());
    }

    public Key getKey() throws UPAException {
        return getEntity().getBuilder().recordToKey(getRecord());
    }

    public void setRawId(Object... ids) throws UPAException {
        Record kr = getEntity().getBuilder().keyToRecord(getEntity().getBuilder().createKey(ids));
        getRecord().setAll(kr);
    }

    public void setIdentifier(Object value) throws UPAException {
        Record kr = getEntity().getBuilder().idToRecord(value);
        getRecord().setAll(kr);
    }

    public void setKey(Key key) throws UPAException {
        Record kr = getEntity().getBuilder().keyToRecord(key);
        getRecord().setAll(kr);
    }

    public Object getId() throws UPAException {
        return getEntity().getBuilder().recordToId(getRecord());
    }

    public Object[] getRawId() throws UPAException {
        return getKey().getValue();
    }

    @Override
    public void setObject(String key, Object value) {
        setUpdated(key);
        getRecord().setObject(key, value);
    }

    @Override
    public <T> T getSingleResult() {
        return getRecord().getSingleResult();
    }

    @Override
    public Set<String> keySet() {
        return getRecord().keySet();
    }

    @Override
    public int size() {
        return getRecord().size();
    }

    @Override
    public Map<String, Object> toMap() {
        return getRecord().toMap();
    }

    @Override
    public boolean isSet(String key) {
        return getRecord().isSet(key);
    }

    @Override
    public void remove(String key) {
        getRecord().remove(key);
    }

    @Override
    public void addPropertyChangeListener(String key, PropertyChangeListener listener) {
        getRecord().addPropertyChangeListener(key, listener);
    }

    @Override
    public void removePropertyChangeListener(String key, PropertyChangeListener listener) {
        getRecord().removePropertyChangeListener(key, listener);
    }

    @Override
    public void addPropertyChangeListener(PropertyChangeListener listener) {
        getRecord().addPropertyChangeListener(listener);
    }

    @Override
    public void removePropertyChangeListener(PropertyChangeListener listener) {
        getRecord().removePropertyChangeListener(listener);
    }

    @Override
    public <T> T getObject(String key) {
        return getRecord().getObject(key);
    }
}
