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
    internal class IfExpressionEvaluator : Net.Vpc.Upa.QLTypeEvaluator {

        public static readonly Net.Vpc.Upa.QLTypeEvaluator INSTANCE = new Net.Vpc.Upa.Impl.Eval.IfExpressionEvaluator();

        public IfExpressionEvaluator() {
        }


        public virtual Net.Vpc.Upa.Expressions.Expression EvalObject(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.QLEvaluator evaluator, object context) {
            Net.Vpc.Upa.Expressions.If ife = (Net.Vpc.Upa.Expressions.If) e;
            int count = ife.GetArgumentsCount();
            int i = 0;
            Net.Vpc.Upa.Expressions.Expression[] allArguments = ife.GetArguments();
            while (i < count) {
                Net.Vpc.Upa.Expressions.Expression ee = allArguments[i];
                allArguments[i] = evaluator.EvalObject(ee, context);
                object o = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(allArguments[i]);
                if (o is Net.Vpc.Upa.Expressions.Expression) {
                    //just simplify don't exec
                    return new Net.Vpc.Upa.Expressions.If(new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(allArguments));
                }
                bool? exprVal = (bool?) o;
                if ((exprVal).Value) {
                    Net.Vpc.Upa.Expressions.Expression thenExpr = allArguments[i + 1];
                    allArguments[i + 1] = evaluator.EvalObject(thenExpr, context);
                    o = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(allArguments[i + 1]);
                    if (o is Net.Vpc.Upa.Expressions.Expression) {
                        //just simplify don't exec
                        return new Net.Vpc.Upa.Expressions.If(new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(allArguments));
                    }
                    return new Net.Vpc.Upa.Expressions.Literal(o, null);
                } else {
                    if (i + 2 == count - 1) {
                        //the else
                        allArguments[i + 2] = evaluator.EvalObject(allArguments[i + 2], context);
                        o = Net.Vpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(allArguments[i + 2]);
                        if (o is Net.Vpc.Upa.Expressions.Expression) {
                            //just simplify don't exec
                            return new Net.Vpc.Upa.Expressions.If(new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(allArguments));
                        }
                        return new Net.Vpc.Upa.Expressions.Literal(o, null);
                    }
                    i += 2;
                }
            }
            return Net.Vpc.Upa.Expressions.Literal.NULL;
        }
    }
}
