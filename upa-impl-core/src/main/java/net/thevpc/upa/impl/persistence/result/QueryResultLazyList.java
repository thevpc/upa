package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.CloseListener;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.persistence.CloseListenerImpl;
import net.thevpc.upa.impl.persistence.QueryExecutor;
import net.thevpc.upa.impl.util.LazyList;
import net.thevpc.upa.persistence.QueryResult;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/21/12 4:09 PM
 */
public abstract class QueryResultLazyList<R> extends LazyList<R> {
    public QueryExecutor queryExecutor;
    private CloseListener closeListener;

    protected QueryResultLazyList(QueryExecutor _queryExecutor) {
        super(null);
        this.queryExecutor = _queryExecutor;
//        this.base = new QueryResultReader<R>(queryExecutor.getQueryResult(),this);

        closeListener = new CloseListenerImpl(this);

        queryExecutor.getConnection().addCloseListener(closeListener);
    }

    public QueryResult getQueryResult() {
        return queryExecutor.getQueryResult();
    }

    @Override
    protected void loadingFinished() {
        getQueryResult().close();
        queryExecutor.getConnection().removeCloseListener(closeListener);
    }

    @PortabilityHint(target = "C#", name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        getQueryResult().close();
    }

    public QueryExecutor getQueryExecutor() {
        return queryExecutor;
    }

    public void loadAll() {
        ensureLoadAll();
    }

}
