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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/4/13 12:09 AM
     */
    internal class DefaultEntityPrivateCacheEmptyListener : Net.TheVpc.Upa.Callbacks.EntityListenerAdapter {

        private Net.TheVpc.Upa.Impl.DefaultEntityCache cache;

        public DefaultEntityPrivateCacheEmptyListener(Net.TheVpc.Upa.Impl.DefaultEntityCache cache) {
            this.cache = cache;
        }


        public override void OnPersist(Net.TheVpc.Upa.Callbacks.PersistEvent @event) {
            cache.isEmpty = new System.Nullable<bool>(false);
        }


        public override void OnUpdate(Net.TheVpc.Upa.Callbacks.UpdateEvent @event) {
        }


        public override void OnRemove(Net.TheVpc.Upa.Callbacks.RemoveEvent @event) {
            cache.isEmpty = null;
        }

        private void ResetCache() {
            cache.isEmpty = null;
        }
    }
}
