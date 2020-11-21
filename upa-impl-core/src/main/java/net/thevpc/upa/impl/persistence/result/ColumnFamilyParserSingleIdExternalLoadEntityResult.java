package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserSingleIdExternalLoadEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserSingleIdExternalLoadEntityResult();

    private ColumnFamilyParserSingleIdExternalLoadEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultFieldParseData idField = columnFamily.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        TypeInfoSupParserHelper.loadExternalObject(id, columnFamily, lazyResult, parser);
    }

}
