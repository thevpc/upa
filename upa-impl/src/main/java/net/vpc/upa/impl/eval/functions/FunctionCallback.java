/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.Callback;
import net.vpc.upa.EvalContext;
import net.vpc.upa.Function;
import net.vpc.upa.impl.config.callback.DefaultCallback;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class FunctionCallback implements net.vpc.upa.Function {
    private final Callback callback;

    public FunctionCallback(Callback b) {
        this.callback = b;
    }

    @Override
    public Object eval(EvalContext evalContext) {
        return callback.invoke(evalContext);
    }

    public Callback getCallback() {
        return callback;
    }

}
