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



namespace Net.TheVpc.Upa.Impl
{


    public abstract class AbstractField : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Field, System.IComparable<object> {

        protected internal Net.TheVpc.Upa.Entity entity;

        protected internal Net.TheVpc.Upa.EntityPart parent;

        protected internal Net.TheVpc.Upa.Types.DataType dataType;

        protected internal Net.TheVpc.Upa.Formula persistFormula;

        protected internal int persistFormulaOrder;

        protected internal Net.TheVpc.Upa.Formula updateFormula;

        protected internal int updateFormulaOrder;

        protected internal Net.TheVpc.Upa.Formula queryFormula;

        protected internal object defaultObject;

        protected internal Net.TheVpc.Upa.SearchOperator searchOperator = Net.TheVpc.Upa.SearchOperator.DEFAULT;

        protected internal Net.TheVpc.Upa.Types.DataTypeTransform typeTransform;

        protected internal System.Collections.Generic.Dictionary<string , object> properties;

        protected internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();

        protected internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> userExcludeModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>();

        protected internal Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> effectiveModifiers = Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.FieldModifier>();

        protected internal bool closed;

        protected internal object unspecifiedValue = Net.TheVpc.Upa.UnspecifiedValue.DEFAULT;

        private Net.TheVpc.Upa.AccessLevel persistAccessLevel = Net.TheVpc.Upa.AccessLevel.PUBLIC;

        private Net.TheVpc.Upa.AccessLevel updateAccessLevel = Net.TheVpc.Upa.AccessLevel.PUBLIC;

        private Net.TheVpc.Upa.AccessLevel readAccessLevel = Net.TheVpc.Upa.AccessLevel.PUBLIC;

        private Net.TheVpc.Upa.Impl.FieldPersister fieldPersister;

        private Net.TheVpc.Upa.PropertyAccessType accessType;

        protected internal AbstractField() {
        }


        public override string GetAbsoluteName() {
            return (GetEntity() == null ? "?" : GetEntity().GetName()) + "." + GetName();
        }

        public virtual Net.TheVpc.Upa.EntityPart GetParent() {
            return parent;
        }

        public virtual void SetParent(Net.TheVpc.Upa.EntityPart item) {
            Net.TheVpc.Upa.EntityPart old = this.parent;
            this.parent = item;
            propertyChangeSupport.FirePropertyChange("parent", old, parent);
        }

        public virtual bool Is(Net.TheVpc.Upa.Filters.FieldFilter ff) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return ff.Accept(this);
        }

