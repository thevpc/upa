package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.Function;
import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.UserPrincipal;


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
