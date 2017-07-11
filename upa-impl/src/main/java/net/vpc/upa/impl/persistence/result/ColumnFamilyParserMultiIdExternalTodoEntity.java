package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserMultiIdExternalTodoEntity implements ColumnFamilyParser {
    public static final ColumnFamilyParser INSTANCE = new ColumnFamilyParserMultiIdExternalTodoEntity();

    private ColumnFamilyParserMultiIdExternalTodoEntity() {

    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        TypeInfoSupParserHelper.todoExternalObject(TypeInfoSupParserHelper.extractArrayId(result, columnFamily), columnFamily, lazyResult,parser);
    }
}
