package net.vpc.upa.impl;


import net.vpc.upa.Document;
import net.vpc.upa.PortabilityHint;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.*;

/**
 * AbstractDocument is an abstract implementation of the Document interface
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/25/12 1:31 AM
 */
public abstract class AbstractDocument implements Document {
    protected transient LinkedHashSet<String> updated;

    protected AbstractDocument() {
    }

    /**
     * reset all updated fields
     */
    public void resetUpdatedFields() {
        updated = null;
    }

    /**
     * return all updated fields
     * @return
     */
    public String[] getUpdatedFields() {
        return updated == null ? new String[0] : updated.toArray(new String[updated.size()]);
    }

    protected void setUpdated(String field) {
        if (updated == null) {
            updated = new LinkedHashSet<String>();
        }
        updated.add(field);
    }

    /**
     * {@inheritDoc}
     */
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

    /**
     * {@inheritDoc}
     */
    @Override
    public <T> T getObject(String key, T value) {
        if (isSet(key)) {
            return (T) getObject(key);
        } else {
            return value;
        }
    }

    @Override
    public Set<Map.Entry<String, Object>> entrySet() {
        return toMap().entrySet();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public int getInt(String key) {
        return ((Number) getObject(key)).intValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public int getInt(String key, int defaultValue) {
        Number object = getObject(key, defaultValue);
        return object.intValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setInt(String key, int value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public int getInt() {
        return getNumber().intValue();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public long getLong(String key) {
        return ((Number) getObject(key)).longValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public long getLong(String key, long defaultValue) {
        Number object = getObject(key, defaultValue);
        return object.longValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setLong(String key, long value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public long getLong() {
        return getNumber().longValue();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public double getDouble(String key) {
        return ((Number) getObject(key)).doubleValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public double getDouble(String key, double defaultValue) {
        Number object = getObject(key, defaultValue);
        if(object==null){
            return defaultValue;
        }
        return object.doubleValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setDouble(String key, double value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public double getDouble() {
        return getNumber().doubleValue();
    }


    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public float getFloat(String key) {
        return ((Number) getObject(key)).floatValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public float getFloat(String key, float defaultValue) {
        Number object = getObject(key, defaultValue);
        if(object==null){
            return defaultValue;
        }
        return object.floatValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setFloat(String key, float value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public float getFloat() {
        return getNumber().floatValue();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal(String key) {
        return ((BigDecimal) getObject(key));
    }

    /**
     * {@inheritDoc}
     */
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal(String key, BigDecimal defaultValue) {
        return getObject(key, defaultValue);
    }

    /**
     * {@inheritDoc}
     */
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void setBigDecimal(String key, BigDecimal value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal() {
        Number n = getNumber();
        return (n instanceof BigDecimal) ? (BigDecimal) n :
                new BigDecimal(n.toString());
    }
    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public BigInteger getBigInteger(String key) {
        return getObject(key);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public BigInteger getBigInteger(String key, BigInteger defaultValue) {
        return getObject(key, defaultValue);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setBigInteger(String key, BigInteger value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public BigInteger getBigInteger() {
        Number n = getNumber();
        return (n instanceof BigInteger) ? (BigInteger) n :
                new BigInteger(n.toString());
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public Number getNumber(String key) {
        return ((Number) getObject(key));
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public Number getNumber(String key, Number defaultValue) {
        Number object = getObject(key, defaultValue);
        if(object==null){
            return defaultValue;
        }
        return object.intValue();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setNumber(String key, Number value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public Number getNumber() {
        return getSingleResult();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean getBoolean(String key) {
        return getObject(key);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean getBoolean(String key, boolean defaultValue) {
        return getObject(key, defaultValue);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setBoolean(String key, boolean value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean getBoolean() {
        return getSingleResult();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public String getString(String key) {
        return ((String) getObject(key));
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String getString(String key, String defaultValue) {
        return getObject(key, defaultValue);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setString(String key, String value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String getString() {
        return getSingleResult();
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public Date getDate(String key) {
        return getObject(key);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public Date getDate(String key, Date defaultValue) {
        return getObject(key, defaultValue);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public void setDate(String key, Date value) {
        setObject(key, value);
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public Date getDate() {
        return getSingleResult();
    }

    //////////////////////////////////////


    @Override
    public void setAll(Document other) {
        if(other!=null) {
            setAll(other.toMap());
        }
    }

    @Override
    public void setAll(Map<String,Object> other) {
        if(other!=null) {
            for (Map.Entry<String, Object> entry : other.entrySet()) {
                setObject(entry.getKey(), entry.getValue());
            }
        }
    }


    /**
     * {@inheritDoc}
     */
    @Override
    public void setAll(Document other, String... keys) {
        if(other!=null) {
            setAll(other.toMap(), keys);
        }
    }

    //////////////////////////////////////

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean retainAll(Set<String> keys) {
        boolean modified = false;
        HashSet<String> k = new HashSet<String>(keySet());
        k.removeAll(keys);
        for (String s : k) {
            modified = true;
            remove(s);
        }
        return modified;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public boolean isEmpty() {
        return size() == 0;
    }

    /**
     * {@inheritDoc}
     */
    public boolean equals(Object o) {
        if (o == null) {
            return false;
        }
        if (o == this) {
            return true;
        }
        if (!(o instanceof Document)) {
            return false;
        }
        Document m = (Document) o;
        if (m.size() != size())
            return false;

        try {
            Iterator<Map.Entry<String,Object>> i = entrySet().iterator();
            while (i.hasNext()) {
                Map.Entry<String,Object> e = i.next();
                String key = e.getKey();
                Object value = e.getValue();
                if (value == null) {
                    if (!(m.get(key)==null && m.isSet(key))) {
                        return false;
                    }
                } else {
                    if (!value.equals(m.get(key))) {
                        return false;
                    }
                }
            }
        } catch (ClassCastException unused) {
            return false;
        } catch (NullPointerException unused) {
            return false;
        }
        return true;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public int hashCode() {
        return toMap().hashCode();
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        Iterator<Map.Entry<String,Object>> i = entrySet().iterator();
        if (! i.hasNext())
            return "{}";

        StringBuilder sb = new StringBuilder();
        sb.append('{');
        for (;;) {
            Map.Entry<String,Object> e = i.next();
            String key = e.getKey();
            Object value = e.getValue();
            sb.append(key);
            sb.append('=');
            sb.append(value == this ? "(this Document)" : value);
            if (! i.hasNext())
                return sb.append('}').toString();
            sb.append(',').append(' ');
        }
    }

    @Override
    public Document copy() {
        DefaultDocument r = new DefaultDocument();
        r.setAll(this);
        return r;
    }

    @Override
    public <T> T get(String key) {
        return getObject(key);
    }

    @Override
    public void set(String key, Object value) {
        setObject(key,value);
    }

}
