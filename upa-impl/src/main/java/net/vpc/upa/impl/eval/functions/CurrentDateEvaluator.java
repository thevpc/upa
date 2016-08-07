package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.EvalContext;
import net.vpc.upa.Function;
import net.vpc.upa.types.Date;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentDateEvaluator implements Function {
    public static final Function INSTANCE=new CurrentDateEvaluator();
    @Override
    public Object eval(EvalContext evalContext) {
        return new Date();
    }
}
