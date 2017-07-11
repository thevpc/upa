package net.vpc.upa.impl.ext;

/**
 * Created by vpc on 7/11/17.
 */
public class QueryHintsExt {
    /**
     * max joins in a query (and all its sub queries)
     * type int &gt;= 0 : default is 60, meaningful in join fetch strategy
     */
    public static final String MAX_COLUMNS = "maxColumns";
}
