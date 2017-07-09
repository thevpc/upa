package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.persistence.result.QueryResultLazyList;
import net.vpc.upa.persistence.QueryResult;

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

    public T parse(QueryResult result) throws UPAException {
        return result.read(index);
    }
}
