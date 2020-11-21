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
    public class IndexEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Index index;

        private Net.TheVpc.Upa.EventPhase phase;

        public IndexEvent(Net.TheVpc.Upa.Index index, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.index = index;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.Index GetIndex() {
            return index;
        }
    }
}
