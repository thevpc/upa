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
    public class ConnectionConfig {

        private string connectionString;

        private bool? enabled;

        private string userName;

        private string password;

        private Net.TheVpc.Upa.Persistence.StructureStrategy structureStrategy;

        private System.Collections.Generic.IDictionary<string , string> properties = new System.Collections.Generic.Dictionary<string , string>();

        public virtual string GetConnectionString() {
            return connectionString;
        }

        public virtual void SetConnectionString(string connectionString) {
            this.connectionString = connectionString;
        }

        public virtual string GetUserName() {
            return userName;
        }

        public virtual void SetUserName(string userName) {
            this.userName = userName;
        }

        public virtual string GetPassword() {
            return password;
        }

        public virtual void SetPassword(string password) {
            this.password = password;
        }

        public virtual Net.TheVpc.Upa.Persistence.StructureStrategy GetStructureStrategy() {
            return structureStrategy;
        }

        public virtual void SetStructureStrategy(Net.TheVpc.Upa.Persistence.StructureStrategy structureStrategy) {
            this.structureStrategy = structureStrategy;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetProperties() {
            return properties;
        }

        public virtual void SetProperties(System.Collections.Generic.IDictionary<string , string> properties) {
            this.properties = properties;
        }

        public virtual bool? IsEnabled() {
            return enabled;
        }

        public virtual void SetEnabled(bool? enabled) {
            this.enabled = enabled;
        }


        public override string ToString() {
            return "ConnectionConfig{" + "connectionString=" + connectionString + ", userName=" + userName + ", password=" + password + ", structureStrategy=" + structureStrategy + ", properties=" + properties + '}';
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.TheVpc.Upa.Persistence.ConnectionConfig that = (Net.TheVpc.Upa.Persistence.ConnectionConfig) o;
            if (connectionString != null ? !connectionString.Equals(that.connectionString) : that.connectionString != null) return false;
            if (enabled != null ? !enabled.Equals(that.enabled) : that.enabled != null) return false;
            if (userName != null ? !userName.Equals(that.userName) : that.userName != null) return false;
            if (password != null ? !password.Equals(that.password) : that.password != null) return false;
            if (structureStrategy != that.structureStrategy) return false;
            return properties != null ? properties.Equals(that.properties) : that.properties == null;
        }


        public override int GetHashCode() {
            int result = connectionString != null ? connectionString.GetHashCode() : 0;
            result = 31 * result + (enabled != null ? enabled.GetHashCode() : 0);
            result = 31 * result + (userName != null ? userName.GetHashCode() : 0);
            result = 31 * result + (password != null ? password.GetHashCode() : 0);
            result = 31 * result + (structureStrategy != default(Net.TheVpc.Upa.Persistence.StructureStrategy) ? structureStrategy.GetHashCode() : 0);
            result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
            return result;
        }
    }
}
