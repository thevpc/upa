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
abstract class AbstractSupParserExternalLoadEntity implements TypeInfoSupParser {
    protected AbstractSupParserExternalLoadEntity() {

    }

    public void loadId(Object idarr, TypeInfo typeInfo, Map<BindingId, Object> groupValues, LoaderContext loaderContext) throws UPAException {
        if (idarr == null) {
            typeInfo.currentResult = new ResultObject();
        } else {
            NamedId key = new NamedId(idarr, typeInfo.entity);
            ResultObject o = loaderContext.getReferencesCache().get(key);
            if (o == null) {
                o = new ResultObject();
                Query query = typeInfo.entity.createQueryBuilder().byId(idarr).setHints(loaderContext.getHints());
                if (typeInfo.documentType) {
                    Object entityObject = null;
                    Document entityDocument = query.getDocument();
                    o.entityObject = entityObject;
                    o.entityDocument = entityDocument;
                    o.entityResult = entityDocument;
                } else {
                    Object entityObject = query.<Object>getFirstResultOrNull();
                    Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
                    o.entityObject = entityObject;
                    o.entityDocument = entityDocument;
                    o.entityResult = entityObject;
                }
                loaderContext.getReferencesCache().put(key, o);
            }
            typeInfo.currentResult = o;
        }
        groupValues.put(typeInfo.binding, typeInfo.currentResult.entityResult);
    }
}
