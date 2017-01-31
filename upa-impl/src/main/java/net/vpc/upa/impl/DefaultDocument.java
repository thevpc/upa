package net.vpc.upa.impl;

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
    private Map<String, Object> base = new HashMap<String, Object>();
    private PropertyChangeSupport propertyChangeSupport;

    public DefaultDocument() {
        propertyChangeSupport = new PropertyChangeSupport(this);
    }

    //////////////////////////////////////

    @Override
    public <T> T getObject(String key) {
        return (T) base.get(key);
    }

    @Override
    public void setObject(String key, Object value) {
        setUpdated(key);
        Object oldValue = base.put(key, value);
        fireChange(key, oldValue, value);
    }

    @Override
    public <T> T getSingleResult() {
        for (Object o : base.values()) {
            return (T) o;
        }
        return null;
    }


    //////////////////////////////////////

    @Override
    public boolean isSet(String key) {
        return base.containsKey(key);
    }

    @Override
    public void remove(String key) {
        base.remove(key);
    }

    @Override
    public boolean retainAll(Set<String> keys) {
        boolean modified = false;
        for (String s : new HashSet<String>(base.keySet())) {
            if (!keys.contains(s)) {
                base.remove(s);
                modified = true;
            }
        }
        return modified;
    }

    @Override
    public Set<String> keySet() {
        return base.keySet();
    }

    @Override
    public int size() {
        return base.size();
    }


    @Override
    public Map<String, Object> toMap() {
        return new HashMap<String, Object>(base);
    }


    @Override
    public void addPropertyChangeListener(String key, PropertyChangeListener listener) {
        propertyChangeSupport.addPropertyChangeListener(key, listener);
    }

    @Override
    public void removePropertyChangeListener(String key, PropertyChangeListener listener) {
        propertyChangeSupport.removePropertyChangeListener(key, listener);
    }

    @Override
    public void addPropertyChangeListener(PropertyChangeListener listener) {
        propertyChangeSupport.addPropertyChangeListener(listener);
    }

    @Override
    public void removePropertyChangeListener(PropertyChangeListener listener) {
        propertyChangeSupport.removePropertyChangeListener(listener);
    }

    protected void fireChange(String property, Object oldVal, Object newVal) {
        propertyChangeSupport.firePropertyChange(property, oldVal, newVal);
    }
}
