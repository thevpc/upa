package net.vpc.upa.impl.persistence;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.CloseListener;
import net.vpc.upa.impl.util.LazyList;
import net.vpc.upa.persistence.QueryResultParser;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/21/12 4:09 PM
 */
public abstract class QueryResultLazyList<R>  extends LazyList<R> implements QueryResultParser<R> {
    QueryExecutor queryExecutor;
    private CloseListener closeListener;

    protected QueryResultLazyList(QueryExecutor _queryExecutor) {
        super(null);
        this.queryExecutor = _queryExecutor;
        this.base = new QueryResultReader<R>(queryExecutor.getQueryResult(),this);

        closeListener = new CloseListenerImpl(this);

        queryExecutor.getConnection().addCloseListener(closeListener);
    }

    @Override
    protected void loadingFinished() {
        queryExecutor.getQueryResult().close();
        queryExecutor.getConnection().removeCloseListener(closeListener);
    }

    @PortabilityHint(target = "C#",name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        queryExecutor.getQueryResult().close();
    }

    public QueryExecutor getQueryExecutor() {
        return queryExecutor;
    }

    public void loadAll(){
        ensureLoadAll();
    }

}
