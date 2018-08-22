/**
 * ====================================================================
 * UPA (Unstructured Persistence API)
 * Yet another ORM Framework
 * ++++++++++++++++++++++++++++++++++
 * Unstructured Persistence API, referred to as UPA, is a genuine effort
 * to raise programming language frameworks managing relational data in
 * applications using Java Platform, Standard Edition and Java Platform,
 * Enterprise Edition and Dot Net Framework equally to the next level of
 * handling ORM for mutable data structures. UPA is intended to provide
 * a solid reflection mechanisms to the mapped data structures while
 * affording to make changes at runtime of those data structures.
 * Besides, UPA has learned considerably of the leading ORM
 * (JPA, Hibernate/NHibernate, MyBatis and Entity Framework to name a few)
 * failures to satisfy very common even known to be trivial requirement in
 * enterprise applications.
 * <p>
 * Copyright (C) 2014-2015 Taha BEN SALAH
 * <p>
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 * <p>
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 * <p>
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import net.vpc.upa.DataTypeInfo;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UnexpectedException;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@PortabilityHint(target = "C#", name = "partial")
public abstract class DefaultDataType implements DataType {
    //    private DataTypeView null_dataTypeView;

    private final static Map<Class, Object> NULLABLE_DEFAULT_VALUES = new HashMap<Class, Object>();
    private final static Map<Class, Object> NON_NULLABLE_DEFAULT_VALUES = new HashMap<Class, Object>();

    static {
        NULLABLE_DEFAULT_VALUES.put(Short.TYPE, (short) 0);
        NULLABLE_DEFAULT_VALUES.put(Long.TYPE, 0L);
        NULLABLE_DEFAULT_VALUES.put(Integer.TYPE, 0);
        NULLABLE_DEFAULT_VALUES.put(Double.TYPE, 0.0);
        NULLABLE_DEFAULT_VALUES.put(Float.TYPE, 0.0f);
        NULLABLE_DEFAULT_VALUES.put(Byte.TYPE, (byte) 0);
        NULLABLE_DEFAULT_VALUES.put(Character.TYPE, (char) 0);

        NON_NULLABLE_DEFAULT_VALUES.put(Short.TYPE, (short) 0);
        NON_NULLABLE_DEFAULT_VALUES.put(Long.TYPE, 0L);
        NON_NULLABLE_DEFAULT_VALUES.put(Integer.TYPE, 0);
        NON_NULLABLE_DEFAULT_VALUES.put(Double.TYPE, 0.0);
        NON_NULLABLE_DEFAULT_VALUES.put(Float.TYPE, 0.0f);
        NON_NULLABLE_DEFAULT_VALUES.put(Byte.TYPE, (byte) 0);
        NON_NULLABLE_DEFAULT_VALUES.put(Character.TYPE, (char) 0);

        NON_NULLABLE_DEFAULT_VALUES.put(Short.class, (short) 0);
        NON_NULLABLE_DEFAULT_VALUES.put(Long.class, 0L);
        NON_NULLABLE_DEFAULT_VALUES.put(Integer.class, 0);
        NON_NULLABLE_DEFAULT_VALUES.put(Double.class, 0.0);
        NON_NULLABLE_DEFAULT_VALUES.put(Float.class, 0.0f);
        NON_NULLABLE_DEFAULT_VALUES.put(Byte.class, (byte) 0);
        NON_NULLABLE_DEFAULT_VALUES.put(Character.class, (char) 0);
    }

    public String unitName;
    public String name;
    protected boolean nullable;
    protected Properties properties;
    protected Object defaultValue;
    protected Object defaultUnspecifiedValue;
    protected boolean defaultValueUserDefined;
    protected boolean defaultUnspecifiedValueUserDefined;
    protected Class platformType;
    protected int scale;
    protected int precision;
    protected List<TypeValueValidator> valueValidators = new ArrayList<TypeValueValidator>(1);
    protected List<TypeValueRewriter> valueRewriters = new ArrayList<TypeValueRewriter>(1);

    public DefaultDataType(String name, Class platformType) {
        this(name, platformType, 0, 0, false);
    }

    public DefaultDataType(String name, Class platformType, boolean nullable) {
        this(name, platformType, 0, 0, nullable);
    }

    public DefaultDataType(String name, Class platformType, int scale, int precision, boolean nullable) {
        this.name = name;
        this.nullable = nullable;
        this.platformType = platformType;
        this.scale = scale;
        this.precision = precision;
        reevaluateCachedValues();
    }

    protected void reevaluateCachedValues(){
        if(!this.defaultValueUserDefined) {
            this.defaultValue = nullable ? NULLABLE_DEFAULT_VALUES.get(platformType) : NON_NULLABLE_DEFAULT_VALUES.get(platformType);
        }
        if(!this.defaultUnspecifiedValueUserDefined) {
            this.defaultUnspecifiedValue = nullable ? null : NULLABLE_DEFAULT_VALUES.get(platformType);
        }
    }

    @Override
    public Object getDefaultUnspecifiedValue() {
        return defaultUnspecifiedValue;
    }

    @Override
    public void setDefaultUnspecifiedValue(Object defaultUnspecifiedValue) {
        this.defaultUnspecifiedValue = defaultUnspecifiedValue;
        this.defaultUnspecifiedValueUserDefined = true;
    }

    @Override
    public Object getDefaultValue() {
        return defaultValue;
    }

    @Override
    public void setDefaultValue(Object defaultValue) {
        this.defaultValue = defaultValue;
        this.defaultValueUserDefined = true;
    }

    @Override
    public boolean isNullable() {
        return nullable;
    }

    @Override
    public void setNullable(boolean enable) {
        nullable = enable;
        reevaluateCachedValues();
    }

    @Override
    public Class getPlatformType() {
        return platformType;
    }

    @Override
    public int getScale() {
        return scale;
    }

    @Override
    public int getPrecision() {
        return precision;
    }

    @Override
    public Object rewrite(Object value, String name, String description) throws ConstraintsException {
        for (TypeValueRewriter typeValidator : valueRewriters) {
            value = typeValidator.rewriteValue(value, name, description, this);
        }
        return value;
    }

    @Override
//    @PortabilityHint(target = "C#", name = "virtual")
    public void check(Object value, String name, String description) throws ConstraintsException {
        if (value == null && !isNullable()) {
            throw new ConstraintsException("IllegalNull", name, description, null);
        }
        for (TypeValueValidator typeValueValidator : valueValidators) {
            typeValueValidator.validateValue(value, name, description, this);
        }
    }

    @Override
    public DataType copy() {
        try {
            DefaultDataType cloned = (DefaultDataType) super.clone();
            cloned.valueValidators = new ArrayList<TypeValueValidator>(valueValidators);
            cloned.valueRewriters = new ArrayList<TypeValueRewriter>(valueRewriters);
            return cloned;
        } catch (Exception ex) {
            throw new UnexpectedException("Clone Not Supported", ex);
        }
    }

    @Override
    public List<TypeValueValidator> getValueValidators() {
        return new ArrayList<TypeValueValidator>(valueValidators);
    }

    @Override
    public DataType addValueValidator(TypeValueValidator validator) {
        valueValidators.add(validator);
        return this;
    }

    @Override
    public DataType removeValueValidator(TypeValueValidator validator) {
        valueValidators.remove(validator);
        return this;
    }

    @Override
    public DataType addValueRewriter(TypeValueRewriter rewriter) {
        valueRewriters.add(rewriter);
        return this;
    }

    @Override
    public DataType removeValueReWriter(TypeValueRewriter rewriter) {
        valueRewriters.remove(rewriter);
        return this;
    }

    @Override
    public List<TypeValueRewriter> getValueRewriters() {
        return new ArrayList<TypeValueRewriter>(valueRewriters);
    }

    @Override
    public String getUnitName() {
        return unitName;
    }

    @Override
    public DataType setUnitName(String unitName) {
        this.unitName = unitName;
        return this;
    }

    @Override
    public boolean isAssignableFrom(DataType type) {
        return this.getClass().isAssignableFrom(type.getClass());
    }

    @Override
    public boolean isInstance(Object object) {
        if (object == null) {
            return true;
        }
        return isAssignableFrom(DataTypeFactory.forPlatformType(object.getClass()));
    }

    @Override
    public void cast(DataType type) {
        if (!isAssignableFrom(type)) {
            throw new ClassCastException("Expected an expression of type " + this + " but got " + type);
        }
    }

    @Override
    @PortabilityHint(target = "C#", name = "virtual")
    public Object convert(Object value) {
        return value;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public void setName(String name) {
        this.name = name;
    }

    @Override
    public Properties getProperties() {
        return properties;
    }

    @Override
    public void setProperties(Properties properties) {
        this.properties = properties;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        DefaultDataType that = (DefaultDataType) o;

        if (nullable != that.nullable) return false;
        if (defaultValueUserDefined != that.defaultValueUserDefined) return false;
        if (defaultUnspecifiedValueUserDefined != that.defaultUnspecifiedValueUserDefined) return false;
        if (scale != that.scale) return false;
        if (precision != that.precision) return false;
        if (unitName != null ? !unitName.equals(that.unitName) : that.unitName != null) return false;
        if (name != null ? !name.equals(that.name) : that.name != null) return false;
        if (properties != null ? !properties.equals(that.properties) : that.properties != null) return false;
        if (defaultValue != null ? !defaultValue.equals(that.defaultValue) : that.defaultValue != null) return false;
        if (defaultUnspecifiedValue != null ? !defaultUnspecifiedValue.equals(that.defaultUnspecifiedValue) : that.defaultUnspecifiedValue != null)
            return false;
        if (platformType != null ? !platformType.equals(that.platformType) : that.platformType != null) return false;
        if (valueValidators != null ? !valueValidators.equals(that.valueValidators) : that.valueValidators != null)
            return false;
        return valueRewriters != null ? valueRewriters.equals(that.valueRewriters) : that.valueRewriters == null;
    }

    @Override
    public int hashCode() {
        int result = unitName != null ? unitName.hashCode() : 0;
        result = 31 * result + (name != null ? name.hashCode() : 0);
        result = 31 * result + (nullable ? 1 : 0);
        result = 31 * result + (properties != null ? properties.hashCode() : 0);
        result = 31 * result + (defaultValue != null ? defaultValue.hashCode() : 0);
        result = 31 * result + (defaultUnspecifiedValue != null ? defaultUnspecifiedValue.hashCode() : 0);
        result = 31 * result + (defaultValueUserDefined ? 1 : 0);
        result = 31 * result + (defaultUnspecifiedValueUserDefined ? 1 : 0);
        result = 31 * result + (platformType != null ? platformType.hashCode() : 0);
        result = 31 * result + scale;
        result = 31 * result + precision;
        result = 31 * result + (valueValidators != null ? valueValidators.hashCode() : 0);
        result = 31 * result + (valueRewriters != null ? valueRewriters.hashCode() : 0);
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = new DataTypeInfo();
        d.setName(getName());
        d.setTypeName(getClass().getName());
        d.setNullable(isNullable());
        d.setPlatformType(getPlatformType().getName());
        d.setUnitName(getUnitName());
        Map<String,String> p=new HashMap<String,String>();
        d.setProperties(p);
        return d;
    }
}
