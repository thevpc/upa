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



namespace Net.TheVpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 7:11 PM
     */
    public class DefaultPersistenceGroupContextProvider : Net.TheVpc.Upa.PersistenceGroupContextProvider {

        private Net.TheVpc.Upa.PersistenceGroup persistenceGroup;

        public DefaultPersistenceGroupContextProvider() {
        }


        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }


        public virtual void SetPersistenceGroup(Net.TheVpc.Upa.PersistenceGroup current) {
            this.persistenceGroup = current;
        }
    }
}
