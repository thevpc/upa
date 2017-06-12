/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa;

import java.util.Map;

import net.vpc.upa.types.DataTypeTransformConfig;
import net.vpc.upa.types.DataType;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultFieldDescriptor implements FieldDescriptor {

    private String name;
    private String fieldPath;
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
    private Map<String, Object> fieldParams;
    private PropertyAccessType propertyAccessType;
    private int position=-1;

    public String getName() {
        return name;
    }

    public DefaultFieldDescriptor setName(String name) {
        this.name = name;
        return this;
    }

    public String getPath() {
        return fieldPath;
    }

    public DefaultFieldDescriptor setPath(String fieldPath) {
        this.fieldPath = fieldPath;
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

    public DefaultFieldDescriptor setAccessLevel(AccessLevel accessLevel) {
        setPersistAccessLevel(accessLevel);
        setUpdateAccessLevel(accessLevel);
        setReadAccessLevel(accessLevel);
        return this;
    }

    public int getIndex() {
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
        setFieldParams(other.getFieldParams());
        setPropertyAccessType(other.getPropertyAccessType());
        setPosition(other.getIndex());
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
        if (other.getFieldParams() != null) {
            setFieldParams(other.getFieldParams());
        }
        if (other.getPropertyAccessType() != null) {
            setPropertyAccessType(other.getPropertyAccessType());
        }
        if (other.getIndex() != 0) {
            setPosition(other.getIndex());
        }
        return this;
    }
}
