package net.thevpc.upa.impl.upql;

import net.thevpc.upa.Entity;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
* Created by vpc on 1/4/14.
*/
class BindingJoinInfo {

    boolean newlyCreated;
    BindingId binding;
    Entity entity;
    String alias;
    CompiledExpressionExt cond;

    @Override
    public String toString() {
        return "BindingJoinInfo{" + "binding=" + binding + ", entity=" + entity + ", alias=" + alias + '}';
    }
}
