package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserMultiIdExternalLoadEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserMultiIdExternalLoadEntityResult();

    private ColumnFamilyParserMultiIdExternalLoadEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        TypeInfoSupParserHelper.loadExternalObject(TypeInfoSupParserHelper.extractArrayId(result, columnFamily), columnFamily, lazyResult,parser);
    }
}
