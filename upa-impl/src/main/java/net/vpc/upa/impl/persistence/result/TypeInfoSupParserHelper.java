package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Document;
import net.vpc.upa.NamedId;
import net.vpc.upa.Query;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.CacheMap;
import net.vpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/10/17.
 */
public class TypeInfoSupParserHelper {
    private TypeInfoSupParserHelper() {
    }

    public static Object[] extractArrayId(QueryResult result, ColumnFamily columnFamily) throws UPAException {
        int size = columnFamily.idFields.size();
        Object[] idarr = new Object[size];
        List<FieldInfo> idFields = columnFamily.idFields;
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
        return idarr;
    }

    public static void loadExternalObject(Object idarr, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultObject resultObject;
        if (idarr == null) {
            resultObject = new ResultObject();
        } else {
            NamedId key = new NamedId(idarr, columnFamily.entity);
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                o = new ResultObject();
                Query query = columnFamily.entity.createQueryBuilder().byId(idarr).setHints(parser.getHints());
                if (columnFamily.documentType) {
                    Object entityObject = null;
                    Document entityDocument = query.getDocument();
                    o.entityObject = entityObject;
                    o.entityDocument = entityDocument;
                    o.entityResult = entityDocument;
                } else {
                    Object entityObject = query.<Object>getFirstResultOrNull();
                    Document entityDocument = columnFamily.entityConverter.objectToDocument(entityObject, true);
                    o.entityObject = entityObject;
                    o.entityDocument = entityDocument;
                    o.entityResult = entityObject;
                }
                referencesCache.put(key, o);
            }
            resultObject = o;
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        lazyResult.currentResult=resultObject;
    }

    public static void todoExternalObject(Object idarr, ColumnFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        ResultObject resultObject;
        if (idarr == null) {
            resultObject = new ResultObject();
            lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
            lazyResult.currentResult=resultObject;
        } else {
            NamedId key = new NamedId(idarr, columnFamily.entity);
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                lazyResult.incomplete=true;
                lazyResult.todos.put(columnFamily.binding, key);
                parser.addWorkspaceMissingObject(columnFamily.entity.getName(),idarr);
            }
        }
    }
}