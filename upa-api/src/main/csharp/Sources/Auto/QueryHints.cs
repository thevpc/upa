/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
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
             * type : boolean, default is false
             *
             */
        public const string NO_TYPE_TRANSFORM = "noTypeTransform";

        /**
             * type : string enum {select, join}, default is 'join'
             */
        public const string FETCH_STRATEGY = "fetchStrategy";

        /**
             * sub entities depth
             *  type int &gt;= 0 : default is 3, meaningful in join fetch strategy
             */
        public const string NAVIGATION_DEPTH = "navigationDepth";

        private QueryHints() {
        }
    }
}
