package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.impl.util.CacheMap;

import java.util.Map;

/**
 * Created by vpc on 6/26/16.
 */
public class LoaderContext {
    protected CacheMap<NamedId, ResultObject> referencesCache;
    protected Map<String, Object> hints;

    public LoaderContext(CacheMap<NamedId, ResultObject> referencesCache, Map<String, Object> hints) {
        this.referencesCache = referencesCache;
        this.hints = hints;
    }

    public CacheMap<NamedId, ResultObject> getReferencesCache() {
        return referencesCache;
    }

    public Map<String, Object> getHints() {
        return hints;
    }
}
