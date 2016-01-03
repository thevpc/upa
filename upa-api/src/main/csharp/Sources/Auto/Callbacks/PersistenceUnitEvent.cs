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
     * @author vpc
     */
    public class PersistenceUnitEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        public PersistenceUnitEvent(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.PersistenceGroup persistenceGroup) {
            this.persistenceUnit = persistenceUnit;
            this.persistenceGroup = persistenceGroup;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }
    }
}
