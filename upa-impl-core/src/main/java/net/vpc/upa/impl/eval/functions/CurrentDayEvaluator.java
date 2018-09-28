package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.FunctionEvalContext;
import net.vpc.upa.Function;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentDayEvaluator implements Function {

    public static final Function INSTANCE = new CurrentDayEvaluator();

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return new net.vpc.upa.types.Date().getDateValue();
    }
}
