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



namespace Net.TheVpc.Upa.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/28/12 10:42 PM
     */
    public class FieldDesc {

        private int configOrder = 100;

        private string name;

        private Net.TheVpc.Upa.Types.DataType type;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers = Net.TheVpc.Upa.FlagSets.NoneOf<T>();

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> excludeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<T>();

        private Net.TheVpc.Upa.Formula persistFormula;

        private Net.TheVpc.Upa.Formula updateFormula;

        private bool persistFormulaSet;

        private bool updateFormulaSet;

        private object defaultValue;

        private bool defaultValueSet;

        private object unspecifiedValue = Net.TheVpc.Upa.UnspecifiedValue.DEFAULT;

        private bool unspecifiedValueSet;

        public virtual string GetName() {
            return name;
        }

        public virtual bool IsPersistFormulaSet() {
            return persistFormulaSet;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetPersistFormulaSet(bool persistFormulaSet) {
            this.persistFormulaSet = persistFormulaSet;
            if (!persistFormulaSet) {
                persistFormula = null;
            }
            return this;
        }

        public virtual bool IsUpdateFormulaSet() {
            return updateFormulaSet;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetUpdateFormulaSet(bool updateFormulaSet) {
            this.updateFormulaSet = updateFormulaSet;
            if (!updateFormulaSet) {
                updateFormula = null;
            }
            return this;
        }

        public virtual bool IsDefaultValueSet() {
            return defaultValueSet;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetDefaultValueSet(bool defaultValueSet) {
            this.defaultValueSet = defaultValueSet;
            if (!defaultValueSet) {
                defaultValue = null;
            }
            return this;
        }

        public virtual bool IsUnspecifiedValueSet() {
            return unspecifiedValueSet;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetUnspecifiedValueSet(bool unspecifiedValueSet) {
            this.unspecifiedValueSet = unspecifiedValueSet;
            if (!unspecifiedValueSet) {
                unspecifiedValue = Net.TheVpc.Upa.UnspecifiedValue.DEFAULT;
            }
            return this;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetModifiers() {
            return modifiers;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            this.modifiers = modifiers;
            return this;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            this.excludeModifiers = modifiers;
            return this;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc AddModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            return SetModifiers(GetModifiers().AddAll(modifiers));
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc RemoveModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            return SetModifiers(GetModifiers().RemoveAll(modifiers));
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc AddExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            return SetExcludeModifiers(GetExcludeModifiers().AddAll(modifiers));
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc RemoveExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            return SetExcludeModifiers(GetExcludeModifiers().RemoveAll(modifiers));
        }

        public virtual Net.TheVpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }

        public virtual Net.TheVpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetFormula(Net.TheVpc.Upa.Formula formula) {
            SetPersistFormula(formula);
            SetUpdateFormula(formula);
            return this;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetPersistFormula(Net.TheVpc.Upa.Formula persistFormula) {
            this.persistFormula = persistFormula;
            this.persistFormulaSet = true;
            return this;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetUpdateFormula(Net.TheVpc.Upa.Formula updateFormula) {
            this.updateFormula = updateFormula;
            this.updateFormulaSet = true;
            return this;
        }

        public virtual object GetDefaultValue() {
            return defaultValue;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetDefaultValue(object defaultValue) {
            this.defaultValue = defaultValue;
            this.defaultValueSet = true;
            return this;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return type;
        }

        public virtual Net.TheVpc.Upa.Config.FieldDesc SetDataType(Net.TheVpc.Upa.Types.DataType type) {
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
