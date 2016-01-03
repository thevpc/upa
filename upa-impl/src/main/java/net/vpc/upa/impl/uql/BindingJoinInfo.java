package net.vpc.upa.impl.uql;

import net.vpc.upa.Entity;

/**
* Created by vpc on 1/4/14.
*/
class BindingJoinInfo {

    String binding;
    Entity entity;
    String alias;

    @Override
    public String toString() {
        return "BindingJoinInfo{" + "binding=" + binding + ", entity=" + entity + ", alias=" + alias + '}';
    }
}
