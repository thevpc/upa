package net.vpc.upa.impl;

import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import net.vpc.upa.Properties;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/23/12 1:26 PM
 */
public class DefaultProperties extends AbstractProperties {

    private Map<String, Object> base = new HashMap<String, Object>();
    private PropertyChangeSupport propertyChangeSupport;
    private Properties parent;

    public DefaultProperties() {
        this(null);
    }

    public DefaultProperties(Properties parent) {
        propertyChangeSupport = new PropertyChangeSupport(this);
        this.parent = parent;
    }

    public boolean containsKey(String key) {
        if (base.containsKey(key)) {
            return true;
        }
        return parent != null && parent.containsKey(key);
    }

    public Properties getParent() {
        return parent;
    }

    public void setParent(Properties parent) {
        this.parent = parent;
    }

    //////////////////////////////////////
    @Override
    public <T> T getObject(String key) {
        if (parent == null || base.containsKey(key)) {
            return (T) base.get(key);
        }
        return parent.getObject(key);
    }

    @Override
    public <T> T getObject(String key, T value) {
        if (base.containsKey(key)) {
            return (T) base.get(key);
        } else {
            if (parent != null) {
                return parent.getObject(key, value);
            }
            return value;
        }
    }

    @Override
    public void setObject(String key, Object value) {
        base.put(key, value);
    }

    @Override
    public <T> T getSingleObject() {
        for (Object o : base.values()) {
            return (T) o;
        }
        if (parent != null) {
            return parent.getSingleObject();
        }
        return null;
    }

    //////////////////////////////////////
    @Override
    public boolean isSet(String key) {
        return base.containsKey(key) || (parent != null && parent.isSet(key));
    }

    @Override
    public void remove(String key) {
        base.remove(key);
    }

    @Override
    public Set<String> keySet() {
        if (parent == null) {
            return base.keySet();
        }
        HashSet<String> all = new HashSet<String>();
        all.addAll(base.keySet());
        all.addAll(parent.keySet());
        return all;
    }

    @Override
    public int size() {
        return keySet().size();
    }

    @Override
    public Map<String, Object> toMap() {
        if (parent == null) {
            return new HashMap<String, Object>(base);
        }
        Map<String, Object> r = new HashMap<String, Object>(parent.toMap());
        r.putAll(base);
        return r;
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

    @Override
    public String toString() {
        return toMap().toString();
    }

}
