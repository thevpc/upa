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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ExpressionCompilerConfig {

        private System.Collections.Generic.IDictionary<string , string> aliasToEntityContext = new System.Collections.Generic.Dictionary<string , string>();

        private System.Collections.Generic.IDictionary<string , object> hints;

        private bool compile = true;

        private bool resolveThis = true;

        private Net.TheVpc.Upa.Filters.FieldFilter expandFieldFilter;

        private string thisAlias = null;

        public ExpressionCompilerConfig() {
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetAliasToEntityContext() {
            return aliasToEntityContext;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig BindAliasToEntity(string alias, string entityName) {
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

        public virtual Net.TheVpc.Upa.Filters.FieldFilter GetExpandFieldFilter() {
            return expandFieldFilter;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig SetExpandFieldFilter(Net.TheVpc.Upa.Filters.FieldFilter expandFieldFilter) {
            this.expandFieldFilter = expandFieldFilter;
            return this;
        }

        public virtual bool IsCompile() {
            return compile;
        }

        public virtual bool IsTranslateOnly() {
            return !compile;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig SetCompile(bool compile) {
            this.compile = compile;
            return this;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig SetTranslateOnly() {
            this.compile = false;
            return this;
        }

        public virtual string GetThisAlias() {
            return thisAlias;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig SetThisAlias(string thisAlias) {
            this.thisAlias = thisAlias;
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }

        public virtual object GetHint(string hintName) {
            return hints == null ? null : Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
        }

        public virtual object GetHint(string hintName, object defaultValue) {
            object c = hints == null ? null : Net.TheVpc.Upa.FwkConvertUtils.GetMapValue<string,object>(hints,hintName);
            return c == null ? defaultValue : c;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig SetHints(System.Collections.Generic.IDictionary<string , object> hints) {
            this.hints = hints;
            return this;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig Copy() {
            Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig other = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            other.aliasToEntityContext = aliasToEntityContext == null ? null : new System.Collections.Generic.Dictionary<string , string>(aliasToEntityContext);
            other.hints = hints == null ? null : new System.Collections.Generic.Dictionary<string , object>(hints);
            other.compile = compile;
            other.thisAlias = thisAlias;
            return other;
        }

        public virtual bool IsResolveThis() {
            return resolveThis;
        }

        public virtual Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig SetResolveThis(bool resolveThis) {
            this.resolveThis = resolveThis;
            return this;
        }


        public override string ToString() {
            return "ExpressionCompilerConfig{" + "aliasToEntityContext=" + aliasToEntityContext + ", " + (compile ? "compile" : "translate") + ", expandFieldFilter=" + expandFieldFilter + ", thisAlias=" + thisAlias + '}';
        }
    }
}
