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
public class CoalesceEvaluator implements Function {
    public static final Function INSTANCE=new CoalesceEvaluator();

    public CoalesceEvaluator() {
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        for (Object arg : evalContext.getArguments()) {
            if (arg != null) {
                return arg;
            }
        }
        return null;
    }


    
}
