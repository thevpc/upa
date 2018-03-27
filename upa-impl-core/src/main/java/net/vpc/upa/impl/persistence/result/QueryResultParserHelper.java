package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.impl.util.CacheMap;

import java.util.Map;

/**
 * Created by vpc on 7/10/17.
 */
public interface QueryResultParserHelper {
    CacheMap<NamedId, ResultObject> getReferencesCache();

    Map<String, Object> getHints();

    void addWorkspaceMissingObject(String entity, Object id);
}
