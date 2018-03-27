package net.vpc.upa.impl;

import net.vpc.upa.Properties;
import net.vpc.upa.PortabilityHint;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Arrays;
import java.util.Date;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import net.vpc.upa.impl.util.StringUtils;

/**
 * AbstractParameters is an abstract implementation of the Parameters interface
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/25/12 1:31 AM
 */
public abstract class AbstractProperties implements Properties {

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
        return getNumber(key,null).intValue();
    }

    @Override
    public int getInt(String key, int defaultValue) {
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof Number){
            return ((Number)value).intValue();
        }
        if(value instanceof String){
            return Integer.parseInt(String.valueOf(value));
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type int");
    }

    @Override
    public void setInt(String key, int value) {
        setObject(key, value);
    }

    @Override
    public int getSingleInt() {
        return getInt(getSinglePropertyName());
    }

    //////////////////////////////////////
    @Override
    public long getLong(String key) {
        return getNumber(key).longValue();
    }

    @Override
    public long getLong(String key, long defaultValue) {
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof Number){
            return ((Number)value).longValue();
        }
        if(value instanceof String){
            return Long.parseLong(String.valueOf(value));
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type long");
    }

    @Override
    public void setLong(String key, long value) {
        setObject(key, value);
    }

    @Override
    public long getSingleLong() {
        return getLong(getSinglePropertyName());
    }

    //////////////////////////////////////
    @Override
    public double getDouble(String key) {
        return getNumber(key,null).doubleValue();
    }

    @Override
    public double getDouble(String key, double defaultValue) {
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof Number){
            return ((Number)value).doubleValue();
        }
        if(value instanceof String){
            return Double.parseDouble(String.valueOf(value));
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type double");
    }

    @Override
    public void setDouble(String key, double value) {
        setObject(key, value);
    }

    @Override
    public double getSingleDouble() {
        return getDouble(getSinglePropertyName());
    }

    //////////////////////////////////////
    @Override
    public float getFloat(String key) {
        return getNumber(key,null).floatValue();
    }

    @Override
    public float getFloat(String key, float defaultValue) {
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof Number){
            return ((Number)value).floatValue();
        }
        if(value instanceof String){
            return Float.parseFloat(String.valueOf(value));
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type float");
    }

    @Override
    public void setFloat(String key, float value) {
        setObject(key, value);
    }

    @Override
    public float getSingleFloat() {
        return getFloat(getSinglePropertyName());
    }

    //////////////////////////////////////
    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal(String key) {
        return getBigDecimal(key,null);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getBigDecimal(String key, BigDecimal defaultValue) {
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof BigDecimal){
            return (BigDecimal) value;
        }
        if(value instanceof BigInteger){
            return new BigDecimal((BigInteger) value);
        }
        if(value instanceof String){
            return new BigDecimal(String.valueOf(value));
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type big decimal");
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void setBigDecimal(String key, BigDecimal value) {
        setObject(key, value);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public BigDecimal getSingleBigDecimal() {
        return getBigDecimal(getSinglePropertyName());
    }
    //////////////////////////////////////

    @Override
    public BigInteger getBigInteger(String key) {
        return getBigInteger(key,null);
    }

    @Override
    public BigInteger getBigInteger(String key, BigInteger defaultValue) {
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof BigInteger){
            return (BigInteger) value;
        }
        if(value instanceof String){
            return new BigInteger(String.valueOf(value));
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type big intege");
    }

    @Override
    public void setBigInteger(String key, BigInteger value) {
        setObject(key, value);
    }

    @Override
    public BigInteger getSingleBigInteger() {
        return getBigInteger(getSinglePropertyName());
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
        Object value = getObject(key);
        if(value==null){
            return defaultValue;
        }
        if(value instanceof Number){
            return (Number) value;
        }
        if(value instanceof String){
            if(((String) value).contains(".")){
                try{
                    return Double.parseDouble(String.valueOf(value));
                }catch(Exception ex){
                    return new BigDecimal(String.valueOf(value));
                }
            }
            try{
                try {
                    return Integer.parseInt(String.valueOf(value));
                }catch (Exception ex) {
                    return Double.parseDouble(String.valueOf(value));
                }
            }catch(Exception ex){
                return new BigDecimal(String.valueOf(value));
            }
        }
        throw new IllegalArgumentException("Property "+key+" was expected to be of type Number");
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public void setNumber(String key, Number value) {
        setObject(key, value);
    }

    @PortabilityHint(target = "C#", name = "suppress")
    @Override
    public Number getSingleNumber() {
        return getNumber(getSinglePropertyName());
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
        return getBoolean(getSinglePropertyName());
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
        return getString(getSinglePropertyName());
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
        return getDate(getSinglePropertyName());
    }

    //////////////////////////////////////
    @Override
    public void setAll(Properties other, String... keys) {
        setAll(other.toMap(), keys);
    }

    public abstract String getSinglePropertyName() ;


}
