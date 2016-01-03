package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 2:20 AM
*/
class QueryResultUpdaterPropertyChangeListener implements PropertyChangeListener {
    private final QueryResult result;
    private MergedRecordList records;

    public QueryResultUpdaterPropertyChangeListener(MergedRecordList records, QueryResult result) {
        this.records = records;
        this.result = result;
    }

    public void propertyChange(PropertyChangeEvent evt) {
        Integer i = records.nameToIndex.get(evt.getPropertyName());
        if (i != null) {
            result.write(i, evt.getNewValue());
        }
    }
}
