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
import net.thevpc.upa.types.PlatformUtils;

import java.util.Map;

/**
 * @author taha.bensalah@gmail.com
 */
public class DefaultFieldDescriptor implements FieldDescriptor {

    private String name;
    private String path;
    private int pathPosition;
    private Object defaultObject;
    private Object unspecifiedObject;
    private DataType dataType;
    private DataTypeTransformConfig[] typeTransform;
    private Formula persistFormula;
    private Formula updateFormula;
    private Formula selectFormula;
    private int persistFormulaOrder;
    private int updateFormulaOrder;
    private FlagSet<UserFieldModifier> userModifiers;
    private FlagSet<UserFieldModifier> userExcludeModifiers;
    private AccessLevel persistAccessLevel = AccessLevel.DEFAULT;
    private AccessLevel updateAccessLevel = AccessLevel.DEFAULT;
    private AccessLevel readAccessLevel = AccessLevel.DEFAULT;
    private ProtectionLevel persistProtectionLevel = ProtectionLevel.DEFAULT;
    private ProtectionLevel updateProtectionLevel = ProtectionLevel.DEFAULT;
    private ProtectionLevel readProtectionLevel = ProtectionLevel.DEFAULT;
    private Map<String, Object> fieldParams;
    private PropertyAccessType propertyAccessType;
    private int position = -1;
    private boolean ignoreExisting;

    public DefaultFieldDescriptor() {
    }

    public DefaultFieldDescriptor(FieldDescriptor other) {
        copyFrom(other);
    }

    public void copyFrom(FieldDescriptor other) {
        setName(other.getName());
        setPath(other.getPath());
        setDefaultObject(other.getDefaultObject());
        setUnspecifiedObject(other.getUnspecifiedObject());
        setDataType(other.getDataType() == null ? null : other.getDataType().copy());
        setTypeTransform(PlatformUtils.copyOf(other.getTypeTransform()));
        setPersistFormula(other.getPersistFormula());
        setUpdateFormula(other.getUpdateFormula());
        setSelectFormula(other.getSelectFormula());
        setPersistFormulaOrder(other.getPersistFormulaOrder());
        setUpdateFormulaOrder(other.getUpdateFormulaOrder());
        setModifiers(other.getModifiers());
        setExcludeModifiers(other.getExcludeModifiers());
        setPersistAccessLevel(other.getPersistAccessLevel());
        setUpdateAccessLevel(other.getUpdateAccessLevel());
        setReadAccessLevel(other.getReadAccessLevel());
        setPersistProtectionLevel(other.getPersistProtectionLevel());
        setUpdateProtectionLevel(other.getUpdateProtectionLevel());
        setReadProtectionLevel(other.getReadProtectionLevel());
        setPropertyAccessType(other.getPropertyAccessType());
        setFieldParams(other.getFieldParams());
        setPosition(other.getPosition());
    }

    public String getName() {
        return name;
    }

    public DefaultFieldDescriptor setName(String name) {
        this.name = name;
        return this;
    }

    public String getPath() {
        return path;
    }

    public DefaultFieldDescriptor setPath(String fieldPath) {
        this.path = fieldPath;
        return this;
    }

    public Object getDefaultObject() {
        return defaultObject;
    }

    public DefaultFieldDescriptor setDefaultObject(Object defaultObject) {
        this.defaultObject = defaultObject;
        return this;
    }

    public Object getUnspecifiedObject() {
        return unspecifiedObject;
    }

    public DefaultFieldDescriptor setUnspecifiedObject(Object unspecifiedObject) {
        this.unspecifiedObject = unspecifiedObject;
        return this;
    }

    public DataType getDataType() {
        return dataType;
    }

    public DefaultFieldDescriptor setDataType(DataType dataType) {
        this.dataType = dataType;
        return this;
    }

    public DataTypeTransformConfig[] getTypeTransform() {
        return typeTransform;
    }

    public DefaultFieldDescriptor setTypeTransform(DataTypeTransformConfig[] typeTransform) {
        this.typeTransform = typeTransform;
        return this;
    }

    public Formula getPersistFormula() {
        return persistFormula;
    }

    public DefaultFieldDescriptor setPersistFormula(Formula persistFormula) {
        this.persistFormula = persistFormula;
        return this;
    }

    public Formula getUpdateFormula() {
        return updateFormula;
    }

