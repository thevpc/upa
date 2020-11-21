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
     * @author taha.bensalah@gmail.com
     */
    public class PersistenceUnitEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.PersistenceGroup persistenceGroup;

        private Net.TheVpc.Upa.EventPhase phase;

        public PersistenceUnitEvent(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.persistenceGroup = persistenceGroup;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }
    }
}
