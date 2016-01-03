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
    * @creationdate 1/8/13 1:55 AM*/
    internal class PersistenceUnitKey {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private string key;

        public PersistenceUnitKey(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string key) {
            this.persistenceUnit = persistenceUnit;
            this.key = key;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual string GetKey() {
            return key;
        }


        public override int GetHashCode() {
            int hash = 5;
            hash = 71 * hash + (this.persistenceUnit != null ? this.persistenceUnit.GetHashCode() : 0);
            hash = 71 * hash + (this.key != null ? this.key.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Context.PersistenceUnitKey other = (Net.Vpc.Upa.Impl.Context.PersistenceUnitKey) obj;
            if (this.persistenceUnit != other.persistenceUnit && (this.persistenceUnit == null || !this.persistenceUnit.Equals(other.persistenceUnit))) {
                return false;
            }
            if ((this.key == null) ? (other.key != null) : !this.key.Equals(other.key)) {
                return false;
            }
            return true;
        }
    }
}
