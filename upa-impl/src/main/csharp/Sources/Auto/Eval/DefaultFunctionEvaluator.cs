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
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultFunctionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        private Net.Vpc.Upa.Function evaluator;

        public DefaultFunctionEvaluator(Net.Vpc.Upa.Function evaluator) {
            this.evaluator = evaluator;
        }


        public Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.FunctionExpression f = (Net.Vpc.Upa.Expressions.FunctionExpression) e;
            Net.Vpc.Upa.Expressions.Expression[] arguments = f.GetArguments();
            object[] oarguments = new object[arguments.Length];
            bool evaluatable = true;
            for (int i = 0; i < arguments.Length; i++) {
                Net.Vpc.Upa.Expressions.Expression expr = evaluator.EvalObject(arguments[i], context);
                arguments[i] = expr;
                object oo = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(expr);
                if (oo is Net.Vpc.Upa.Expressions.Expression) {
                    evaluatable = false;
                } else {
                    oarguments[i] = oo;
                }
            }
            if (!evaluatable) {
                return Net.Vpc.Upa.Impl.Uql.Parser.Syntax.FunctionFactory.CreateFunction(f.GetName(), new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(arguments));
            }
            object v = this.evaluator.Eval(new Net.Vpc.Upa.EvalContext(f.GetName(), oarguments, null));
            return new Net.Vpc.Upa.Expressions.Literal(v, null);
        }
    }
}
