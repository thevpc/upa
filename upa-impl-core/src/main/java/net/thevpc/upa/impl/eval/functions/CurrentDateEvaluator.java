package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;
import net.thevpc.upa.types.Date;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentDateEvaluator implements Function {
    public static final Function INSTANCE=new CurrentDateEvaluator();
    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return new Date();
    }
}
