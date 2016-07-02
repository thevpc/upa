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

    //////////////////////////////////////
    public Object eval(String key) {
        if (key == null || !(key instanceof String)) {
            return key;
        }
        final List<String> vars = StringUtils.parseVarsList(key);
        switch (vars.size()) {
            case 0: {
                return key;
            }
            case 1: {
                String v = vars.get(0);
                Object ov = getObject(v);
                if (ov != null || !(ov instanceof String)) {
                    return ov;
                }
                return eval((String) v);
            }
            default: {
                String s=key;
                Set<String> vars2 = new LinkedHashSet<String>(vars);
                for (String v : vars2) {
                    Object ov = getObject(v);
                    if (ov == null) {
                        ov="";
                    }else if(!(ov instanceof String)){
                        ov=String.valueOf(ov);
                    }else{
                      ov=eval((String) v); 
                    }
                    s = s.replaceAll("\\$\\{" + v + "\\}", String.valueOf(ov));
                }
                return s;
            }
        }
    }

}
