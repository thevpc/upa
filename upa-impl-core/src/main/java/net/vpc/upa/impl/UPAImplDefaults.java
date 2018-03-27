package net.vpc.upa.impl;


/**
 * Created by vpc on 7/11/17.
 */
public class UPAImplDefaults {
    public static final int QueryHints_MAX_JOINS=60;
    public static final int QueryHints_MAX_COLUMNS=1000;
    public static final int QueryHints_MAX_NAVIGATION_DEPTH=60;
    public static final int QueryHints_MAX_HIERARCHY_NAVIGATION_DEPTH=1;
    public static final int QueryHints_REDUCE_BUFFER_SIZE=10000000;
    public static final int QueryHints_CACHE_SIZE=100000;
    public static boolean PRODUCTION_MODE=true;

    private UPAImplDefaults() {
    }
}
