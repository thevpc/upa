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
    public class PackageEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private int index;

        private int oldIndex;

        private Net.Vpc.Upa.Package item;

        private Net.Vpc.Upa.Package parent;

        private Net.Vpc.Upa.Package oldParent;

        public PackageEvent(Net.Vpc.Upa.Package item, Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Package parent, int index, Net.Vpc.Upa.Package oldParent, int oldIndex) {
            this.persistenceUnit = persistenceUnit;
            this.item = item;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
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

        public virtual Net.Vpc.Upa.Package GetItem() {
            return item;
        }

        public virtual Net.Vpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual Net.Vpc.Upa.Package GetOldParent() {
            return oldParent;
        }
    }
}
