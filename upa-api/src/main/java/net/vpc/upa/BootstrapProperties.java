package net.vpc.upa;


import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.*;

/**
 * AbstractParameters is an abstract implementation of the Parameters interface
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/25/12 1:31 AM
 */
class BootstrapProperties implements Properties {


    private Map<String, Object> base = new HashMap<String, Object>();
    private PropertyChangeSupport propertyChangeSupport;
    private Properties parent;

    public BootstrapProperties() {
        this(null);
    }

    public BootstrapProperties(Properties parent) {
        propertyChangeSupport = new PropertyChangeSupport(this);
        this.parent = parent;
    }

    @Override
    public void setAll(Map<String, Object> other, String... keys) {
        if (keys.length == 0) {
            for (Map.Entry<String, Object> entry : other.entrySet()) {
                setObject(entry.getKey(), entry.getValue());
            }
        } else {
            HashSet<String> accepted = new HashSet<String>(Arrays.asList(keys));
            for (String s : accepted) {
                if (other.containsKey(s)) {
                    setObject(s, other.get(s));
                }
            }
        }
    }

    //////////////////////////////////////
    @Override
    public int getInt(String key) {
        return ((Number) getObject(key)).intValue();
    }

    @Override
    public int getInt(String key, int defaultValue) {
        return ((Number) getObject(key, defaultValue)).intValue();
    }

    @Override
    public void setInt(String key, int value) {
        setObject(key, value);
    }

    @Override
    public int getSingleInt() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @Override
    public long getLong(String key) {
        return ((Number) getObject(key)).longValue();
    }

    @Override
    public long getLong(String key, long defaultValue) {
        Number object = getObject(key, defaultValue);
        return object.longValue();
    }

    @Override
    public void setLong(String key, long value) {
        setObject(key, value);
    }

    @Override
    public long getSingleLong() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @Override
    public double getDouble(String key) {
        return ((Number) getObject(key)).doubleValue();
    }

    @Override
    public double getDouble(String key, double defaultValue) {
        return ((Number) getObject(key, defaultValue)).doubleValue();
    }

    @Override
    public void setDouble(String key, double value) {
        setObject(key, value);
    }

    @Override
    public double getSingleDouble() {
        return ((Number) getSingleObject()).doubleValue();
    }

    //////////////////////////////////////
    @Override
    public float getFloat(String key) {
        return ((Number) getObject(key)).floatValue();
    }

    @Override
    public float getFloat(String key, float defaultValue) {
        return ((Number) getObject(key, defaultValue)).floatValue();
    }

    @Override
    public void setFloat(String key, float value) {
        setObject(key, value);
    }

    @Override
    public float getSingleFloat() {
        return ((Number) getSingleObject()).floatValue();
    }

    //////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal(String key) {
        return ((BigDecimal) getObject(key));
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal(String key, BigDecimal defaultValue) {
        return getObject(key, defaultValue);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void setBigDecimal(String key, BigDecimal value) {
        setObject(key, value);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getSingleBigDecimal() {
        return getSingleObject();
    }
    //////////////////////////////////////

    @Override
    public BigInteger getBigInteger(String key) {
        return getObject(key);
    }

    @Override
    public BigInteger getBigInteger(String key, BigInteger defaultValue) {
        return getObject(key, defaultValue);
    }

    @Override
    public void setBigInteger(String key, BigInteger value) {
        setObject(key, value);
    }

    @Override
    public BigInteger getSingleBigInteger() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public Number getNumber(String key) {
        return ((Number) getObject(key));
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public Number getNumber(String key, Number defaultValue) {
        return ((Number) getObject(key, defaultValue)).intValue();
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void setNumber(String key, Number value) {
        setObject(key, value);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public Number getSingleNumber() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @Override
    public boolean getBoolean(String key) {
        return getObject(key);
    }

    @Override
    public boolean getBoolean(String key, boolean defaultValue) {
        return getObject(key, defaultValue);
    }

    @Override
    public void setBoolean(String key, boolean value) {
        setObject(key, value);
    }

    @Override
    public boolean getSingleBoolean() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @Override
    public String getString(String key) {
        return ((String) getObject(key));
    }

    @Override
    public String getString(String key, String defaultValue) {
        return getObject(key, defaultValue);
    }

    @Override
    public void setString(String key, String value) {
        setObject(key, value);
    }

    @Override
    public String getSingleString() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @Override
    public Date getDate(String key) {
        return getObject(key);
    }

    @Override
    public Date getDate(String key, Date defaultValue) {
        return getObject(key, defaultValue);
    }

    @Override
    public void setDate(String key, Date value) {
        setObject(key, value);
    }

    @Override
    public Date getSingleDate() {
        return getSingleObject();
    }

    //////////////////////////////////////
    @Override
    public void setAll(Properties other, String... keys) {
        setAll(other.toMap(), keys);
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
