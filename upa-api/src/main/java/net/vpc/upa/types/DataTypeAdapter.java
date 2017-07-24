package net.vpc.upa.types;

import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UnexpectedException;

import java.util.List;

/**
 * Created by vpc on 6/17/16.
 */
public class DataTypeAdapter implements DataType, Cloneable {
    private DataType dataType;

    public DataTypeAdapter(DataType dataType) {
        this.dataType = dataType;
    }

    public Object getDefaultUnspecifiedValue() {
        return dataType.getDefaultUnspecifiedValue();
    }

    public void setDefaultUnspecifiedValue(Object defaultUnspecifiedValue) {
        dataType.setDefaultUnspecifiedValue(defaultUnspecifiedValue);
    }

    public Object getDefaultValue() {
        return dataType.getDefaultValue();
    }

    public void setDefaultValue(Object defaultValue) {
        dataType.setDefaultValue(defaultValue);
    }

    public boolean isNullable() {
        return dataType.isNullable();
    }

    public void setNullable(boolean enable) {
        dataType.setNullable(enable);
    }

    public Class getPlatformType() {
        return dataType.getPlatformType();
    }

    public int getScale() {
        return dataType.getScale();
    }

    public int getPrecision() {
        return dataType.getPrecision();
    }

    public Object rewrite(Object value, String name, String description) throws ConstraintsException {
        return dataType.rewrite(value, name, description);
    }

    public void check(Object value, String name, String description) throws ConstraintsException {
        dataType.check(value, name, description);
    }

    public List<TypeValueValidator> getValueValidators() {
        return dataType.getValueValidators();
    }

    public DataType addValueValidator(TypeValueValidator validator) {
        return dataType.addValueValidator(validator);
    }

    public DataType removeValueValidator(TypeValueValidator validator) {
        return dataType.removeValueValidator(validator);
    }

    public DataType addValueRewriter(TypeValueRewriter rewriter) {
        return dataType.addValueRewriter(rewriter);
    }

    public DataType removeValueReWriter(TypeValueRewriter rewriter) {
        return dataType.removeValueReWriter(rewriter);
    }

    public List<TypeValueRewriter> getValueRewriters() {
        return dataType.getValueRewriters();
    }

    public String getUnitName() {
        return dataType.getUnitName();
    }

    public DataType setUnitName(String unitName) {
        return dataType.setUnitName(unitName);
    }

    public boolean isAssignableFrom(DataType type) {
        return dataType.isAssignableFrom(type);
    }

    public boolean isInstance(Object object) {
        return dataType.isInstance(object);
    }

    public void cast(DataType type) {
        dataType.cast(type);
    }

    public Object convert(Object value) {
        return dataType.convert(value);
    }

    public String getName() {
        return dataType.getName();
    }

    public void setName(String name) {
        dataType.setName(name);
    }

    public Properties getProperties() {
        return dataType.getProperties();
    }

    public void setProperties(Properties properties) {
        dataType.setProperties(properties);
    }

    public Object copy() {
        try {
            return super.clone();
        } catch (CloneNotSupportedException ex) {
            throw new UnexpectedException("Clone Not Supported", ex);
        }
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        DataTypeAdapter that = (DataTypeAdapter) o;

        return dataType != null ? dataType.equals(that.dataType) : that.dataType == null;
    }

    @Override
    public int hashCode() {
        return dataType != null ? dataType.hashCode() : 0;
    }
}
