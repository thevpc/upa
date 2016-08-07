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



namespace Net.Vpc.Upa.Impl.Persistence.Connection
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/13/12 7:53 PM
     */
    public class DefaultConnectionProfile : Net.Vpc.Upa.Persistence.ConnectionProfile {

        private Net.Vpc.Upa.Persistence.DatabaseProduct databaseProduct;

        private string databaseProductVersion;

        private string connectionDriver;

        private string connectionDriverVersion;

        private Net.Vpc.Upa.Persistence.StructureStrategy structureStrategy = Net.Vpc.Upa.Persistence.StructureStrategy.IGNORE;

        private System.Collections.Generic.IDictionary<string , string> properties;

        public virtual Net.Vpc.Upa.Persistence.DatabaseProduct GetDatabaseProduct() {
            return databaseProduct;
        }

        public virtual void SetDatabaseProduct(Net.Vpc.Upa.Persistence.DatabaseProduct databaseProduct) {
            this.databaseProduct = databaseProduct;
        }

        public virtual string GetDatabaseProductVersion() {
            return databaseProductVersion;
        }

        public virtual void SetDatabaseProductVersion(string databaseProductVersion) {
            this.databaseProductVersion = databaseProductVersion;
        }

        public virtual string GetConnectionDriver() {
            return connectionDriver;
        }

        public virtual void SetConnectionDriver(string connectionDriver) {
            this.connectionDriver = connectionDriver;
        }

        public virtual string GetConnectionDriverVersion() {
            return connectionDriverVersion;
        }

        public virtual void SetConnectionDriverVersion(string connectionDriverVersion) {
            this.connectionDriverVersion = connectionDriverVersion;
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


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("ConnectionProfile{");
            sb.Append("databaseProduct=").Append(databaseProduct);
            if (databaseProductVersion != null) {
                sb.Append(", databaseProductVersion='").Append(databaseProductVersion).Append('\'');
            }
            if (connectionDriver != null) {
                sb.Append(", connectionDriver='").Append(connectionDriver).Append('\'');
            }
            if (connectionDriverVersion != null) {
                sb.Append(", connectionDriverVersion='").Append(connectionDriverVersion).Append('\'');
            }
            if (structureStrategy != default(Net.Vpc.Upa.Persistence.StructureStrategy)) {
                sb.Append(", structureStrategy='").Append(structureStrategy).Append('\'');
            }
            sb.Append(", properties=").Append(properties);
            sb.Append("}");
            return sb.ToString();
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfile that = (Net.Vpc.Upa.Impl.Persistence.Connection.DefaultConnectionProfile) o;
            if (connectionDriver != null ? !connectionDriver.Equals(that.connectionDriver) : that.connectionDriver != null) {
                return false;
            }
            if (connectionDriverVersion != null ? !connectionDriverVersion.Equals(that.connectionDriverVersion) : that.connectionDriverVersion != null) {
                return false;
            }
            if (databaseProduct != that.databaseProduct) {
                return false;
            }
            if (databaseProductVersion != null ? !databaseProductVersion.Equals(that.databaseProductVersion) : that.databaseProductVersion != null) {
                return false;
            }
            if (properties != null ? !properties.Equals(that.properties) : that.properties != null) {
                return false;
            }
            if (structureStrategy != that.structureStrategy) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            int result = databaseProduct != default(Net.Vpc.Upa.Persistence.DatabaseProduct) ? databaseProduct.GetHashCode() : 0;
            result = 31 * result + (databaseProductVersion != null ? databaseProductVersion.GetHashCode() : 0);
            result = 31 * result + (connectionDriver != null ? connectionDriver.GetHashCode() : 0);
            result = 31 * result + (connectionDriverVersion != null ? connectionDriverVersion.GetHashCode() : 0);
            result = 31 * result + (structureStrategy != default(Net.Vpc.Upa.Persistence.StructureStrategy) ? structureStrategy.GetHashCode() : 0);
            result = 31 * result + (properties != null ? properties.GetHashCode() : 0);
            return result;
        }
    }
}
