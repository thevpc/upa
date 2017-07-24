package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.NativeField;
import net.vpc.upa.impl.persistence.QueryExecutor;
import net.vpc.upa.impl.persistence.result.QueryResultLazyList;
import net.vpc.upa.impl.util.PlatformBeanTypeRepository;
import net.vpc.upa.persistence.QueryResult;

import java.sql.SQLException;
import java.util.Set;

public class TypeList<T> extends QueryResultLazyList<T> {
    private int columns;
    private PlatformBeanType platformBeanType;
    private String[] fields;
    private String[] fieldsByExpression;
    public TypeList(QueryExecutor queryExecutor, Class<T> entity, String[] fields) throws SQLException {
        super(queryExecutor);
        NativeField[] expressions = queryExecutor.getFields();
        this.fields = fields;
        platformBeanType = PlatformBeanTypeRepository.getInstance().getBeanType(entity);
        if(fields==null || fields.length==0){
            Set<String> fieldNames = platformBeanType.getPropertyNames();
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

    public T loadNext() throws UPAException {
        QueryResult result = getQueryResult();
        T instance = (T) platformBeanType.newInstance();
        System.out.println("---New Line");
        for (int i = 0; i < columns; i++) {
            Object v = result.read(i);
            System.out.println("\t"+i+""+v);
            if(fieldsByExpression[i]!=null){
                platformBeanType.setProperty(instance, fieldsByExpression[i], v);
            }
        }
        return instance;
    }

    @Override
    public boolean checkHasNext() throws UPAException {
        return getQueryResult().hasNext();
    }

}
