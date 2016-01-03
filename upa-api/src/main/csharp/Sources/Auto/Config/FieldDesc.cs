/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 10:42 PM
     */
    public class FieldDesc {

        private int configOrder = 100;

        private string name;

        private Net.Vpc.Upa.Types.DataType type;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> excludeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();

        private Net.Vpc.Upa.Formula insertFormula;

        private Net.Vpc.Upa.Formula updateFormula;

        private bool insertFormulaSet;

        private bool updateFormulaSet;

        private object defaultValue;

        private bool defaultValueSet;

        private object unspecifiedValue = Net.Vpc.Upa.UnspecifiedValue.DEFAULT;

        private bool unspecifiedValueSet;

        public virtual string GetName() {
            return name;
        }

        public virtual bool IsInsertFormulaSet() {
            return insertFormulaSet;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetInsertFormulaSet(bool insertFormulaSet) {
            this.insertFormulaSet = insertFormulaSet;
            if (!insertFormulaSet) {
                insertFormula = null;
            }
            return this;
        }

        public virtual bool IsUpdateFormulaSet() {
            return updateFormulaSet;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetUpdateFormulaSet(bool updateFormulaSet) {
            this.updateFormulaSet = updateFormulaSet;
            if (!updateFormulaSet) {
                updateFormula = null;
            }
            return this;
        }

        public virtual bool IsDefaultValueSet() {
            return defaultValueSet;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetDefaultValueSet(bool defaultValueSet) {
            this.defaultValueSet = defaultValueSet;
            if (!defaultValueSet) {
                defaultValue = null;
            }
            return this;
        }

        public virtual bool IsUnspecifiedValueSet() {
            return unspecifiedValueSet;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetUnspecifiedValueSet(bool unspecifiedValueSet) {
            this.unspecifiedValueSet = unspecifiedValueSet;
            if (!unspecifiedValueSet) {
                unspecifiedValue = Net.Vpc.Upa.UnspecifiedValue.DEFAULT;
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetModifiers() {
            return modifiers;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            this.modifiers = modifiers;
            return this;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            this.excludeModifiers = modifiers;
            return this;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc AddModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            return SetModifiers(GetModifiers().AddAll(modifiers));
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc RemoveModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            return SetModifiers(GetModifiers().RemoveAll(modifiers));
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc AddExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            return SetExcludeModifiers(GetExcludeModifiers().AddAll(modifiers));
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc RemoveExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            return SetExcludeModifiers(GetExcludeModifiers().RemoveAll(modifiers));
        }

        public virtual Net.Vpc.Upa.Formula GetInsertFormula() {
            return insertFormula;
        }

        public virtual Net.Vpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetFormula(Net.Vpc.Upa.Formula formula) {
            SetInsertFormula(formula);
            SetUpdateFormula(formula);
            return this;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetInsertFormula(Net.Vpc.Upa.Formula insertFormula) {
            this.insertFormula = insertFormula;
            this.insertFormulaSet = true;
            return this;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetUpdateFormula(Net.Vpc.Upa.Formula updateFormula) {
            this.updateFormula = updateFormula;
            this.updateFormulaSet = true;
            return this;
        }

        public virtual object GetDefaultValue() {
            return defaultValue;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetDefaultValue(object defaultValue) {
            this.defaultValue = defaultValue;
            this.defaultValueSet = true;
            return this;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return type;
        }

        public virtual Net.Vpc.Upa.Config.FieldDesc SetDataType(Net.Vpc.Upa.Types.DataType type) {
            this.type = type;
            return this;
        }

        public virtual object GetUnspecifiedValue() {
            return unspecifiedValue;
        }

        public virtual void SetUnspecifiedValue(object unspecifiedValue) {
            this.unspecifiedValue = unspecifiedValue;
            this.unspecifiedValueSet = true;
        }

        public virtual int GetConfigOrder() {
            return configOrder;
        }

        public virtual void SetConfigOrder(int configOrder) {
            this.configOrder = configOrder;
        }
    }
}
