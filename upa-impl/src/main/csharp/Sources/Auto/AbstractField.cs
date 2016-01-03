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



namespace Net.Vpc.Upa.Impl
{


    public abstract class AbstractField : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Field, System.IComparable<object> {

        protected internal Net.Vpc.Upa.Entity entity;

        protected internal Net.Vpc.Upa.EntityPart parent;

        protected internal Net.Vpc.Upa.Types.DataType dataType;

        protected internal Net.Vpc.Upa.Formula insertFormula;

        protected internal int insertFormulaOrder;

        protected internal Net.Vpc.Upa.Formula updateFormula;

        protected internal int updateFormulaOrder;

        protected internal Net.Vpc.Upa.Formula queryFormula;

        protected internal object defaultObject;

        protected internal Net.Vpc.Upa.SearchOperator searchOperator = Net.Vpc.Upa.SearchOperator.DEFAULT;

        protected internal Net.Vpc.Upa.Types.DataTypeTransform typeTransform;

        protected internal System.Collections.Generic.Dictionary<string , object> properties;

        protected internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();

        protected internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> userExcludeModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>();

        protected internal Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> effectiveModifiers = Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.FieldModifier>();

        protected internal bool closed;

        protected internal object unspecifiedValue = Net.Vpc.Upa.UnspecifiedValue.DEFAULT;

        private Net.Vpc.Upa.Relationship[] rightsRelations = new Net.Vpc.Upa.Relationship[0];

        private Net.Vpc.Upa.AccessLevel insertAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;

        private Net.Vpc.Upa.AccessLevel updateAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;

        private Net.Vpc.Upa.AccessLevel selectAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;

        private Net.Vpc.Upa.Impl.FieldPersister fieldPersister;

        private Net.Vpc.Upa.PropertyAccessType accessType;

        protected internal AbstractField() {
        }


        public override string GetAbsoluteName() {
            return (GetEntity() == null ? "?" : GetEntity().GetName()) + "." + GetName();
        }

        public virtual Net.Vpc.Upa.EntityPart GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.Vpc.Upa.EntityPart item) {
            Net.Vpc.Upa.EntityPart old = this.parent;
            this.parent = item;
            propertyChangeSupport.FirePropertyChange("parent", old, parent);
        }

