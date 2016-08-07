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



namespace Net.Vpc.Upa
{


    /**
     *
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

        private System.Collections.Generic.IDictionary<string , object> fieldParams;

        private Net.Vpc.Upa.PropertyAccessType propertyAccessType;

        private int position;

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual string GetFieldPath() {
            return fieldPath;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetFieldPath(string fieldPath) {
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


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserFieldModifiers() {
            return userModifiers;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUserFieldModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers) {
            this.userModifiers = userModifiers;
            return this;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserExcludeModifiers() {
            return userExcludeModifiers;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers) {
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

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
            return this;
        }

        public virtual int GetPosition() {
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
            SetFieldPath(other.GetFieldPath());
            SetDefaultObject(other.GetDefaultObject());
            SetUnspecifiedObject(other.GetUnspecifiedObject());
            SetDataType(other.GetDataType());
            SetTypeTransform(other.GetTypeTransform());
            SetPersistFormula(other.GetPersistFormula());
            SetUpdateFormula(other.GetUpdateFormula());
            SetSelectFormula(other.GetSelectFormula());
            SetPersistFormulaOrder(other.GetPersistFormulaOrder());
            SetUpdateFormulaOrder(other.GetUpdateFormulaOrder());
            SetUserFieldModifiers(other.GetUserFieldModifiers());
            SetUserExcludeModifiers(other.GetUserExcludeModifiers());
            SetPersistAccessLevel(other.GetPersistAccessLevel());
            SetUpdateAccessLevel(other.GetUpdateAccessLevel());
            SetReadAccessLevel(other.GetReadAccessLevel());
            SetFieldParams(other.GetFieldParams());
            SetPropertyAccessType(other.GetPropertyAccessType());
            SetPosition(other.GetPosition());
            return this;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor Merge(Net.Vpc.Upa.FieldDescriptor other) {
            if (other == null) {
                other = new Net.Vpc.Upa.DefaultFieldDescriptor();
            }
            if (other.GetName() != null) {
                SetName(other.GetName());
            }
            if (other.GetFieldPath() != null) {
                SetFieldPath(other.GetFieldPath());
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
            if (other.GetUserFieldModifiers() != null) {
                SetUserFieldModifiers(other.GetUserFieldModifiers());
            }
            if (other.GetUserExcludeModifiers() != null) {
                SetUserExcludeModifiers(other.GetUserExcludeModifiers());
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
            if (other.GetFieldParams() != null) {
                SetFieldParams(other.GetFieldParams());
            }
            if (other.GetPropertyAccessType() != default(Net.Vpc.Upa.PropertyAccessType)) {
                SetPropertyAccessType(other.GetPropertyAccessType());
            }
            if (other.GetPosition() != 0) {
                SetPosition(other.GetPosition());
            }
            return this;
        }
    }
}
