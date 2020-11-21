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



namespace Net.TheVpc.Upa.Persistence
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class PersistenceNameConfig {

        private int configOrder;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.PersistenceName> names = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.PersistenceName>(2);

        private string globalPersistenceNameFormat;

        private string localPersistenceNameFormat;

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
            return globalPersistenceNameFormat;
        }

        public virtual void SetGlobalPersistenceName(string globalPersistenceNameFormat) {
            this.globalPersistenceNameFormat = globalPersistenceNameFormat;
        }

        public virtual string GetPersistenceNameEscape() {
            return persistenceNameEscape;
        }

        public virtual void SetPersistenceNameEscape(string persistenceNameEscape) {
            this.persistenceNameEscape = persistenceNameEscape;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.PersistenceName> GetNames() {
            return names;
        }

        public virtual string GetLocalPersistenceName() {
            return localPersistenceNameFormat;
        }

        public virtual void SetLocalPersistenceName(string localPersistenceNameFormat) {
            this.localPersistenceNameFormat = localPersistenceNameFormat;
        }


        public override int GetHashCode() {
            int hash = 5;
            hash = 59 * hash + (this.names != null ? this.names.GetHashCode() : 0);
            hash = 59 * hash + (this.globalPersistenceNameFormat != null ? this.globalPersistenceNameFormat.GetHashCode() : 0);
            hash = 59 * hash + (this.localPersistenceNameFormat != null ? this.localPersistenceNameFormat.GetHashCode() : 0);
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
            Net.TheVpc.Upa.Persistence.PersistenceNameConfig other = (Net.TheVpc.Upa.Persistence.PersistenceNameConfig) obj;
            if (this.names != other.names && (this.names == null || !this.names.Equals(other.names))) {
                return false;
            }
            if ((this.globalPersistenceNameFormat == null) ? (other.globalPersistenceNameFormat != null) : !this.globalPersistenceNameFormat.Equals(other.globalPersistenceNameFormat)) {
                return false;
            }
            if ((this.localPersistenceNameFormat == null) ? (other.localPersistenceNameFormat != null) : !this.localPersistenceNameFormat.Equals(other.localPersistenceNameFormat)) {
                return false;
            }
            if ((this.persistenceNameEscape == null) ? (other.persistenceNameEscape != null) : !this.persistenceNameEscape.Equals(other.persistenceNameEscape)) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return "PersistenceNameStrategyModel{" + "names=" + names + ", globalPersistenceNameFormat=" + globalPersistenceNameFormat + ", localPersistenceNameFormat=" + localPersistenceNameFormat + ", persistenceNameEscape=" + persistenceNameEscape + '}';
        }
    }
}
