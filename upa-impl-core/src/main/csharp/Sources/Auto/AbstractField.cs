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

        protected internal Net.Vpc.Upa.Formula persistFormula;

        protected internal int persistFormulaOrder;

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

        private Net.Vpc.Upa.AccessLevel persistAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;

        private Net.Vpc.Upa.AccessLevel updateAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;

        private Net.Vpc.Upa.AccessLevel readAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;

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

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> GetManyToOneRelationships() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Relationship> relations = new System.Collections.Generic.List<Net.Vpc.Upa.Relationship>();
            foreach (Net.Vpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsBySource(GetEntity())) {
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
            SetPersistFormula(formula);
            SetUpdateFormula(formula);
        }


        public virtual void SetFormula(string formula) {
            SetFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetPersistFormula(Net.Vpc.Upa.Formula formula) {
            this.persistFormula = formula;
        }


        public virtual void SetPersistFormula(string formula) {
            SetPersistFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetUpdateFormula(Net.Vpc.Upa.Formula formula) {
            this.updateFormula = formula;
        }


        public virtual void SetUpdateFormula(string formula) {
            SetUpdateFormula(formula == null ? null : new Net.Vpc.Upa.ExpressionFormula(formula));
        }


        public virtual void SetFormulaOrder(int order) {
            SetPersistFormulaOrder(order);
            SetUpdateFormulaOrder(order);
        }


        public virtual void SetPersistFormulaOrder(int order) {
            this.persistFormulaOrder = order;
        }


        public virtual void SetUpdateFormulaOrder(int order) {
            this.updateFormulaOrder = order;
        }

        public virtual int GetUpdateFormulaOrder() {
            return updateFormulaOrder;
        }

        public virtual int GetPersistFormulaOrder() {
            return persistFormulaOrder;
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

        public virtual Net.Vpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
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

        public virtual Net.Vpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual void SetPersistAccessLevel(Net.Vpc.Upa.AccessLevel persistAccessLevel) {
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), persistAccessLevel)) {
                persistAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;
            }
            this.persistAccessLevel = persistAccessLevel;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual void SetUpdateAccessLevel(Net.Vpc.Upa.AccessLevel updateAccessLevel) {
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), updateAccessLevel)) {
                updateAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;
            }
            this.updateAccessLevel = updateAccessLevel;
        }

        public virtual Net.Vpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }

        public virtual void SetReadAccessLevel(Net.Vpc.Upa.AccessLevel readAccessLevel) {
            if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.Vpc.Upa.AccessLevel>(typeof(Net.Vpc.Upa.AccessLevel), readAccessLevel)) {
                readAccessLevel = Net.Vpc.Upa.AccessLevel.PUBLIC;
            }
            this.readAccessLevel = readAccessLevel;
        }

        public virtual void SetAccessLevel(Net.Vpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
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


        public virtual object GetMainValue(object instance) {
            object v = GetValue(instance);
            if (v != null) {
                Net.Vpc.Upa.Types.DataType d = GetDataType();
                if (d is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Types.ManyToOneType ed = (Net.Vpc.Upa.Types.ManyToOneType) d;
                    v = ed.GetRelationship().GetTargetEntity().GetBuilder().GetMainValue(v);
                }
            }
            return v;
        }


        public virtual object GetValue(object instance) {
            if (instance is Net.Vpc.Upa.Record) {
                return ((Net.Vpc.Upa.Record) instance).GetObject<T>(GetName());
            }
            return GetEntity().GetBuilder().GetProperty(instance, GetName());
        }


        public virtual void SetValue(object instance, object @value) {
            GetEntity().GetBuilder().SetProperty(instance, GetName(), @value);
        }


        public virtual void Check(object @value) {
            GetDataType().Check(@value, GetName(), null);
        }
    }
}
