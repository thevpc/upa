package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultField;
import net.vpc.upa.persistence.ResultMetaData;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/10/17.
 */
public class LazyResult {
    QueryResult result;
    boolean updatable;
    boolean incomplete;
    ResultMetaData metaData;
    ResultObject currentResult;
    Map<BindingId, Object> values = new HashMap<BindingId, Object>();
    Map<BindingId, NamedId> todos = new HashMap<BindingId, NamedId>();
    Map<BindingId, ColumnFamily> types = new HashMap<BindingId, ColumnFamily>();

    public LazyResult(QueryResult result, boolean updatable,ResultMetaData metaData) {
        this.result = result;
        this.updatable = updatable;
        this.metaData = metaData;
    }

    public ResultColumn[] build() {
        for (Map.Entry<BindingId, Object> e : values.entrySet()) {
            BindingId currBinding = e.getKey();
            Object currValue = e.getValue();
            BindingId parentBinding = currBinding.getParent();
            if (parentBinding != null) {
                ColumnFamily parentType = types.get(parentBinding);
                Object parent = values.get(parentBinding);
                if (parent != null) {
                    parentType.setterFor(currBinding.getName()).set(parent, currValue);
                }
            }
        }
        List<ResultField> resultFields = metaData.getResultFields();
        ResultColumn[] columns = new ResultColumn[resultFields.size()];
        if (updatable) {
            for (ColumnFamily columnFamily : types.values()) {
                if (columnFamily.documentType) {
                    QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(columnFamily, result);
                    currentResult.entityDocument.addPropertyChangeListener(li);
                } else {
                    currentResult.entityUpdatable = PlatformUtils.createObjectInterceptor(
                            columnFamily.resultType,
                            new UpdatableObjectInterceptor(columnFamily, currentResult.entityObject, result));
                    values.put(columnFamily.binding, currentResult.entityUpdatable);
                    int index = columnFamily.nonIdFields.get(0).nativeField.getIndex();
                    if (columns[index].getValue() == columnFamily.resultType) {
                        columns[index].setValue(currentResult.entityUpdatable);
                    }
                }
            }
        }
        for (int i = 0; i < columns.length; i++) {
            ResultColumn c=columns[i] = new ResultColumn();
            c.setLabel(resultFields.get(i).getAlias());
            c.setValue(values.get(BindingId.create(String.valueOf(i))));
        }
        return columns;
    }
}
