/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{

    /**
     * Created by vpc on 6/17/16.
     */
    public sealed class QueryHints {

        /**
             * when true password transformations are disabled. this is helpful when copying entities (import/export)
             * type : boolean
             * default : false
             */
        public const string NO_TYPE_TRANSFORM = "noTypeTransform";

        /**
             * type :QueryFetchStrategy enum {select, join}
             * default is 'join'
             * @see QueryFetchStrategy see QueryFetchStrategy for possible values
             */
        public const string FETCH_STRATEGY = "fetchStrategy";

        /**
             * sub entities depth
             * type int &gt;= 0 : default is 60, meaningful in join fetch strategy
             */
        public const string MAX_NAVIGATION_DEPTH = "maxNavigationDepth";

        /**
             * max joins in a query (and all its sub queries)
             * type int &gt;= 0 : default is 60, meaningful in join fetch strategy
             */
        public const string MAX_JOINS = "maxJoins";

        /**
             * query cache size to reuse
             * type int
             */
        public const string QUERY_CACHE_SIZE = "queryCacheSize";

        private QueryHints() {
        }
    }
}
