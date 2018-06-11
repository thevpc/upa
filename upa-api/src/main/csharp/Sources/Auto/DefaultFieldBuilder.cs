/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 6/9/17.
     */
    public class DefaultFieldBuilder : Net.Vpc.Upa.FieldBuilder, Net.Vpc.Upa.FieldDescriptor {

        private string name;

        private string path;

        private object defaultValue;

        private object unspecifiedObject;

        private Net.Vpc.Upa.Types.DataType dataType;

        private Net.Vpc.Upa.Types.DataTypeTransformConfig[] typeTransform;

        private Net.Vpc.Upa.Formula persistFormula;

        private Net.Vpc.Upa.Formula updateFormula;

        private Net.Vpc.Upa.Formula selectFormula;

        private int persistFormulaOrder;

        private int updateFormulaOrder;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludeModifiers;

        private Net.Vpc.Upa.AccessLevel persistAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.AccessLevel updateAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.AccessLevel readAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.ProtectionLevel persistProtectionLevel = Net.Vpc.Upa.ProtectionLevel.DEFAULT;

        private Net.Vpc.Upa.ProtectionLevel updateProtectionLevel = Net.Vpc.Upa.ProtectionLevel.DEFAULT;

        private Net.Vpc.Upa.ProtectionLevel readProtectionLevel = Net.Vpc.Upa.ProtectionLevel.DEFAULT;

        private System.Collections.Generic.IDictionary<string , object> fieldParams;

        private Net.Vpc.Upa.PropertyAccessType propertyAccessType;

        private int index = -1;


        public virtual Net.Vpc.Upa.FieldDescriptor Build() {
            return this;
        }


        public virtual string GetName() {
            return name;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetName(string name) {
            this.name = name;
            return this;
        }


        public virtual string GetPath() {
            return path;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPath(string fieldPath) {
            this.path = fieldPath;
            return this;
        }


        public virtual object GetDefaultObject() {
            return defaultValue;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetDefaultObject(object defaultObject) {
            this.defaultValue = defaultObject;
            return this;
        }


        public virtual object GetUnspecifiedObject() {
            return unspecifiedObject;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetUnspecifiedObject(object unspecifiedObject) {
            this.unspecifiedObject = unspecifiedObject;
            return this;
        }


        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetDataType(Net.Vpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
            return this;
        }


        public virtual Net.Vpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform() {
            return typeTransform;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransformConfig[] typeTransform) {
            this.typeTransform = typeTransform;
            return this;
        }


        public virtual Net.Vpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPersistFormula(Net.Vpc.Upa.Formula persistFormula) {
            this.persistFormula = persistFormula;
            return this;
        }


        public virtual Net.Vpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetUpdateFormula(Net.Vpc.Upa.Formula updateFormula) {
            this.updateFormula = updateFormula;
            return this;
        }


        public virtual Net.Vpc.Upa.Formula GetSelectFormula() {
            return selectFormula;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetSelectFormula(string selectFormula) {
            return SetSelectFormula(selectFormula == null ? null : new Net.Vpc.Upa.ExpressionFormula(selectFormula));
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetLiveSelectFormula(string selectFormula) {
            return SetLiveSelectFormula(selectFormula == null ? null : new Net.Vpc.Upa.ExpressionFormula(selectFormula));
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetCompiledSelectFormula(string selectFormula) {
            return SetCompiledSelectFormula(selectFormula == null ? null : new Net.Vpc.Upa.ExpressionFormula(selectFormula));
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetFormula(string formula) {
            return SetFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetFormula(Net.Vpc.Upa.Formula formula) {
            SetPersistFormula(formula);
            SetUpdateFormula(formula);
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPersistFormula(string persistFormula) {
            return SetPersistFormula(persistFormula == null ? null : new Net.Vpc.Upa.ExpressionFormula(persistFormula));
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetUpdateFormula(string updateFormula) {
            return SetUpdateFormula(updateFormula == null ? null : new Net.Vpc.Upa.ExpressionFormula(updateFormula));
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetSelectFormula(Net.Vpc.Upa.Formula selectFormula) {
            this.selectFormula = selectFormula;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetLiveSelectFormula(Net.Vpc.Upa.Formula selectFormula) {
            AddModifier(Net.Vpc.Upa.UserFieldModifier.LIVE);
            this.selectFormula = selectFormula;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetCompiledSelectFormula(Net.Vpc.Upa.Formula selectFormula) {
            AddModifier(Net.Vpc.Upa.UserFieldModifier.COMPILED);
            this.selectFormula = selectFormula;
            return this;
        }


        public virtual int GetPersistFormulaOrder() {
            return persistFormulaOrder;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPersistFormulaOrder(int persistFormulaOrder) {
            this.persistFormulaOrder = persistFormulaOrder;
            return this;
        }


        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetUpdateFormulaOrder(int updateFormulaOrder) {
            this.updateFormulaOrder = updateFormulaOrder;
            return this;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetModifiers() {
            return modifiers;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers) {
            this.modifiers = userModifiers;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder AddModifier(Net.Vpc.Upa.UserFieldModifier userModifier) {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> val = Net.Vpc.Upa.FlagSets.NoneOf<>();
            if (this.modifiers != null) {
                val = val.AddAll(this.modifiers);
            }
            if (userModifier != default(Net.Vpc.Upa.UserFieldModifier)) {
                val = val.Add(userModifier);
            }
            this.modifiers = val;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder RemoveModifier(Net.Vpc.Upa.UserFieldModifier userModifiers) {
            if (this.modifiers != null && userModifiers != default(Net.Vpc.Upa.UserFieldModifier)) {
                this.modifiers = this.modifiers.Remove(userModifiers);
            }
            return this;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }


        public virtual Net.Vpc.Upa.FieldBuilder AddExcludeModifier(Net.Vpc.Upa.UserFieldModifier userModifier) {
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> val = Net.Vpc.Upa.FlagSets.NoneOf<>();
            if (this.excludeModifiers != null) {
                val = val.AddAll(this.excludeModifiers);
            }
            if (userModifier != default(Net.Vpc.Upa.UserFieldModifier)) {
                val = val.Add(userModifier);
            }
            this.excludeModifiers = val;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder RemoveExcludeModifier(Net.Vpc.Upa.UserFieldModifier userModifier) {
            if (this.excludeModifiers != null && userModifier != default(Net.Vpc.Upa.UserFieldModifier)) {
                this.excludeModifiers = this.excludeModifiers.Remove(userModifier);
            }
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers) {
            this.excludeModifiers = userExcludeModifiers;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
            return this;
        }


        public virtual Net.Vpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPersistAccessLevel(Net.Vpc.Upa.AccessLevel persistAccessLevel) {
            this.persistAccessLevel = persistAccessLevel;
            return this;
        }


        public virtual Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel updateAccessLevel) {
            this.updateAccessLevel = updateAccessLevel;
            return this;
        }


        public virtual Net.Vpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetReadAccessLevel(Net.Vpc.Upa.AccessLevel readAccessLevel) {
            this.readAccessLevel = readAccessLevel;
            return this;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel) {
            SetPersistProtectionLevel(protectionLevel);
            SetUpdateProtectionLevel(protectionLevel);
            SetReadProtectionLevel(protectionLevel);
            return this;
        }


        public virtual Net.Vpc.Upa.ProtectionLevel GetPersistProtectionLevel() {
            return persistProtectionLevel;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPersistProtectionLevel(Net.Vpc.Upa.ProtectionLevel persistProtectionLevel) {
            this.persistProtectionLevel = persistProtectionLevel;
            return this;
        }


        public virtual Net.Vpc.Upa.ProtectionLevel GetUpdateProtectionLevel() {
            return updateProtectionLevel;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetUpdateProtectionLevel(Net.Vpc.Upa.ProtectionLevel updateProtectionLevel) {
            this.updateProtectionLevel = updateProtectionLevel;
            return this;
        }


        public virtual Net.Vpc.Upa.ProtectionLevel GetReadProtectionLevel() {
            return readProtectionLevel;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetReadProtectionLevel(Net.Vpc.Upa.ProtectionLevel readProtectionLevel) {
            this.readProtectionLevel = readProtectionLevel;
            return this;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetFieldParams() {
            return fieldParams;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetFieldParams(System.Collections.Generic.IDictionary<string , object> fieldParams) {
            this.fieldParams = fieldParams;
            return this;
        }


        public virtual Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return propertyAccessType;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetPropertyAccessType(Net.Vpc.Upa.PropertyAccessType propertyAccessType) {
            this.propertyAccessType = propertyAccessType;
            return this;
        }


        public virtual int GetIndex() {
            return index;
        }


        public virtual Net.Vpc.Upa.FieldBuilder SetIndex(int position) {
            this.index = position;
            return this;
        }
    }
}
