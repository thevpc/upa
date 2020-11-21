package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.impl.persistence.FieldTracking;
import net.thevpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.util.Map;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 3:05 AM
*/
class MultiDocumentListTrackPropertyChangeListener implements PropertyChangeListener {
    private final String r;
    private final QueryResult result;
    private MultiDocumentList multiDocuments;

    public MultiDocumentListTrackPropertyChangeListener(MultiDocumentList multiDocuments, String r, QueryResult result) {
        this.multiDocuments = multiDocuments;
        this.r = r;
        this.result = result;
    }

    @Override
    public void propertyChange(PropertyChangeEvent evt) {
        Map<String, FieldTracking> stringFieldTrackingMap = multiDocuments.setterToProp.get(r);
        FieldTracking t = stringFieldTrackingMap.get(evt.getPropertyName());
        if(t!=null){
            result.write(t.getIndex(),evt.getNewValue());
        }
    }
}
