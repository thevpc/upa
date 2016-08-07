package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.NamedId;
import net.vpc.upa.impl.util.CacheMap;

import java.util.Map;

/**
 * Created by vpc on 6/26/16.
 */
public class LoaderContext {
    protected CacheMap<NamedId, Object> referencesCache;
    protected Map<String, Object> hints;

    public LoaderContext(CacheMap<NamedId, Object> referencesCache, Map<String, Object> hints) {
        this.referencesCache = referencesCache;
        this.hints = hints;
    }

    public CacheMap<NamedId, Object> getReferencesCache() {
        return referencesCache;
    }

    public Map<String, Object> getHints() {
        return hints;
    }
}
