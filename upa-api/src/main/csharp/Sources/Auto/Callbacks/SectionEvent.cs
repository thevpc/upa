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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class SectionEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private int index;

        private int oldIndex;

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.Section item;

        private Net.Vpc.Upa.Section parent;

        private Net.Vpc.Upa.Section oldParent;

        public SectionEvent(Net.Vpc.Upa.Section item, Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Section parent, int index, Net.Vpc.Upa.Section oldParent, int oldIndex) {
            this.persistenceUnit = persistenceUnit;
            this.item = item;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
            this.entity = entity;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual int GetOldIndex() {
            return oldIndex;
        }

        public virtual Net.Vpc.Upa.Section GetItem() {
            return item;
        }

        public virtual Net.Vpc.Upa.Section GetParent() {
            return parent;
        }

        public virtual Net.Vpc.Upa.Section GetOldParent() {
            return oldParent;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }
    }
}
