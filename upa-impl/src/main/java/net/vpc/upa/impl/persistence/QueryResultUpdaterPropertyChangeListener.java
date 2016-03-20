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
    private final MergedRecordList records;
    private final TypeInfo typeInfo;

    public QueryResultUpdaterPropertyChangeListener(MergedRecordList records, TypeInfo typeInfo, QueryResult result) {
        this.records = records;
        this.result = result;
        this.typeInfo = typeInfo;
    }

    public void propertyChange(PropertyChangeEvent evt) {
        int index = typeInfo.fields.get(evt.getPropertyName()).index;
        result.write(index, evt.getNewValue());
    }
}
