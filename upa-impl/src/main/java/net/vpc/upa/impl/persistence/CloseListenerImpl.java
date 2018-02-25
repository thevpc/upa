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
    private final QueryResultLazyList<R> queryResult;

    public CloseListenerImpl(QueryResultLazyList<R> queryResult) {
        this.queryResult = queryResult;
    }

    @Override
    public void beforeClose(Object source) {
        queryResult.ensureLoadAll();
    }

    @Override
    public void afterClose(Object source) {
        queryResult.queryExecutor.getConnection().removeCloseListener(this);
    }
    
}