    public DefaultFieldDescriptor setUpdateFormula(Formula updateFormula) {
        this.updateFormula = updateFormula;
        return this;
    }

    public Formula getSelectFormula() {
        return selectFormula;
    }

    public DefaultFieldDescriptor setSelectFormula(Formula selectFormula) {
        this.selectFormula = selectFormula;
        return this;
    }

    public int getPersistFormulaOrder() {
        return persistFormulaOrder;
    }

    public DefaultFieldDescriptor setPersistFormulaOrder(int persistFormulaOrder) {
        this.persistFormulaOrder = persistFormulaOrder;
        return this;
    }

    public int getUpdateFormulaOrder() {
        return updateFormulaOrder;
    }

    public DefaultFieldDescriptor setUpdateFormulaOrder(int updateFormulaOrder) {
        this.updateFormulaOrder = updateFormulaOrder;
        return this;
    }

    @Override
    public FlagSet<UserFieldModifier> getModifiers() {
        return userModifiers;
    }

    public DefaultFieldDescriptor setModifiers(FlagSet<UserFieldModifier> userModifiers) {
        this.userModifiers = userModifiers;
        return this;
    }

    @Override
    public FlagSet<UserFieldModifier> getExcludeModifiers() {
        return userExcludeModifiers;
    }

    public DefaultFieldDescriptor setExcludeModifiers(FlagSet<UserFieldModifier> userExcludeModifiers) {
        this.userExcludeModifiers = userExcludeModifiers;
        return this;
    }

    public AccessLevel getPersistAccessLevel() {
        return persistAccessLevel;
    }

    public DefaultFieldDescriptor setPersistAccessLevel(AccessLevel persistAccessLevel) {
        this.persistAccessLevel = persistAccessLevel;
        return this;
    }

    public AccessLevel getUpdateAccessLevel() {
        return updateAccessLevel;
    }

    public DefaultFieldDescriptor setUpdateAccessLevel(AccessLevel updateAccessLevel) {
        this.updateAccessLevel = updateAccessLevel;
        return this;
    }

    public AccessLevel getReadAccessLevel() {
        return readAccessLevel;
    }

    public DefaultFieldDescriptor setReadAccessLevel(AccessLevel readAccessLevel) {
        this.readAccessLevel = readAccessLevel;
        return this;
    }

    public DefaultFieldDescriptor setAccessLevel(AccessLevel accessLevel) {
        setPersistAccessLevel(accessLevel);
        setUpdateAccessLevel(accessLevel);
        setReadAccessLevel(accessLevel);
        return this;
    }

    public ProtectionLevel getPersistProtectionLevel() {
        return persistProtectionLevel;
    }

    public DefaultFieldDescriptor setPersistProtectionLevel(ProtectionLevel persistProtectionLevel) {
        this.persistProtectionLevel = persistProtectionLevel;
        return this;
    }

    public ProtectionLevel getUpdateProtectionLevel() {
        return updateProtectionLevel;
    }

    public DefaultFieldDescriptor setUpdateProtectionLevel(ProtectionLevel updateProtectionLevel) {
        this.updateProtectionLevel = updateProtectionLevel;
        return this;
    }

    public ProtectionLevel getReadProtectionLevel() {
        return readProtectionLevel;
    }

    public DefaultFieldDescriptor setReadProtectionLevel(ProtectionLevel readProtectionLevel) {
        this.readProtectionLevel = readProtectionLevel;
        return this;
    }

    public DefaultFieldDescriptor setProtectionLevel(ProtectionLevel protectionLevel) {
        setPersistProtectionLevel(protectionLevel);
        setUpdateProtectionLevel(protectionLevel);
        setReadProtectionLevel(protectionLevel);
        return this;
    }

    public Map<String, Object> getFieldParams() {
        return fieldParams;
    }

    public DefaultFieldDescriptor setFieldParams(Map<String, Object> fieldParams) {
        this.fieldParams = fieldParams;
        return this;
    }

    public PropertyAccessType getPropertyAccessType() {
        return propertyAccessType;
    }

    public DefaultFieldDescriptor setPropertyAccessType(PropertyAccessType propertyAccessType) {
        this.propertyAccessType = propertyAccessType;
        return this;
    }

    public int getPosition() {
        return position;
    }

    public DefaultFieldDescriptor setPosition(int position) {
        this.position = position;
        return this;
    }

