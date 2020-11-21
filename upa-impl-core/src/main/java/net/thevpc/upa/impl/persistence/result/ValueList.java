package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.QueryExecutor;

import java.sql.SQLException;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 6:41 AM To change
 * this template use File | Settings | File Templates.
 */
public class ValueList<T> extends QueryResultLazyList<T> {
    int index;

    public ValueList(QueryExecutor queryExecutor, int index) throws SQLException, UPAException {
        super(queryExecutor);
        this.index = index;
    }

    @Override
    protected boolean checkHasNext() {
        return getQueryResult().hasNext();
    }

    @Override
    protected T loadNext() {
        return getQueryResult().read(index);
    }
}
