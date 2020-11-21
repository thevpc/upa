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



namespace Net.TheVpc.Upa
{


    /**
     * Created by vpc on 6/9/17.
     */
    public class DefaultFieldBuilder : Net.TheVpc.Upa.FieldBuilder, Net.TheVpc.Upa.FieldDescriptor {

        private string name;

        private string path;

        private object defaultValue;

        private object unspecifiedObject;

        private Net.TheVpc.Upa.Types.DataType dataType;

        private Net.TheVpc.Upa.Types.DataTypeTransformConfig[] typeTransform;

        private Net.TheVpc.Upa.Formula persistFormula;

        private Net.TheVpc.Upa.Formula updateFormula;

        private Net.TheVpc.Upa.Formula selectFormula;

        private int persistFormulaOrder;

        private int updateFormulaOrder;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> excludeModifiers;

        private Net.TheVpc.Upa.AccessLevel persistAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;

        private Net.TheVpc.Upa.AccessLevel updateAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;

        private Net.TheVpc.Upa.AccessLevel readAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;

        private Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;

        private Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;

        private Net.TheVpc.Upa.ProtectionLevel readProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;

        private System.Collections.Generic.IDictionary<string , object> fieldParams;

        private Net.TheVpc.Upa.PropertyAccessType propertyAccessType;

        private int index = -1;


        public virtual Net.TheVpc.Upa.FieldDescriptor Build() {
            return this;
        }


