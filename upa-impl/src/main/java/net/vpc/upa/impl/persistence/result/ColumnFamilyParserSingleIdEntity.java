package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserSingleIdEntity implements ColumnFamilyParser {
    public static final ColumnFamilyParser INSTANCE = new ColumnFamilyParserSingleIdEntity();

    private ColumnFamilyParserSingleIdEntity() {

    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        FieldInfo idField = columnFamily.idFields.get(0);
        Object id = result.read(idField.dbIndex);
        ResultObject resultObject;
        if (id == null) {
            resultObject = ResultObject.forNull();
        } else {
            NamedId key = new NamedId(id, columnFamily.entity);
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                o = columnFamily.createResultObject();
                referencesCache.put(key, o);
                o.entityDocument.setObject(idField.field.getName(), id);
                List<FieldInfo> fields = columnFamily.nonIdFields;
                for (FieldInfo f : fields) {
                    Object fieldValue = result.read(f.dbIndex);
                    o.entityDocument.setObject(f.name, fieldValue);
//                    System.out.println("read "+f+" => "+id+"   ___   "+o.entityDocument);
                }
            }
            resultObject = o;
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        columnFamily.currentResult=resultObject;
    }
}
