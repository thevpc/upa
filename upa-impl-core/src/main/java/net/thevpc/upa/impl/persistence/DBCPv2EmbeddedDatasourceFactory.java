package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.util.PlatformLenientType;
import net.thevpc.upa.impl.util.UPAUtils;

import javax.sql.DataSource;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author taha.bensalah@gmail.com on 7/20/16.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DBCPv2EmbeddedDatasourceFactory implements  EmbeddedDatasourceFactory{
    protected static Logger log = Logger.getLogger(DBCPv2EmbeddedDatasourceFactory.class.getName());
    public static final DBCPv2EmbeddedDatasourceFactory INSTANCE=new DBCPv2EmbeddedDatasourceFactory();

    private PlatformLenientType DBCP_TYPE = new PlatformLenientType("org.apache.commons.dbcp2.BasicDataSource");

    @Override
    public boolean isSupported() {
        return DBCP_TYPE.isValid();
    }

    @Override
    public DataSource createDataSource(String driver, String url, String user, String password, Map<String, String> properties) {
        DataSource ds = (DataSource) DBCP_TYPE.newInstance();
        DBCP_TYPE.setProperty(ds, "driverClassName", driver);
        DBCP_TYPE.setProperty(ds, "username", user);
        DBCP_TYPE.setProperty(ds, "password", password);
        DBCP_TYPE.setProperty(ds, "url", url);

        Map<String, String> dbcpProperties = UPAUtils.extractMap(properties, "connection.pool.dbcp", true);
        for (Map.Entry<String, String> ee : properties.entrySet()) {
            String key = ee.getKey();
            String val = ee.getValue();
            if (!key.contains(".") && key.startsWith("pool") &&  (!"pool".equals(key))) {
                if (key.equals("poolInitialSize")) {
                    DBCP_TYPE.setProperty(ds, "initialSize", val);
                } else if (key.equals("poolMaxSize")) {
                    DBCP_TYPE.setPropertyAsString(ds, "maxTotal", val);
                } else if (key.equals("poolMaxIdle")) {
                    DBCP_TYPE.setPropertyAsString(ds, "maxIdle", val);
                } else if (key.equals("poolMinIdle")) {
                    DBCP_TYPE.setPropertyAsString(ds, "minIdle", val);
                } else if (key.equals("poolIdleTimeout")) {
                    //idle time in seconds
                    int x = (Integer) UPAUtils.createValue(val, Integer.class, null);
                    DBCP_TYPE.setProperty(ds, "removeAbandonedTimeout", x);
                    if (!dbcpProperties.containsKey("removeAbandonedOnMaintenance")
                            && !dbcpProperties.containsKey("removeAbandonedOnMaintenance")
                            ) {
                        DBCP_TYPE.setProperty(ds, "removeAbandonedOnMaintenance", x > 0);
                    }
                } else if (key.equals("poolTestOnBorrow")) {
                    DBCP_TYPE.setPropertyAsString(ds, "testOnBorrow", val);
                } else if (key.equals("poolValidationQuery")) {
                    DBCP_TYPE.setPropertyAsString(ds, "testOnBorrow", val);
                } else {
                    log.log(Level.WARNING, "Ignored DBCP pool parameter " + key + " = " + val);
                }
            }else{
                DBCP_TYPE.invokeInstance(ds,"addConnectionProperty",new Class[]{String.class,String.class},new Object[]{key,val});
            }
        }

        for (Map.Entry<String, String> e : dbcpProperties.entrySet()) {
            DBCP_TYPE.setPropertyAsString(ds, e.getKey(), e.getValue());
        }
        return ds;
    }
}
