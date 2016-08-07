/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.EvalContext;
import net.vpc.upa.Function;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class IfEvaluator implements net.vpc.upa.Function {
    public static final Function INSTANCE=new IfEvaluator();

    public IfEvaluator() {
    }

    @Override
    public Object eval(EvalContext evalContext) {
        Object[] args = evalContext.getArguments();
        int i = 1;
        while (i < args.length) {
            if(i<args.length-1) {
                if ((Boolean)(args[i])) {
                    return args[i + 1];
                }
                i++;
            }else {
                return args[i];
            }
            i++;
        }
        return null;
    }


    
}
