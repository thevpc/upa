package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.NamedId;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.upql.BindingId;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.QueryResult;
import net.thevpc.upa.persistence.ResultField;
import net.thevpc.upa.persistence.ResultMetaData;

import java.util.Collection;
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
    Map<BindingId, Object> values = new HashMap<BindingId, Object>();
    Map<BindingId, NamedId> todos = new HashMap<BindingId, NamedId>();
    Map<BindingId, ResultFieldFamily> types = new HashMap<BindingId, ResultFieldFamily>();

    public LazyResult(QueryResult result, boolean updatable, ResultMetaData metaData) {
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
                ResultFieldFamily parentType = types.get(parentBinding);
                Object parent = values.get(parentBinding);
                if (parent != null) {
                    parentType.setterFor(currBinding.getName()).set(parent, currValue);
                }
            }
        }
        List<ResultField> resultFields = metaData.getResultFields();
        ResultColumn[] columns = new ResultColumn[resultFields.size()];
        Collection<ResultFieldFamily> values2 = types.values();

        Map<BindingId,ResultColumn> bindingIdToResultColumn=new HashMap<>();
        for (int i = 0; i < columns.length; i++) {
            ResultColumn c = columns[i] = new ResultColumn();
            c.setLabel(resultFields.get(i).getAlias());
            BindingId bindingId = BindingId.create(String.valueOf(i));
            c.setValue(values.get(bindingId));
            bindingIdToResultColumn.put(bindingId,c);
        }

        if (updatable) {
//            if(columns.length!=values2.size()){
//                throw new UPAException("InvalidColumnIndexBinding",String.valueOf(columns.length!=values2.size()));
//            }
            for (ResultFieldFamily columnFamily : values2) {
                if (!columnFamily.currentResult.isNull()) {
                    if (columnFamily.documentType) {
                        QueryResultUpdaterPropertyChangeListener li = new QueryResultUpdaterPropertyChangeListener(columnFamily, result);
                        columnFamily.currentResult.entityDocument.addPropertyChangeListener(li);
                    } else {
                        Object entityUpdatable = PlatformUtils.createObjectInterceptor(
                                columnFamily.resultType,
                                new UpdatableObjectInterceptor(columnFamily, columnFamily.currentResult.entityObject, result));

                        columnFamily.currentResult.entityUpdatable=entityUpdatable;
                        this.values.put(columnFamily.binding, entityUpdatable);
                        ResultColumn resultColumn = bindingIdToResultColumn.get(columnFamily.binding);
                        if(resultColumn==null){
                            throw new UPAException("ResultColumnNotFound",columnFamily.binding);
                        }
//                        if (resultColumn.getValue() == columnFamily.resultType) {
                            resultColumn.setValue(columnFamily.currentResult.entityUpdatable);
//                        }
                    }
                }
            }
        }
        return columns;
    }
}
