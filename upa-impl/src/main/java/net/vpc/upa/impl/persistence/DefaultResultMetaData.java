package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/1/12 12:42 AM
 */
public class DefaultResultMetaData implements ResultMetaData {

    private List<String> fieldNames = new ArrayList<String>();
    private List<DataTypeTransform> fieldTypes = new ArrayList<DataTypeTransform>();
    private List<Field> fields = new ArrayList<Field>();

    public void addField(String name, DataTypeTransform type, Field field) {
        fieldNames.add(name);
        fieldTypes.add(type);
        fields.add(field);
    }

    @Override
    public int getFieldsCount() throws UPAException {
        return fields.size();
    }

    @Override
    public String getFieldName(int index) throws UPAException {
        return fieldNames.get(index);
    }

    @Override
    public DataType getFieldType(int index) throws UPAException {
        return fieldTypes.get(index).getSourceType();
    }

    public DataTypeTransform getFieldTransform(int index) throws UPAException {
        return fieldTypes.get(index);
    }

    @Override
    public Field getField(int index) throws UPAException {
        return fields.get(index);
    }

    @Override
    public Entity getEntity(int index) throws UPAException {
        Field f = getField(index);
        return f == null ? null : f.getEntity();
    }
}
