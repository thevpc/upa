package net.vpc.upa.impl.persistence.connection;

/**
 * Created by vpc on 8/7/15.
 */
public class DefaultConnectionProfileData {
    String databaseProductName ;
    String databaseProductVersion ;
    String connectionDriverName ;
    String connectionDriverVersion ;
    String server ;
    String port ;
    String pathAndName ;
    String paramsString;

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
}
