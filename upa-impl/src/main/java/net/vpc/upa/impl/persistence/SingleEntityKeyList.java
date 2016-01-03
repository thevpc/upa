package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

import java.sql.SQLException;

public class SingleEntityKeyList<K> extends QueryResultIteratorList<K> {
    private int columns;
    private Entity entity;
    public SingleEntityKeyList(NativeSQL nativeSQL, Entity entity) throws SQLException {
        super(nativeSQL);
        this.entity = entity;
        columns = nativeSQL.getFields().length;
    }

    @Override
    public K parse(QueryResult result) throws UPAException {
        Object[] keyObj = new Object[columns];
        for (int i = 0; i < columns; i++) {
            keyObj[i] = result.read(i);
        }
        return (K) entity.createId(keyObj);
    }
}
