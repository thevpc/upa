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
    public class PersistenceGroupEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.UPAContext context;

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        public PersistenceGroupEvent(Net.Vpc.Upa.PersistenceGroup persistenceGroup, Net.Vpc.Upa.UPAContext context) {
            this.persistenceGroup = persistenceGroup;
            this.context = context;
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual Net.Vpc.Upa.UPAContext GetContext() {
            return context;
        }
    }
}
