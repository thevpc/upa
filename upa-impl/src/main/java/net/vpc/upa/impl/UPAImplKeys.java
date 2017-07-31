package net.vpc.upa.impl;

import net.vpc.upa.QueryHints;

/**
 * Created by vpc on 7/11/17.
 */
public class UPAImplKeys {
    public static final String System_Perf_ResultList_MaxReduceSize="UPA.perf.ResultList.MaxReduceSize";
    public static final String System_Perf_Connection_Query="UPA.perf.Connection.Query";
    public static final String System_Perf_Connection_NonQuery="UPA.perf.Connection.NonQuery";
    public static final String System_Perf_Connection_Statement="UPA.perf.Connection.Statement";
    /**
     * max joins in a query (and all its sub queries)
     * type int &gt;= 0 : default is 60, meaningful in join fetch strategy
     */
    public static final String QueryHints_maxColumns = "maxColumns";
    public static final String QueryHints_queryCache = "queryCache";
    public static final String QueryHints_maxHierarchyNavigationDepth = "maxHierarchyNavigationDepth";

    private UPAImplKeys() {
    }
}
