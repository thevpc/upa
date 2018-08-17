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
import net.vpc.upa.Properties;

import java.util.List;

/**
 * Created by vpc on 6/17/16.
 */
public interface DataType extends Cloneable {
    Object getDefaultUnspecifiedValue();

    void setDefaultUnspecifiedValue(Object defaultUnspecifiedValue);

    Object getDefaultValue();

    void setDefaultValue(Object defaultValue);

    boolean isNullable();

    void setNullable(boolean enable);

    Class getPlatformType();

    int getScale();

    int getPrecision();

    Object rewrite(Object value, String name, String description) throws ConstraintsException;

    void check(Object value, String name, String description) throws ConstraintsException;

    Object copy();

    List<TypeValueValidator> getValueValidators();

    DataType addValueValidator(TypeValueValidator validator);

    DataType removeValueValidator(TypeValueValidator validator);

    DataType addValueRewriter(TypeValueRewriter rewriter);

    DataType removeValueReWriter(TypeValueRewriter rewriter);

    List<TypeValueRewriter> getValueRewriters();

    String getUnitName();

    DataType setUnitName(String unitName);

    boolean isAssignableFrom(DataType type);

    boolean isInstance(Object object);

    void cast(DataType type);

    Object convert(Object value);

    String getName();

    void setName(String name);

    Properties getProperties();

    void setProperties(Properties properties);

    DataTypeInfo getInfo();
}
