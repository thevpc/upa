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


    /**
     * Created by vpc on 6/12/16.
     */
    public class DefaultUpdateQuery : Net.TheVpc.Upa.UpdateQuery {

        private Net.TheVpc.Upa.Impl.DefaultEntity entity;

        private Net.TheVpc.Upa.ConditionType updateConditionType = Net.TheVpc.Upa.ConditionType.EXPRESSION;

        private object updateCondition;

        private object updatesValue;

        private bool ignoreUnspecified;

        private System.Collections.Generic.ISet<string> partialUpdateFields;

        private Net.TheVpc.Upa.Filters.FieldFilter formulaFieldsFilter;

        private System.Collections.Generic.IDictionary<string , object> hints;

        public DefaultUpdateQuery(Net.TheVpc.Upa.Impl.DefaultEntity entity) {
            this.entity = entity;
        }

        public virtual Net.TheVpc.Upa.UpdateQuery SetNone() {
            return SetUpdates(null);
        }

        public virtual Net.TheVpc.Upa.UpdateQuery SetValues(Net.TheVpc.Upa.Record record) {
            return SetUpdates(record);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ById(object expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.ID, expr);
        }


        public virtual  Net.TheVpc.Upa.UpdateQuery ByIdList<T>(System.Collections.Generic.IList<T> expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.ID_LIST, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByKey(Net.TheVpc.Upa.Key expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.KEY, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByObject(object expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.OBJECT, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByPrototype(object expr) {
            if (expr is Net.TheVpc.Upa.Record) {
                return SetCondition(Net.TheVpc.Upa.ConditionType.RECORD_PROTOTYPE, expr);
            } else {
                return SetCondition(Net.TheVpc.Upa.ConditionType.PROTOTYPE, expr);
            }
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByRecord(Net.TheVpc.Upa.Record expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.RECORD, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByPrototype(Net.TheVpc.Upa.Record expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.RECORD_PROTOTYPE, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByKeyList(System.Collections.Generic.IList<Net.TheVpc.Upa.Key> expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.ID_LIST, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByExpressionList(System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.EXPRESSION_LIST, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByExpression(Net.TheVpc.Upa.Expressions.Expression expr) {
            return SetCondition(Net.TheVpc.Upa.ConditionType.EXPRESSION, expr);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ByAll() {
            return SetCondition(Net.TheVpc.Upa.ConditionType.EXPRESSION, null);
        }

        private Net.TheVpc.Upa.UpdateQuery SetUpdates(object updatesValue) {
            this.updatesValue = updatesValue;
            return this;
        }

        private Net.TheVpc.Upa.UpdateQuery SetCondition(Net.TheVpc.Upa.ConditionType updateConditionType, object updateCondition) {
            this.updateConditionType = updateConditionType;
            this.updateCondition = updateCondition;
            return this;
        }


        public virtual Net.TheVpc.Upa.ConditionType GetUpdateConditionType() {
            return updateConditionType;
        }


        public virtual object GetUpdateCondition() {
            return updateCondition;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetHints(bool autoCreate) {
            if (hints == null && autoCreate) {
                hints = new System.Collections.Generic.Dictionary<string , object>();
            }
            return hints;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            this.hints = hints;
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery SetHint(string name, object @value) {
            if (@value == null) {
                if (hints != null) {
                    hints.Remove(name);
                }
            } else {
                if (hints == null) {
                    hints = new System.Collections.Generic.Dictionary<string , object>();
                }
                hints[name]=@value;
            }
            return this;
        }


        public virtual object GetValues() {
            return updatesValue;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery SetValues(object updatesValue) {
            this.updatesValue = updatesValue;
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery AddUpdatableField(string name) {
            if (partialUpdateFields == null) {
                partialUpdateFields = new System.Collections.Generic.HashSet<string>();
            }
            partialUpdateFields.Add(name);
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery RemoveUpdatableField(string name) {
            if (partialUpdateFields != null) {
                partialUpdateFields.Remove(name);
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery AddUpdatableFields(params string [] names) {
            return AddUpdatableFields(new System.Collections.Generic.List<string>(names));
        }


        public virtual Net.TheVpc.Upa.UpdateQuery RemoveUpdatableFields(params string [] names) {
            return RemoveUpdatableFields(new System.Collections.Generic.List<string>(names));
        }


        public virtual Net.TheVpc.Upa.UpdateQuery AddUpdatableFields(System.Collections.Generic.ICollection<string> names) {
            if (partialUpdateFields == null) {
                partialUpdateFields = new System.Collections.Generic.HashSet<string>();
            }
            Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(partialUpdateFields, names);
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery RemoveUpdatableFields(System.Collections.Generic.ICollection<string> names) {
            if (partialUpdateFields != null) {
                Net.TheVpc.Upa.Impl.FwkConvertUtils.SetRemoveRange(partialUpdateFields, names);
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery UpdateAll() {
            if (partialUpdateFields != null) {
                partialUpdateFields.Clear();
            }
            return this;
        }


        public virtual System.Collections.Generic.ISet<string> GetUpdatedFields() {
            return partialUpdateFields;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery SetUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields) {
            this.partialUpdateFields = partialUpdateFields == null ? null : new System.Collections.Generic.HashSet<string>(partialUpdateFields);
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Update(System.Collections.Generic.ICollection<string> partialUpdateFields) {
            if (partialUpdateFields != null) {
                System.Collections.Generic.HashSet<string> s = new System.Collections.Generic.HashSet<string>(partialUpdateFields);
                if (this.partialUpdateFields != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(s, this.partialUpdateFields);
                }
                this.partialUpdateFields = s;
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Update(params string [] partialUpdateFields) {
            return Update(new System.Collections.Generic.List<string>(partialUpdateFields));
        }


        public virtual Net.TheVpc.Upa.UpdateQuery RemoveUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields) {
            if (partialUpdateFields != null) {
                if (this.partialUpdateFields != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.SetRemoveRange(this.partialUpdateFields, partialUpdateFields);
                }
            }
            return null;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Update(string field) {
            if (field != null) {
                System.Collections.Generic.HashSet<string> s = new System.Collections.Generic.HashSet<string>();
                if (this.partialUpdateFields != null) {
                    Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(s, this.partialUpdateFields);
                }
                s.Add(field);
                this.partialUpdateFields = s;
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.Filters.FieldFilter GetFormulaFields() {
            return formulaFieldsFilter;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Validate(Net.TheVpc.Upa.Filters.FieldFilter formulaFields) {
            if (formulaFields != null) {
                if (this.formulaFieldsFilter == null) {
                    this.formulaFieldsFilter = formulaFields;
                } else {
                    this.formulaFieldsFilter = Net.TheVpc.Upa.Filters.FieldOrFilter.Or(this.formulaFieldsFilter, formulaFields);
                }
            }
            return this;
        }


        public virtual long Execute() {
            return entity.Update(this);
        }


        public virtual bool IsIgnoreUnspecified() {
            return ignoreUnspecified;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery SetIgnoreUnspecified(bool ignoreUnspecified) {
            this.ignoreUnspecified = ignoreUnspecified;
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Validate(System.Collections.Generic.ICollection<string> formulaFields) {
            return Validate(Net.TheVpc.Upa.Filters.Fields.ByName(formulaFields));
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ValidateAll() {
            return Validate(Net.TheVpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA);
        }


        public virtual Net.TheVpc.Upa.UpdateQuery ValidateNone() {
            this.formulaFieldsFilter = null;
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Validate(string formulaField) {
            if (formulaField != null) {
                return Validate(new System.Collections.Generic.List<string>(new[]{formulaField}));
            }
            return this;
        }


        public virtual Net.TheVpc.Upa.UpdateQuery Validate(params string [] formulaFields) {
            return Validate(new System.Collections.Generic.List<string>(formulaFields));
        }
    }
}
