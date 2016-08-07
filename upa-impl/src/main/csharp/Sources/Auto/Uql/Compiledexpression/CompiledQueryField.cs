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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{

    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:10 PM To change
     * this template use File | Settings | File Templates.
     */
    public class CompiledQueryField : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNamedExpression {

        private int index = -1;

        private bool expanded = false;

        private string alias;

        private string binding;

        private string aliasBinding;

        private static string ResolveName(string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (alias != null) {
                return alias;
            }
            if (expression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar cv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod dc = cv.GetDeepChild();
                return (dc == null ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod)(cv)) : dc).GetName();
            }
            return null;
        }

        private static string ResolveBinding(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (expression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar cv = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod cv1 = cv.GetDeepChild();
                if (cv1 != null && cv1 is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression cv2 = cv1.GetParentExpression();
                    if (cv2 != null && cv2 is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                        return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) cv2).GetChildlessPath();
                    }
                }
            }
            return null;
        }

        public CompiledQueryField(string alias, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression)  : base(ResolveName(alias, expression), expression){

            this.alias = alias;
            this.binding = ResolveBinding(expression);
        }

        public virtual string GetAlias() {
            return alias;
        }

        public virtual void SetAlias(string alias) {
            this.alias = alias;
        }


        public override string ToString() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = GetExpression();
            return (e == null ? "NULL" : e.ToString()) + (alias == null ? "" : (" " + alias));
        }

        public virtual string GetBinding() {
            return binding;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField SetBinding(string binding) {
            this.binding = binding;
            return this;
        }

        public virtual string GetAliasBinding() {
            return aliasBinding;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField SetAliasBinding(string aliasBinding) {
            this.aliasBinding = aliasBinding;
            return this;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField SetIndex(int index) {
            this.index = index;
            return this;
        }

        public virtual bool IsExpanded() {
            return expanded;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField SetExpanded(bool expanded) {
            this.expanded = expanded;
            return this;
        }
    }
}
