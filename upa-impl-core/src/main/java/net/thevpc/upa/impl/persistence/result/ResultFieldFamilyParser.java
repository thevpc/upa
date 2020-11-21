package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.QueryResult;

/**
 * Created by vpc on 7/2/17.
 */
interface ResultFieldFamilyParser {
    //Map<BindingId, Object> values
    void parse(final QueryResult result, ResultFieldFamily type, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException;
}
