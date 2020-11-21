package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.NamedId;
import net.thevpc.upa.impl.cache.EntityCollectionCache;
import net.thevpc.upa.impl.util.CacheMap;

import java.util.Map;

/**
 * Created by vpc on 7/10/17.
 */
public interface QueryResultParserHelper {
    CacheMap<NamedId, ResultObject> getReferencesCache();

    EntityCollectionCache getEntityCollectionCache();

    Map<String, Object> getHints();

    void addWorkspaceMissingObject(String entity, Object id);
}
