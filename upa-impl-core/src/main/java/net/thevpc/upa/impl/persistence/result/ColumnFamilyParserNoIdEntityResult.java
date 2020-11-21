package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserNoIdEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserNoIdEntityResult();

    public ColumnFamilyParserNoIdEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultObject resultObject = columnFamily.createResultObject();
        List<ResultFieldParseData> idFields = columnFamily.nonIdFields;
        for (ResultFieldParseData f : idFields) {
            Object fieldValue = result.read(f.dbIndex);
            resultObject.entityDocument.setObject(f.name, fieldValue);
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        columnFamily.currentResult=resultObject;
    }
}
