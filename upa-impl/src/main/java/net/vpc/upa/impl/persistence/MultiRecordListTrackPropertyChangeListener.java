package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.util.Map;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 3:05 AM
*/
class MultiRecordListTrackPropertyChangeListener implements PropertyChangeListener {
    private final String r;
    private final QueryResult result;
    private MultiRecordList multiRecords;

    public MultiRecordListTrackPropertyChangeListener(MultiRecordList multiRecords, String r, QueryResult result) {
        this.multiRecords = multiRecords;
        this.r = r;
        this.result = result;
    }

    @Override
    public void propertyChange(PropertyChangeEvent evt) {
        Map<String, FieldTracking> stringFieldTrackingMap = multiRecords.setterToProp.get(r);
        FieldTracking t = stringFieldTrackingMap.get(evt.getPropertyName());
        if(t!=null){
            result.write(t.getIndex(),evt.getNewValue());
        }
    }
}
