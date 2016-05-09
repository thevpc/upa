package net.vpc.upa.impl.persistence.connection;

import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.persistence.DatabaseProduct;
import net.vpc.upa.persistence.StructureStrategy;

import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/13/12 7:53 PM
 */
public class DefaultConnectionProfile implements ConnectionProfile {

    private DatabaseProduct databaseProduct;

    private String databaseProductVersion;

    private String connectionDriver;

    private String connectionDriverVersion;

    private StructureStrategy structureStrategy = StructureStrategy.IGNORE;

    private Map<String, String> properties;

    public DatabaseProduct getDatabaseProduct() {
        return databaseProduct;
    }

    public void setDatabaseProduct(DatabaseProduct databaseProduct) {
        this.databaseProduct = databaseProduct;
    }

    public String getDatabaseProductVersion() {
        return databaseProductVersion;
    }

    public void setDatabaseProductVersion(String databaseProductVersion) {
        this.databaseProductVersion = databaseProductVersion;
    }

    public String getConnectionDriver() {
        return connectionDriver;
    }

    public void setConnectionDriver(String connectionDriver) {
        this.connectionDriver = connectionDriver;
    }

    public String getConnectionDriverVersion() {
        return connectionDriverVersion;
    }

    public void setConnectionDriverVersion(String connectionDriverVersion) {
        this.connectionDriverVersion = connectionDriverVersion;
    }

    public StructureStrategy getStructureStrategy() {
        return structureStrategy;
    }

    public void setStructureStrategy(StructureStrategy structureStrategy) {
        this.structureStrategy = structureStrategy;
    }

    public Map<String, String> getProperties() {
        return properties;
    }

    public void setProperties(Map<String, String> properties) {
        this.properties = properties;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder("ConnectionProfile{");
        sb.append("databaseProduct=").append(databaseProduct);
        if (databaseProductVersion != null) {
            sb.append(", databaseProductVersion='").append(databaseProductVersion).append('\'');
        }
        if (connectionDriver != null) {
            sb.append(", connectionDriver='").append(connectionDriver).append('\'');
        }
        if (connectionDriverVersion != null) {
            sb.append(", connectionDriverVersion='").append(connectionDriverVersion).append('\'');
        }
        if (structureStrategy != null) {
            sb.append(", structureStrategy='").append(structureStrategy).append('\'');
        }
        sb.append(", properties=").append(properties);
        sb.append("}");
        return sb.toString();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        DefaultConnectionProfile that = (DefaultConnectionProfile) o;

        if (connectionDriver != null ? !connectionDriver.equals(that.connectionDriver) : that.connectionDriver != null) {
            return false;
        }
        if (connectionDriverVersion != null ? !connectionDriverVersion.equals(that.connectionDriverVersion) : that.connectionDriverVersion != null) {
            return false;
        }
        if (databaseProduct != that.databaseProduct) {
            return false;
        }
        if (databaseProductVersion != null ? !databaseProductVersion.equals(that.databaseProductVersion) : that.databaseProductVersion != null) {
            return false;
        }
        if (properties != null ? !properties.equals(that.properties) : that.properties != null) {
            return false;
        }
        if (structureStrategy != that.structureStrategy) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        int result = databaseProduct != null ? databaseProduct.hashCode() : 0;
        result = 31 * result + (databaseProductVersion != null ? databaseProductVersion.hashCode() : 0);
        result = 31 * result + (connectionDriver != null ? connectionDriver.hashCode() : 0);
        result = 31 * result + (connectionDriverVersion != null ? connectionDriverVersion.hashCode() : 0);
        result = 31 * result + (structureStrategy != null ? structureStrategy.hashCode() : 0);
        result = 31 * result + (properties != null ? properties.hashCode() : 0);
        return result;
    }
}
