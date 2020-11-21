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
     * @author taha.bensalah@gmail.com
     */
    public class DefaultFieldDescriptor : Net.TheVpc.Upa.FieldDescriptor {

        private string name;

        private string fieldPath;

        private object defaultObject;

        private object unspecifiedObject;

        private Net.TheVpc.Upa.Types.DataType dataType;

        private Net.TheVpc.Upa.Types.DataTypeTransformConfig[] typeTransform;

        private Net.TheVpc.Upa.Formula persistFormula;

        private Net.TheVpc.Upa.Formula updateFormula;

        private Net.TheVpc.Upa.Formula selectFormula;

        private int persistFormulaOrder;

        private int updateFormulaOrder;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userModifiers;

        private Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userExcludeModifiers;

        private Net.TheVpc.Upa.AccessLevel persistAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;

        private Net.TheVpc.Upa.AccessLevel updateAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;

        private Net.TheVpc.Upa.AccessLevel readAccessLevel = Net.TheVpc.Upa.AccessLevel.DEFAULT;

        private Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;

        private Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;

        private Net.TheVpc.Upa.ProtectionLevel readProtectionLevel = Net.TheVpc.Upa.ProtectionLevel.DEFAULT;

        private System.Collections.Generic.IDictionary<string , object> fieldParams;

        private Net.TheVpc.Upa.PropertyAccessType propertyAccessType;

        private int position = -1;

        public virtual string GetName() {
            return name;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual string GetPath() {
            return fieldPath;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPath(string fieldPath) {
            this.fieldPath = fieldPath;
            return this;
        }

        public virtual object GetDefaultObject() {
            return defaultObject;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetDefaultObject(object defaultObject) {
            this.defaultObject = defaultObject;
            return this;
        }

        public virtual object GetUnspecifiedObject() {
            return unspecifiedObject;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetUnspecifiedObject(object unspecifiedObject) {
            this.unspecifiedObject = unspecifiedObject;
            return this;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetDataType(Net.TheVpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
            return this;
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform() {
            return typeTransform;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetTypeTransform(Net.TheVpc.Upa.Types.DataTypeTransformConfig[] typeTransform) {
            this.typeTransform = typeTransform;
            return this;
        }

        public virtual Net.TheVpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPersistFormula(Net.TheVpc.Upa.Formula persistFormula) {
            this.persistFormula = persistFormula;
            return this;
        }

        public virtual Net.TheVpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetUpdateFormula(Net.TheVpc.Upa.Formula updateFormula) {
            this.updateFormula = updateFormula;
            return this;
        }

        public virtual Net.TheVpc.Upa.Formula GetSelectFormula() {
            return selectFormula;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetSelectFormula(Net.TheVpc.Upa.Formula selectFormula) {
            this.selectFormula = selectFormula;
            return this;
        }

        public virtual int GetPersistFormulaOrder() {
            return persistFormulaOrder;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPersistFormulaOrder(int persistFormulaOrder) {
            this.persistFormulaOrder = persistFormulaOrder;
            return this;
        }

        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetUpdateFormulaOrder(int updateFormulaOrder) {
            this.updateFormulaOrder = updateFormulaOrder;
            return this;
        }


        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetModifiers() {
            return userModifiers;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userModifiers) {
            this.userModifiers = userModifiers;
            return this;
        }


        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetExcludeModifiers() {
            return userExcludeModifiers;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userExcludeModifiers) {
            this.userExcludeModifiers = userExcludeModifiers;
            return this;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPersistAccessLevel(Net.TheVpc.Upa.AccessLevel persistAccessLevel) {
            this.persistAccessLevel = persistAccessLevel;
            return this;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel updateAccessLevel) {
            this.updateAccessLevel = updateAccessLevel;
            return this;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetReadAccessLevel(Net.TheVpc.Upa.AccessLevel readAccessLevel) {
            this.readAccessLevel = readAccessLevel;
            return this;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
            return this;
        }

        public virtual Net.TheVpc.Upa.ProtectionLevel GetPersistProtectionLevel() {
            return persistProtectionLevel;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPersistProtectionLevel(Net.TheVpc.Upa.ProtectionLevel persistProtectionLevel) {
            this.persistProtectionLevel = persistProtectionLevel;
            return this;
        }

        public virtual Net.TheVpc.Upa.ProtectionLevel GetUpdateProtectionLevel() {
            return updateProtectionLevel;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetUpdateProtectionLevel(Net.TheVpc.Upa.ProtectionLevel updateProtectionLevel) {
            this.updateProtectionLevel = updateProtectionLevel;
            return this;
        }

        public virtual Net.TheVpc.Upa.ProtectionLevel GetReadProtectionLevel() {
            return readProtectionLevel;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetReadProtectionLevel(Net.TheVpc.Upa.ProtectionLevel readProtectionLevel) {
            this.readProtectionLevel = readProtectionLevel;
            return this;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetProtectionLevel(Net.TheVpc.Upa.ProtectionLevel protectionLevel) {
            SetPersistProtectionLevel(protectionLevel);
            SetUpdateProtectionLevel(protectionLevel);
            SetReadProtectionLevel(protectionLevel);
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetFieldParams() {
            return fieldParams;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetFieldParams(System.Collections.Generic.IDictionary<string , object> fieldParams) {
            this.fieldParams = fieldParams;
            return this;
        }

        public virtual Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return propertyAccessType;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPropertyAccessType(Net.TheVpc.Upa.PropertyAccessType propertyAccessType) {
            this.propertyAccessType = propertyAccessType;
            return this;
        }

        public virtual int GetIndex() {
            return position;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetPosition(int position) {
            this.position = position;
            return this;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor SetFieldDescriptor(Net.TheVpc.Upa.FieldDescriptor other) {
            if (other == null) {
                other = new Net.TheVpc.Upa.DefaultFieldDescriptor();
            }
            SetName(other.GetName());
            SetPath(other.GetPath());
            SetDefaultObject(other.GetDefaultObject());
            SetUnspecifiedObject(other.GetUnspecifiedObject());
            SetDataType(other.GetDataType());
            SetTypeTransform(other.GetTypeTransform());
            SetPersistFormula(other.GetPersistFormula());
            SetUpdateFormula(other.GetUpdateFormula());
            SetSelectFormula(other.GetSelectFormula());
            SetPersistFormulaOrder(other.GetPersistFormulaOrder());
            SetUpdateFormulaOrder(other.GetUpdateFormulaOrder());
            SetModifiers(other.GetModifiers());
            SetExcludeModifiers(other.GetExcludeModifiers());
            SetPersistAccessLevel(other.GetPersistAccessLevel());
            SetUpdateAccessLevel(other.GetUpdateAccessLevel());
            SetReadAccessLevel(other.GetReadAccessLevel());
            SetPersistProtectionLevel(other.GetPersistProtectionLevel());
            SetUpdateProtectionLevel(other.GetUpdateProtectionLevel());
            SetReadProtectionLevel(other.GetReadProtectionLevel());
            SetFieldParams(other.GetFieldParams());
            SetPropertyAccessType(other.GetPropertyAccessType());
            SetPosition(other.GetIndex());
            return this;
        }

        public virtual Net.TheVpc.Upa.DefaultFieldDescriptor Merge(Net.TheVpc.Upa.FieldDescriptor other) {
            if (other == null) {
                other = new Net.TheVpc.Upa.DefaultFieldDescriptor();
            }
            if (other.GetName() != null) {
                SetName(other.GetName());
            }
            if (other.GetPath() != null) {
                SetPath(other.GetPath());
            }
            if (other.GetDefaultObject() != null) {
                SetDefaultObject(other.GetDefaultObject());
            }
            if (other.GetUnspecifiedObject() != null) {
                SetUnspecifiedObject(other.GetUnspecifiedObject());
            }
            if (other.GetDataType() != null) {
                SetDataType(other.GetDataType());
            }
            if (other.GetTypeTransform() != null) {
                SetTypeTransform(other.GetTypeTransform());
            }
            if (other.GetPersistFormula() != null) {
                SetPersistFormula(other.GetPersistFormula());
            }
            if (other.GetUpdateFormula() != null) {
                SetUpdateFormula(other.GetUpdateFormula());
            }
            if (other.GetSelectFormula() != null) {
                SetSelectFormula(other.GetSelectFormula());
            }
            if (other.GetPersistFormulaOrder() != 0) {
                SetPersistFormulaOrder(other.GetPersistFormulaOrder());
            }
            if (other.GetUpdateFormulaOrder() != 0) {
                SetUpdateFormulaOrder(other.GetUpdateFormulaOrder());
            }
            if (other.GetModifiers() != null) {
                SetModifiers(other.GetModifiers());
            }
            if (other.GetExcludeModifiers() != null) {
                SetExcludeModifiers(other.GetExcludeModifiers());
            }
            if (other.GetPersistAccessLevel() != default(Net.TheVpc.Upa.AccessLevel)) {
                SetPersistAccessLevel(other.GetPersistAccessLevel());
            }
            if (other.GetUpdateAccessLevel() != default(Net.TheVpc.Upa.AccessLevel)) {
                SetUpdateAccessLevel(other.GetUpdateAccessLevel());
            }
            if (other.GetReadAccessLevel() != default(Net.TheVpc.Upa.AccessLevel)) {
                SetReadAccessLevel(other.GetReadAccessLevel());
            }
            if (other.GetPersistProtectionLevel() != default(Net.TheVpc.Upa.ProtectionLevel)) {
                SetPersistProtectionLevel(other.GetPersistProtectionLevel());
            }
            if (other.GetUpdateProtectionLevel() != default(Net.TheVpc.Upa.ProtectionLevel)) {
                SetUpdateProtectionLevel(other.GetUpdateProtectionLevel());
            }
            if (other.GetReadProtectionLevel() != default(Net.TheVpc.Upa.ProtectionLevel)) {
                SetReadProtectionLevel(other.GetReadProtectionLevel());
            }
            if (other.GetFieldParams() != null) {
                SetFieldParams(other.GetFieldParams());
            }
            if (other.GetPropertyAccessType() != default(Net.TheVpc.Upa.PropertyAccessType)) {
                SetPropertyAccessType(other.GetPropertyAccessType());
            }
            if (other.GetIndex() != 0) {
                SetPosition(other.GetIndex());
            }
            return this;
        }
    }
}
