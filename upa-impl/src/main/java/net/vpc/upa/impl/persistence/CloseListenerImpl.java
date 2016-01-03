/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.CloseListener;

/**
 *
 * @author vpc
 */
class CloseListenerImpl<R> implements CloseListener {
    private final QueryResultIteratorList<R> outer;

    public CloseListenerImpl(final QueryResultIteratorList<R> outer) {
        this.outer = outer;
    }

    @Override
    public void beforeClose(Object source) {
        outer.ensureLoadAll();
    }

    @Override
    public void afterClose(Object source) {
        outer.nativeSQL.getConnection().removeCloseListener(this);
    }
    
}
