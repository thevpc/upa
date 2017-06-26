package net.vpc.upa;

/**
 * Created by vpc on 6/17/16.
 */
public final class QueryHints {
    /**
     * when true password transformations are disabled. this is helpful when copying entities (import/export)
     * type : boolean, default is false
     */
    public static final String NO_TYPE_TRANSFORM = "noTypeTransform";

    /**
     * type : string enum {select, join}, default is 'join'
     */
    public static final String FETCH_STRATEGY = "fetchStrategy";

    /**
     * sub entities depth
     * type int &gt;= 0 : default is 3, meaningful in join fetch strategy
     */
    public static final String NAVIGATION_DEPTH = "navigationDepth";

    private QueryHints() {
    }
}
