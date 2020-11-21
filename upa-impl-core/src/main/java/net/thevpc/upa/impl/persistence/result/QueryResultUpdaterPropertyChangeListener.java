package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 2:20 AM
 */
class QueryResultUpdaterPropertyChangeListener implements PropertyChangeListener {

    private final QueryResult result;
    private final ResultFieldFamily columnFamily;

    public QueryResultUpdaterPropertyChangeListener(ResultFieldFamily columnFamily, QueryResult result) {
        this.result = result;
        this.columnFamily = columnFamily;
    }

    public void propertyChange(PropertyChangeEvent evt) {
        int index = columnFamily.fieldsMap.get(evt.getPropertyName()).dbIndex;
        result.write(index, evt.getNewValue());
    }
}
