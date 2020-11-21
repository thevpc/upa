package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.expressions.EntityStatement;
import net.thevpc.upa.persistence.ResultField;
import net.thevpc.upa.persistence.ResultMetaData;

import java.util.*;

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

    public List<ResultField> getResultFields() {
        return Collections.unmodifiableList(fields);
    }

    public Map<String, Object> getProperties() {
        return properties;
    }
}
