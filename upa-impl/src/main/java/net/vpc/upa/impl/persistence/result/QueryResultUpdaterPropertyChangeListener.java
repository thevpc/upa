package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 2:20 AM
 */
public class QueryResultUpdaterPropertyChangeListener implements PropertyChangeListener {

    private final QueryResult result;
    private final TypeInfo typeInfo;

    public QueryResultUpdaterPropertyChangeListener(TypeInfo typeInfo, QueryResult result) {
        this.result = result;
        this.typeInfo = typeInfo;
    }

    public void propertyChange(PropertyChangeEvent evt) {
        int index = typeInfo.fields.get(evt.getPropertyName()).dbIndex;
        result.write(index, evt.getNewValue());
    }
}
