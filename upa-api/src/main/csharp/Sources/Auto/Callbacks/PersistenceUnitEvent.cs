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
     *
     * @author taha.bensalah@gmail.com
     */
    public class PersistenceUnitEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        private Net.Vpc.Upa.EventPhase phase;

        public PersistenceUnitEvent(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.persistenceGroup = persistenceGroup;
            this.phase = phase;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }
    }
}
