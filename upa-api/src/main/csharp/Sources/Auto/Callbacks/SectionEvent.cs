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



namespace Net.TheVpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class SectionEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private int index;

        private int oldIndex;

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Section item;

        private Net.TheVpc.Upa.Section parent;

        private Net.TheVpc.Upa.Section oldParent;

        private Net.TheVpc.Upa.EventPhase phase;

        public SectionEvent(Net.TheVpc.Upa.Section item, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Section parent, int index, Net.TheVpc.Upa.Section oldParent, int oldIndex, Net.TheVpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.item = item;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
            this.entity = entity;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual int GetOldIndex() {
            return oldIndex;
        }

        public virtual Net.TheVpc.Upa.Section GetItem() {
            return item;
        }

        public virtual Net.TheVpc.Upa.Section GetParent() {
            return parent;
        }

        public virtual Net.TheVpc.Upa.Section GetOldParent() {
            return oldParent;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
