package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.FunctionEvalContext;
import net.vpc.upa.Function;

/**
 * Created by vpc on 7/3/16.
 */
public class StrLenEvaluator implements Function {
    public static final Function INSTANCE=new StrLenEvaluator();
    @Override
    public Object eval(FunctionEvalContext evalContext) {
        Object obj = evalContext.getArguments()[0];
        return obj==null?"":String.valueOf(obj);
    }
}
