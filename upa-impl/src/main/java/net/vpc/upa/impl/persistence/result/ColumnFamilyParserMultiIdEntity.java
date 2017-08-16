package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/2/17.
 */
class ColumnFamilyParserMultiIdEntity implements ColumnFamilyParser {
    public static final ColumnFamilyParser INSTANCE = new ColumnFamilyParserMultiIdEntity();

    private ColumnFamilyParserMultiIdEntity() {

    }

    @Override
    public void parse(QueryResult result, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultObject resultObject;
        Object[] idarr = TypeInfoSupParserHelper.extractArrayId(result, columnFamily);
        if (idarr == null) {
            resultObject = ResultObject.forNull();
        } else {
            NamedId key = new NamedId(idarr, columnFamily.entity.getName());
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                o = columnFamily.createResultObject();
                referencesCache.put(key, o);
                List<FieldInfo> entityFields = columnFamily.idFields;
                int length = idarr.length;
                for (int i = 0; i < length; i++) {
                    FieldInfo idField = entityFields.get(i);
                    o.entityDocument.setObject(idField.field.getName(), idarr[i]);
                }
                entityFields = columnFamily.nonIdFields;
                for (FieldInfo f : entityFields) {
                    Object fieldValue = result.read(f.dbIndex);
                    o.entityDocument.setObject(f.name, fieldValue);
                }
            }
            resultObject = o;
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        columnFamily.currentResult=resultObject;
    }
}
