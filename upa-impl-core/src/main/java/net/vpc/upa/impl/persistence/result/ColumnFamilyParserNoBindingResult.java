package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserNoBindingResult implements ResultFieldFamilyParser {
    final static ColumnFamilyParserNoBindingResult INSTANCE=new ColumnFamilyParserNoBindingResult();

    private ColumnFamilyParserNoBindingResult() {
    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        for (ResultFieldParseData f : columnFamily.idFields) {
            Object fieldValue = result.read(f.dbIndex);
            lazyResult.values.put(f.binding, fieldValue);
        }
        for (ResultFieldParseData f : columnFamily.nonIdFields) {
            Object fieldValue = result.read(f.dbIndex);
            lazyResult.values.put(f.binding, fieldValue);
        }
    }
}
