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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 1:54 AM*/
    public class PersistentObjectInfo {

        private Net.Vpc.Upa.UPAObject @object;

        private string type;

        private Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;

        private string persistentName;

        internal PersistentObjectInfo(Net.Vpc.Upa.UPAObject @object, string type) {
            this.@object = @object;
            this.type = type;
        }

        public virtual Net.Vpc.Upa.PersistenceState GetPersistenceState() {
            return persistenceState;
        }

        public virtual void SetPersistenceState(Net.Vpc.Upa.PersistenceState persistenceState) {
            this.persistenceState = persistenceState;
        }

        public virtual string GetPersistentName() {
            return persistentName;
        }

        public virtual void SetPersistentName(string persistentName) {
            this.persistentName = persistentName;
        }
    }
}
