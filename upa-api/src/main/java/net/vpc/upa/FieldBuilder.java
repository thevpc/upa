package net.vpc.upa;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransformConfig;

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

    Map<String, Object> getFieldParams();

    FieldBuilder setFieldParams(Map<String, Object> fieldParams);

    PropertyAccessType getPropertyAccessType();

    FieldBuilder setPropertyAccessType(PropertyAccessType propertyAccessType);

    int getIndex();

    FieldBuilder setIndex(int position);

    FieldDescriptor build();
}
