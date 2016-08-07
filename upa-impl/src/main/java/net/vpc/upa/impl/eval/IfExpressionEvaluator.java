/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval;

import net.vpc.upa.QLEvaluator;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.If;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.impl.util.UPAUtils;

import java.util.Arrays;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class IfExpressionEvaluator implements QLTypeEvaluator {
    public static final QLTypeEvaluator INSTANCE=new IfExpressionEvaluator();

    public IfExpressionEvaluator() {
    }

    @Override
    public Expression evalObject(Expression e, QLEvaluator evaluator, Object context) {
        If ife = (If) e;
        int count = ife.getArgumentsCount();
        int i = 0;
        Expression[] allArguments = ife.getArguments();

        while (i < count) {
            Expression ee = allArguments[i];
            allArguments[i] = evaluator.evalObject(ee, context);
            Object o = UPAUtils.unwrapLiteral(allArguments[i]);
            if(o instanceof Expression){
                //just simplify don't exec
                return new If(Arrays.asList(allArguments));
            }
            Boolean exprVal = (Boolean) o;
            if (exprVal) {
                Expression thenExpr = allArguments[i + 1];
                allArguments[i + 1]=evaluator.evalObject(thenExpr, context);
                o = UPAUtils.unwrapLiteral(allArguments[i + 1]);
                if(o instanceof Expression){
                    //just simplify don't exec
                    return new If(Arrays.asList(allArguments));
                }

                return new Literal(o,null);
            } else {
                if (i + 2 == count - 1) {
                    //the else
                    allArguments[i + 2]=evaluator.evalObject(allArguments[i + 2], context);
                    o = UPAUtils.unwrapLiteral(allArguments[i + 2]);
                    if(o instanceof Expression){
                        //just simplify don't exec
                        return new If(Arrays.asList(allArguments));
                    }

                    return new Literal(o,null);
                }
                i += 2;
            }
        }
        return Literal.NULL;
    }
    
}
