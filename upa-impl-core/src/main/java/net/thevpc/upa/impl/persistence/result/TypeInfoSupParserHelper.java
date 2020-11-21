package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.EntityBuilder;
import net.thevpc.upa.Key;
import net.thevpc.upa.NamedId;
import net.thevpc.upa.QueryBuilder;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.DefaultKey;
import net.thevpc.upa.impl.cache.EntityCollectionCache;
import net.thevpc.upa.impl.util.CacheMap;
import net.thevpc.upa.persistence.QueryResult;

import java.util.List;

/**
 * Created by vpc on 7/10/17.
 */
public class TypeInfoSupParserHelper {
    private TypeInfoSupParserHelper() {
    }

    public static Object[] extractArrayId(QueryResult result, ResultFieldFamily columnFamily) throws UPAException {
        int size = columnFamily.idFields.size();
        Object[] idarr = new Object[size];
        List<ResultFieldParseData> idFields = columnFamily.idFields;
        for (int i = 0; i < idFields.size(); i++) {
            ResultFieldParseData f = idFields.get(i);
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

    public static void loadExternalObject(Object idarr, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        EntityCollectionCache c = parser.getEntityCollectionCache();
        ResultObject resultObject;
        if (idarr == null) {
            resultObject = ResultObject.forNull();
        } else {
            Key kid=new DefaultKey(idarr);
            NamedId key = new NamedId(idarr, columnFamily.entity.getName());
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                Object old = c.findById(columnFamily.entity.getName(),kid);
                if(old!=null){
                    o = ResultObject.forObject(old, columnFamily.entity.getBuilder(),columnFamily.documentType);
                }else {
                    EntityBuilder builder = columnFamily.entity.getBuilder();
                    QueryBuilder query = columnFamily.entity.createQueryBuilder().byId(idarr).setHints(parser.getHints());
                    if (columnFamily.documentType) {
                        o = ResultObject.forDocument(query.getDocument(), builder);
                    } else {
                        Object entityObject = query.<Object>getFirstResultOrNull();
                        o = ResultObject.forObject(entityObject, columnFamily.builder,columnFamily.documentType);
                        if(!columnFamily.partialObject){
                            c.add(columnFamily.entity.getName(),kid,o.entityObject);
                        }
                    }
                }
                referencesCache.put(key, o);
            }
            resultObject = o;
        }
        lazyResult.values.put(columnFamily.binding, resultObject.entityResult);
        columnFamily.currentResult=resultObject;
    }

    public static void todoExternalObject(Object idarr, ResultFieldFamily columnFamily, LazyResult lazyResult, QueryResultParserHelper parser) throws UPAException {
        if (idarr == null) {
            lazyResult.values.put(columnFamily.binding, null);
            columnFamily.currentResult=null;
        } else {
            NamedId key = new NamedId(idarr, columnFamily.entity.getName());
            CacheMap<NamedId, ResultObject> referencesCache = parser.getReferencesCache();
            ResultObject o = referencesCache.get(key);
            if (o == null) {
                lazyResult.incomplete = true;
                lazyResult.todos.put(columnFamily.binding, key);
                parser.addWorkspaceMissingObject(columnFamily.entity.getName(), idarr);
            }else{
                lazyResult.values.put(columnFamily.binding, o.entityResult);
            }
        }
    }
}
