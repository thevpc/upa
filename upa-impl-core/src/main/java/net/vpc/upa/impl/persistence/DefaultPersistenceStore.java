package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.*;
import net.vpc.upa.impl.DefaultProperties;
import net.vpc.upa.impl.persistence.connection.ConnectionProfileParser;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.*;

import javax.naming.InitialContext;
import javax.sql.DataSource;
import java.sql.*;
import java.util.*;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

@PortabilityHint(target = "C#", name = "partial")
public class DefaultPersistenceStore extends AbstractPersistenceStore {

    protected static Logger log = Logger.getLogger(DefaultPersistenceStore.class.getName());
    private static PlatformLenientType JAVAMELODY_JDBCDRIVER = new PlatformLenientType("net.bull.javamelody.JdbcDriver");
    @PortabilityHint(target = "C#", name = "suppress")
    protected EmbeddedDatasourceFactoryComparator embeddedDatasourceFactoryComparator = DefaultEmbeddedDatasourceFactoryComparator.INSTANCE;
    @PortabilityHint(target = "C#", name = "suppress")
    protected List<EmbeddedDatasourceFactory> embeddedDatasourceFactories = new ArrayList<EmbeddedDatasourceFactory>();
    @PortabilityHint(target = "C#", name = "suppress")
    protected EmbeddedDatasourceFactory currentEmbeddedDatasourceFactory = null;
    @PortabilityHint(target = "C#", name = "suppress")
    protected Boolean embeddedDataSourceSupported = null;
    private final Map<String, DataSource> embeddedDataSources = new HashMap<String, DataSource>();



    @Override
    public void init(PersistenceUnit persistenceUnit, boolean readOnly, ConnectionProfile connectionProfile, PersistenceNameConfig nameConfig) throws UPAException {
        embeddedDataSourceSupported = null;
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        embeddedDatasourceFactories.add(DBCPv1EmbeddedDatasourceFactory.INSTANCE);
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        embeddedDatasourceFactories.add(DBCPv2EmbeddedDatasourceFactory.INSTANCE);
        super.init(persistenceUnit, readOnly, connectionProfile, nameConfig); //To change body of generated methods, choose Tools | Templates.
    }



    public UConnection createRootUConnection(EntityExecutionContext context) throws UPAException {
        return wrapConnection(createNativeRootConnection(context));
    }

    protected void disposeNativeConnection(Connection connection, Map<String, Object> customAttributes) throws UPAException {
        /**
         * @PortabilityHint(target="C#",name="suppress")
         */
        try {
            boolean newAutoCommit = connection.getAutoCommit();
            boolean oldAutoCommit = (Boolean) customAttributes.get("AutoCommit");
            if (oldAutoCommit != newAutoCommit) {
                connection.setAutoCommit(oldAutoCommit);
            }
            connection.rollback();
        } catch (SQLException e) {
            throw new ConnectionException("DisableAutoCommitFailedException");
        }
    }

    public UConnection createConnection() throws UPAException {
        UConnection connection = createConnection(getConnectionProfile());
        reconfigureStore(connection);
        return connection;
    }
    
    public UConnection createConnection(ConnectionProfile connectionProfile) throws UPAException {
        Connection nativeConnection = createNativeConnection(connectionProfile);
        knownCreatedStores.add(connectionProfile.toString());
        log.log(Level.FINE, "Connection Created {0}", nativeConnection);
        final Map<String, Object> customAttributes = new HashMap<String, Object>();
        UConnection connection = wrapConnection(nativeConnection);
        prepareNativeConnection(connection, customAttributes, connectionProfile);
        return connection;
        //ConnectionDelegate connectionDelegate = new ConnectionDelegate(this, nativeConnection);
        //log.log(Level.FINE,"createConnection created new Connection");
        //return connectionDelegate;
    }

