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
    public class PersistenceGroupEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.UPAContext context;

        private Net.TheVpc.Upa.PersistenceGroup persistenceGroup;

        public PersistenceGroupEvent(Net.TheVpc.Upa.PersistenceGroup persistenceGroup, Net.TheVpc.Upa.UPAContext context) {
            this.persistenceGroup = persistenceGroup;
            this.context = context;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual Net.TheVpc.Upa.UPAContext GetContext() {
            return context;
        }
    }
}
