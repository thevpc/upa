package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.EvalContext;
import net.vpc.upa.Function;

/**
 * Created by vpc on 7/3/16.
 */
public class SignEvaluator implements Function {
    public static final Function INSTANCE=new SignEvaluator();
    @Override
    public Object eval(EvalContext evalContext) {
        Object obj = evalContext.getArguments()[0];
        Number n = (Number) obj;
        return n.doubleValue()>0?1:n.doubleValue()<0?-1:0;
    }
}
