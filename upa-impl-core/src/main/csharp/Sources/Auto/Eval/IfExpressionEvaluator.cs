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
    internal class IfExpressionEvaluator : Net.TheVpc.Upa.QLTypeEvaluator {

        public static readonly Net.TheVpc.Upa.QLTypeEvaluator INSTANCE = new Net.TheVpc.Upa.Impl.Eval.IfExpressionEvaluator();

        public IfExpressionEvaluator() {
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression EvalObject(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.QLEvaluator evaluator, object context) {
            Net.TheVpc.Upa.Expressions.If ife = (Net.TheVpc.Upa.Expressions.If) e;
            int count = ife.GetArgumentsCount();
            int i = 0;
            Net.TheVpc.Upa.Expressions.Expression[] allArguments = ife.GetArguments();
            while (i < count) {
                Net.TheVpc.Upa.Expressions.Expression ee = allArguments[i];
                allArguments[i] = evaluator.EvalObject(ee, context);
                object o = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(allArguments[i]);
                if (o is Net.TheVpc.Upa.Expressions.Expression) {
                    //just simplify don't exec
                    return new Net.TheVpc.Upa.Expressions.If(new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(allArguments));
                }
                bool? exprVal = (bool?) o;
                if ((exprVal).Value) {
                    Net.TheVpc.Upa.Expressions.Expression thenExpr = allArguments[i + 1];
                    allArguments[i + 1] = evaluator.EvalObject(thenExpr, context);
                    o = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(allArguments[i + 1]);
                    if (o is Net.TheVpc.Upa.Expressions.Expression) {
                        //just simplify don't exec
                        return new Net.TheVpc.Upa.Expressions.If(new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(allArguments));
                    }
                    return new Net.TheVpc.Upa.Expressions.Literal(o, null);
                } else {
                    if (i + 2 == count - 1) {
                        //the else
                        allArguments[i + 2] = evaluator.EvalObject(allArguments[i + 2], context);
                        o = Net.TheVpc.Upa.Impl.Util.UPAUtils.UnwrapLiteral(allArguments[i + 2]);
                        if (o is Net.TheVpc.Upa.Expressions.Expression) {
                            //just simplify don't exec
                            return new Net.TheVpc.Upa.Expressions.If(new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(allArguments));
                        }
                        return new Net.TheVpc.Upa.Expressions.Literal(o, null);
                    }
                    i += 2;
                }
            }
            return Net.TheVpc.Upa.Expressions.Literal.NULL;
        }
    }
}
