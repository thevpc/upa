package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Key;
import net.vpc.upa.NamedId;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.DefaultKey;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserMultiIdEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserMultiIdEntityResult();

    private ColumnFamilyParserMultiIdEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultObject resultObject;
        Object[] idarr = TypeInfoSupParserHelper.extractArrayId(result, columnFamily);
        if (idarr == null) {
            resultObject = ResultObject.forNull();
        } else {
            String entityName = columnFamily.entity.getName();
            NamedId key = new NamedId(idarr, entityName);
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                Key kid = new DefaultKey(idarr);
                Object old = parser.getEntityCollectionCache().findById(entityName, kid);
                if(old!=null){
                    o = columnFamily.importObject(old);
                }else {
                    o = columnFamily.createResultObject();
                    List<ResultFieldParseData> entityFields = columnFamily.idFields;
                    int length = idarr.length;
                    for (int i = 0; i < length; i++) {
                        ResultFieldParseData idField = entityFields.get(i);
                        o.entityDocument.setObject(idField.field.getName(), idarr[i]);
                    }
                    entityFields = columnFamily.nonIdFields;
                    for (ResultFieldParseData f : entityFields) {
                        Object fieldValue = result.read(f.dbIndex);
                        o.entityDocument.setObject(f.name, fieldValue);
                    }
                    if(!columnFamily.partialObject) {
                        parser.getEntityCollectionCache().add(entityName, kid, o.entityObject);
                    }
                }
                referencesCache.put(key, o);
            }
            resultObject = o;
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        columnFamily.currentResult=resultObject;
    }
}
