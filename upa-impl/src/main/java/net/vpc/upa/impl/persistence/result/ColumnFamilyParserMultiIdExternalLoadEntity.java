package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserMultiIdExternalLoadEntity implements ColumnFamilyParser {
    public static final ColumnFamilyParser INSTANCE = new ColumnFamilyParserMultiIdExternalLoadEntity();

    private ColumnFamilyParserMultiIdExternalLoadEntity() {

    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        TypeInfoSupParserHelper.loadExternalObject(TypeInfoSupParserHelper.extractArrayId(result, columnFamily), columnFamily, lazyResult,parser);
    }
}
