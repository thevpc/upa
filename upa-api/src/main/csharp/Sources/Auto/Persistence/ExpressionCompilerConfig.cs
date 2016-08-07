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



namespace Net.Vpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ExpressionCompilerConfig {

        private System.Collections.Generic.IDictionary<string , string> aliasToEntityContext;

        private System.Collections.Generic.IDictionary<string , object> hints;

        private bool validate = true;

        private bool expandFields = true;

        private Net.Vpc.Upa.Filters.FieldFilter expandFieldFilter;

        private bool expandEntityFilter = true;

        private string thisAlias = null;

        public ExpressionCompilerConfig() {
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetAliasToEntityContext() {
            return aliasToEntityContext;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig BindAliastoEntity(string alias, string entityName) {
            if (aliasToEntityContext == null) {
                aliasToEntityContext = new System.Collections.Generic.Dictionary<string , string>();
            }
            if (entityName == null) {
                aliasToEntityContext.Remove(alias);
            } else {
                aliasToEntityContext[alias]=entityName;
            }
            return this;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetAliasToEntityContext(System.Collections.Generic.IDictionary<string , string> aliasToEntityContext) {
            this.aliasToEntityContext = aliasToEntityContext;
            return this;
        }

        public virtual bool IsExpandFields() {
            return expandFields;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetExpandFields(bool expandFields) {
            this.expandFields = expandFields;
            return this;
        }

        public virtual Net.Vpc.Upa.Filters.FieldFilter GetExpandFieldFilter() {
            return expandFieldFilter;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetExpandFieldFilter(Net.Vpc.Upa.Filters.FieldFilter expandFieldFilter) {
            this.expandFieldFilter = expandFieldFilter;
            return this;
        }

        public virtual bool IsExpandEntityFilter() {
            return expandEntityFilter;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetExpandEntityFilter(bool expandEntityFilter) {
            this.expandEntityFilter = expandEntityFilter;
            return this;
        }

        public virtual bool IsValidate() {
            return validate;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetValidate(bool validate) {
            this.validate = validate;
            return this;
        }

        public virtual string GetThisAlias() {
            return thisAlias;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetThisAlias(string thisAlias) {
            this.thisAlias = thisAlias;
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }

        public virtual object GetHint(string hintName) {
            return hints == null ? null : Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
        }

        public virtual object GetHint(string hintName, object defaultValue) {
            object c = hints == null ? null : Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
            return c == null ? defaultValue : c;
        }

        public virtual Net.Vpc.Upa.Persistence.ExpressionCompilerConfig SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            this.hints = hints;
            return this;
        }


        public override string ToString() {
            return "ExpressionCompilerConfig{" + "aliasToEntityContext=" + aliasToEntityContext + ", validate=" + validate + ", expandFields=" + expandFields + ", expandFieldFilter=" + expandFieldFilter + ", expandEntityFilter=" + expandEntityFilter + ", thisAlias=" + thisAlias + '}';
        }
    }
}
