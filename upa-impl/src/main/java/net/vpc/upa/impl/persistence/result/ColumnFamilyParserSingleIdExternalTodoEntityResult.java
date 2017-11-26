package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserSingleIdExternalTodoEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserSingleIdExternalTodoEntityResult();

    private ColumnFamilyParserSingleIdExternalTodoEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultFieldParseData idField = columnFamily.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        TypeInfoSupParserHelper.todoExternalObject(id, columnFamily, lazyResult, parser);
    }

}
