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
package net.thevpc.upa;

import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeTransformConfig;

import java.util.Map;

/**
 * Created by vpc on 6/9/17.
 */
public interface FieldBuilder {

    String getName();

    FieldBuilder setName(String name);

    String getPath();

    FieldBuilder setPath(String fieldPath);

    Object getDefaultObject();

    FieldBuilder setDefaultObject(Object defaultObject);

    Object getUnspecifiedObject();

    FieldBuilder setUnspecifiedObject(Object unspecifiedObject);

    DataType getDataType();

    FieldBuilder setDataType(DataType dataType);

    DataTypeTransformConfig[] getTypeTransform();

    FieldBuilder setTypeTransform(DataTypeTransformConfig[] typeTransform);

    Formula getPersistFormula();

    FieldBuilder setPersistFormula(String persistFormula);

    FieldBuilder setPersistFormula(Formula persistFormula);

    Formula getUpdateFormula();

    FieldBuilder setUpdateFormula(String updateFormula);

    FieldBuilder setUpdateFormula(Formula updateFormula);

    Formula getSelectFormula();

    FieldBuilder setSelectFormula(Formula selectFormula);

    FieldBuilder setSelectFormula(String selectFormula);

    FieldBuilder setLiveSelectFormula(String selectFormula);

    FieldBuilder setCompiledSelectFormula(String selectFormula);

    FieldBuilder setFormula(String formula);

    FieldBuilder setFormula(Formula formula);

    FieldBuilder setLiveSelectFormula(Formula selectFormula);

    FieldBuilder setCompiledSelectFormula(Formula selectFormula);

    int getPersistFormulaOrder();

    FieldBuilder setPersistFormulaOrder(int persistFormulaOrder);

    int getUpdateFormulaOrder();

    FieldBuilder setUpdateFormulaOrder(int updateFormulaOrder);

    FlagSet<UserFieldModifier> getModifiers();

    FieldBuilder setModifiers(FlagSet<UserFieldModifier> userModifiers);

    FieldBuilder addModifier(UserFieldModifier userModifiers);

    FieldBuilder removeModifier(UserFieldModifier userModifiers);

    FlagSet<UserFieldModifier> getExcludeModifiers();

    FieldBuilder setExcludeModifiers(FlagSet<UserFieldModifier> userExcludeModifiers);

    FieldBuilder addExcludeModifier(UserFieldModifier userModifiers);

    FieldBuilder removeExcludeModifier(UserFieldModifier userModifiers);

    FieldBuilder setAccessLevel(AccessLevel accessLevel);

    AccessLevel getPersistAccessLevel();

    FieldBuilder setPersistAccessLevel(AccessLevel persistAccessLevel);

    AccessLevel getUpdateAccessLevel();

    FieldBuilder setUpdateAccessLevel(AccessLevel updateAccessLevel);

    AccessLevel getReadAccessLevel();

    FieldBuilder setReadAccessLevel(AccessLevel readAccessLevel);

    FieldBuilder setProtectionLevel(ProtectionLevel protectionLevel);

    ProtectionLevel getPersistProtectionLevel();

    FieldBuilder setPersistProtectionLevel(ProtectionLevel persistProtectionLevel);

    ProtectionLevel getUpdateProtectionLevel();

    FieldBuilder setUpdateProtectionLevel(ProtectionLevel updateProtectionLevel);

    ProtectionLevel getReadProtectionLevel();

    FieldBuilder setReadProtectionLevel(ProtectionLevel readProtectionLevel);

    Map<String, Object> getFieldParams();

    FieldBuilder setFieldParams(Map<String, Object> fieldParams);

    PropertyAccessType getPropertyAccessType();

    FieldBuilder setPropertyAccessType(PropertyAccessType propertyAccessType);

    int getPosition();

    FieldBuilder setPosition(int position);

    FieldBuilder setPathPosition(int pathPosition);

    FieldBuilder setIgnoreExisting(boolean ignoreExisting);

    FieldDescriptor build();
}
