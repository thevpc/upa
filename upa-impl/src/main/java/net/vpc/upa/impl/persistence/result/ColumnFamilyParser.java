package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
interface ColumnFamilyParser {
    //Map<BindingId, Object> values
    void parse(final QueryResult result, ColumnFamily type, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException;
}
