package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.FunctionEvalContext;
import net.vpc.upa.Function;
import net.vpc.upa.types.Timestamp;

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
