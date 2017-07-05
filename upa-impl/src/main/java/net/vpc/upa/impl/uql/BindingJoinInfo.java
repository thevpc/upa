package net.vpc.upa.impl.uql;

import net.vpc.upa.Entity;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
* Created by vpc on 1/4/14.
*/
class BindingJoinInfo {

    boolean newlyCreated;
    BindingId binding;
    Entity entity;
    String alias;
    DefaultCompiledExpression cond;

    @Override
    public String toString() {
        return "BindingJoinInfo{" + "binding=" + binding + ", entity=" + entity + ", alias=" + alias + '}';
    }
}
