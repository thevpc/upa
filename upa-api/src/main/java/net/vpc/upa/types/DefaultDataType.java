/**
 * ==================================================================== 
 * UPA (Unstructured Persistence API)
 *    Yet another ORM Framework
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
 *
 * Copyright (C) 2014-2015 Taha BEN SALAH
 *
 * This program is free software; you can redistribute it and/or modify it under
 * the terms of the GNU General Public License as published by the Free Software
 * Foundation; either version 2 of the License, or (at your option) any later
 * version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 51
 * Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * ====================================================================
 */
package net.vpc.upa.types;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.Properties;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@PortabilityHint(target = "C#", name = "partial")
public abstract class DefaultDataType implements DataType {
    //    private DataTypeView null_dataTypeView;

    public String unitName;
    public String name;
    protected boolean nullable;
    protected Properties properties;
    protected Object defaultNonNullValue;
    protected Object defaultValue;
    protected Object defaultUnspecifiedValue;
    protected Class platformType;
    protected int scale;
    protected int precision;
    protected List<TypeValueValidator> valueValidators = new ArrayList<TypeValueValidator>();
    protected List<TypeValueRewriter> valueRewriters = new ArrayList<TypeValueRewriter>();
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
        this.defaultValue = nullable ? NULLABLE_DEFAULT_VALUES.get(platformType) : NON_NULLABLE_DEFAULT_VALUES.get(platformType);
        this.defaultUnspecifiedValue = NULLABLE_DEFAULT_VALUES.get(platformType);
        this.defaultNonNullValue = this.defaultValue;
    }

    @Override
    public Object getDefaultUnspecifiedValue() {
        return defaultUnspecifiedValue;
    }

    @Override
    public void setDefaultUnspecifiedValue(Object defaultUnspecifiedValue) {
        this.defaultUnspecifiedValue = defaultUnspecifiedValue;
    }

    @Override
    public Object getDefaultValue() {
        return defaultValue;
    }

    @Override
    public void setDefaultValue(Object defaultValue) {
        this.defaultValue = defaultValue;
    }

    @Override
    public Object getDefaultNonNullValue() {
        return defaultNonNullValue;
    }

    @Override
    public void setDefaultNonNullValue(Object defaultNonNullValue) {
        this.defaultNonNullValue = defaultNonNullValue;
    }

    @Override
    public boolean isNullable() {
        return nullable;
    }

    @Override
    public void setNullable(boolean enable) {
        nullable = enable;
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
    @PortabilityHint(target = "C#", name = "virtual")
    public void check(Object value, String name, String description) throws ConstraintsException {
        if (value == null && !isNullable()) {
            throw new ConstraintsException("IllegalNull", name, description, value);
        }
        for (TypeValueValidator typeValueValidator : valueValidators) {
            typeValueValidator.validateValue(value, name, description, this);
        }
    }

    @Override
    public Object clone() {
        try {
            DefaultDataType cloned = (DefaultDataType) super.clone();
            cloned.valueValidators = new ArrayList<TypeValueValidator>(valueValidators);
            cloned.valueRewriters = new ArrayList<TypeValueRewriter>(valueRewriters);
            return cloned;
        } catch (Exception e) {
            throw new RuntimeException(e.toString());
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
        return isAssignableFrom(TypesFactory.forPlatformType(object.getClass()));
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
}
