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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/4/13 12:09 AM
     */
    public class DefaultEntityPrivateCacheEmptyListener : Net.Vpc.Upa.Callbacks.EntityListenerAdapter {

        private bool? cache_isEmpty;


        public override void OnPersist(Net.Vpc.Upa.Callbacks.PersistEvent @event) {
            cache_isEmpty = true;
        }


        public override void OnUpdate(Net.Vpc.Upa.Callbacks.UpdateEvent @event) {
        }


        public override void OnRemove(Net.Vpc.Upa.Callbacks.RemoveEvent @event) {
            cache_isEmpty = null;
        }

        private void ResetCache() {
            cache_isEmpty = null;
        }
    }
}
