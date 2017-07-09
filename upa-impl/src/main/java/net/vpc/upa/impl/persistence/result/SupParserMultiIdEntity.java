package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
class SupParserMultiIdEntity implements TypeInfoSupParser {
    public static final TypeInfoSupParser INSTANCE = new SupParserMultiIdEntity();

    private SupParserMultiIdEntity() {

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
        if (idarr == null) {
            typeInfo.currentResult = new ResultObject();
        } else {
            NamedId key = new NamedId(idarr, typeInfo.entity);
            ResultObject o = loaderContext.getReferencesCache().get(key);
            if (o == null) {
                o = typeInfo.createResultObject();
                loaderContext.getReferencesCache().put(key, o);
                List<FieldInfo> entityFields = typeInfo.idFields;
                for (int i = 0; i < size; i++) {
                    FieldInfo idField = entityFields.get(i);
                    o.entityDocument.setObject(idField.field.getName(), idarr[i]);
                }
                entityFields = typeInfo.nonIdFields;
                for (FieldInfo f : entityFields) {
                    Object fieldValue = result.read(f.dbIndex);
                    o.entityDocument.setObject(f.name, fieldValue);
                }
            }
            typeInfo.currentResult = o;
        }
        groupValues.put(typeInfo.binding, typeInfo.currentResult.entityResult);
    }
}
