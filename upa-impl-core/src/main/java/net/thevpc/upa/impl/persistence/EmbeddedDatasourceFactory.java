package net.thevpc.upa.impl.persistence;

import javax.sql.DataSource;
import java.util.Map;

/**
 * @author taha.bensalah@gmail.com on 7/20/16.
 */
public interface EmbeddedDatasourceFactory {
    boolean isSupported();
    DataSource createDataSource(
            String driver,
            String url,
            String user,
            String password,
            Map<String, String> properties
    );
}
