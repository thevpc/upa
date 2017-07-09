package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.persistence.QueryResult;

import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
interface TypeInfoSupParser {
    //Map<BindingId, Object> groupValues
    void parse(final QueryResult result, TypeInfo type, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException;
}
