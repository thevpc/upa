package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.DefaultBeanAdapter;
import net.vpc.upa.persistence.QueryResult;

import java.sql.SQLException;
import java.util.List;

public class TypeList<T> extends QueryResultIteratorList<T> {
    private int columns;
    private DefaultBeanAdapter beanAdapter;
    private String[] fields;
    private String[] fieldsByExpression;
    public TypeList(NativeSQL nativeSQL, Class<T> entity, String[] fields) throws SQLException {
        super(nativeSQL);
        NativeField[] expressions = nativeSQL.getFields();
        this.fields = fields;
        beanAdapter=new DefaultBeanAdapter(entity);
        if(fields==null || fields.length==0){
            List<String> fieldNames = beanAdapter.getFieldNames();
            this.fields=fieldNames.toArray(new String[fieldNames.size()]);
        }
        fieldsByExpression=new String[expressions.length];
        for (int i = 0; i < fieldsByExpression.length; i++) {
            NativeField  e = expressions[i];
            String name = e.getName();
            for (String field : this.fields) {
                if (name.equals(field)) {
                    fieldsByExpression[i] = field;
                    break;
                }
            }
        }
        columns = expressions.length;
    }

    @Override
    public T parse(QueryResult result) throws UPAException {
        T instance = (T) beanAdapter.newInstance();
        for (int i = 0; i < columns; i++) {
            Object v = result.read(i);
            if(fieldsByExpression[i]!=null){
                beanAdapter.setProperty(instance, fieldsByExpression[i], v);
            }
        }
        return instance;
    }
}
