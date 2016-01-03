package net.vpc.upa.impl.persistence;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.DefaultMultiRecord;
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
public class MultiRecordList extends QueryResultIteratorList<MultiRecord> {
    private String[] recordName;
    private Entity[] entities;
    Map<String, Map<String, FieldTracking>> setterToProp;
    private Map<String, MultiRecordListTracker> currentRecords;
    private int columns;
    private NativeField[] fields;
    private boolean forUpdate;

    public MultiRecordList(NativeSQL nativeSQL, boolean forUpdate) throws SQLException, UPAException {
        super(nativeSQL);
        this.forUpdate = forUpdate;
        this.fields = nativeSQL.getFields();
        this.entities = new Entity[this.fields.length];
        this.recordName = new String[this.fields.length];
        this.currentRecords=new HashMap<String, MultiRecordListTracker>();
        this.setterToProp=new HashMap<String, Map<String, FieldTracking>>();
        int fieldsCount = fields.length;
        for (int i = 0; i < fieldsCount; i++) {
            NativeField namedExpression = fields[i];
            Field field = namedExpression.getField();
            entities[i] = field == null ? null : field.getEntity();
            if (namedExpression.getGroupName() != null) {
                recordName[i] = namedExpression.getGroupName();
            } else if (entities[i] != null) {
                recordName[i] = entities[i].getName();
            }
            Map<String, FieldTracking> stringFieldTrackingMap = setterToProp.get(recordName[i]);
            if (stringFieldTrackingMap == null) {
                stringFieldTrackingMap = new HashMap<String, FieldTracking>();
                setterToProp.put(recordName[i], stringFieldTrackingMap);
            }
            if (field != null) {
                FieldTracking t = new FieldTracking(field.getName(), PlatformUtils.setterName(field.getName()), i);
                stringFieldTrackingMap.put(t.getSetterMethodName(), t);
            }
        }
        columns = this.fields.length;
    }

    protected void resetListeners() {
        for (MultiRecordListTracker tracker : currentRecords.values()) {
            tracker.record.removePropertyChangeListener(tracker.changeListener);
        }
        currentRecords.clear();
    }

    @PortabilityHint(target = "C#",name = "ignore")
    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        resetListeners();
    }

    @Override
    public MultiRecord parse(final QueryResult result) throws UPAException {
        if (forUpdate) {
            resetListeners();
            MultiRecord multiRecord = new DefaultMultiRecord();
            for (int i = 0; i < columns; i++) {
                String r = recordName[i];
                Record current;
                if (r == null) {
                    current = multiRecord.getPlainRecord(true);
                } else {
                    current = multiRecord.getRecord(r);
                    if (current == null) {
                        current = entities[i].getBuilder().createRecord();
                        multiRecord.setRecord(r, current);
                    }
                }
                current.setObject(fields[i].getName(), result.read(i));
                MultiRecordListTracker tr = currentRecords.get(recordName[i]);
                if(tr==null){
                    PropertyChangeListener li= new MultiRecordListTrackPropertyChangeListener(this, r, result);
                    currentRecords.put(recordName[i],new MultiRecordListTracker(recordName[i],current,li));
                    current.addPropertyChangeListener(li);
                }
            }
            return multiRecord;
        } else {
            resetListeners();
            MultiRecord multiRecord = new DefaultMultiRecord();
            for (int i = 0; i < columns; i++) {
                String r = recordName[i];
                Record current;
                if (r == null) {
                    current = multiRecord.getPlainRecord(true);
                } else {
                    current = multiRecord.getRecord(r);
                    if (current == null) {
                        current = entities[i].getBuilder().createRecord();
                        multiRecord.setRecord(r, current);
                    }
                }
                current.setObject(fields[i].getName(), result.read(i));
            }
            return multiRecord;
        }
    }

}
