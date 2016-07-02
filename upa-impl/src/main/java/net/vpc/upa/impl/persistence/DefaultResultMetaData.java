package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.EntityStatement;
import net.vpc.upa.expressions.QueryStatement;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.*;

import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/1/12 12:42 AM
 */
public class DefaultResultMetaData implements ResultMetaData {

    private Map<String,Object> properties = new HashMap<String, Object>();
    private List<ResultField> fields = new ArrayList<ResultField>();
    private EntityStatement statement;

    public EntityStatement getStatement() {
        return statement;
    }

    public void setStatement(EntityStatement statement) {
        this.statement = statement;
    }

    public void addField(ResultField field) {
        fields.add(field);
    }

    public List<ResultField> getFields() {
        return Collections.unmodifiableList(fields);
    }

    public Map<String, Object> getProperties() {
        return properties;
    }
}
