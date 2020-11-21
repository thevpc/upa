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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultEntityPrivateListener : Net.TheVpc.Upa.UPAObjectListener {

        private Net.TheVpc.Upa.Impl.DefaultEntity entity;

        public DefaultEntityPrivateListener(Net.TheVpc.Upa.Impl.DefaultEntity entity) {
            this.entity = entity;
        }

        public virtual void ItemRemoved(Net.TheVpc.Upa.UPAObject @object, int position, Net.TheVpc.Upa.EventPhase eventPhase) {
        }

        public virtual void ItemMoved(Net.TheVpc.Upa.UPAObject @object, int position, int toPosition, Net.TheVpc.Upa.EventPhase eventPhase) {
        }

        public virtual void ItemAdded(Net.TheVpc.Upa.UPAObject @object, int position, Net.TheVpc.Upa.UPAObject parent, Net.TheVpc.Upa.EventPhase eventPhase) {
            if (eventPhase == Net.TheVpc.Upa.EventPhase.BEFORE) {
                entity.BeforePartAdded((Net.TheVpc.Upa.EntityPart) parent, (Net.TheVpc.Upa.EntityPart) @object, position);
            } else {
                entity.AfterPartAdded((Net.TheVpc.Upa.EntityPart) parent, (Net.TheVpc.Upa.EntityPart) @object, position);
            }
        }
    }
}