    protected void reconfigureStore(UConnection connection) {
        if (!getStoreParameters().containsKey("configured")) {
            /**
             * @PortabilityHint(target = "C#",name = "todo")
             */
            try {
                DatabaseMetaData metaData = ((Connection)connection.getMetadataAccessibleConnection()).getMetaData();
                getStoreParameters().setString("configured", String.valueOf(true));
                getStoreParameters().setString("databaseMajorVersion", String.valueOf(metaData.getDatabaseMajorVersion()));
                getStoreParameters().setString("databaseMinorVersion", String.valueOf(metaData.getDatabaseMinorVersion()));
                getStoreParameters().setString("databaseProductVersion", String.valueOf(metaData.getDatabaseProductVersion()));
                getStoreParameters().setString("databaseProductName", String.valueOf(metaData.getDatabaseProductName()));
                getStoreParameters().setString("driverName", String.valueOf(metaData.getDriverName()));
                getStoreParameters().setString("driverName", String.valueOf(metaData.getDriverName()));
                getStoreParameters().setString("driverVersion", String.valueOf(metaData.getDriverVersion()));
                getStoreParameters().setString("driverVersion", String.valueOf(metaData.getDriverVersion()));
                getStoreParameters().setString("driverMajorVersion", String.valueOf(metaData.getDriverMajorVersion()));
                getStoreParameters().setString("driverMinorVersion", String.valueOf(metaData.getDriverMinorVersion()));
                getStoreParameters().setString("identifierQuoteString", identifierQuoteString = (metaData.getIdentifierQuoteString()));
                identifierStoreTranslator = createIdentifierStoreTranslator(connection);

                HashSet<String> r = new HashSet<String>();
                String rw = null;
                try {
                    rw = metaData.getSQLKeywords();
                } catch (SQLException ex) {
                    throw new UPAException(ex, new I18NString("getSQLKeywords"));
                }
                if (rw != null) {
                    for (String s : rw.split(", \n")) {
                        if (s.length() > 0) {
                            r.add(s.toUpperCase());
                        }
                    }
                    r.addAll(SQL2003_RESERVED_WORDS);
                    Set<String> crw = getCustomReservedKeywords();
                    if (crw != null) {
                        r.addAll(crw);
                    }
                }
                reservedWords = r;

            } catch (Exception ee) {
                ee.printStackTrace();
            }
            isUpdateComplexValuesStatementSupported = getStoreParameters().getBoolean("isUpdateComplexValuesStatementSupported", false);
            isUpdateComplexValuesIncludingUpdatedTableSupported = getStoreParameters().getBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
        }

    }

    //    @Override
//    public Connection createNativeConnection() throws UPAException {
//        return createNativeConnection(getConnectionProfile());
//    }