        public virtual bool IsId() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.ID);
        }

        public virtual bool IsMain() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.MAIN);
        }

        public virtual bool IsSummary() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.SUMMARY);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> GetManyToOneRelationships() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Relationship> relations = new System.Collections.Generic.List<Net.TheVpc.Upa.Relationship>();
            foreach (Net.TheVpc.Upa.Relationship r in GetPersistenceUnit().GetRelationshipsBySource(GetEntity())) {
                Net.TheVpc.Upa.Field entityField = r.GetSourceRole().GetEntityField();
                if (entityField != null && entityField.Equals(this)) {
                    relations.Add(r);
                } else {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields = r.GetSourceRole().GetFields();
                    foreach (Net.TheVpc.Upa.Field field in fields) {
                        if (field.Equals(this)) {
                            relations.Add(r);
                        }
                    }
                }
            }
            return relations;
        }

        public virtual void SetFormula(Net.TheVpc.Upa.Formula formula) {
            SetPersistFormula(formula);
            SetUpdateFormula(formula);
        }


        public virtual void SetFormula(string formula) {
            SetFormula(formula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetPersistFormula(Net.TheVpc.Upa.Formula formula) {
            this.persistFormula = formula;
        }


        public virtual void SetPersistFormula(string formula) {
            SetPersistFormula(formula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetUpdateFormula(Net.TheVpc.Upa.Formula formula) {
            this.updateFormula = formula;
        }


        public virtual void SetUpdateFormula(string formula) {
            SetUpdateFormula(formula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(formula));
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

        public virtual Net.TheVpc.Upa.Formula GetUpdateFormula() {
            return updateFormula;
        }

        public virtual Net.TheVpc.Upa.Formula GetSelectFormula() {
            return queryFormula;
        }


        public virtual void SetSelectFormula(string formula) {
            SetSelectFormula(formula == null ? null : new Net.TheVpc.Upa.ExpressionFormula(formula));
        }

        public virtual void SetSelectFormula(Net.TheVpc.Upa.Formula queryFormula) {
            this.queryFormula = queryFormula;
        }

        public virtual string GetPath() {
            Net.TheVpc.Upa.EntityPart parent = GetParent();
            return parent == null ? ("/" + GetName()) : (parent.GetPath() + "/" + GetName());
        }


        public override Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return entity.GetPersistenceUnit();
        }

        public virtual Net.TheVpc.Upa.Formula GetPersistFormula() {
            return persistFormula;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        /**
             * called by PersistenceUnitFilter / Table You should not use it
             *
             * @param datatype datatype
             */

        public virtual void SetDataType(Net.TheVpc.Upa.Types.DataType datatype) {
            this.dataType = datatype;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
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
            return _defaultValue != null ? (_defaultValue is Net.TheVpc.Upa.CustomDefaultObject) ? ((Net.TheVpc.Upa.CustomDefaultObject) _defaultValue).GetObject() : _defaultValue : null;
        }

        public virtual object GetDefaultObject() {
            return defaultObject;
        }

        public virtual void SetUserModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            this.userModifiers = modifiers == null ? Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>() : modifiers;
        }

        public virtual void SetUserExcludeModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> modifiers) {
            this.userExcludeModifiers = modifiers == null ? Net.TheVpc.Upa.FlagSets.NoneOf<Net.TheVpc.Upa.UserFieldModifier>() : modifiers;
        }

        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> GetModifiers() {
            return effectiveModifiers;
        }

        public virtual void SetEffectiveModifiers(Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> effectiveModifiers) {
            this.effectiveModifiers = effectiveModifiers;
        }


        public override bool Equals(object other) {
            return !(other == null || !(other is Net.TheVpc.Upa.Field)) && CompareTo(other) == 0;
        }

        public virtual int CompareTo(object other) {
            if (other == this) {
                return 0;
            }
            if (other == null) {
                return 1;
            }
            Net.TheVpc.Upa.Field f = (Net.TheVpc.Upa.Field) other;
            Net.TheVpc.Upa.NamingStrategy comp = GetEntity().GetPersistenceUnit().GetNamingStrategy();
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

        public virtual void SetEntity(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }


        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetUserModifiers() {
            return userModifiers;
        }


        public virtual Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.UserFieldModifier> GetUserExcludeModifiers() {
            return userExcludeModifiers;
        }


        public override string ToString() {
            return GetAbsoluteName();
        }


        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
            if (Net.TheVpc.Upa.UnspecifiedValue.DEFAULT.Equals(fuv)) {
                return GetDataType().GetDefaultUnspecifiedValue();
            } else {
                return fuv;
            }
        }

        public virtual bool IsUnspecifiedValue(object @value) {
            object v = GetUnspecifiedValueDecoded();
            return (v == @value || (v != null && v.Equals(@value)));
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetPersistAccessLevel() {
            return persistAccessLevel;
        }

        public virtual void SetPersistAccessLevel(Net.TheVpc.Upa.AccessLevel persistAccessLevel) {
            if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), persistAccessLevel)) {
                persistAccessLevel = Net.TheVpc.Upa.AccessLevel.PUBLIC;
            }
            this.persistAccessLevel = persistAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetUpdateAccessLevel() {
            return updateAccessLevel;
        }

        public virtual void SetUpdateAccessLevel(Net.TheVpc.Upa.AccessLevel updateAccessLevel) {
            if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), updateAccessLevel)) {
                updateAccessLevel = Net.TheVpc.Upa.AccessLevel.PUBLIC;
            }
            this.updateAccessLevel = updateAccessLevel;
        }

        public virtual Net.TheVpc.Upa.AccessLevel GetReadAccessLevel() {
            return readAccessLevel;
        }

        public virtual void SetReadAccessLevel(Net.TheVpc.Upa.AccessLevel readAccessLevel) {
            if (Net.TheVpc.Upa.Impl.Util.PlatformUtils.IsUndefinedValue<Net.TheVpc.Upa.AccessLevel>(typeof(Net.TheVpc.Upa.AccessLevel), readAccessLevel)) {
                readAccessLevel = Net.TheVpc.Upa.AccessLevel.PUBLIC;
            }
            this.readAccessLevel = readAccessLevel;
        }

        public virtual void SetAccessLevel(Net.TheVpc.Upa.AccessLevel accessLevel) {
            SetPersistAccessLevel(accessLevel);
            SetUpdateAccessLevel(accessLevel);
            SetReadAccessLevel(accessLevel);
        }

        public virtual Net.TheVpc.Upa.SearchOperator GetSearchOperator() {
            return searchOperator;
        }

        public virtual void SetSearchOperator(Net.TheVpc.Upa.SearchOperator searchOperator) {
            this.searchOperator = searchOperator;
        }

        public virtual Net.TheVpc.Upa.Impl.FieldPersister GetFieldPersister() {
            return fieldPersister;
        }

        public virtual void SetFieldPersister(Net.TheVpc.Upa.Impl.FieldPersister fieldPersister) {
            this.fieldPersister = fieldPersister;
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return typeTransform;
        }

        public virtual void SetTypeTransform(Net.TheVpc.Upa.Types.DataTypeTransform transform) {
            this.typeTransform = transform;
        }

        public virtual Net.TheVpc.Upa.PropertyAccessType GetPropertyAccessType() {
            return accessType;
        }

        public virtual void SetPropertyAccessType(Net.TheVpc.Upa.PropertyAccessType accessType) {
            this.accessType = accessType;
        }


        public virtual object GetMainValue(object instance) {
            object v = GetValue(instance);
            if (v != null) {
                Net.TheVpc.Upa.Types.DataType d = GetDataType();
                if (d is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType ed = (Net.TheVpc.Upa.Types.ManyToOneType) d;
                    v = ed.GetRelationship().GetTargetEntity().GetBuilder().GetMainValue(v);
                }
            }
            return v;
        }


        public virtual object GetValue(object instance) {
            if (instance is Net.TheVpc.Upa.Record) {
                return ((Net.TheVpc.Upa.Record) instance).GetObject<T>(GetName());
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
