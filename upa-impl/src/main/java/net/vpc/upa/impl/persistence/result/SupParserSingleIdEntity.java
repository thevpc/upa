package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Document;
import net.vpc.upa.NamedId;
import net.vpc.upa.ObjectFactory;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.BindingId;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/2/17.
 */
class SupParserSingleIdEntity implements TypeInfoSupParser {
    private ObjectFactory ofactory;

    public SupParserSingleIdEntity(ObjectFactory ofactory) {
        this.ofactory = ofactory;
    }

    @Override
    public void parse(QueryResult result, TypeInfo typeInfo, Map<BindingId, Object> groupValues, CacheMap<NamedId, Object> sharedCache) throws UPAException {
        FieldInfo idField = typeInfo.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        if (id == null) {
            typeInfo.currentResult = new ResultObject();
        } else {
            NamedId key = new NamedId(id, typeInfo.entity);
            ResultObject o = sharedCache == null ? null : ((ResultObject) sharedCache.get(key));
            if (o == null) {
                o = new ResultObject();
                if (typeInfo.document) {
                    Object entityObject = null;
                    Document entityDocument = typeInfo.builder == null ? ofactory.createObject(Document.class) : typeInfo.builder.createDocument();
                    o.entityObject = entityObject;
                    o.entityDocument = entityDocument;
                    o.entityResult = entityDocument;
                } else {
                    Object entityObject = typeInfo.builder.createObject();
                    Document entityDocument = typeInfo.entityConverter.objectToDocument(entityObject, true);
                    o.entityObject = entityObject;
                    o.entityDocument = entityDocument;
                    o.entityResult = entityObject;
                }
                if (sharedCache != null) {
                    sharedCache.put(key, o);
                }
                o.entityDocument.setObject(idField.field.getName(), id);
                List<FieldInfo> idFields = typeInfo.nonIdFields;
                for (FieldInfo f : idFields) {
                    Object fieldValue = result.read(f.dbIndex);
                    o.entityDocument.setObject(f.name, fieldValue);
                }
            }
            typeInfo.currentResult = o;
        }
        groupValues.put(typeInfo.binding, typeInfo.currentResult.entityResult);
    }
}
