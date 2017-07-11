package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserNoIdEntity implements ColumnFamilyParser {
    public static final ColumnFamilyParser INSTANCE = new ColumnFamilyParserNoIdEntity();

    public ColumnFamilyParserNoIdEntity() {

    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultObject resultObject = columnFamily.createResultObject();
        List<FieldInfo> idFields = columnFamily.nonIdFields;
        for (FieldInfo f : idFields) {
            Object fieldValue = result.read(f.dbIndex);
            resultObject.entityDocument.setObject(f.name, fieldValue);
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        lazyResult.currentResult=resultObject;
    }
}
