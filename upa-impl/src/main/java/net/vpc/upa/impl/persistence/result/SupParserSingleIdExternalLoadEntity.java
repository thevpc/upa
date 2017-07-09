package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.persistence.QueryResult;

import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
class SupParserSingleIdExternalLoadEntity extends AbstractSupParserExternalLoadEntity {
    public static final TypeInfoSupParser INSTANCE = new SupParserSingleIdExternalLoadEntity();

    private SupParserSingleIdExternalLoadEntity() {

    }

    @Override
    public void parse(QueryResult result, TypeInfo typeInfo, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException {
        FieldInfo idField = typeInfo.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        loadId(id, typeInfo, groupValues, loaderContext);
    }

}
