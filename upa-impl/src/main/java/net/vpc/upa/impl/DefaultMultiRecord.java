package net.vpc.upa.impl;

import net.vpc.upa.MultiRecord;
import net.vpc.upa.Record;

import java.util.HashMap;
import java.util.Map;

public class DefaultMultiRecord implements MultiRecord {
    public static final String NO_ENTITY = "*";
    private Map<String, Record> records = new HashMap<String, Record>();
    private Record plainRecord;

    public int entitySize() {
        int size = 0;
        if (isValidRecord(plainRecord)) {
            size++;
        }
        for (Record record : records.values()) {
            if (isValidRecord(record)) {
                size++;
            }
        }
        return size;
    }

    private boolean isValidRecord(Record r) {
        return r != null && r.size() > 0;
    }

    public int fieldSize() {
        int s = 0;
        for (Record record : records.values()) {
            s += record.size();
        }
        return s;
    }

    public Record getPlainRecord() {
        return getPlainRecord(false);
    }

    public Record getPlainRecord(boolean create) {
        if (plainRecord == null && create) {
            plainRecord = new DefaultRecord();
        }
        return plainRecord;
    }

    public Record getRecord(String entityName) {
        return records.get(entityName);
    }

    public void setRecord(String entityName, Record record) {
        if (record == null) {
            records.remove(entityName);
        } else {
            records.put(entityName, record);
        }
    }

    public Record getSingleRecord() {
        if (entitySize() == 1) {
            if (isValidRecord(plainRecord)) {
                return plainRecord;
            }
            for (Record record : records.values()) {
                if (isValidRecord(record)) {
                    return record;
                }
            }
        }
        throw new IndexOutOfBoundsException();
    }

    public Record merge() {
        Record r = new DefaultRecord();
        if (plainRecord != null) {
            r.setAll(plainRecord);
        }
        for (Record record : records.values()) {
            r.setAll(record);
        }
        return r;
    }

}
