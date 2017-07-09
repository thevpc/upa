/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.CloseListener;
import net.vpc.upa.impl.persistence.result.QueryResultLazyList;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class CloseListenerImpl<R> implements CloseListener {
    private final QueryResultLazyList<R> outer;

    public CloseListenerImpl(final QueryResultLazyList<R> outer) {
        this.outer = outer;
    }

    @Override
    public void beforeClose(Object source) {
        outer.ensureLoadAll();
    }

    @Override
    public void afterClose(Object source) {
        outer.queryExecutor.getConnection().removeCloseListener(this);
    }
    
}
