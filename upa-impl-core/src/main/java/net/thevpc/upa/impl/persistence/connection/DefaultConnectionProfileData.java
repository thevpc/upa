package net.thevpc.upa.impl.persistence.connection;

/**
 * Created by vpc on 8/7/15.
 */
public class DefaultConnectionProfileData {
    private String databaseProductName ;
    private String databaseProductVersion ;
    private String connectionDriverName ;
    private String connectionDriverVersion ;
    private String server ;
    private String port ;
    private String pathAndName ;
    private String paramsString;

    @Override
    public String toString() {
        return "DefaultConnectionProfileData{" +
                "databaseProductName='" + databaseProductName + '\'' +
                ", databaseProductVersion='" + databaseProductVersion + '\'' +
                ", connectionDriverName='" + connectionDriverName + '\'' +
                ", connectionDriverVersion='" + connectionDriverVersion + '\'' +
                ", server='" + server + '\'' +
                ", port='" + port + '\'' +
                ", pathAndName='" + pathAndName + '\'' +
                ", params='" + paramsString + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        DefaultConnectionProfileData that = (DefaultConnectionProfileData) o;

        if (databaseProductName != null ? !databaseProductName.equals(that.databaseProductName) : that.databaseProductName != null)
            return false;
        if (databaseProductVersion != null ? !databaseProductVersion.equals(that.databaseProductVersion) : that.databaseProductVersion != null)
            return false;
        if (connectionDriverName != null ? !connectionDriverName.equals(that.connectionDriverName) : that.connectionDriverName != null)
            return false;
        if (connectionDriverVersion != null ? !connectionDriverVersion.equals(that.connectionDriverVersion) : that.connectionDriverVersion != null)
            return false;
        if (server != null ? !server.equals(that.server) : that.server != null) return false;
        if (port != null ? !port.equals(that.port) : that.port != null) return false;
        if (pathAndName != null ? !pathAndName.equals(that.pathAndName) : that.pathAndName != null) return false;
        return paramsString != null ? paramsString.equals(that.paramsString) : that.paramsString == null;

    }

    @Override
    public int hashCode() {
        int result = databaseProductName != null ? databaseProductName.hashCode() : 0;
        result = 31 * result + (databaseProductVersion != null ? databaseProductVersion.hashCode() : 0);
        result = 31 * result + (connectionDriverName != null ? connectionDriverName.hashCode() : 0);
        result = 31 * result + (connectionDriverVersion != null ? connectionDriverVersion.hashCode() : 0);
        result = 31 * result + (server != null ? server.hashCode() : 0);
        result = 31 * result + (port != null ? port.hashCode() : 0);
        result = 31 * result + (pathAndName != null ? pathAndName.hashCode() : 0);
        result = 31 * result + (paramsString != null ? paramsString.hashCode() : 0);
        return result;
    }

    public String getDatabaseProductName() {
        return databaseProductName;
    }

    public void setDatabaseProductName(String databaseProductName) {
        this.databaseProductName = databaseProductName;
    }

    public String getDatabaseProductVersion() {
        return databaseProductVersion;
    }

    public void setDatabaseProductVersion(String databaseProductVersion) {
        this.databaseProductVersion = databaseProductVersion;
    }

    public String getConnectionDriverName() {
        return connectionDriverName;
    }

    public void setConnectionDriverName(String connectionDriverName) {
        this.connectionDriverName = connectionDriverName;
    }

    public String getConnectionDriverVersion() {
        return connectionDriverVersion;
    }

    public void setConnectionDriverVersion(String connectionDriverVersion) {
        this.connectionDriverVersion = connectionDriverVersion;
    }

    public String getServer() {
        return server;
    }

    public void setServer(String server) {
        this.server = server;
    }

    public String getPort() {
        return port;
    }

    public void setPort(String port) {
        this.port = port;
    }

    public String getPathAndName() {
        return pathAndName;
    }

    public void setPathAndName(String pathAndName) {
        this.pathAndName = pathAndName;
    }

    public String getParamsString() {
        return paramsString;
    }

    public void setParamsString(String paramsString) {
        this.paramsString = paramsString;
    }
}
