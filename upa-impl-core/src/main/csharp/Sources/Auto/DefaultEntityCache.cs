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



namespace Net.Vpc.Upa.Impl
{

    /**
     * Created by vpc on 6/12/16.
     */
    internal class DefaultEntityCache {

        internal bool needsRevalidateCache = false;

        internal bool? isEmpty;

        internal Net.Vpc.Upa.Impl.DefaultEntityPrivateCacheEmptyListener cache_isEmpty_Listener;

        public DefaultEntityCache() {
            cache_isEmpty_Listener = new Net.Vpc.Upa.Impl.DefaultEntityPrivateCacheEmptyListener(this);
        }
    }
}
