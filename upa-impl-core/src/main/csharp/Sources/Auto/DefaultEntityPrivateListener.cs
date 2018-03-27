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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultEntityPrivateListener : Net.Vpc.Upa.UPAObjectListener {

        private Net.Vpc.Upa.Impl.DefaultEntity entity;

        public DefaultEntityPrivateListener(Net.Vpc.Upa.Impl.DefaultEntity entity) {
            this.entity = entity;
        }

        public virtual void ItemRemoved(Net.Vpc.Upa.UPAObject @object, int position, Net.Vpc.Upa.EventPhase eventPhase) {
        }

        public virtual void ItemMoved(Net.Vpc.Upa.UPAObject @object, int position, int toPosition, Net.Vpc.Upa.EventPhase eventPhase) {
        }

        public virtual void ItemAdded(Net.Vpc.Upa.UPAObject @object, int position, Net.Vpc.Upa.UPAObject parent, Net.Vpc.Upa.EventPhase eventPhase) {
            if (eventPhase == Net.Vpc.Upa.EventPhase.BEFORE) {
                entity.BeforePartAdded((Net.Vpc.Upa.EntityPart) parent, (Net.Vpc.Upa.EntityPart) @object, position);
            } else {
                entity.AfterPartAdded((Net.Vpc.Upa.EntityPart) parent, (Net.Vpc.Upa.EntityPart) @object, position);
            }
        }
    }
}
