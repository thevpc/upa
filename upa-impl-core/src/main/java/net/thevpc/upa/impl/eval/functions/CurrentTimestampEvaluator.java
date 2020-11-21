package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;
import net.thevpc.upa.types.Timestamp;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentTimestampEvaluator implements Function {
    public static final Function INSTANCE=new CurrentTimestampEvaluator();
    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return new Timestamp();
    }
}