        public virtual bool Is(Net.Vpc.Upa.Filters.FieldFilter ff) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return ff.Accept(this);
        }

        public virtual bool IsId() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.ID);
        }

        public virtual bool IsMain() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.MAIN);
        }

        public virtual bool IsSummary() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.SUMMARY);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetRelationships() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> relations = new System.Collections.Generic.List<Net.Vpc.Upa.Relationship>();
            foreach (Net.Vpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsForSource(GetEntity())) {
                Net.Vpc.Upa.Field entityField = r.GetSourceRole().GetEntityField();
                if (entityField != null && entityField.Equals(this)) {
                    relations.Add(r);
                } else {
                    System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = r.GetSourceRole().GetFields();
                    foreach (Net.Vpc.Upa.Field field in fields) {
                        if (field.Equals(this)) {
                            relations.Add(r);
                        }
                    }
                }
            }
            return relations;
        }

        public virtual void SetFormula(Net.Vpc.Upa.Formula formula) {
            SetInsertFormula(formula);
            SetUpdateFormula(formula);
        }


        public virtual void SetFormula(string formula) {
            SetFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetInsertFormula(Net.Vpc.Upa.Formula formula) {
            this.insertFormula = formula;
        }


        public virtual void SetInsertFormula(string formula) {
            SetInsertFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetUpdateFormula(Net.Vpc.Upa.Formula formula) {
            this.updateFormula = formula;
        }


        public virtual void SetUpdateFormula(string formula) {
            SetUpdateFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }


        public virtual void SetFormulaOrder(int order) {
            SetInsertFormulaOrder(order);
            SetUpdateFormulaOrder(order);
        }


        public virtual void SetInsertFormulaOrder(int order) {
            this.insertFormulaOrder = order;
        }


        public virtual void SetUpdateFormulaOrder(int order) {
            this.updateFormulaOrder = order;
        }

        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }

        public virtual int GetInsertFormulaOrder() {
            return insertFormulaOrder;
        }

        public virtual Net.Vpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.Vpc.Upa.Formula GetSelectFormula() {
            return queryFormula;
        }


        public virtual void SetSelectFormula(string formula) {
            SetSelectFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetSelectFormula(Net.Vpc.Upa.Formula queryFormula) {
            this.queryFormula = queryFormula;
        }

        public virtual string GetPath() {
            Net.Vpc.Upa.EntityPart parent = GetParent();
            return parent == null ? ("/" + GetName()) : (parent.GetPath() + "/" + GetName());
        }


        public override Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return entity.GetPersistenceUnit();
        }

        public virtual Net.Vpc.Upa.Formula GetInsertFormula() {
            return insertFormula;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        /**
             * called by PersistenceUnitFilter / Table You should not use it
             *
             * @param datatype datatype
             */

        public virtual void SetDataType(Net.Vpc.Upa.Types.DataType datatype) {
            this.dataType = datatype;
        }

        public virtual Net.Vpc.Upa.Types.DataType GetDataType() {
            return dataType;
        }

        /**
             * called by PersistenceUnitFilter / Table You should not use it
             *
             * @param o default value witch may be san ObjectHandler
             */
        public virtual void SetDefaultObject(object o) {
            defaultObject = o;
        }

        public virtual object GetDefaultValue() {
            object _defaultValue = GetDefaultObject();
            return _defaultValue != null ? (_defaultValue is Net.Vpc.Upa.CustomDefaultObject) ? ((Net.Vpc.Upa.CustomDefaultObject) _defaultValue).GetObject() : _defaultValue : null;
        }

        public virtual object GetDefaultObject() {
            return defaultObject;
        }

        public virtual void SetUserModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            this.userModifiers = modifiers == null ? Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>() : modifiers;
        }

        public virtual void SetUserExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> modifiers) {
            this.userExcludeModifiers = modifiers == null ? Net.Vpc.Upa.FlagSets.NoneOf<Net.Vpc.Upa.UserFieldModifier>() : modifiers;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> GetModifiers() {
            return effectiveModifiers;
        }

        public virtual void SetEffectiveModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> effectiveModifiers) {
            this.effectiveModifiers = effectiveModifiers;
        }


        public override bool Equals(object other) {
            return !(other == null || !(other is Net.Vpc.Upa.Field)) && CompareTo(other) == 0;
        }

        public virtual int CompareTo(object other) {
            if (other == this) {
                return 0;
            }
            if (other == null) {
                return 1;
            }
            Net.Vpc.Upa.Field f = (Net.Vpc.Upa.Field) other;
            Net.Vpc.Upa.NamingStrategy comp = GetEntity().GetPersistenceUnit().GetNamingStrategy();
            string s1 = entity != null ? comp.GetUniformValue(entity.GetName()) : "";
            string s2 = f.GetName() != null ? comp.GetUniformValue(f.GetEntity().GetName()) : "";
            int i = s1.CompareTo(s2);
            if (i != 0) {
                return i;
            } else {
                string s3 = GetName() != null ? comp.GetUniformValue(GetName()) : "";
                string s4 = f.GetName() != null ? comp.GetUniformValue(f.GetName()) : "";
                i = s3.CompareTo(s4);
                return i;
            }
        }

        /**
             * called by PersistenceUnitFilter You should not use it
             *
             * @param r relation
             */
        public virtual void AddTargetRelationship(Net.Vpc.Upa.Relationship r) {
            int max = rightsRelations.Length;
            for (int i = 0; i < rightsRelations.Length; i++) {
                Net.Vpc.Upa.Relationship relation = rightsRelations[i];
                if (relation.Equals(r)) {
                    return;
                }
            }
            Net.Vpc.Upa.Relationship[] rr = new Net.Vpc.Upa.Relationship[max + 1];
            System.Array.Copy(rightsRelations, 0, rr, 0, max);
            rr[max] = r;
            rightsRelations = rr;
        }

        public virtual Net.Vpc.Upa.Relationship[] GetTargetRelationships() {
            return rightsRelations;
        }

        public virtual void SetEntity(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserModifiers() {
            return userModifiers;
        }


        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.UserFieldModifier> GetUserExcludeModifiers() {
            return userExcludeModifiers;
        }


        public override string ToString() {
            return GetAbsoluteName();
        }


        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            this.closed = true;
        }

        public virtual bool IsClosed() {
            return closed;
        }


        public virtual void SetUnspecifiedValue(object o) {
            this.unspecifiedValue = o;
        }


        public virtual object GetUnspecifiedValue() {
            return unspecifiedValue;
        }

        public virtual object GetUnspecifiedValueDecoded() {
            object fuv = GetUnspecifiedValue();
            if (Net.Vpc.Upa.UnspecifiedValue.DEFAULT.Equals(fuv)) {
                return GetDataType().GetDefaultUnspecifiedValue();
            } else {
                return fuv;
            }
        }

        public virtual bool IsUnspecifiedValue(object @value) {
            object v = GetUnspecifiedValueDecoded();
            return (v == @value || (v != null && v.Equals(@value)));
        }

        public virtual Net.Vpc.Upa.AccessLevel GetInsertAccessLevel() {
            return insertAccessLevel;
        }

        public virtual void SetInsertAccessLevel(Net.Vpc.Upa.AccessLevel insertAccessLevel) {
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), insertAccessLevel) || insertAccessLevel == Net.Vpc.Upa.AccessLevel.DEFAULT) {
                insertAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;
            }
            this.insertAccessLevel = insertAccessLevel;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual void SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel updateAccessLevel) {
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), updateAccessLevel) || updateAccessLevel == Net.Vpc.Upa.AccessLevel.DEFAULT) {
                updateAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;
            }
            this.updateAccessLevel = updateAccessLevel;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetSelectAccessLevel() {
            return selectAccessLevel;
        }

        public virtual void SetSelectAccessLevel(Net.Vpc.Upa.AccessLevel selectAccessLevel) {
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), selectAccessLevel) || selectAccessLevel == Net.Vpc.Upa.AccessLevel.DEFAULT) {
                selectAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;
            }
            this.selectAccessLevel = selectAccessLevel;
        }

        public virtual void SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel) {
            SetInsertAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetSelectAccessLevel(accessLevel);
        }

        public virtual Net.Vpc.Upa.SearchOperator GetSearchOperator() {
            return searchOperator;
        }

        public virtual void SetSearchOperator(Net.Vpc.Upa.SearchOperator searchOperator) {
            this.searchOperator = searchOperator;
        }

        public virtual Net.Vpc.Upa.Impl.FieldPersister GetFieldPersister() {
            return fieldPersister;
        }

        public virtual void SetFieldPersister(Net.Vpc.Upa.Impl.FieldPersister fieldPersister) {
            this.fieldPersister = fieldPersister;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return typeTransform;
        }

        public virtual void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform transform) {
            this.typeTransform = transform;
        }

        public virtual Net.Vpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return accessType;
        }

        public virtual void SetPropertyAccessType(Net.Vpc.Upa.PropertyAccessType accessType) {
            this.accessType = accessType;
        }
    }
}
