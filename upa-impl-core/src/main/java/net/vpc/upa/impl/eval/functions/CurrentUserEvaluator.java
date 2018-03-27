package net.vpc.upa.impl.eval.functions;

import net.vpc.upa.*;

/**
 * Created by vpc on 7/3/16.
 */
public class CurrentUserEvaluator implements Function {
    public static final Function INSTANCE=new CurrentUserEvaluator();
    @Override
    public Object eval(FunctionEvalContext evalContext) {
        PersistenceUnit pu = evalContext.getPersistenceUnit();
        UserPrincipal user = pu.getUserPrincipal();
        return user==null?"anonymous":user.getName();
    }
}
