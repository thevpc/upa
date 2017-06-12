package net.vpc.upa;

import net.vpc.upa.types.DataType;
import net.vpc.upa.types.DataTypeTransformConfig;

import java.util.Map;

/**
 * Created by vpc on 6/9/17.
 */
public class DefaultFieldBuilder implements FieldBuilder, FieldDescriptor {
    private String name;
    private String path;
    private Object defaultValue;
    private Object unspecifiedObject;
    private DataType dataType;
    private DataTypeTransformConfig[] typeTransform;
    private Formula persistFormula;
    private Formula updateFormula;
    private Formula selectFormula;
    private int persistFormulaOrder;
    private int updateFormulaOrder;
    private FlagSet<UserFieldModifier> modifiers;
    private FlagSet<UserFieldModifier> excludeModifiers;
    private AccessLevel persistAccessLevel = AccessLevel.DEFAULT;
    private AccessLevel updateAccessLevel = AccessLevel.DEFAULT;
    private AccessLevel readAccessLevel = AccessLevel.DEFAULT;
    private Map<String, Object> fieldParams;
    private PropertyAccessType propertyAccessType;
    private int index = -1;

    @Override
    public FieldDescriptor build() {
        return this;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public FieldBuilder setName(String name) {
        this.name = name;
        return this;
    }

    @Override
    public String getPath() {
        return path;
    }

    @Override
    public FieldBuilder setPath(String fieldPath) {
        this.path = fieldPath;
        return this;
    }

    @Override
    public Object getDefaultObject() {
        return defaultValue;
    }

    @Override
    public FieldBuilder setDefaultObject(Object defaultObject) {
        this.defaultValue = defaultObject;
        return this;
    }

    @Override
    public Object getUnspecifiedObject() {
        return unspecifiedObject;
    }

    @Override
    public FieldBuilder setUnspecifiedObject(Object unspecifiedObject) {
        this.unspecifiedObject = unspecifiedObject;
        return this;
    }

    @Override
    public DataType getDataType() {
        return dataType;
    }

    @Override
    public FieldBuilder setDataType(DataType dataType) {
        this.dataType = dataType;
        return this;
    }

    @Override
    public DataTypeTransformConfig[] getTypeTransform() {
        return typeTransform;
    }

    @Override
    public FieldBuilder setTypeTransform(DataTypeTransformConfig[] typeTransform) {
        this.typeTransform = typeTransform;
        return this;
    }

    @Override
    public Formula getPersistFormula() {
        return persistFormula;
    }

    @Override
    public FieldBuilder setPersistFormula(Formula persistFormula) {
        this.persistFormula = persistFormula;
        return this;
    }

    @Override
    public Formula getUpdateFormula() {
        return updateFormula;
    }

    @Override
    public FieldBuilder setUpdateFormula(Formula updateFormula) {
        this.updateFormula = updateFormula;
        return this;
    }

    @Override
    public Formula getSelectFormula() {
        return selectFormula;
    }

    @Override
    public FieldBuilder setSelectFormula(String selectFormula) {
        return setSelectFormula(selectFormula == null ? null : new ExpressionFormula(selectFormula));
    }

    @Override
    public FieldBuilder setLiveSelectFormula(String selectFormula) {
        return setLiveSelectFormula(selectFormula == null ? null : new ExpressionFormula(selectFormula));
    }

    @Override
    public FieldBuilder setCompiledSelectFormula(String selectFormula) {
        return setCompiledSelectFormula(selectFormula == null ? null : new ExpressionFormula(selectFormula));
    }

    @Override
    public FieldBuilder setFormula(String formula) {
        return setFormula(formula == null ? null : new ExpressionFormula(formula));
    }

    @Override
    public FieldBuilder setFormula(Formula formula) {
        setPersistFormula(formula);
        setUpdateFormula(formula);
        return this;
    }

    @Override
    public FieldBuilder setPersistFormula(String persistFormula) {
        return setPersistFormula(persistFormula == null ? null : new ExpressionFormula(persistFormula));
    }

    @Override
    public FieldBuilder setUpdateFormula(String updateFormula) {
        return setUpdateFormula(updateFormula == null ? null : new ExpressionFormula(updateFormula));
    }

    @Override
    public FieldBuilder setSelectFormula(Formula selectFormula) {
        this.selectFormula = selectFormula;
        return this;
    }

    @Override
    public FieldBuilder setLiveSelectFormula(Formula selectFormula) {
        addModifier(UserFieldModifier.LIVE);
        this.selectFormula = selectFormula;
        return this;
    }

    @Override
    public FieldBuilder setCompiledSelectFormula(Formula selectFormula) {
        addModifier(UserFieldModifier.COMPILED);
        this.selectFormula = selectFormula;
        return this;
    }

    @Override
    public int getPersistFormulaOrder() {
        return persistFormulaOrder;
    }

    @Override
    public FieldBuilder setPersistFormulaOrder(int persistFormulaOrder) {
        this.persistFormulaOrder = persistFormulaOrder;
        return this;
    }

    @Override
    public int getUpdateFormulaOrder() {
        return updateFormulaOrder;
    }

    @Override
    public FieldBuilder setUpdateFormulaOrder(int updateFormulaOrder) {
        this.updateFormulaOrder = updateFormulaOrder;
        return this;
    }

    public FlagSet<UserFieldModifier> getModifiers() {
        return modifiers;
    }

    @Override
    public FieldBuilder setModifiers(FlagSet<UserFieldModifier> userModifiers) {
        this.modifiers = userModifiers;
        return this;
    }

    @Override
    public FieldBuilder addModifier(UserFieldModifier userModifier) {
        FlagSet<UserFieldModifier> val = FlagSets.noneOf(UserFieldModifier.class);
        if (this.modifiers != null) {
            val = val.addAll(this.modifiers);
        }
        if (userModifier != null) {
            val = val.add(userModifier);
        }
        this.modifiers = val;
        return this;
    }

    @Override
    public FieldBuilder removeModifier(UserFieldModifier userModifiers) {
        if (this.modifiers != null && userModifiers != null) {
            this.modifiers = this.modifiers.remove(userModifiers);
        }
        return this;
    }

    @Override
    public FlagSet<UserFieldModifier> getExcludeModifiers() {
        return excludeModifiers;
    }

    @Override
    public FieldBuilder addExcludeModifier(UserFieldModifier userModifier) {
        FlagSet<UserFieldModifier> val = FlagSets.noneOf(UserFieldModifier.class);
        if (this.excludeModifiers != null) {
            val = val.addAll(this.excludeModifiers);
        }
        if (userModifier != null) {
            val = val.add(userModifier);
        }
        this.excludeModifiers = val;
        return this;
    }

    @Override
    public FieldBuilder removeExcludeModifier(UserFieldModifier userModifier) {
        if (this.excludeModifiers != null && userModifier != null) {
            this.excludeModifiers = this.excludeModifiers.remove(userModifier);
        }
        return this;
    }

    @Override
    public FieldBuilder setExcludeModifiers(FlagSet<UserFieldModifier> userExcludeModifiers) {
        this.excludeModifiers = userExcludeModifiers;
        return this;
    }

    @Override
    public FieldBuilder setAccessLevel(AccessLevel accessLevel) {
        setPersistAccessLevel(accessLevel);
        setUpdateAccessLevel(accessLevel);
        setReadAccessLevel(accessLevel);
        return this;
    }

    @Override
    public AccessLevel getPersistAccessLevel() {
        return persistAccessLevel;
    }

    @Override
    public FieldBuilder setPersistAccessLevel(AccessLevel persistAccessLevel) {
        this.persistAccessLevel = persistAccessLevel;
        return this;
    }

    @Override
    public AccessLevel getUpdateAccessLevel() {
        return updateAccessLevel;
    }

    @Override
    public FieldBuilder setUpdateAccessLevel(AccessLevel updateAccessLevel) {
        this.updateAccessLevel = updateAccessLevel;
        return this;
    }

    @Override
    public AccessLevel getReadAccessLevel() {
        return readAccessLevel;
    }

    @Override
    public FieldBuilder setReadAccessLevel(AccessLevel readAccessLevel) {
        this.readAccessLevel = readAccessLevel;
        return this;
    }

    @Override
    public Map<String, Object> getFieldParams() {
        return fieldParams;
    }

    @Override
    public FieldBuilder setFieldParams(Map<String, Object> fieldParams) {
        this.fieldParams = fieldParams;
        return this;
    }

    @Override
    public PropertyAccessType getPropertyAccessType() {
        return propertyAccessType;
    }

    @Override
    public FieldBuilder setPropertyAccessType(PropertyAccessType propertyAccessType) {
        this.propertyAccessType = propertyAccessType;
        return this;
    }

    @Override
    public int getIndex() {
        return index;
    }

    @Override
    public FieldBuilder setIndex(int position) {
        this.index = position;
        return this;
    }
}
