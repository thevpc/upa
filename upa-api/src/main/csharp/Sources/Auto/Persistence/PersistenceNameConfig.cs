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



namespace Net.Vpc.Upa.Persistence
{


    /**
     *
     * @author vpc
     */
    public class PersistenceNameConfig {

        private int configOrder;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceName> names = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.PersistenceName>();

        private string globalPersistenceName;

        private string localPersistenceName;

        private string persistenceNameEscape;

        public PersistenceNameConfig(int configOrder) {
            this.configOrder = configOrder;
        }

        public virtual int GetConfigOrder() {
            return configOrder;
        }

        public virtual void SetConfigOrder(int configOrder) {
            this.configOrder = configOrder;
        }

        public virtual string GetGlobalPersistenceName() {
            return globalPersistenceName;
        }

        public virtual void SetGlobalPersistenceName(string globalPersistenceName) {
            this.globalPersistenceName = globalPersistenceName;
        }

        public virtual string GetPersistenceNameEscape() {
            return persistenceNameEscape;
        }

        public virtual void SetPersistenceNameEscape(string persistenceNameEscape) {
            this.persistenceNameEscape = persistenceNameEscape;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.PersistenceName> GetNames() {
            return names;
        }

        public virtual string GetLocalPersistenceName() {
            return localPersistenceName;
        }

        public virtual void SetLocalPersistenceName(string localPersistenceName) {
            this.localPersistenceName = localPersistenceName;
        }


        public override int GetHashCode() {
            int hash = 5;
            hash = 59 * hash + (this.names != null ? this.names.GetHashCode() : 0);
            hash = 59 * hash + (this.globalPersistenceName != null ? this.globalPersistenceName.GetHashCode() : 0);
            hash = 59 * hash + (this.localPersistenceName != null ? this.localPersistenceName.GetHashCode() : 0);
            hash = 59 * hash + (this.persistenceNameEscape != null ? this.persistenceNameEscape.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Persistence.PersistenceNameConfig other = (Net.Vpc.Upa.Persistence.PersistenceNameConfig) obj;
            if (this.names != other.names && (this.names == null || !this.names.Equals(other.names))) {
                return false;
            }
            if ((this.globalPersistenceName == null) ? (other.globalPersistenceName != null) : !this.globalPersistenceName.Equals(other.globalPersistenceName)) {
                return false;
            }
            if ((this.localPersistenceName == null) ? (other.localPersistenceName != null) : !this.localPersistenceName.Equals(other.localPersistenceName)) {
                return false;
            }
            if ((this.persistenceNameEscape == null) ? (other.persistenceNameEscape != null) : !this.persistenceNameEscape.Equals(other.persistenceNameEscape)) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return "PersistenceNameStrategyModel{" + "names=" + names + ", globalPersistenceName=" + globalPersistenceName + ", localPersistenceName=" + localPersistenceName + ", persistenceNameEscape=" + persistenceNameEscape + '}';
        }
    }
}
