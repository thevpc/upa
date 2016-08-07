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



namespace Net.Vpc.Upa.Impl.Eval
{


    /**
     * @author taha.bensalah@gmail.com
     */
    public class DefaultQLEvaluator : Net.Vpc.Upa.QLEvaluator {

        private Net.Vpc.Upa.QLEvaluatorRegistry registry;

        public DefaultQLEvaluator() {
            registry = new Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluatorRegistry();
        }

        public DefaultQLEvaluator(Net.Vpc.Upa.QLEvaluatorRegistry registry) {
            this.registry = registry;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression EvalString(string expression, object context) {
            if (expression == null) {
                return null;
            }
            if ((expression).Length == 0) {
                return new Net.Vpc.Upa.Expressions.Literal("");
            }
            if (IsVarName(expression)) {
                return GetRegistry().GetTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.Var)).EvalObject(new Net.Vpc.Upa.Expressions.Var(expression), this, context);
            }
            Net.Vpc.Upa.QLExpressionParser parser = Net.Vpc.Upa.UPA.GetBootstrapFactory().CreateObject<Net.Vpc.Upa.QLExpressionParser>(typeof(Net.Vpc.Upa.QLExpressionParser));
            Net.Vpc.Upa.Expressions.Expression exprObj = parser.Parse(expression);
            return EvalObject(exprObj, context);
        }

        public virtual string EvalFormatted(string expr, object context) {
            return FormatResult(EvalString(expr, context));
        }

        public virtual string FormatResult(object result) {
            return result == null ? "" : result.ToString();
        }

        public virtual bool IsVarName(string s) {
            if (s == null || (s).Length == 0) {
                return false;
            }
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++) {
                char c = chars[i];
                if (i == 0) {
                    if (!(Net.Vpc.Upa.Expressions.ExpressionHelper.IsIdentifierStart(c))) {
                        return false;
                    }
                } else if (!(Net.Vpc.Upa.Expressions.ExpressionHelper.IsIdentifierPart(c) || c == '.')) {
                    return false;
                }
            }
            return true;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, object context) {
            return GetRegistry().GetTypeEvaluator(e.GetType()).EvalObject(e, this, context);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (!(o is Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluator)) return false;
            Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluator that = (Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluator) o;
            return !(registry != null ? !registry.Equals(that.registry) : that.registry != null);
        }


        public override int GetHashCode() {
            return registry != null ? registry.GetHashCode() : 0;
        }


        public virtual Net.Vpc.Upa.QLEvaluatorRegistry GetRegistry() {
            return registry;
        }
    }
}
