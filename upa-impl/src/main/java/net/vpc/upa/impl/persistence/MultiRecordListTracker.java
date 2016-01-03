package net.vpc.upa.impl.persistence;

import net.vpc.upa.Record;

import java.beans.PropertyChangeListener;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:55 AM
*/
class MultiRecordListTracker {
    String recordName;
    Record record;
    PropertyChangeListener changeListener;

    MultiRecordListTracker(String recordName, Record record, PropertyChangeListener changeListener) {
        this.recordName = recordName;
        this.record = record;
        this.changeListener = changeListener;
    }
}
