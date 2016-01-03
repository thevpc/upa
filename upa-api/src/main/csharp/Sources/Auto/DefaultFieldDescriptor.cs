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
     * @author vpc
     */
    public class DefaultFieldDescriptor : Net.Vpc.Upa.FieldDescriptor {

        private string name;

        private string fieldPath;

        private object defaultObject;

        private object unspecifiedObject;

        private Net.Vpc.Upa.Types.DataType dataType;

        private Net.Vpc.Upa.Types.DataTypeTransformConfig[] typeTransform;

        private Net.Vpc.Upa.Formula insertFormula;

        private Net.Vpc.Upa.Formula updateFormula;

        private Net.Vpc.Upa.Formula selectFormula;

        private int insertFormulaOrder;

        private int updateFormulaOrder;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers;

        private Net.Vpc.Upa.AccessLevel insertAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.AccessLevel updateAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

        private Net.Vpc.Upa.AccessLevel selectAccessLevel = Net.Vpc.Upa.AccessLevel.DEFAULT;

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

        public virtual Net.Vpc.Upa.Formula GetInsertFormula() {
            return insertFormula;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetInsertFormula(Net.Vpc.Upa.Formula insertFormula) {
            this.insertFormula = insertFormula;
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

        public virtual int GetInsertFormulaOrder() {
            return insertFormulaOrder;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetInsertFormulaOrder(int insertFormulaOrder) {
            this.insertFormulaOrder = insertFormulaOrder;
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

        public virtual Net.Vpc.Upa.AccessLevel GetInsertAccessLevel() {
            return insertAccessLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetInsertAccessLevel(Net.Vpc.Upa.AccessLevel insertAccessLevel) {
            this.insertAccessLevel = insertAccessLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel updateAccessLevel) {
            this.updateAccessLevel = updateAccessLevel;
            return this;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetSelectAccessLevel() {
            return selectAccessLevel;
        }

        public virtual Net.Vpc.Upa.DefaultFieldDescriptor SetSelectAccessLevel(Net.Vpc.Upa.AccessLevel selectAccessLevel) {
            this.selectAccessLevel = selectAccessLevel;
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
            SetInsertAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetSelectAccessLevel(accessLevel);
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
            SetInsertFormula(other.GetInsertFormula());
            SetUpdateFormula(other.GetUpdateFormula());
            SetSelectFormula(other.GetSelectFormula());
            SetInsertFormulaOrder(other.GetInsertFormulaOrder());
            SetUpdateFormulaOrder(other.GetUpdateFormulaOrder());
            SetUserFieldModifiers(other.GetUserFieldModifiers());
            SetUserExcludeModifiers(other.GetUserExcludeModifiers());
            SetInsertAccessLevel(other.GetInsertAccessLevel());
            SetUpdateAccessLevel(other.GetUpdateAccessLevel());
            SetSelectAccessLevel(other.GetSelectAccessLevel());
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
            if (other.GetInsertFormula() != null) {
                SetInsertFormula(other.GetInsertFormula());
            }
            if (other.GetUpdateFormula() != null) {
                SetUpdateFormula(other.GetUpdateFormula());
            }
            if (other.GetSelectFormula() != null) {
                SetSelectFormula(other.GetSelectFormula());
            }
            if (other.GetInsertFormulaOrder() != 0) {
                SetInsertFormulaOrder(other.GetInsertFormulaOrder());
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
            if (other.GetInsertAccessLevel() != null) {
                SetInsertAccessLevel(other.GetInsertAccessLevel());
            }
            if (other.GetUpdateAccessLevel() != null) {
                SetUpdateAccessLevel(other.GetUpdateAccessLevel());
            }
            if (other.GetSelectAccessLevel() != null) {
                SetSelectAccessLevel(other.GetSelectAccessLevel());
            }
            if (other.GetFieldParams() != null) {
                SetFieldParams(other.GetFieldParams());
            }
            if (other.GetPropertyAccessType() != null) {
                SetPropertyAccessType(other.GetPropertyAccessType());
            }
            if (other.GetPosition() != 0) {
                SetPosition(other.GetPosition());
            }
            return this;
        }
    }
}
