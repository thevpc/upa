package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.Entity;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.QueryExecutor;
import net.thevpc.upa.persistence.QueryResult;

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
