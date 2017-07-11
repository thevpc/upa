package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 2:20 AM
 */
class QueryResultUpdaterPropertyChangeListener implements PropertyChangeListener {

    private final QueryResult result;
    private final ColumnFamily columnFamily;

    public QueryResultUpdaterPropertyChangeListener(ColumnFamily columnFamily, QueryResult result) {
        this.result = result;
        this.columnFamily = columnFamily;
    }

    public void propertyChange(PropertyChangeEvent evt) {
        int index = columnFamily.fieldsMap.get(evt.getPropertyName()).dbIndex;
        result.write(index, evt.getNewValue());
    }
}
