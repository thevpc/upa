package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.persistence.QueryResult;

import java.sql.SQLException;

public class SingleEntityKeyList<K> extends QueryResultLazyList<K> {
    private int columns;
    private Entity entity;

    public SingleEntityKeyList(QueryExecutor queryExecutor, Entity entity) throws SQLException {
        super(queryExecutor);
        this.entity = entity;
        columns = queryExecutor.getFields().length;
    }

    @Override
    public K loadNext() throws UPAException {
        QueryResult result = getQueryResult();
        Object[] keyObj = new Object[columns];
        for (int i = 0; i < columns; i++) {
            keyObj[i] = result.read(i);
        }
        return (K) entity.createId(keyObj);
    }

    @Override
    public boolean checkHasNext() throws UPAException {
        return getQueryResult().hasNext();
    }

}
