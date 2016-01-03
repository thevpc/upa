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
    public class ConnectionConfig {

        private string connectionString;

        private bool? enabled;

        private string userName;

        private string password;

        private Net.Vpc.Upa.Persistence.StructureStrategy structureStrategy;

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

        public virtual Net.Vpc.Upa.Persistence.StructureStrategy GetStructureStrategy() {
            return structureStrategy;
        }

        public virtual void SetStructureStrategy(Net.Vpc.Upa.Persistence.StructureStrategy structureStrategy) {
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
    }
}
