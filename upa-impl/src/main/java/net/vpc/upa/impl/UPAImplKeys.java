package net.vpc.upa.impl;

/**
 * Created by vpc on 7/11/17.
 */
public class UPAImplKeys {
    public static final String System_Perf_ResultList_MaxReduceSize="System.Perf.ResultList.MaxReduceSize";
    public static final String System_Perf_Connection_Query="System.Perf.Connection.Query";
    public static final String System_Perf_Connection_NonQuery="System.Perf.Connection.NonQuery";
    public static final String System_Perf_Connection_Statement="System.Perf.Connection.Statement";
    /**
     * max joins in a query (and all its sub queries)
     * type int &gt;= 0 : default is 60, meaningful in join fetch strategy
     */
    public static final String QueryHints_MAX_COLUMNS = "maxColumns";
    public static final String QueryHints_QUERY_CACHE = "queryCache";
    public static final String QueryHints_MAX_HIERARCHY_NAVIGATION_DEPTH = "maxHierarchyNavigationDepth";

    private UPAImplKeys() {
    }
}