    public Connection createNativeConnection(ConnectionProfile p) throws UPAException {
        try {
            String connectionDriver = p.getConnectionDriver();
            if (connectionDriver == null || connectionDriver.trim().isEmpty()) {
                connectionDriver = DRIVER_TYPE_DEFAULT;
            }
            /**
             * @PortabilityHint(target="C#",name="suppress")
             */
            if (DRIVER_TYPE_DATASOURCE.equalsIgnoreCase(connectionDriver)) {
                return createDataSourceConnection(p);
            }
            if (DRIVER_TYPE_GENERIC.equalsIgnoreCase(connectionDriver)) {
                return createPlatformGenericConnection(p);
            }
            if (DRIVER_TYPE_ODBC.equalsIgnoreCase(connectionDriver)) {
                return createOdbcConnection(p);
            }
            return createCustomPlatformConnection(p);
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
    }

    @PortabilityHint(target = "C#", name = "suppress")
    protected Connection createDataSourceConnection(ConnectionProfile p) throws UPAException {
        try {
//            Map<String, String> properties = p.getProperties();
            InitialContext ic = new InitialContext();
            String dbPrefix = p.getProperty(ConnectionOption.SERVER_ADDRESS);
            String dbname = p.getProperty(ConnectionOption.DATABASE_NAME);
            if (dbPrefix == null && dbname == null) {
                throw new UPAException(new I18NString("MissingDatasourceName"));
            } else if (dbname == null) {
                dbname = dbPrefix;
            } else if (dbPrefix != null) {
                dbname = dbPrefix + "/" + dbname;
            }
            String noDatasourcePrefix = p.getProperty("noDatasourcePrefix");
            if (!Boolean.parseBoolean(noDatasourcePrefix) && dbname != null && !dbname.startsWith("java:comp/env/")) {
                dbname = "java:comp/env/" + dbname;
            }
            DataSource dataSource = (DataSource) ic.lookup(dbname);
            return dataSource.getConnection();
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
    }

    @PortabilityHint(target = "C#", name = "suppress")
    protected DataSource resolvePoolableDataSource(
            String driver,
            String url,
            String user,
            String password,
            Map<String, String> properties
    ) throws UPAException {

        if (embeddedDataSourceSupported == null) {
            synchronized (embeddedDataSources) {
                if (embeddedDataSourceSupported == null) {
                    boolean supported = false;
                    if (!embeddedDatasourceFactories.isEmpty()) {
                        Collections.sort(embeddedDatasourceFactories, embeddedDatasourceFactoryComparator);
                        for (EmbeddedDatasourceFactory fac : embeddedDatasourceFactories) {
                            if (fac.isSupported()) {
                                currentEmbeddedDatasourceFactory = fac;
                                supported = true;
                                break;
                            }
                        }
                    }
                    this.embeddedDataSourceSupported = supported;
                }
            }
        }

        if (!embeddedDataSourceSupported) {
            return null;
        }
        String k = driver + "\n" + url + "\n" + user + "\n" + password;
        DataSource ds = embeddedDataSources.get(k);
        if (ds == null) {
            ds = currentEmbeddedDatasourceFactory.createDataSource(driver, url, user, password, properties);
            embeddedDataSources.put(k, ds);
        }
        return ds;
    }

    protected Connection createPlatformGenericConnection(ConnectionProfile p) throws UPAException {
        try {
//            Map<String, String> properties = p.getProperties();
            String driver = p.getProperty(ConnectionOption.DRIVER);
            String url = p.getProperty(ConnectionOption.URL);
            String user = p.getProperty(ConnectionOption.USER_NAME);
            String password = p.getProperty(ConnectionOption.PASSWORD);
            return createPlatformConnection(driver, url, user, password, p.getProperties());
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
    }

    protected Connection createPlatformConnection(String driver,
            String url,
            String user,
            String password,
            Map<String, String> properties0) throws UPAException {
        Map<CaseInsensitiveString, String> properties=StringUtils.toCaseInsensitiveStringMap(properties0);
        try {
            net.vpc.upa.Properties uproperties = this.properties;
            PropertiesDollarConverter varConverter = new PropertiesDollarConverter(uproperties);
            driver = StringUtils.replaceDollarVars(driver, varConverter);
            url = StringUtils.replaceDollarVars(url, varConverter);
            user = StringUtils.replaceDollarVars(user, varConverter);
            password = StringUtils.replaceSingleDollarVars(password, varConverter);

            Map<String, String> jdbcProperties = new HashMap<String, String>();
            if (properties != null) {
                for (Map.Entry<CaseInsensitiveString, String> e : properties.entrySet()) {
                    String value = e.getValue();
                    value = StringUtils.replaceDollarVars(value, varConverter);
                    jdbcProperties.put(e.getKey().toString(), value);
                }
            }
            if (user != null) {
                jdbcProperties.put("user", user);
            }
            if (password != null) {
                jdbcProperties.put("password", password);
            }

            /**
             * @PortabilityHint(target="C#",name="replace") // monitoring is not
             * supprted in C#
             */
            {
                String monitor = jdbcProperties.get("monitor");
                if (monitor != null) {
                    for (String mon : monitor.split(" ,;\n")) {
                        if ("javamelody".equalsIgnoreCase(mon)) {
                            if (JAVAMELODY_JDBCDRIVER.isValid()) {
                                jdbcProperties.put("driver", driver);
                                driver = JAVAMELODY_JDBCDRIVER.getTypeName();
                            }
                        }
                    }
                }
            }

            /**
             * @PortabilityHint(target="C#",name="replace") // pooling is
             * managed virtually in C#
             */
            {
                String poolName = jdbcProperties.get("pool");
                if (poolName == null) {
                    poolName = "";
                }
                poolName = poolName.trim();
                boolean pool = poolName.length() > 0 && !("false".equalsIgnoreCase(poolName));
                if (pool) {
                    DataSource ds = resolvePoolableDataSource(driver, url, user, password, jdbcProperties);
                    if (ds != null) {
                        return ds.getConnection();
                    }
                    log.severe("Datasource is not supported, ignored pooling");
                }
            }

            /**
             * @PortabilityHint(target="C#",name="replace") return new
             * System.Data.OleDb.OleDbConnection(url);
             */
            {
                if (!StringUtils.isNullOrEmpty(driver)) {
                    try {
                        PlatformUtils.forName(driver);
                    } catch (Exception cls) {
                        throw new DriverNotFoundException(driver);
                    }
                }
                Properties info = new Properties();
                info.putAll(jdbcProperties);
                return DriverManager.getConnection(url, info);
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
    }

    protected Connection createOdbcConnection(ConnectionProfile p) throws UPAException {
        try {
//            Map<String, String> properties = p.getProperties();
            String user = p.getProperty(ConnectionOption.USER_NAME);
            String password = p.getProperty(ConnectionOption.PASSWORD);
            String odbcDriver = p.getProperty(ConnectionOption.DRIVER);
            String trustedString = p.getProperty(ConnectionOption.TRUSTED);
            boolean trustedBoolean = false;

            if (trustedString != null) {
                String trustedLowered = trustedString.toLowerCase();
                if (trustedLowered.equals("true") || trustedLowered.equals("on") || trustedLowered.equals("yes")) {
                    trustedBoolean = true;
                }
            }

            String odbcURL = "jdbc:odbc:";
            if (odbcDriver == null) {
                String dbname = p.getProperty(ConnectionOption.DATABASE_NAME);
                odbcURL += dbname;
            } else if (odbcDriver.equals("mdb")) {
                odbcURL += "Driver={Microsoft Access Driver (*.mdb)}";
                String dbname = p.getProperty(ConnectionOption.DATABASE_PATH);
                odbcURL += ";DBQ=" + dbname;
            } else if (odbcDriver.equals("xls")) {
                odbcURL += "Driver={Microsoft Excel Driver (*.xls)}";
                String dbname = p.getProperty(ConnectionOption.DATABASE_PATH);
                odbcURL += ";DBQ=" + dbname;
            } else if (odbcDriver.equals("oracle")) {
                odbcURL += "Driver={Microsoft ODBC for Oracle}";
                String server = p.getProperty(ConnectionOption.SERVER_ADDRESS);
                if (server == null) {
                    server = "localhost";
                }
                odbcURL += ";Server=" + server;
                if (trustedBoolean) {
                    odbcURL += ";Trusted_Connection=Yes";
                }
            } else if (odbcDriver.equals("mssqlserver")) {
                odbcURL += "Driver={SQL Server}";
                String server = p.getProperty(ConnectionOption.SERVER_ADDRESS);
                if (server == null) {
                    server = "(local)";
                }
                odbcURL += ";Server=" + server;
                if (trustedBoolean) {
                    odbcURL += ";Trusted_Connection=Yes";
                }
            }
            return createPlatformConnection(null, odbcURL, user, password, p.getProperties());

        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
    }

    public Connection createCustomPlatformConnection(ConnectionProfile p) throws UPAException {
        throw new UPAException(new I18NString("CreateCustomNativeConnectionNotSupported"));
    }

    public Connection createNativeRootConnection(EntityExecutionContext context) throws UPAException {
        ConnectionProfileParser connectionProfileParser = new ConnectionProfileParser();
        DefaultProperties p2 = new DefaultProperties(context.getPersistenceUnit().getProperties());
        List<ConnectionProfile> all = connectionProfileParser.parseEnabled(p2, context.getPersistenceUnit().getRootConnectionConfigs(), UPA.ROOT_CONNECTION_STRING);
        if (all.size() == 0) {
            throw new RootConnectionStringNotFoundException();
        }
        List<Object[]> errors = new ArrayList<Object[]>();
        for (ConnectionProfile cp : all) {
            try {
                return createNativeConnection(cp);
            } catch (Exception e) {
                errors.add(new Object[]{cp, e});
            }
        }
        for (Object[] objects : errors) {
            log.log(Level.SEVERE, "RootProfile " + objects[0] + " failed because of " + ((Throwable) objects[1]).toString(), ((Throwable) objects[1]));
        }
        throw new ConnectionException("CreateNativeRootConnectionFailed");
    }

    protected void prepareNativeConnection(UConnection connection, Map<String, Object> customAttributes, ConnectionProfile connectionProfile) throws UPAException {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        try {
            Connection nativeConnection = (Connection)connection.getPlatformConnection();
            customAttributes.put("AutoCommit", nativeConnection.getAutoCommit());
            nativeConnection.setAutoCommit(false);
        } catch (SQLException e) {
            throw new ConnectionException("DisableAutoCommitFailedException");
        }
    }
}
