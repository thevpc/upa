package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.Entity;
import net.vpc.upa.NamedId;
import net.vpc.upa.Query;
import net.vpc.upa.impl.util.CacheMap;

/**
 * Created by vpc on 6/26/16.
 */
public class QueryRelationLoaderSelectObject implements QueryResultRelationLoader {
    public Object loadObject(Entity e, Object id,boolean document,LoaderContext context){
        NamedId cacheId = new NamedId(id, e.getName());
        CacheMap<NamedId, Object> referencesCache = context.getReferencesCache();
        Object existingValue = referencesCache.get(cacheId);
        if(existingValue==null && !referencesCache.containsKey(cacheId)){
            Query query = e.createQueryBuilder().byId(id).setHints(context.getHints());
            existingValue= document?query.getDocument():query.<Object>getFirstResultOrNull();
            referencesCache.put(cacheId,existingValue);
        }
        return existingValue;
    }
}
