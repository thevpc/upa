package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.*;
import net.thevpc.upa.persistence.*;

import net.thevpc.upa.persistence.*;
import net.thevpc.upa.types.DataType;

import java.beans.PropertyChangeListener;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.Set;

public class ExecutionContextAdapter implements EntityExecutionContext {

    private final EntityExecutionContext adaptee;

    public ExecutionContextAdapter(EntityExecutionContext adaptee) {
        this.adaptee = adaptee;
    }

    public PersistenceUnit getPersistenceUnit() {
        return adaptee.getPersistenceUnit();
    }

    public UConnection getConnection() {
        return adaptee.getConnection();
    }

    public Session getSession() {
        return adaptee.getSession();
    }

    public PersistenceStore getPersistenceStore() {
        return adaptee.getPersistenceStore();
    }

    public ContextOperation getOperation() {
        return adaptee.getOperation();
    }

    public Document getUpdateDocument() {
        return adaptee.getUpdateDocument();
    }

    public UpdateQuery getUpdateQuery() {
        return adaptee.getUpdateQuery();
    }

    public Entity getEntity() {
        return adaptee.getEntity();
    }

    public Map<String, Object> getValues() {
        return adaptee.getValues();
    }

    public Map<String, Object> getHints() {
        return adaptee.getHints();
    }

    public Object getHint(String hintName) {
        return adaptee.getHint(hintName);
    }

    public Object getHint(String hintName, Object defaultValue) {
        return adaptee.getHint(hintName, defaultValue);
    }

    public EntityExecutionContext resetHints() {
        return adaptee.resetHints();
    }

    public EntityExecutionContext setHint(String name, Object value) {
        return adaptee.setHint(name, value);
    }

    public EntityExecutionContext setHints(Map<String, Object> hints) {
        return adaptee.setHints(hints);
    }

    public EntityOperationManager getEntityOperationManager() {
        return adaptee.getEntityOperationManager();
    }

    public void addGeneratedValue(String name, DataType type) {
        adaptee.addGeneratedValue(name, type);
    }

    public void removeGeneratedValue(Parameter parameter) {
        adaptee.removeGeneratedValue(parameter);
    }

    public List<Parameter> getGeneratedValues() {
        return adaptee.getGeneratedValues();
    }

    public Parameter getGeneratedValue(String name) {
        return adaptee.getGeneratedValue(name);
    }

    public boolean containsKey(String key) {
        return adaptee.containsKey(key);
    }

    public <T> T getObject(String key) {
        return adaptee.getObject(key);
    }

    public <T> T getObject(String key, T defaultValue) {
        return adaptee.getObject(key, defaultValue);
    }

    public void setObject(String key, Object value) {
        adaptee.setObject(key, value);
    }

    public <T> T getSingleObject() {
        return adaptee.getSingleObject();
    }

    public int getInt(String key) {
        return adaptee.getInt(key);
    }

    public int getInt(String key, int value) {
        return adaptee.getInt(key, value);
    }

    public void setInt(String key, int value) {
        adaptee.setInt(key, value);
    }

    public int getSingleInt() {
        return adaptee.getSingleInt();
    }

    public long getLong(String key) {
        return adaptee.getLong(key);
    }

    public long getLong(String key, long value) {
        return adaptee.getLong(key, value);
    }

    public void setLong(String key, long value) {
        adaptee.setLong(key, value);
    }

    public long getSingleLong() {
        return adaptee.getSingleLong();
    }

    public double getDouble(String key) {
        return adaptee.getDouble(key);
    }

    public double getDouble(String key, double value) {
        return adaptee.getDouble(key, value);
    }

    public void setDouble(String key, double value) {
        adaptee.setDouble(key, value);
    }

    public double getSingleDouble() {
        return adaptee.getSingleDouble();
    }

    public float getFloat(String key) {
        return adaptee.getFloat(key);
    }

    public float getFloat(String key, float value) {
        return adaptee.getFloat(key, value);
    }

    public void setFloat(String key, float value) {
        adaptee.setFloat(key, value);
    }

    public float getSingleFloat() {
        return adaptee.getSingleFloat();
    }

    public Date getDate(String key) {
        return adaptee.getDate(key);
    }

    public Date getDate(String key, Date value) {
        return adaptee.getDate(key, value);
    }

    public void setDate(String key, Date value) {
        adaptee.setDate(key, value);
    }

    public Date getSingleDate() {
        return adaptee.getSingleDate();
    }

    public String getString(String key) {
        return adaptee.getString(key);
    }

    public String getString(String key, String value) {
        return adaptee.getString(key, value);
    }

    public void setString(String key, String value) {
        adaptee.setString(key, value);
    }

    public String getSingleString() {
        return adaptee.getSingleString();
    }

    public boolean getBoolean(String key) {
        return adaptee.getBoolean(key);
    }

    public boolean getBoolean(String key, boolean value) {
        return adaptee.getBoolean(key, value);
    }

    public void setBoolean(String key, boolean value) {
        adaptee.setBoolean(key, value);
    }

    public boolean getSingleBoolean() {
        return adaptee.getSingleBoolean();
    }

    public void setNumber(String key, Number value) {
        adaptee.setNumber(key, value);
    }

    public Number getNumber(String key, Number value) {
        return adaptee.getNumber(key, value);
    }

    public Number getNumber(String key) {
        return adaptee.getNumber(key);
    }

    public Number getSingleNumber() {
        return adaptee.getSingleNumber();
    }

    public void setBigDecimal(String key, BigDecimal value) {
        adaptee.setBigDecimal(key, value);
    }

    public BigDecimal getBigDecimal(String key, BigDecimal value) {
        return adaptee.getBigDecimal(key, value);
    }

    public BigDecimal getBigDecimal(String key) {
        return adaptee.getBigDecimal(key);
    }

    public BigDecimal getSingleBigDecimal() {
        return adaptee.getSingleBigDecimal();
    }

    public void setBigInteger(String key, BigInteger value) {
        adaptee.setBigInteger(key, value);
    }

    public BigInteger getBigInteger(String key, BigInteger value) {
        return adaptee.getBigInteger(key, value);
    }

    public BigInteger getBigInteger(String key) {
        return adaptee.getBigInteger(key);
    }

    public BigInteger getSingleBigInteger() {
        return adaptee.getSingleBigInteger();
    }

    public Set<String> keySet() {
        return adaptee.keySet();
    }

    public int size() {
        return adaptee.size();
    }

    public Map<String, Object> toMap() {
        return adaptee.toMap();
    }

    public void setAll(Map<String, Object> other, String... keys) {
        adaptee.setAll(other, keys);
    }

    public void setAll(Properties other, String... keys) {
        adaptee.setAll(other, keys);
    }

    public boolean isSet(String key) {
        return adaptee.isSet(key);
    }

    public void remove(String key) {
        adaptee.remove(key);
    }

    public void addPropertyChangeListener(String key, PropertyChangeListener listener) {
        adaptee.addPropertyChangeListener(key, listener);
    }

    public void removePropertyChangeListener(String key, PropertyChangeListener listener) {
        adaptee.removePropertyChangeListener(key, listener);
    }

    public void addPropertyChangeListener(PropertyChangeListener listener) {
        adaptee.addPropertyChangeListener(listener);
    }

    public void removePropertyChangeListener(PropertyChangeListener listener) {
        adaptee.removePropertyChangeListener(listener);
    }

    protected EntityExecutionContext getAdaptee() {
        return adaptee;
    }
}
