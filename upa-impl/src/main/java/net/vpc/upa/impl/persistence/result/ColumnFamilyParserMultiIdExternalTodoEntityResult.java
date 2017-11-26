package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserMultiIdExternalTodoEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserMultiIdExternalTodoEntityResult();

    private ColumnFamilyParserMultiIdExternalTodoEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        TypeInfoSupParserHelper.todoExternalObject(TypeInfoSupParserHelper.extractArrayId(result, columnFamily), columnFamily, lazyResult,parser);
    }
}
