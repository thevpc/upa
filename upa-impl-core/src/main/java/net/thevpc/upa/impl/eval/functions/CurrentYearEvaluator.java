package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;
import net.thevpc.upa.types.Year;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentYearEvaluator implements Function {
    public static final Function INSTANCE=new CurrentYearEvaluator();
    @Override
    public Object eval(FunctionEvalContext evalContext) {
        return new Year().getYearValue();
    }
}
