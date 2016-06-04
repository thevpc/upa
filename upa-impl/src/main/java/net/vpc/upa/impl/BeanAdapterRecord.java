package net.vpc.upa.impl;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.util.EntityBeanAdapter;

import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.util.*;
import net.vpc.upa.impl.util.EntityBeanAttribute;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/23/12 1:26 PM
 */
public class BeanAdapterRecord extends AbstractRecord {
//    private Map<String,Object> base=new HashMap<String, Object>();

    private boolean ignoreUnspecified;
    private Object userObject;
    private Map<String, Object> extra;
    private EntityBeanAdapter nfo;
    private PropertyChangeSupport propertyChangeSupport;

    public BeanAdapterRecord(Object userObject, EntityBeanAdapter nfo, boolean ignoreUnspecified) {
        this.userObject = userObject;
        this.nfo = nfo;
        this.ignoreUnspecified = ignoreUnspecified;
        propertyChangeSupport = new PropertyChangeSupport(this);
    }

    public Object userObject() {
        return this.userObject;
    }

//////////////////////////////////////
    @Override
    public <T> T getObject(String key) {
        T y = (T) nfo.getProperty(userObject, key);
        //in C# could not compare y == default(y)
        //so cast y to Object to do so
        if (((Object)y) == null && nfo.getAttrAdapter(key) == null && extra != null) {
            y = (T) extra.get(key);
        }
        return y;
    }

    @Override
    public void setObject(String key, Object value) {
        setUpdated(key);
        Object oldValue = nfo.getProperty(userObject, key);
        if (value instanceof Expression || !nfo.setProperty(userObject, key, value)) {
            // handle unstructured fields (non defined in the bean class)
            if (extra == null) {
                extra = new LinkedHashMap<String, Object>();
            }
            extra.put(key, value);
        }
        fireChange(key, oldValue, value);
    }

    @Override
    public <T> T getSingleResult() {
        for (Object o : toMap().values()) {
            return (T) o;
        }
        return null;
    }

    //////////////////////////////////////
    @Override
    public boolean isSet(String key) {
        EntityBeanAttribute f = nfo.getAttrAdapter(key);
        if (f != null) {
            if (!ignoreUnspecified || !f.isDefaultValue(userObject)) {
                return true;
            }
        }
        if (extra != null) {
            if (extra.containsKey(key)) {
                return true;
            }
        }
        return false;
    }

    @Override
    public void remove(String key) {
        nfo.resetToDefaultValue(userObject, key);
        if (extra != null) {
            extra.remove(key);
        }
    }

    @Override
    public Set<String> keySet() {
        Boolean includeDefaults = null;
        if (ignoreUnspecified) {
            includeDefaults = false;
        }
        Set<String> keySet = nfo.keySet(userObject, includeDefaults);
        if (extra != null && extra.size()>0) {
            keySet.addAll(extra.keySet());
        }
        return keySet;
    }

    @Override
    public int size() {
        return keySet().size();
    }

    @Override
    public Map<String, Object> toMap() {
        Boolean includeDefaults = null;
        if (ignoreUnspecified) {
            includeDefaults = false;
        }
        Map<String, Object> m = nfo.toMap(userObject, includeDefaults);
        if (extra != null && extra.size()>0) {
            m.putAll(extra);
        }
        return m;
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

    @Override
    public String toString() {
        return nfo.getEntity().getName() + toMap().toString();
    }

}