        public virtual string GetName() {
            return name;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetName(string name) {
            this.name = name;
            return this;
        }


        public virtual string GetPath() {
            return path;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPath(string fieldPath) {
            this.path = fieldPath;
            return this;
        }


        public virtual object GetDefaultObject() {
            return defaultValue;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetDefaultObject(object defaultObject) {
            this.defaultValue = defaultObject;
            return this;
        }


        public virtual object GetUnspecifiedObject() {
            return unspecifiedObject;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetUnspecifiedObject(object unspecifiedObject) {
            this.unspecifiedObject = unspecifiedObject;
            return this;
        }


        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetDataType(Net.TheVpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
            return this;
        }


        public virtual Net.TheVpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform() {
            return typeTransform;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetTypeTransform(Net.TheVpc.Upa.Types.DataTypeTransformConfig[] typeTransform) {
            this.typeTransform = typeTransform;
            return this;
        }


        public virtual Net.TheVpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPersistFormula(Net.TheVpc.Upa.Formula persistFormula) {
            this.persistFormula = persistFormula;
            return this;
        }


        public virtual Net.TheVpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetUpdateFormula(Net.TheVpc.Upa.Formula updateFormula) {
            this.updateFormula = updateFormula;
            return this;
        }


        public virtual Net.TheVpc.Upa.Formula GetSelectFormula() {
            return selectFormula;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetSelectFormula(string selectFormula) {
            return SetSelectFormula(selectFormula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(selectFormula));
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetLiveSelectFormula(string selectFormula) {
            return SetLiveSelectFormula(selectFormula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(selectFormula));
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetCompiledSelectFormula(string selectFormula) {
            return SetCompiledSelectFormula(selectFormula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(selectFormula));
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetFormula(string formula) {
            return SetFormula(formula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(formula));
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetFormula(Net.TheVpc.Upa.Formula formula) {
            SetPersistFormula(formula);
            SetUpdateFormula(formula);
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPersistFormula(string persistFormula) {
            return SetPersistFormula(persistFormula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(persistFormula));
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetUpdateFormula(string updateFormula) {
            return SetUpdateFormula(updateFormula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(updateFormula));
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetSelectFormula(Net.TheVpc.Upa.Formula selectFormula) {
            this.selectFormula = selectFormula;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetLiveSelectFormula(Net.TheVpc.Upa.Formula selectFormula) {
            AddModifier(Net.TheVpc.Upa.UserFieldModifier.LIVE);
            this.selectFormula = selectFormula;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetCompiledSelectFormula(Net.TheVpc.Upa.Formula selectFormula) {
            AddModifier(Net.TheVpc.Upa.UserFieldModifier.COMPILED);
            this.selectFormula = selectFormula;
            return this;
        }


        public virtual int GetPersistFormulaOrder() {
            return persistFormulaOrder;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPersistFormulaOrder(int persistFormulaOrder) {
            this.persistFormulaOrder = persistFormulaOrder;
            return this;
        }


        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetUpdateFormulaOrder(int updateFormulaOrder) {
            this.updateFormulaOrder = updateFormulaOrder;
            return this;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetModifiers() {
            return modifiers;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userModifiers) {
            this.modifiers = userModifiers;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder AddModifier(Net.TheVpc.Upa.UserFieldModifier userModifier) {
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> val = Net.TheVpc.Upa.FlagSets.NoneOf<>();
            if (this.modifiers != null) {
                val = val.AddAll(this.modifiers);
            }
            if (userModifier != default(Net.TheVpc.Upa.UserFieldModifier)) {
                val = val.Add(userModifier);
            }
            this.modifiers = val;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder RemoveModifier(Net.TheVpc.Upa.UserFieldModifier userModifiers) {
            if (this.modifiers != null && userModifiers != default(Net.TheVpc.Upa.UserFieldModifier)) {
                this.modifiers = this.modifiers.Remove(userModifiers);
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder AddExcludeModifier(Net.TheVpc.Upa.UserFieldModifier userModifier) {
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> val = Net.TheVpc.Upa.FlagSets.NoneOf<>();
            if (this.excludeModifiers != null) {
                val = val.AddAll(this.excludeModifiers);
            }
            if (userModifier != default(Net.TheVpc.Upa.UserFieldModifier)) {
                val = val.Add(userModifier);
            }
            this.excludeModifiers = val;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder RemoveExcludeModifier(Net.TheVpc.Upa.UserFieldModifier userModifier) {
            if (this.excludeModifiers != null && userModifier != default(Net.TheVpc.Upa.UserFieldModifier)) {
                this.excludeModifiers = this.excludeModifiers.Remove(userModifier);
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userExcludeModifiers) {
            this.excludeModifiers = userExcludeModifiers;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
            return this;
        }


        public virtual Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPersistAccessLevel(Net.TheVpc.Upa.AccessLevel persistAccessLevel) {
            this.persistAccessLevel = persistAccessLevel;
            return this;
        }


        public virtual Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel updateAccessLevel) {
            this.updateAccessLevel = updateAccessLevel;
            return this;
        }


        public virtual Net.TheVpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetReadAccessLevel(Net.TheVpc.Upa.AccessLevel readAccessLevel) {
            this.readAccessLevel = readAccessLevel;
            return this;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel) {
            SetPersistProtectionLevel(protectionLevel);
            SetUpdateProtectionLevel(protectionLevel);
            SetReadProtectionLevel(protectionLevel);
            return this;
        }


        public virtual Net.TheVpc.Upa.ProtectionLevel GetPersistProtectionLevel() {
            return persistProtectionLevel;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPersistProtectionLevel(Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel) {
            this.persistProtectionLevel = persistProtectionLevel;
            return this;
        }


        public virtual Net.TheVpc.Upa.ProtectionLevel GetUpdateProtectionLevel() {
            return updateProtectionLevel;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetUpdateProtectionLevel(Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel) {
            this.updateProtectionLevel = updateProtectionLevel;
            return this;
        }


        public virtual Net.TheVpc.Upa.ProtectionLevel GetReadProtectionLevel() {
            return readProtectionLevel;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetReadProtectionLevel(Net.TheVpc.Upa.ProtectionLevel readProtectionLevel) {
            this.readProtectionLevel = readProtectionLevel;
            return this;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetFieldParams() {
            return fieldParams;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetFieldParams(System.Collections.Generic.IDictionary<string , object> fieldParams) {
            this.fieldParams = fieldParams;
            return this;
        }


        public virtual Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return propertyAccessType;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetPropertyAccessType(Net.TheVpc.Upa.PropertyAccessType propertyAccessType) {
            this.propertyAccessType = propertyAccessType;
            return this;
        }


        public virtual int GetIndex() {
            return index;
        }


        public virtual Net.TheVpc.Upa.FieldBuilder SetIndex(int position) {
            this.index = position;
            return this;
        }
    }
}
