package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
class SupParserNoIdEntity implements TypeInfoSupParser {
    public static final TypeInfoSupParser INSTANCE = new SupParserNoIdEntity();

    public SupParserNoIdEntity() {

    }

    @Override
    public void parse(QueryResult result, TypeInfo typeInfo, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException {
        ResultObject o = typeInfo.createResultObject();
        typeInfo.currentResult = o;
        List<FieldInfo> idFields = typeInfo.nonIdFields;
        for (FieldInfo f : idFields) {
            Object fieldValue = result.read(f.dbIndex);
            o.entityDocument.setObject(f.name, fieldValue);
        }
        groupValues.put(typeInfo.binding, typeInfo.currentResult.entityResult);
    }
}
