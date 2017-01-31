package net.vpc.upa.impl.persistence;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.DefaultMultiDocument;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;

import java.beans.PropertyChangeListener;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/16/12
 * Time: 6:41 AM
 * To change this template use File | Settings | File Templates.
 */
public class MultiDocumentList extends QueryResultLazyList<MultiDocument> {
    private String[] documentName;
    private Entity[] entities;
    Map<String, Map<String, FieldTracking>> setterToProp;
    private Map<String, MultiDocumentListTracker> currentDocuments;
    private int columns;
    private NativeField[] fields;
    private boolean forUpdate;

    public MultiDocumentList(QueryExecutor queryExecutor, boolean forUpdate) throws SQLException, UPAException {
        super(queryExecutor);
        this.forUpdate = forUpdate;
        this.fields = queryExecutor.getFields();
        this.entities = new Entity[this.fields.length];
        this.documentName = new String[this.fields.length];
        this.currentDocuments =new HashMap<String, MultiDocumentListTracker>();
        this.setterToProp=new HashMap<String, Map<String, FieldTracking>>();
        int fieldsCount = fields.length;
        for (int i = 0; i < fieldsCount; i++) {
            NativeField namedExpression = fields[i];
            Field field = namedExpression.getField();
            entities[i] = field == null ? null : field.getEntity();
            if (namedExpression.getGroupName() != null) {
                documentName[i] = namedExpression.getGroupName();
            } else if (entities[i] != null) {
                documentName[i] = entities[i].getName();
            }
            Map<String, FieldTracking> stringFieldTrackingMap = setterToProp.get(documentName[i]);
            if (stringFieldTrackingMap == null) {
                stringFieldTrackingMap = new HashMap<String, FieldTracking>();
                setterToProp.put(documentName[i], stringFieldTrackingMap);
            }
            if (field != null) {
                FieldTracking t = new FieldTracking(field.getName(), PlatformUtils.setterName(field.getName()), i);
                stringFieldTrackingMap.put(t.getSetterMethodName(), t);
            }
        }
        columns = this.fields.length;
    }

    protected void resetListeners() {
        for (MultiDocumentListTracker tracker : currentDocuments.values()) {
            tracker.document.removePropertyChangeListener(tracker.changeListener);
        }
        currentDocuments.clear();
    }

    @PortabilityHint(target = "C#",name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        resetListeners();
    }

    @Override
    public MultiDocument parse(final QueryResult result) throws UPAException {
        if (forUpdate) {
            resetListeners();
            MultiDocument multiDocument = new DefaultMultiDocument();
            for (int i = 0; i < columns; i++) {
                String r = documentName[i];
                Document current;
                if (r == null) {
                    current = multiDocument.getPlainDocument(true);
                } else {
                    current = multiDocument.getDocument(r);
                    if (current == null) {
                        current = entities[i].getBuilder().createDocument();
                        multiDocument.setDocument(r, current);
                    }
                }
                current.setObject(fields[i].getName(), result.read(i));
                MultiDocumentListTracker tr = currentDocuments.get(documentName[i]);
                if(tr==null){
                    PropertyChangeListener li= new MultiDocumentListTrackPropertyChangeListener(this, r, result);
                    currentDocuments.put(documentName[i],new MultiDocumentListTracker(documentName[i],current,li));
                    current.addPropertyChangeListener(li);
                }
            }
            return multiDocument;
        } else {
            resetListeners();
            MultiDocument multiDocument = new DefaultMultiDocument();
            for (int i = 0; i < columns; i++) {
                String r = documentName[i];
                Document current;
                if (r == null) {
                    current = multiDocument.getPlainDocument(true);
                } else {
                    current = multiDocument.getDocument(r);
                    if (current == null) {
                        current = entities[i].getBuilder().createDocument();
                        multiDocument.setDocument(r, current);
                    }
                }
                current.setObject(fields[i].getName(), result.read(i));
            }
            return multiDocument;
        }
    }

}
