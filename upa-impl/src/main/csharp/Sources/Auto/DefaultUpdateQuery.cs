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


    /**
     * Created by vpc on 6/12/16.
     */
    public class DefaultUpdateQuery : Net.Vpc.Upa.UpdateQuery {

        private Net.Vpc.Upa.Impl.DefaultEntity entity;

        private Net.Vpc.Upa.ConditionType updateConditionType = Net.Vpc.Upa.ConditionType.EXPRESSION;

        private object updateCondition;

        private object updatesValue;

        private bool ignoreUnspecified;

        private System.Collections.Generic.ISet<string> partialUpdateFields;

        private Net.Vpc.Upa.Filters.FieldFilter formulaFieldsFilter;

        private System.Collections.Generic.IDictionary<string , object> hints;

        public DefaultUpdateQuery(Net.Vpc.Upa.Impl.DefaultEntity entity) {
            this.entity = entity;
        }

        public virtual Net.Vpc.Upa.UpdateQuery SetNone() {
            return SetUpdates(null);
        }

        public virtual Net.Vpc.Upa.UpdateQuery SetValues(Net.Vpc.Upa.Record record) {
            return SetUpdates(record);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ById(object expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.ID, expr);
        }


        public virtual  Net.Vpc.Upa.UpdateQuery ByIdList<T>(System.Collections.Generic.IList<T> expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.ID_LIST, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByKey(Net.Vpc.Upa.Key expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.KEY, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByObject(object expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.OBJECT, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByPrototype(object expr) {
            if (expr is Net.Vpc.Upa.Record) {
                return SetCondition(Net.Vpc.Upa.ConditionType.RECORD_PROTOTYPE, expr);
            } else {
                return SetCondition(Net.Vpc.Upa.ConditionType.PROTOTYPE, expr);
            }
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByRecord(Net.Vpc.Upa.Record expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.RECORD, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByPrototype(Net.Vpc.Upa.Record expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.RECORD_PROTOTYPE, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByKeyList(System.Collections.Generic.IList<Net.Vpc.Upa.Key> expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.ID_LIST, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByExpressionList(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.EXPRESSION_LIST, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByExpression(Net.Vpc.Upa.Expressions.Expression expr) {
            return SetCondition(Net.Vpc.Upa.ConditionType.EXPRESSION, expr);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ByAll() {
            return SetCondition(Net.Vpc.Upa.ConditionType.EXPRESSION, null);
        }

        private Net.Vpc.Upa.UpdateQuery SetUpdates(object updatesValue) {
            this.updatesValue = updatesValue;
            return this;
        }

        private Net.Vpc.Upa.UpdateQuery SetCondition(Net.Vpc.Upa.ConditionType updateConditionType, object updateCondition) {
            this.updateConditionType = updateConditionType;
            this.updateCondition = updateCondition;
            return this;
        }


        public virtual Net.Vpc.Upa.ConditionType GetUpdateConditionType() {
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


        public virtual Net.Vpc.Upa.UpdateQuery SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            this.hints = hints;
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery SetHint(string name, object @value) {
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


        public virtual Net.Vpc.Upa.UpdateQuery SetValues(object updatesValue) {
            this.updatesValue = updatesValue;
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery AddUpdatableField(string name) {
            if (partialUpdateFields == null) {
                partialUpdateFields = new System.Collections.Generic.HashSet<string>();
            }
            partialUpdateFields.Add(name);
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery RemoveUpdatableField(string name) {
            if (partialUpdateFields != null) {
                partialUpdateFields.Remove(name);
            }
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery AddUpdatableFields(params string [] names) {
            return AddUpdatableFields(new System.Collections.Generic.List<string>(names));
        }


        public virtual Net.Vpc.Upa.UpdateQuery RemoveUpdatableFields(params string [] names) {
            return RemoveUpdatableFields(new System.Collections.Generic.List<string>(names));
        }


        public virtual Net.Vpc.Upa.UpdateQuery AddUpdatableFields(System.Collections.Generic.ICollection<string> names) {
            if (partialUpdateFields == null) {
                partialUpdateFields = new System.Collections.Generic.HashSet<string>();
            }
            Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(partialUpdateFields, names);
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery RemoveUpdatableFields(System.Collections.Generic.ICollection<string> names) {
            if (partialUpdateFields != null) {
                Net.Vpc.Upa.Impl.FwkConvertUtils.SetRemoveRange(partialUpdateFields, names);
            }
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery UpdateAll() {
            if (partialUpdateFields != null) {
                partialUpdateFields.Clear();
            }
            return this;
        }


        public virtual System.Collections.Generic.ISet<string> GetUpdatedFields() {
            return partialUpdateFields;
        }


        public virtual Net.Vpc.Upa.UpdateQuery SetUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields) {
            this.partialUpdateFields = partialUpdateFields == null ? null : new System.Collections.Generic.HashSet<string>(partialUpdateFields);
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Update(System.Collections.Generic.ICollection<string> partialUpdateFields) {
            if (partialUpdateFields != null) {
                System.Collections.Generic.HashSet<string> s = new System.Collections.Generic.HashSet<string>(partialUpdateFields);
                if (this.partialUpdateFields != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(s, this.partialUpdateFields);
                }
                this.partialUpdateFields = s;
            }
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Update(params string [] partialUpdateFields) {
            return Update(new System.Collections.Generic.List<string>(partialUpdateFields));
        }


        public virtual Net.Vpc.Upa.UpdateQuery RemoveUpdatedFields(System.Collections.Generic.ICollection<string> partialUpdateFields) {
            if (partialUpdateFields != null) {
                if (this.partialUpdateFields != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.SetRemoveRange(this.partialUpdateFields, partialUpdateFields);
                }
            }
            return null;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Update(string field) {
            if (field != null) {
                System.Collections.Generic.HashSet<string> s = new System.Collections.Generic.HashSet<string>();
                if (this.partialUpdateFields != null) {
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(s, this.partialUpdateFields);
                }
                s.Add(field);
                this.partialUpdateFields = s;
            }
            return this;
        }


        public virtual Net.Vpc.Upa.Filters.FieldFilter GetFormulaFields() {
            return formulaFieldsFilter;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Validate(Net.Vpc.Upa.Filters.FieldFilter formulaFields) {
            if (formulaFields != null) {
                if (this.formulaFieldsFilter == null) {
                    this.formulaFieldsFilter = formulaFields;
                } else {
                    this.formulaFieldsFilter = Net.Vpc.Upa.Filters.FieldOrFilter.Or(this.formulaFieldsFilter, formulaFields);
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


        public virtual Net.Vpc.Upa.UpdateQuery SetIgnoreUnspecified(bool ignoreUnspecified) {
            this.ignoreUnspecified = ignoreUnspecified;
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Validate(System.Collections.Generic.ICollection<string> formulaFields) {
            return Validate(Net.Vpc.Upa.Filters.Fields.ByName(formulaFields));
        }


        public virtual Net.Vpc.Upa.UpdateQuery ValidateAll() {
            return Validate(Net.Vpc.Upa.Impl.Util.Filters.Fields2.UPDATE_FORMULA);
        }


        public virtual Net.Vpc.Upa.UpdateQuery ValidateNone() {
            this.formulaFieldsFilter = null;
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Validate(string formulaField) {
            if (formulaField != null) {
                return Validate(new System.Collections.Generic.List<string>(new[]{formulaField}));
            }
            return this;
        }


        public virtual Net.Vpc.Upa.UpdateQuery Validate(params string [] formulaFields) {
            return Validate(new System.Collections.Generic.List<string>(formulaFields));
        }
    }
}
