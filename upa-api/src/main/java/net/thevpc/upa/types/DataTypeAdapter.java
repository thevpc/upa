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
package net.thevpc.upa.types;

import net.thevpc.upa.Properties;
import net.thevpc.upa.exceptions.UnexpectedException;
import net.thevpc.upa.DataTypeInfo;

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

    public DataType copy() {
        try {
            return (DataType) super.clone();
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

    @Override
    public DataTypeInfo getInfo() {
        return dataType.getInfo();
    }
}
