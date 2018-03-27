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



namespace Net.Vpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 7:11 PM
     */
    public class DefaultPersistenceGroupContextProvider : Net.Vpc.Upa.PersistenceGroupContextProvider {

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        public DefaultPersistenceGroupContextProvider() {
        }


        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }


        public virtual void SetPersistenceGroup(Net.Vpc.Upa.PersistenceGroup current) {
            this.persistenceGroup = current;
        }
    }
}
