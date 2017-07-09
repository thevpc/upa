package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Document;
import net.vpc.upa.NamedId;
import net.vpc.upa.Query;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
class SupParserMultiIdExternalLoadEntity extends AbstractSupParserExternalLoadEntity {
    public static final TypeInfoSupParser INSTANCE = new SupParserMultiIdExternalLoadEntity();

    private SupParserMultiIdExternalLoadEntity() {

    }

    @Override
    public void parse(QueryResult result, TypeInfo typeInfo, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException {
        int size = typeInfo.idFields.size();
        Object[] idarr = new Object[size];
        List<FieldInfo> idFields = typeInfo.idFields;
        for (int i = 0; i < idFields.size(); i++) {
            FieldInfo f = idFields.get(i);
            Object fieldValue = result.read(f.dbIndex);
            if (fieldValue == null) {
                idarr = null;
                break;
            } else {
                idarr[i] = fieldValue;
            }
        }
        loadId(idarr,typeInfo, groupValues,loaderContext);
    }
}
