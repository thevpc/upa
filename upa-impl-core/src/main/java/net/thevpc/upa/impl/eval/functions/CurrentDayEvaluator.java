package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.types.Date;
import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentDayEvaluator implements Function {

    public static final Function INSTANCE = new CurrentDayEvaluator();

    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return new Date().getDateValue();
    }
}
