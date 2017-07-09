package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Document;

import java.beans.PropertyChangeListener;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:55 AM
*/
class MultiDocumentListTracker {
    String documentName;
    Document document;
    PropertyChangeListener changeListener;

    MultiDocumentListTracker(String documentName, Document document, PropertyChangeListener changeListener) {
        this.documentName = documentName;
        this.document = document;
        this.changeListener = changeListener;
    }
}