    public DefaultFieldDescriptor setFieldDescriptor(FieldDescriptor other) {
        if (other == null) {
            other = new DefaultFieldDescriptor();
        }
        setName(other.getName());
        setPath(other.getPath());
        setPathPosition(other.getPathPosition());
        setDefaultObject(other.getDefaultObject());
        setUnspecifiedObject(other.getUnspecifiedObject());
        setDataType(other.getDataType());
        setTypeTransform(other.getTypeTransform());
        setPersistFormula(other.getPersistFormula());
        setUpdateFormula(other.getUpdateFormula());
        setSelectFormula(other.getSelectFormula());
        setPersistFormulaOrder(other.getPersistFormulaOrder());
        setUpdateFormulaOrder(other.getUpdateFormulaOrder());
        setModifiers(other.getModifiers());
        setExcludeModifiers(other.getExcludeModifiers());
        setPersistAccessLevel(other.getPersistAccessLevel());
        setUpdateAccessLevel(other.getUpdateAccessLevel());
        setReadAccessLevel(other.getReadAccessLevel());
        setPersistProtectionLevel(other.getPersistProtectionLevel());
        setUpdateProtectionLevel(other.getUpdateProtectionLevel());
        setReadProtectionLevel(other.getReadProtectionLevel());
        setFieldParams(other.getFieldParams());
        setPropertyAccessType(other.getPropertyAccessType());
        setPosition(other.getPosition());
        return this;
    }

    public DefaultFieldDescriptor merge(FieldDescriptor other) {
        if (other == null) {
            other = new DefaultFieldDescriptor();
        }
        if (other.getName() != null) {
            setName(other.getName());
        }
        if (other.getPath() != null) {
            setPath(other.getPath());
        }
        if (other.getDefaultObject() != null) {
            setDefaultObject(other.getDefaultObject());
        }
        if (other.getUnspecifiedObject() != null) {
            setUnspecifiedObject(other.getUnspecifiedObject());
        }
        if (other.getDataType() != null) {
            setDataType(other.getDataType());
        }
        if (other.getTypeTransform() != null) {
            setTypeTransform(other.getTypeTransform());
        }
        if (other.getPersistFormula() != null) {
            setPersistFormula(other.getPersistFormula());
        }
        if (other.getUpdateFormula() != null) {
            setUpdateFormula(other.getUpdateFormula());
        }
        if (other.getSelectFormula() != null) {
            setSelectFormula(other.getSelectFormula());
        }
        if (other.getPersistFormulaOrder() != 0) {
            setPersistFormulaOrder(other.getPersistFormulaOrder());
        }
        if (other.getUpdateFormulaOrder() != 0) {
            setUpdateFormulaOrder(other.getUpdateFormulaOrder());
        }
        if (other.getModifiers() != null) {
            setModifiers(other.getModifiers());
        }
        if (other.getExcludeModifiers() != null) {
            setExcludeModifiers(other.getExcludeModifiers());
        }
        if (other.getPersistAccessLevel() != null) {
            setPersistAccessLevel(other.getPersistAccessLevel());
        }
        if (other.getUpdateAccessLevel() != null) {
            setUpdateAccessLevel(other.getUpdateAccessLevel());
        }
        if (other.getReadAccessLevel() != null) {
            setReadAccessLevel(other.getReadAccessLevel());
        }
        if (other.getPersistProtectionLevel() != null) {
            setPersistProtectionLevel(other.getPersistProtectionLevel());
        }
        if (other.getUpdateProtectionLevel() != null) {
            setUpdateProtectionLevel(other.getUpdateProtectionLevel());
        }
        if (other.getReadProtectionLevel() != null) {
            setReadProtectionLevel(other.getReadProtectionLevel());
        }
        if (other.getFieldParams() != null) {
            setFieldParams(other.getFieldParams());
        }
        if (other.getPropertyAccessType() != null) {
            setPropertyAccessType(other.getPropertyAccessType());
        }
        if (other.getPosition() != 0) {
            setPosition(other.getPosition());
        }
        return this;
    }

    public int getPathPosition() {
        return pathPosition;
    }

    public void setPathPosition(int pathPosition) {
        this.pathPosition = pathPosition;
    }

    public boolean isIgnoreExisting() {
        return ignoreExisting;
    }

    public void setIgnoreExisting(boolean ignoreExisting) {
        this.ignoreExisting = ignoreExisting;
    }

    
}
