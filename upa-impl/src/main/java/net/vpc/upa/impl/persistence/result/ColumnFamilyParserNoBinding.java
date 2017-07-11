package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserNoBinding implements ColumnFamilyParser {
    final static ColumnFamilyParserNoBinding INSTANCE=new ColumnFamilyParserNoBinding();

    private ColumnFamilyParserNoBinding() {
    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        for (FieldInfo f : columnFamily.idFields) {
            Object fieldValue = result.read(f.dbIndex);
            lazyResult.values.put(f.binding, fieldValue);
        }
        for (FieldInfo f : columnFamily.nonIdFields) {
            Object fieldValue = result.read(f.dbIndex);
            lazyResult.values.put(f.binding, fieldValue);
        }
    }
}
