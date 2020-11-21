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
    public class PackageEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private int index;

        private int oldIndex;

        private Net.TheVpc.Upa.Package item;

        private Net.TheVpc.Upa.Package parent;

        private Net.TheVpc.Upa.Package oldParent;

        private Net.TheVpc.Upa.EventPhase phase;

        public PackageEvent(Net.TheVpc.Upa.Package item, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Package parent, int index, Net.TheVpc.Upa.Package oldParent, int oldIndex, Net.TheVpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.item = item;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
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

        public virtual Net.TheVpc.Upa.Package GetItem() {
            return item;
        }

        public virtual Net.TheVpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual Net.TheVpc.Upa.Package GetOldParent() {
            return oldParent;
        }
    }
}
