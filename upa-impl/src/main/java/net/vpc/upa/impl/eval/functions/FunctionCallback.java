/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.EvalContext;
import net.vpc.upa.Function;
import net.vpc.upa.impl.config.callback.DefaultCallback;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class FunctionCallback implements net.vpc.upa.Function {
    private final DefaultCallback callback;

    public FunctionCallback(DefaultCallback b) {
        this.callback = b;
    }

    @Override
    public Object eval(EvalContext evalContext) {
        return callback.invoke(evalContext);
    }

    public DefaultCallback getCallback() {
        return callback;
    }

}
