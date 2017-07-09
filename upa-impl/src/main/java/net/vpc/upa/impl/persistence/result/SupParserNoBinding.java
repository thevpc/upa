package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.persistence.QueryResult;

import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
class SupParserNoBinding implements TypeInfoSupParser {
    final static SupParserNoBinding INSTANCE=new SupParserNoBinding();

    private SupParserNoBinding() {
    }

    @Override
    public void parse(QueryResult result, TypeInfo typeInfo, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException {
        for (FieldInfo f : typeInfo.idFields) {
            Object fieldValue = result.read(f.dbIndex);
            groupValues.put(f.binding, fieldValue);
        }
        for (FieldInfo f : typeInfo.nonIdFields) {
            Object fieldValue = result.read(f.dbIndex);
            groupValues.put(f.binding, fieldValue);
        }
    }
}
