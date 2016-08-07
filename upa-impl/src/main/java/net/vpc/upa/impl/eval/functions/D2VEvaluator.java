package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.*;

/**
 * Created by vpc on 7/3/16.
 */
public class D2VEvaluator implements Function {
    public static final Function INSTANCE=new D2VEvaluator();
    @Override
    public Object eval(EvalContext evalContext) {
        Object obj = evalContext.getArguments()[0];
        return obj==null?"":String.valueOf(obj);
    }
}
