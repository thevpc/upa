package net.vpc.upa.impl;

import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.ManyToOneType;

import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.util.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/23/12 1:26 PM
 */
public class BeanAdapterDocument extends AbstractDocument {
//    private Map<String,Object> base=new HashMap<String, Object>();

    private boolean ignoreUnspecified;
    private Object userObject;
    private Map<String, Object> extra;
    private Entity entityName;
    private PlatformBeanType nfo;
    private PropertyChangeSupport propertyChangeSupport;

    public BeanAdapterDocument(Object userObject, Entity entityName, PlatformBeanType nfo, boolean ignoreUnspecified) {
        this.userObject = userObject;
        this.entityName = entityName;
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
        if (((Object)y) == null && !nfo.containsProperty(key)  && extra != null) {
            y = (T) extra.get(key);
        }
        return y;
    }

    @Override
    public void setObject(String key, Object value) {
        setUpdated(key);
        Object oldValue = nfo.getProperty(userObject, key);
        if(value instanceof Document){
            DataType dataType = entityName.getField(key).getDataType();
            if(dataType instanceof ManyToOneType){
                value = ((ManyToOneType) dataType).getTargetEntity().getBuilder().documentToObject((Document) value);
            }
        }
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
        if (nfo.containsProperty(key)) {
            if (!ignoreUnspecified || !nfo.isDefaultValue(userObject, key)) {
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
        Set<String> keySet = nfo.getPropertyNames(userObject, includeDefaults);
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
        return entityName + toMap().toString();
    }

}
