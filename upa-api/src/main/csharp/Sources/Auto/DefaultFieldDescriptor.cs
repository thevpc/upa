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
     * @author taha.bensalah@gmail.com
     */
    public class DefaultFieldDescriptor : Net.Vpc.Upa.FieldDescriptor {

        private string name;

        private string fieldPath;

        private object defaultObject;

        private object unspecifiedObject;

        private Net.Vpc.Upa.Types.DataType dataType;

        private Net.Vpc.Upa.Types.DataTypeTransformConfig[] typeTransform;

        private Net.Vpc.Upa.Formula persistFormula;

        private Net.Vpc.Upa.Formula updateFormula;

        private Net.Vpc.Upa.Formula selectFormula;

        private int persistFormulaOrder;

        private int updateFormulaOrder;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers;

        private Net.Vpc.Upa.AccessLevel persistAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.AccessLevel updateAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.AccessLevel readAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.ProtectionLevel persistProtectionLevel = Net.Vpc.Upa.ProtectionLevel.DEFAULT;

        private Net.Vpc.Upa.ProtectionLevel updateProtectionLevel = Net.Vpc.Upa.ProtectionLevel.DEFAULT;

        private Net.Vpc.Upa.ProtectionLevel readProtectionLevel = Net.Vpc.Upa.ProtectionLevel.DEFAULT;

        private System.Collections.Generic.IDictionary<string , object> fieldParams;

        private Net.Vpc.Upa.PropertyAccessType propertyAccessType;

        private int position = -1;

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual string GetPath() {
            return fieldPath;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPath(string fieldPath) {
            this.fieldPath = fieldPath;
            return this;
        }

        public virtual object GetDefaultObject() {
            return defaultObject;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetDefaultObject(object defaultObject) {
            this.defaultObject = defaultObject;
            return this;
        }

        public virtual object GetUnspecifiedObject() {
            return unspecifiedObject;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUnspecifiedObject(object unspecifiedObject) {
            this.unspecifiedObject = unspecifiedObject;
            return this;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetDataType(Net.Vpc.Upa.Types.DataType dataType) {
            this.dataType = dataType;
            return this;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransformConfig[] GetTypeTransform() {
            return typeTransform;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransformConfig[] typeTransform) {
            this.typeTransform = typeTransform;
            return this;
        }

        public virtual Net.Vpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPersistFormula(Net.Vpc.Upa.Formula persistFormula) {
            this.persistFormula = persistFormula;
            return this;
        }

        public virtual Net.Vpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUpdateFormula(Net.Vpc.Upa.Formula updateFormula) {
            this.updateFormula = updateFormula;
            return this;
        }

        public virtual Net.Vpc.Upa.Formula GetSelectFormula() {
            return selectFormula;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetSelectFormula(Net.Vpc.Upa.Formula selectFormula) {
            this.selectFormula = selectFormula;
            return this;
        }

        public virtual int GetPersistFormulaOrder() {
            return persistFormulaOrder;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPersistFormulaOrder(int persistFormulaOrder) {
            this.persistFormulaOrder = persistFormulaOrder;
            return this;
        }

        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUpdateFormulaOrder(int updateFormulaOrder) {
            this.updateFormulaOrder = updateFormulaOrder;
            return this;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetModifiers() {
            return userModifiers;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers) {
            this.userModifiers = userModifiers;
            return this;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetExcludeModifiers() {
            return userExcludeModifiers;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers) {
            this.userExcludeModifiers = userExcludeModifiers;
            return this;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPersistAccessLevel(Net.Vpc.Upa.AccessLevel persistAccessLevel) {
            this.persistAccessLevel = persistAccessLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel updateAccessLevel) {
            this.updateAccessLevel = updateAccessLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetReadAccessLevel(Net.Vpc.Upa.AccessLevel readAccessLevel) {
            this.readAccessLevel = readAccessLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
            return this;
        }

        public virtual Net.Vpc.Upa.ProtectionLevel GetPersistProtectionLevel() {
            return persistProtectionLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPersistProtectionLevel(Net.Vpc.Upa.ProtectionLevel persistProtectionLevel) {
            this.persistProtectionLevel = persistProtectionLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.ProtectionLevel GetUpdateProtectionLevel() {
            return updateProtectionLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUpdateProtectionLevel(Net.Vpc.Upa.ProtectionLevel updateProtectionLevel) {
            this.updateProtectionLevel = updateProtectionLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.ProtectionLevel GetReadProtectionLevel() {
            return readProtectionLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetReadProtectionLevel(Net.Vpc.Upa.ProtectionLevel readProtectionLevel) {
            this.readProtectionLevel = readProtectionLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetProtectionLevel(Net.Vpc.Upa.ProtectionLevel protectionLevel) {
            SetPersistProtectionLevel(protectionLevel);
            SetUpdateProtectionLevel(protectionLevel);
            SetReadProtectionLevel(protectionLevel);
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetFieldParams() {
            return fieldParams;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetFieldParams(System.Collections.Generic.IDictionary<string , object> fieldParams) {
            this.fieldParams = fieldParams;
            return this;
        }

        public virtual Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return propertyAccessType;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPropertyAccessType(Net.Vpc.Upa.PropertyAccessType propertyAccessType) {
            this.propertyAccessType = propertyAccessType;
            return this;
        }

        public virtual int GetIndex() {
            return position;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetPosition(int position) {
            this.position = position;
            return this;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetFieldDescriptor(Net.Vpc.Upa.FieldDescriptor other) {
            if (other == null) {
                other = new Net.Vpc.Upa.DefaultFieldDescriptor();
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

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor Merge(Net.Vpc.Upa.FieldDescriptor other) {
            if (other == null) {
                other = new Net.Vpc.Upa.DefaultFieldDescriptor();
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
            if (other.GetPersistAccessLevel() != default(Net.Vpc.Upa.AccessLevel)) {
                SetPersistAccessLevel(other.GetPersistAccessLevel());
            }
            if (other.GetUpdateAccessLevel() != default(Net.Vpc.Upa.AccessLevel)) {
                SetUpdateAccessLevel(other.GetUpdateAccessLevel());
            }
            if (other.GetReadAccessLevel() != default(Net.Vpc.Upa.AccessLevel)) {
                SetReadAccessLevel(other.GetReadAccessLevel());
            }
            if (other.GetPersistProtectionLevel() != default(Net.Vpc.Upa.ProtectionLevel)) {
                SetPersistProtectionLevel(other.GetPersistProtectionLevel());
            }
            if (other.GetUpdateProtectionLevel() != default(Net.Vpc.Upa.ProtectionLevel)) {
                SetUpdateProtectionLevel(other.GetUpdateProtectionLevel());
            }
            if (other.GetReadProtectionLevel() != default(Net.Vpc.Upa.ProtectionLevel)) {
                SetReadProtectionLevel(other.GetReadProtectionLevel());
            }
            if (other.GetFieldParams() != null) {
                SetFieldParams(other.GetFieldParams());
            }
            if (other.GetPropertyAccessType() != default(Net.Vpc.Upa.PropertyAccessType)) {
                SetPropertyAccessType(other.GetPropertyAccessType());
            }
            if (other.GetIndex() != 0) {
                SetPosition(other.GetIndex());
            }
            return this;
        }
    }
}
