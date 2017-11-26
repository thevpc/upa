package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserSingleIdEntityResult implements ResultFieldFamilyParser {
    public static final ResultFieldFamilyParser INSTANCE = new ColumnFamilyParserSingleIdEntityResult();

    private ColumnFamilyParserSingleIdEntityResult() {

    }

    @Override
    public void parse(QueryResult result, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultFieldParseData idField = columnFamily.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        ResultObject resultObject;
        if (id == null) {
            resultObject = ResultObject.forNull();
        } else {
            NamedId key = new NamedId(id, columnFamily.entity.getName());
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                o = columnFamily.createResultObject();
                referencesCache.put(key, o);
                o.entityDocument.setObject(idField.field.getName(), id);
                List<ResultFieldParseData> fields = columnFamily.nonIdFields;
                for (ResultFieldParseData f : fields) {
                    Object fieldValue = result.read(f.dbIndex);
                    o.entityDocument.setObject(f.name, fieldValue);
                }
//            }else{
//                List<ResultFieldParseData> fields = columnFamily.nonIdFields;
//                for (ResultFieldParseData f : fields) {
//                    Object fieldValue = result.read(f.dbIndex);
//                    o.entityDocument.setObject(f.name, fieldValue);
//                }
            }
            resultObject = o;
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        columnFamily.currentResult=resultObject;
    }
}
