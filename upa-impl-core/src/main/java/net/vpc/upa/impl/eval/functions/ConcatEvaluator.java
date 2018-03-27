/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.FunctionEvalContext;
import net.vpc.upa.Function;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ConcatEvaluator implements net.vpc.upa.Function {
    public static final Function INSTANCE=new ConcatEvaluator();

    public ConcatEvaluator() {
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        StringBuilder sb=new StringBuilder();
        for (Object arg : evalContext.getArguments()) {
            if (arg != null) {
                sb.append(arg);
            }
        }
        return sb.toString();
    }


    
}
