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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     *
     * @author vpc
     */
    public class DefaultQLEvaluator : Net.Vpc.Upa.QLEvaluator {

        private System.Collections.Generic.IDictionary<System.Type , Net.Vpc.Upa.QLTypeEvaluator> evaluators = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.QLTypeEvaluator>();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.QLTypeEvaluator> functionsEvaluators = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.QLTypeEvaluator>();

        private Net.Vpc.Upa.QLTypeEvaluator nullEvaluator = new Net.Vpc.Upa.Impl.Uql.NullQLTypeEvaluator();

        private Net.Vpc.Upa.QLTypeEvaluator notFoundEvaluator = new Net.Vpc.Upa.Impl.Uql.NotFoundEvaluatorQLTypeEvaluator();

        private Net.Vpc.Upa.QLTypeEvaluator functionDispacthEvaluator;

        public DefaultQLEvaluator() {
            functionDispacthEvaluator = new Net.Vpc.Upa.Impl.Uql.FunctionDispacthEvaluatorQLTypeEvaluator(functionsEvaluators);
            RegisterTypeEvaluator(null, nullEvaluator);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.Function), functionDispacthEvaluator);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.Literal), new Net.Vpc.Upa.Impl.Uql.LiteralExpressionEvaluator());
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.UnaryOperatorExpression), new Net.Vpc.Upa.Impl.Uql.UnaryOperatorExpressionEvaluator(this));
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.If), new Net.Vpc.Upa.Impl.Uql.IfExpressionEvaluator());
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.BinaryOperatorExpression), new Net.Vpc.Upa.Impl.Uql.BinaryOperatorExpressionEvaluator(this));
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.Not), new Net.Vpc.Upa.Impl.Uql.NotExpressionEvaluator());
            RegisterFunctionEvaluator("file_exists", new Net.Vpc.Upa.Impl.Uql.FileExistsExpressionEvaluator());
        }

        public virtual object EvalString(string expression, object context) {
            if (expression == null) {
                return null;
            }
            if ((expression).Length == 0) {
                return "";
            }
            if (IsVarName(expression)) {
                return GetTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.Var)).EvalObject(new Net.Vpc.Upa.Expressions.Var(expression), this, context);
            }
            Net.Vpc.Upa.QLExpressionParser parser = Net.Vpc.Upa.UPA.GetBootstrapFactory().CreateObject<Net.Vpc.Upa.QLExpressionParser>(typeof(Net.Vpc.Upa.QLExpressionParser));
            Net.Vpc.Upa.Expressions.Expression exprObj = parser.Parse(expression);
            return EvalObject(exprObj, context);
        }

        public virtual void RegisterFunctionEvaluator(string name, Net.Vpc.Upa.QLTypeEvaluator t) {
            functionsEvaluators[name]=t;
        }

        public virtual void RegisterTypeEvaluator(System.Type type, Net.Vpc.Upa.QLTypeEvaluator t) {
            evaluators[type]=t;
        }

        public virtual Net.Vpc.Upa.QLTypeEvaluator GetTypeEvaluator(System.Type type) {
            Net.Vpc.Upa.QLTypeEvaluator y = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.QLTypeEvaluator>(evaluators,type);
            if (y != null) {
                return y;
            }
            if (type == null) {
                return nullEvaluator;
            }
            foreach (System.Collections.Generic.KeyValuePair<System.Type , Net.Vpc.Upa.QLTypeEvaluator> en in evaluators) {
                if ((en).Key != null && (en).Key.IsAssignableFrom(type)) {
                    return (en).Value;
                }
            }
            return notFoundEvaluator;
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

        public virtual object EvalObject(Net.Vpc.Upa.Expressions.Expression e, object context) {
            return GetTypeEvaluator(e.GetType()).EvalObject(e, this, context);
        }

        internal virtual Net.Vpc.Upa.Impl.Util.XNumber ToNumber(object o) {
            if (o == null) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(0);
            }
            if (o is string) {
                return new Net.Vpc.Upa.Impl.Util.XNumber(System.Convert.ToDouble((string) o));
            }
            return new Net.Vpc.Upa.Impl.Util.XNumber((object) o);
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 31 * hash;
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            return true;
        }
    }
}
