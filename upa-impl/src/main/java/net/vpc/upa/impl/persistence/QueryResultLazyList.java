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
    NativeSQL nativeSQL;
    private CloseListener closeListener;

    protected QueryResultLazyList(NativeSQL _nativeSQL) {
        super(null);
        this.nativeSQL = _nativeSQL;
        this.base = new QueryResultReader<R>(nativeSQL.getQueryResult(),this);

        closeListener = new CloseListenerImpl(this);

        nativeSQL.getConnection().addCloseListener(closeListener);
    }

    @Override
    protected void loadingFinished() {
        nativeSQL.getQueryResult().close();
        nativeSQL.getConnection().removeCloseListener(closeListener);
    }

    @PortabilityHint(target = "C#",name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        nativeSQL.getQueryResult().close();
    }

    public NativeSQL getNativeSQL() {
        return nativeSQL;
    }

    public void loadAll(){
        size();
    }

}
