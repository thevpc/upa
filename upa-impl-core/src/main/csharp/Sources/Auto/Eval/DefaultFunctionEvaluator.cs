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



namespace Net.TheVpc.Upa.Impl.Eval
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultFunctionEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        private Net.TheVpc.Upa.Function evaluator;

        public DefaultFunctionEvaluator(Net.TheVpc.Upa.Function evaluator) {
            this.evaluator = evaluator;
        }


        public Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            Net.TheVpc.Upa.Expressions.FunctionExpression f = (Net.TheVpc.Upa.Expressions.FunctionExpression) e;
            Net.TheVpc.Upa.Expressions.Expression[] arguments = f.GetArguments();
            object[] oarguments = new object[arguments.Length];
            bool evaluatable = true;
            for (int i = 0; i < arguments.Length; i++) {
                Net.TheVpc.Upa.Expressions.Expression expr = evaluator.EvalObject(arguments[i], context);
                arguments[i] = expr;
                object oo = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(expr);
                if (oo is Net.TheVpc.Upa.Expressions.Expression) {
                    evaluatable = false;
                } else {
                    oarguments[i] = oo;
                }
            }
            if (!evaluatable) {
                return Net.TheVpc.Upa.Impl.Uql.Parser.Syntax.FunctionFactory.CreateFunction(f.GetName(), new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(arguments));
            }
            object v = this.evaluator.Eval(new Net.TheVpc.Upa.EvalContext(f.GetName(), oarguments, null));
            return new Net.TheVpc.Upa.Expressions.Literal(v, null);
        }
    }
}
