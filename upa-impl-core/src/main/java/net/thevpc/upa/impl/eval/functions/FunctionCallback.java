/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.Function;
import net.thevpc.upa.Callback;
import net.thevpc.upa.FunctionEvalContext;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class FunctionCallback implements Function {
    private final Callback callback;

    public FunctionCallback(Callback b) {
        this.callback = b;
    }

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return callback.invoke(evalContext);
    }

    public Callback getCallback() {
        return callback;
    }

}
