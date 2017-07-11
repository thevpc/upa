package net.vpc.upa.impl;

import net.vpc.upa.QueryHints;

/**
 * Created by vpc on 7/11/17.
 */
public class UPAImplDefaults {
    public static final int QueryHints_MAX_JOINS=60;
    public static final int QueryHints_MAX_COLUMNS=1000;
    public static final int QueryHints_MAX_NAVIGATION_DEPTH=60;
    public static final int QueryHints_MAX_HIERARCHY_NAVIGATION_DEPTH=3;
    public static final int QueryHints_REDUCE_BUFFER_SIZE=1000;
    public static final int QueryHints_CACHE_SIZE=10000;
    public static boolean PRODUCTION_MODE=true;

    private UPAImplDefaults() {
    }
}
