/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class IfEvaluator implements Function {
    public static final Function INSTANCE=new IfEvaluator();

    public IfEvaluator() {
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
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
