package net.thevpc.upa.impl;

import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/23/12 1:26 PM
 */
public class DefaultDocument extends AbstractDocument {

    private Map<String, Object> values = new HashMap<String, Object>();
    private transient PropertyChangeSupport propertyChangeSupport;

    public DefaultDocument() {
    }

    //////////////////////////////////////
    @Override
    public <T> T getObject(String key) {
        return (T) values.get(key);
    }

    @Override
    public void setObject(String key, Object value) {
        setUpdated(key);
        Object oldValue = values.put(key, value);
        fireChange(key, oldValue, value);
    }

    @Override
    public <T> T getSingleResult() {
        for (Object o : values.values()) {
            return (T) o;
        }
        return null;
    }

    //////////////////////////////////////
    @Override
    public boolean isSet(String key) {
        return values.containsKey(key);
    }

    @Override
    public void remove(String key) {
        values.remove(key);
    }

    @Override
    public boolean retainAll(Set<String> keys) {
        boolean modified = false;
        for (String s : new HashSet<String>(values.keySet())) {
            if (!keys.contains(s)) {
                values.remove(s);
                modified = true;
            }
        }
        return modified;
    }

    @Override
    public Set<String> keySet() {
        return values.keySet();
    }

    @Override
    public int size() {
        return values.size();
    }

    @Override
    public Map<String, Object> toMap() {
        return new HashMap<String, Object>(values);
    }

    @Override
    public Set<Map.Entry<String, Object>> entrySet() {
        return values.entrySet();
    }

    @Override
    public void addPropertyChangeListener(String key, PropertyChangeListener listener) {
        getPropertyChangeSupport().addPropertyChangeListener(key, listener);
    }

    @Override
    public void removePropertyChangeListener(String key, PropertyChangeListener listener) {
        getPropertyChangeSupport().removePropertyChangeListener(key, listener);
    }

    @Override
    public void addPropertyChangeListener(PropertyChangeListener listener) {
        getPropertyChangeSupport().addPropertyChangeListener(listener);
    }

    @Override
    public void removePropertyChangeListener(PropertyChangeListener listener) {
        getPropertyChangeSupport().removePropertyChangeListener(listener);
    }

    protected void fireChange(String property, Object oldVal, Object newVal) {
        if (propertyChangeSupport != null) {
            propertyChangeSupport.firePropertyChange(property, oldVal, newVal);
        }
    }

    protected PropertyChangeSupport getPropertyChangeSupport() {
        if (propertyChangeSupport == null) {
            propertyChangeSupport = new PropertyChangeSupport(this);
        }
        return propertyChangeSupport;
    }

}
