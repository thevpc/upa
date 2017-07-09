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
class SupParserSingleIdEntity implements TypeInfoSupParser {
    public static final TypeInfoSupParser INSTANCE = new SupParserSingleIdEntity();

    private SupParserSingleIdEntity() {

    }

    @Override
    public void parse(QueryResult result, TypeInfo typeInfo, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException {
        FieldInfo idField = typeInfo.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        System.out.println("read "+idField+" => "+id);
        if (id == null) {
            typeInfo.currentResult = new ResultObject();
        } else {
            NamedId key = new NamedId(id, typeInfo.entity);
            ResultObject o = loaderContext.getReferencesCache().get(key);
            if (o == null) {
                o = typeInfo.createResultObject();
                loaderContext.getReferencesCache().put(key, o);
                o.entityDocument.setObject(idField.field.getName(), id);
                List<FieldInfo> fields = typeInfo.nonIdFields;
                for (FieldInfo f : fields) {
                    Object fieldValue = result.read(f.dbIndex);
                    o.entityDocument.setObject(f.name, fieldValue);
//                    System.out.println("read "+f+" => "+id+"   ___   "+o.entityDocument);
                }
            }
            typeInfo.currentResult = o;
        }
        groupValues.put(typeInfo.binding, typeInfo.currentResult.entityResult);
    }
}
