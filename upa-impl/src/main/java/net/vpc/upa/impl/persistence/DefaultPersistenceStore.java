package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.*;
import net.vpc.upa.exceptions.IllegalArgumentException;
import net.vpc.upa.expressions.*;
import net.vpc.upa.extensions.FilterEntityExtensionDefinition;
import net.vpc.upa.extensions.UnionEntityExtensionDefinition;
import net.vpc.upa.extensions.ViewEntityExtensionDefinition;
import net.vpc.upa.filters.FieldFilter;
import net.vpc.upa.filters.FieldFilters;
import net.vpc.upa.impl.DefaultPersistenceUnit;
import net.vpc.upa.impl.DefaultProperties;
import net.vpc.upa.impl.SessionParams;
import net.vpc.upa.impl.persistence.connection.ConnectionProfileParser;
import net.vpc.upa.impl.persistence.shared.marshallers.ConstantDataMarshallerFactory;
import net.vpc.upa.impl.persistence.shared.marshallers.DefaultSerializablePlatformObjectMarshaller;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.DefaultExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionHelper;
import net.vpc.upa.impl.uql.compiledfilters.TypeCompiledExpressionFilter;
import net.vpc.upa.impl.uql.filters.ExpressionFilterFactory;
import net.vpc.upa.impl.util.*;
import net.vpc.upa.impl.util.filters.Fields2;
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
public class DefaultPersistenceStore implements PersistenceStore {

    public static final String DRIVER_TYPE_EMBEDDED = "EMBEDDED";
    public static final String DRIVER_TYPE_DEFAULT = "DEFAULT";
    public static final String DRIVER_TYPE_DATASOURCE = "DATASOURCE";
    public static final String DRIVER_TYPE_GENERIC = "GENERIC";
    public static final String DRIVER_TYPE_ODBC = "ODBC";
    protected static final TypeMarshaller SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER = new DefaultSerializablePlatformObjectMarshaller();

    protected static Logger log = Logger.getLogger(DefaultPersistenceStore.class.getName());

    protected static final String COMPLEX_SELECT_PERSIST = "Store.COMPLEX_SELECT_PERSIST";
    protected static final String COMPLEX_SELECT_MERGE = "Store.COMPLEX_SELECT_MERGE";
    public static boolean DO_WARNINGS = false;
    //    String verrou;
//    private boolean isOpen;
    private boolean readOnly;
    private String persistenceUnitName;
    private ObjectFactory factory;
    private IdentifierStoreTranslator identifierStoreTranslator;
    private static PlatformLenientType JAVAMELODY_JDBCDRIVER=new PlatformLenientType("net.bull.javamelody.JdbcDriver");



    //    private StatementDelegate statement;
//    private ConnectionProfile profile;
//    private String dbName;
//    private String dbVersion;
//    private SQLParser parser;
    private PersistenceNameStrategy persistenceNameStrategy;
    private Map<UPAObjectAndSpec, String> persistenceNamesMap = new HashMap<UPAObjectAndSpec, String>();
    //    private DefaultPersistenceNameStrategyManager defaultPersistenceNameStrategyManager;
    //    private String name;
    private net.vpc.upa.Properties parameters = new DefaultProperties();
    private DefaultPersistenceUnitCommitManager commitManager = new DefaultPersistenceUnitCommitManager();
    //    public static final DataWrapperFactory F_LIST = new ListDataMarshallerFactory();
    private MarshallManager marshallManager;
    private SQLManager sqlManager;
    private String identifierQuoteString;
    private PersistenceNameConfig nameConfig;
    private HashSet<String> reservedWords;
    private static HashSet<String> SQL2003_RESERVED_WORDS = new HashSet<String>(Arrays.asList(
            "ADD", "ALL", "ALLOCATE", "ALTER", "AND", "ANY", "ARE", "ARRAY", "AS", "ASENSITIVE", "ASYMMETRIC", "AT", "ATOMIC", "AUTHORIZATION", "BEGIN", "BETWEEN", "BIGINT", "BINARY", "BLOB", "BOOLEAN", "BOTH", "BY", "CALL", "CALLED", "CASCADED", "CASE", "CAST", "CHAR", "CHARACTER", "CHECK", "CLOB", "CLOSE", "COLLATE", "COLUMN", "COMMIT", "CONNECT", "CONSTRAINT", "CONTINUE", "CORRESPONDING", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_DATE", "CURRENT_DEFAULT_TRANSFORM_GROUP", "CURRENT_PATH", "CURRENT_ROLE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_TRANSFORM_GROUP_FOR_TYPE", "CURRENT_USER", "CURSOR", "CYCLE", "DATE", "DAY", "DEALLOCATE", "DEC", "DECIMAL", "DECLARE", "DEFAULT", "DELETE", "DEREF", "DESCRIBE", "DETERMINISTIC", "DISCONNECT", "DISTINCT", "DOUBLE", "DROP", "DYNAMIC", "EACH", "ELEMENT", "ELSE", "END", "END-EXEC", "ESCAPE", "EXCEPT", "EXEC", "EXECUTE", "EXISTS", "EXTERNAL", "FALSE", "FETCH", "FILTER", "FLOAT", "FOR", "FOREIGN", "FREE", "FROM", "FULL", "FUNCTION", "GET", "GLOBAL", "GRANT", "GROUP", "GROUPING", "HAVING", "HOLD", "HOUR", "IDENTITY", "IMMEDIATE", "IN", "INDICATOR", "INNER", "INOUT", "INPUT", "INSENSITIVE", "INSERT", "INT", "INTEGER", "INTERSECT", "INTERVAL", "INTO", "IS", "ISOLATION", "JOIN", "LANGUAGE", "LARGE", "LATERAL", "LEADING", "LEFT", "LIKE", "LOCAL", "LOCALTIME", "LOCALTIMESTAMP", "MATCH", "MEMBER", "MERGE", "METHOD", "MINUTE", "MODIFIES", "MODULE", "MONTH", "MULTISET", "NATIONAL", "NATURAL", "NCHAR", "NCLOB", "NEXT", "NEW", "NO", "NONE", "NOT", "NULL", "NUMERIC", "OF", "OLD", "ON", "ONLY", "OPEN", "OR", "ORDER", "OUT", "OUTER", "OUTPUT", "OVER", "OVERLAPS", "PARAMETER", "PARTITION", "PRECISION", "PREPARE", "PRIMARY", "PROCEDURE", "RANGE", "READS", "REAL", "RECURSIVE", "REF", "REFERENCES", "REFERENCING", "REGR_AVGX", "REGR_AVGY", "REGR_COUNT", "REGR_INTERCEPT", "REGR_R2", "REGR_SLOPE", "REGR_SXX", "REGR_SXY", "REGR_SYY", "RELEASE", "RESULT", "RETURN", "RETURNS", "REVOKE", "RIGHT", "ROLLBACK", "ROLLUP", "ROW", "ROWS", "SAVEPOINT", "SCROLL", "SEARCH", "SECOND", "SELECT", "SENSITIVE", "SESSION_USER", "SET", "SIMILAR", "SMALLINT", "SOME", "SPECIFIC", "SPECIFICTYPE", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "START", "STATIC", "SUBMULTISET", "SYMMETRIC", "SYSTEM", "SYSTEM_USER", "TABLE", "THEN", "TIME", "TIMESTAMP", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TRAILING", "TRANSLATION", "TREAT", "TRIGGER", "TRUE", "UESCAPE", "UNION", "UNIQUE", "UNKNOWN", "UNNEST", "UPDATE", "UPPER", "USER", "USING", "VALUE", "VALUES", "VAR_POP", "VAR_SAMP", "VARCHAR", "VARYING", "WHEN", "WHENEVER", "WHERE", "WIDTH_BUCKET", "WINDOW", "WITH", "WITHIN", "WITHOUT", "YEAR"));
    private ConnectionProfile connectionProfile;
    boolean isUpdateComplexValuesStatementSupported;
    boolean isUpdateComplexValuesIncludingUpdatedTableSupported;

    @PortabilityHint(target = "C#", name = "suppress")
    private final Map<String, DataSource> embeddedDataSources = new HashMap<String, DataSource>();
    @PortabilityHint(target = "C#", name = "suppress")
    private EmbeddedDatasourceFactoryComparator embeddedDatasourceFactoryComparator = DefaultEmbeddedDatasourceFactoryComparator.INSTANCE;
    @PortabilityHint(target = "C#", name = "suppress")
    private List<EmbeddedDatasourceFactory> embeddedDatasourceFactories = new ArrayList<EmbeddedDatasourceFactory>();
    @PortabilityHint(target = "C#", name = "suppress")
    private EmbeddedDatasourceFactory currentEmbeddedDatasourceFactory = null;
    @PortabilityHint(target = "C#", name = "suppress")
    private Boolean embeddedDataSourceSupported = null;

    //    protected static Hashtable litteralConverters=new Hashtable();
//    protected static LitteralConverter nullLitteralConverter;
//    static final public FunctionHandler DEFAULT_HANDLER=new FunctionHandler() {
//        public String simplify(String functionName, String[] params, HashMap context) {
//            StringBuffer sb = new StringBuffer(functionName);
//            sb.append('(');
//            if (params != null && params.length > 0) {
//                sb.append(params[0]);
//                for (int i = 1; i < params.length; i++) {
//                    sb.append(',');
//                    sb.append(params[i]);
//                }
//            }
//            sb.append(')');
//            return sb.toString();
//        }
//    };
    //    public static final DataWrapperFactory F_SERIALIZABLE_JAVA_OBJECT = new ConstantDataMarshallerFactory(SERIALIZABLE_JAVA_OBJECT);
//    public static final DataWrapperFactory F_IMAGE = new ConstantDataMarshallerFactory(IMAGE);
//    public static final DataWrapper FILE = SERIALIZABLE_JAVA_OBJECT;
//    public static final DataWrapper IMAGE = SERIALIZABLE_JAVA_OBJECT;
//    public static final DataWrapper SERIALIZABLE_JAVA_OBJECT = new SerializablePlatformObjectMarshaller();
//    public static final DataWrapperFactory F_NUMBER = new NumberDataMarshallerFactory();
//    public static final DataWrapperFactory F_DATE = new DateDataMarshallerFactory();
//    private Hashtable registredFunctionsMap=new Hashtable();


    @Override
    public void init(PersistenceUnit persistenceUnit, boolean readOnly, ConnectionProfile connectionProfile, PersistenceNameConfig nameConfig) throws UPAException {
        this.persistenceUnitName = persistenceUnit.toString();
        this.nameConfig = nameConfig;
        this.readOnly = readOnly;
        this.connectionProfile = connectionProfile;

        embeddedDataSourceSupported=null;
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        embeddedDatasourceFactories.add(DBCPv1EmbeddedDatasourceFactory.INSTANCE);
        /**
         * @PortabilityHint(target = "C#", name = "suppress")
         */
        embeddedDatasourceFactories.add(DBCPv2EmbeddedDatasourceFactory.INSTANCE);

        PersistenceNameStrategy c = persistenceUnit.getFactory().createObject(PersistenceNameStrategy.class);
        setPersistenceNameStrategy(c);
        PlatformBeanType b = PlatformBeanTypeRepository.getInstance().getBeanType(persistenceNameStrategy.getClass());
        b.inject(persistenceNameStrategy, "persistenceStore", this);
        b.inject(persistenceNameStrategy, "persistenceUnit", persistenceUnit);
        commitManager.init(persistenceUnit, this);
    }

    public final MarshallManager getMarshallManager() {
        return marshallManager;
    }

    //    public SQLParser getParser() {
//        return parser;
//    }
//
//    public void setParser(SQLParser parser) {
//        this.parser = parser;
//    }
    //    public void registerFunctionHandler(String functionName,FunctionHandler funtionHandler){
//        registredFunctionsMap.put(functionName.toLowerCase(),funtionHandler);
//    }
//
//    public void unregisterFunctionHandler(String functionName){
//        registredFunctionsMap.remove(functionName.toLowerCase());
//    }
//    public FunctionHandler getFunctionHandler(String functionName){
//        FunctionHandler functionHandler=(FunctionHandler) registredFunctionsMap.get(functionName.toLowerCase());
//        if(functionHandler==null){
//            return DEFAULT_HANDLER;
//        }
//        return functionHandler;
//    }
//
//    public void unregisterAllFunctionHandlers(){
//        registredFunctionsMap.clear();
//    }
    @Override
    public Set<String> getSupportedDrivers() {
        return new HashSet<String>();
    }

    public DefaultPersistenceStore() {
        parameters = new DefaultProperties();
        net.vpc.upa.Properties map = parameters;
        map.setBoolean("isComplexSelectSupported", false);
        map.setBoolean("isUpdateComplexValuesStatementSupported", false);
        map.setBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
        map.setBoolean("isFromClauseInUpdateStatementSupported", false);
        map.setBoolean("isFromClauseInDeleteStatementSupported", false);
        map.setBoolean("isReferencingSupported", true);
        map.setBoolean("isViewSupported", false);
        map.setBoolean("isTopSupported", false);
//        this.parser = (new SQLParser());
        marshallManager = new DefaultMarshallManager();
        sqlManager = new DefaultSQLManager(marshallManager);

//        setWrapper(java.util.Date.class,DATETIME);
//        setWrapper(java.sql.Date.class,DATE);
//        setWrapper(java.sql.Time.class,TIME);
//        setWrapper(java.sql.Timestamp.class,TIMESTAMP);
        getMarshallManager().setTypeMarshaller(Object.class, SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
        getMarshallManager().setTypeMarshaller(FileData.class, SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
        getMarshallManager().setTypeMarshaller(DataType.class, SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
        ConstantDataMarshallerFactory blobfactory = new ConstantDataMarshallerFactory(SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
        getMarshallManager().setTypeMarshaller(java.sql.Date.class, TypeMarshallerUtils.SQL_DATE);
        getMarshallManager().setTypeMarshallerFactory(ImageType.class, blobfactory);
        getMarshallManager().setTypeMarshallerFactory(FileType.class, blobfactory);
        getMarshallManager().setTypeMarshallerFactory(DataType.class, blobfactory);

    }

    public boolean isComplexSelectSupported() {
        return getProperties().getBoolean("isComplexSelectSupported", false);
    }

    public boolean isFromClauseInUpdateStatementSupported() {
        return getProperties().getBoolean("isFromClauseInUpdateStatementSupported", false);
    }

    public boolean isFromClauseInDeleteStatementSupported() {
        return getProperties().getBoolean("isFromClauseInDeleteStatementSupported", false);
    }

    public boolean isReferencingSupported() {
        return getProperties().getBoolean("isReferencingSupported", false);
    }

    public boolean isViewSupported() {
        return getProperties().getBoolean("isViewSupported", false);
    }

    public boolean isTopSupported() {
        return getProperties().getBoolean("isTopSupported", false);
    }

    //    @Override
//    public Connection createMasterConnection(String masterDatabaseName, String loginText, String pwdText, Properties properties, boolean windowMode) throws UPAException {
//        ConnectionProfile profile = (ConnectionProfile) getConnectionProfile().copy();
//        profile.setProperty(ConnectionProfile.DATABASE_NAME, masterDatabaseName);
//        Connection c = null;
//        try {
//            profile.addProperties(properties);
//            c = createNativeConnection(profile);
//        } catch (DriverNotFoundException e) {
//            throw e;
//        } catch (SQLException e) {
//            if (properties != null) {
//                if (properties.contains(ConnectionProfile.USER_NAME)) {
//                    profile.setProperty(ConnectionProfile.USER_NAME, properties.getProperty(ConnectionProfile.USER_NAME));
//                } else {
//                    profile.setProperty(ConnectionProfile.USER_NAME, loginText);
//                }
//                if (properties.contains(ConnectionProfile.PASSWORD)) {
//                    profile.setProperty(ConnectionProfile.PASSWORD, properties.getProperty(ConnectionProfile.PASSWORD));
//                } else {
//                    profile.setProperty(ConnectionProfile.PASSWORD, pwdText);
//                }
//            } else {
//                profile.setProperty(ConnectionProfile.USER_NAME, loginText);
//                profile.setProperty(ConnectionProfile.PASSWORD, pwdText);
//            }
//            loop:
//            while (true) {
//                try {
//                    c = createNativeConnection(profile);
//                    break loop;
//                } catch (SQLException e1) {
////                    if (!windowMode) {
//                    throw new UPAException(e1, new I18NString("ConnectionFailed"));
////                    }
////                    JPanel allPanel = new JPanel(new BorderLayout());
////                    allPanel.add(new JLabel(getPersistenceUnit().getResources().get("PersistenceUnitFilter.createMasterConnection.message")), BorderLayout.PAGE_START);
////                    ECGroupPanel panel = new ECGroupPanel();
////                    ECTextField login = new ECTextField("login", 20, 1, 30, false);
////                    login.setDescription(getPersistenceUnit().getResources().get("DBConnectionModule.user"));
////                    ECPasswordField pwd = new ECPasswordField("pwd", 20, 1, 30, true);
////                    pwd.setDescription(getPersistenceUnit().getResources().get("DBConnectionModule.password"));
////                    panel.add(new EditComponent[]{login, pwd}, 1);
////                    allPanel.add(panel, BorderLayout.CENTER);
////                    loop2:
////                    while (true) {
////                        int ret = JOptionPane.showConfirmDialog(Swings.DEFAULT_PARENT_COMPONENT, allPanel,
////                                getPersistenceUnit().getResources().get("PersistenceUnitFilter.createMasterConnection.title"), JOptionPane.OK_CANCEL_OPTION, JOptionPane.PLAIN_MESSAGE);
////                        if (ret == JOptionPane.OK_OPTION) {
////                            try {
////                                profile.setProperty(ConnectionProfile.USER_NAME, login.getText());
////                                profile.setProperty(ConnectionProfile.PASSWORD, (String) pwd.getObject());
////                            } catch (ConstraintsException e2) {
////                                JOptionPane2.showErrorDialog(e2);
////                                continue loop2;
////                            }
////                            break loop2;
////                        } else {
////                            return null;
////                        }
////                    }
//                }
//            }
//        }
//        return c;
//    }
    public FieldPersister createPersistSequenceGenerator(Field field) throws UPAException {
        throw new UPAException("UnsupportedException", "createInsertSequenceGenerator");
    }

    public FieldPersister createUpdateSequenceGenerator(Field field) throws UPAException {
        throw new UPAException("UnsupportedException", "createUpdateSequenceGenerator");
    }

    @Override
    public void createStorage(EntityExecutionContext context) throws UPAException {
        try {
            UConnection executor = null;
            try {
                executor = createRootUConnection(context);
                executor.executeNonQuery("Create Database " + getConnectionProfile().getProperties().get(ConnectionOption.DATABASE_NAME), null, null);
            } finally {
                if (executor != null) {
                    executor.close();
                }
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new CreatePersistenceUnitException(e, new I18NString("CreateSchemaFailed"));
        }
    }

    @Override
    public void dropStorage(EntityExecutionContext context) throws UPAException {
        try {
            UConnection executor = null;
            try {
                executor = createRootUConnection(context);
                executor.executeNonQuery("Create Database " + getConnectionProfile().getProperties().get(ConnectionOption.DATABASE_NAME), null, null);
            } finally {
                if (executor != null) {
                    executor.close();
                }
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new DropPersistenceUnitException(e, new I18NString("DropSchemaFailed"));
        }
    }

    public boolean isDelegationConnectionManagement() throws UPAException {
        ConnectionProfile p = getConnectionProfile();
        String connectionDriver = p.getConnectionDriver();
        if (connectionDriver == null || connectionDriver.trim().isEmpty()) {
            connectionDriver = DRIVER_TYPE_DEFAULT;
        }
//        Map<String, String> properties = p.getProperties();
        if (DRIVER_TYPE_DATASOURCE.equalsIgnoreCase(connectionDriver)) {
            return true;
        }
        if (DRIVER_TYPE_GENERIC.equalsIgnoreCase(connectionDriver)) {
            return true;
        }
        if (DRIVER_TYPE_ODBC.equalsIgnoreCase(connectionDriver)) {
            return true;
        }
        return false;

    }

    @Override
    public boolean isCreatedStorage() throws UPAException {
        UConnection c = null;
        try {
            try {
                c = createConnection();
            } finally {
                if (c != null) {
                    c.close();
                }
            }
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    //    @Override
//    public String getDBVersion() {
//        return dbVersion;
//    }
    @Override
    public net.vpc.upa.Properties getProperties() {
        return parameters;
    }

    //    @Override
//    public void setDBVersion(String dbVersion) {
//        this.dbVersion = dbVersion;
//    }
//    @Override
//    public String getDBName() {
//        return dbName;
//    }
//    @Override
//    public String getDatabaseName() {
//        return dbName;
//    }
//
//    @Override
//    public String getDatabaseVersion() {
//        return dbVersion;
//    }
    @Override
    public ConnectionProfile getConnectionProfile() throws UPAException {
        return connectionProfile;
    }

    //    private void checkConnection()
//            throws UPAException {
//        if (getSession().getParam(persistenceUnit, Connection.class, SessionParams.CONNECTION, null) == null) {
//            throw new UPAException("Could not connect to database");
//        }
//    }
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

    public UConnection wrapConnection(Connection connection) throws UPAException {
        return new DefaultUConnection(persistenceUnitName, connection, getMarshallManager());
    }

    public UConnection createRootUConnection(EntityExecutionContext context) throws UPAException {
        return wrapConnection(createNativeRootConnection(context));
    }

    protected void prepareNativeConnection(UConnection connection, Map<String, Object> customAttributes) throws UPAException {
        /**
         * @PortabilityHint(target = "C#",name = "suppress")
         */
        try {
            Connection nativeConnection = connection.getPlatformConnection();
            customAttributes.put("AutoCommit", nativeConnection.getAutoCommit());
            nativeConnection.setAutoCommit(false);
        } catch (SQLException e) {
            throw new ConnectionException("DisableAutoCommitFailedException");
        }
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
        Connection nativeConnection = createNativeConnection();
        log.log(Level.FINE, "Connection Created {0}", nativeConnection);
        final Map<String, Object> customAttributes = new HashMap<String, Object>();
        UConnection connection = wrapConnection(nativeConnection);
        prepareNativeConnection(connection, customAttributes);
        reconfigureStore(connection);
        return connection;
        //ConnectionDelegate connectionDelegate = new ConnectionDelegate(this, nativeConnection);
        //log.log(Level.FINE,"createConnection created new Connection");
        //return connectionDelegate;
    }

    protected void reconfigureStore(UConnection connection) {
        if (!getProperties().containsKey("configured")) {
            /**
             * @PortabilityHint(target = "C#",name = "todo")
             */
            try {
                DatabaseMetaData metaData = connection.getMetadataAccessibleConnection().getMetaData();
                getProperties().setString("configured", String.valueOf(true));
                getProperties().setString("databaseMajorVersion", String.valueOf(metaData.getDatabaseMajorVersion()));
                getProperties().setString("databaseMinorVersion", String.valueOf(metaData.getDatabaseMinorVersion()));
                getProperties().setString("databaseProductVersion", String.valueOf(metaData.getDatabaseProductVersion()));
                getProperties().setString("databaseProductName", String.valueOf(metaData.getDatabaseProductName()));
                getProperties().setString("driverName", String.valueOf(metaData.getDriverName()));
                getProperties().setString("driverName", String.valueOf(metaData.getDriverName()));
                getProperties().setString("driverVersion", String.valueOf(metaData.getDriverVersion()));
                getProperties().setString("driverVersion", String.valueOf(metaData.getDriverVersion()));
                getProperties().setString("driverMajorVersion", String.valueOf(metaData.getDriverMajorVersion()));
                getProperties().setString("driverMinorVersion", String.valueOf(metaData.getDriverMinorVersion()));
                getProperties().setString("identifierQuoteString", identifierQuoteString = (metaData.getIdentifierQuoteString()));
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
            isUpdateComplexValuesStatementSupported = getProperties().getBoolean("isUpdateComplexValuesStatementSupported", false);
            isUpdateComplexValuesIncludingUpdatedTableSupported = getProperties().getBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
        }

    }

    //    @Override
    public Connection createNativeConnection() throws UPAException {
        return createNativeConnection(getConnectionProfile());
    }

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
            Map<String, String> properties = p.getProperties();
            InitialContext ic = new InitialContext();
            String dbPrefix = properties.get(ConnectionOption.SERVER_ADDRESS);
            String dbname = properties.get(ConnectionOption.DATABASE_NAME);
            if (dbPrefix == null && dbname == null) {
                throw new UPAException(new I18NString("MissingDatasourceName"));
            } else if (dbname == null) {
                dbname = dbPrefix;
            } else if (dbPrefix != null) {
                dbname = dbPrefix + "/" + dbname;
            }
            String noDatasourcePrefix = properties.get("noDatasourcePrefix");
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
            Map<String, String> properties = p.getProperties();
            String driver = properties.get(ConnectionOption.DRIVER);
            String url = properties.get(ConnectionOption.URL);
            String user = properties.get(ConnectionOption.USER_NAME);
            String password = properties.get(ConnectionOption.PASSWORD);
            return createPlatformConnection(driver, url, user, password, properties);
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
                                                  Map<String, String> properties) throws UPAException {
        try {
            Map<String, String> jdbcProperties=new HashMap<String, String>();
            if(properties!=null){
                jdbcProperties.putAll(properties);
            }
            if (user != null) {
                jdbcProperties.put("user", user);
            }
            if (password != null) {
                jdbcProperties.put("password", password);
            }

            /**
             * @PortabilityHint(target="C#",name="replace")
             * // monitoring is not supprted in C#
             */
            {
                String monitor = jdbcProperties.get("monitor");
                if(monitor!=null){
                    for (String mon : monitor.split(" ,;\n")) {
                        if("javamelody".equalsIgnoreCase(mon)){
                            if(JAVAMELODY_JDBCDRIVER.isValid()){
                                jdbcProperties.put("driver",driver);
                                driver=JAVAMELODY_JDBCDRIVER.getTypeName();
                            }
                        }
                    }
                }
            }

            /**
             * @PortabilityHint(target="C#",name="replace")
             * // pooling is managed virtually in C#
             */
            {
                String poolName = jdbcProperties.get("pool");
                if(poolName==null){
                    poolName="";
                }
                poolName=poolName.trim();
                boolean pool = poolName.length()>0 && !("false".equalsIgnoreCase(poolName));
                if (pool) {
                    DataSource ds = resolvePoolableDataSource(driver, url, user, password, jdbcProperties);
                    if (ds != null) {
                        return ds.getConnection();
                    }
                    log.severe("Datasource is not supported, ignored pooling");
                }
            }



            /**
             * @PortabilityHint(target="C#",name="replace")
             * return new System.Data.OleDb.OleDbConnection(url);
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
            Map<String, String> properties = p.getProperties();
            String user = properties.get(ConnectionOption.USER_NAME);
            String password = properties.get(ConnectionOption.PASSWORD);
            String odbcDriver = properties.get(ConnectionOption.DRIVER);
            String trustedString = properties.get(ConnectionOption.TRUSTED);
            boolean trustedBoolean = false;

            if (trustedString != null) {
                String trustedLowered = trustedString.toLowerCase();
                if (trustedLowered.equals("true") || trustedLowered.equals("on") || trustedLowered.equals("yes")) {
                    trustedBoolean = true;
                }
            }

            String odbcURL = "jdbc:odbc:";
            if (odbcDriver == null) {
                String dbname = properties.get(ConnectionOption.DATABASE_NAME);
                odbcURL += dbname;
            } else if (odbcDriver.equals("mdb")) {
                odbcURL += "Driver={Microsoft Access Driver (*.mdb)}";
                String dbname = properties.get(ConnectionOption.DATABASE_PATH);
                odbcURL += ";DBQ=" + dbname;
            } else if (odbcDriver.equals("xls")) {
                odbcURL += "Driver={Microsoft Excel Driver (*.xls)}";
                String dbname = properties.get(ConnectionOption.DATABASE_PATH);
                odbcURL += ";DBQ=" + dbname;
            } else if (odbcDriver.equals("oracle")) {
                odbcURL += "Driver={Microsoft ODBC for Oracle}";
                String server = properties.get(ConnectionOption.SERVER_ADDRESS);
                if (server == null) {
                    server = "localhost";
                }
                odbcURL += ";Server=" + server;
                if (trustedBoolean) {
                    odbcURL += ";Trusted_Connection=Yes";
                }
            } else if (odbcDriver.equals("mssqlserver")) {
                odbcURL += "Driver={SQL Server}";
                String server = properties.get(ConnectionOption.SERVER_ADDRESS);
                if (server == null) {
                    server = "(local)";
                }
                odbcURL += ";Server=" + server;
                if (trustedBoolean) {
                    odbcURL += ";Trusted_Connection=Yes";
                }
            }
            return createPlatformConnection(null, odbcURL, user, password, properties);

        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
    }

    public Connection createCustomPlatformConnection(ConnectionProfile p) throws UPAException {
        throw new UPAException(new I18NString("CreateCustomNativeConnectionNotSupported"));
    }

    protected int getMaxJoinCount() {
        return getProperties().getInt("maxQueryJoinCount", -1);
    }

    public QueryExecutor createExecutor(
            Expression baseExpression,
            Map<String, Object> parametersByName,
            Map<Integer, Object> parametersByIndex,
            boolean updatable,
            FieldFilter defaultFieldFilter,
            EntityExecutionContext context) throws UPAException {
        if (isUpdateComplexValuesIncludingUpdatedTableSupported || !(baseExpression instanceof Update)) {
            return createDefaultExecutor(baseExpression,
                    parametersByName,
                    parametersByIndex,
                    updatable,
                    defaultFieldFilter, context);
        }
        return createCustomUpdateExecutor((Update) baseExpression,
                parametersByName,
                parametersByIndex,
                updatable,
                defaultFieldFilter, context);
    }


    public QueryExecutor createCustomUpdateExecutor(
            final Update baseExpression,
            final Map<String, Object> parametersByName,
            final Map<Integer, Object> parametersByIndex,
            final boolean updatable,
            final FieldFilter defaultFieldFilter,
            final EntityExecutionContext context
    ) throws UPAException {

        ExpressionManager expressionManager = context.getPersistenceUnit().getExpressionManager();
        final ResultMetaData metadata = expressionManager.createMetaData((EntityStatement) baseExpression, defaultFieldFilter);
        Map<String, Object> hints = context.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        }
        Update update2 = (Update) baseExpression.copy();
        PersistenceUnit pu = context.getPersistenceUnit();
        final Entity entity = pu.getEntity(update2.getEntityName());
        final String entityName = entity.getName();
        final List<VarVal> complexVals = new ArrayList<VarVal>();
        for (int i = update2.countFields() - 1; i >= 0; i--) {
            VarVal varVal = update2.getVarVal(i);
            boolean complexSelect = false;
            Expression fieldExpression = varVal.getVal();
            if (null != fieldExpression.findOne(new ComplexUpdateExpressionFilter(entityName, isUpdateComplexValuesStatementSupported))) {
                complexSelect = true;
            }
            if (complexSelect) {
                //complex expression
                complexVals.add(varVal);
                update2.removeFieldAt(i);
            }
        }
        final Map<String, Object> finalHints = hints;
        return new CustomUpdateQueryExecutor(this, finalHints, update2, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context, complexVals, entity, entityName, metadata);
    }

    public QueryExecutor createDefaultExecutor(
            Expression baseExpression,
            Map<String, Object> parametersByName,
            Map<Integer, Object> parametersByIndex,
            boolean updatable,
            FieldFilter defaultFieldFilter, EntityExecutionContext context) throws UPAException {

        if (defaultFieldFilter == null) {
            defaultFieldFilter = Fields2.READ;
        }
        ExpressionManager expressionManager = context.getPersistenceUnit().getExpressionManager();
        ResultMetaData m = expressionManager.createMetaData((EntityStatement) baseExpression, defaultFieldFilter);
        EntityStatement statement = m.getStatement();

        //apply parameters
        if (parametersByName != null) {
            for (Map.Entry<String, Object> entry : parametersByName.entrySet()) {
                String name = entry.getKey();
                Object value = entry.getValue();

                List<Expression> params = statement.findAll(ExpressionFilterFactory.forParam(name));
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("Parameter not found " + name);
                }
                for (Expression e : params) {
                    Param p = (Param) e;
                    p.setValue(value);
                    p.setUnspecified(false);
                }
            }
        }
        if (parametersByIndex != null && !parametersByIndex.isEmpty()) {
            List<Expression> params = statement.findAll(ExpressionFilterFactory.PARAM_FILTER);
            for (Map.Entry<Integer, Object> entry : parametersByIndex.entrySet()) {
                Integer index = entry.getKey();
                Object value = entry.getValue();
                if (params.size() <= index) {
                    throw new IllegalArgumentException("Parameter not found " + index);
                }
                Param p = (Param) params.get(index);
                if (p == null) {
                    throw new IllegalArgumentException("Parameter not found " + index);
                }
                p.setValue(value);
                p.setUnspecified(false);
            }
        }


        Map<String, Object> hints = context.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        }

        int maxJoinCount = getMaxJoinCount();
        ExpressionCompilerConfig config = new ExpressionCompilerConfig();
        config.setExpandEntityFilter(true);
        config.setExpandFieldFilter(defaultFieldFilter);
        config.setExpandFields(true);
        config.setValidate(true);
        config.setHints(hints);
        config.setThisAlias(StringUtils.isNullOrEmpty(statement.getEntityAlias())?statement.getEntityName():statement.getEntityAlias());

        DefaultCompiledExpression compiledExpression = (DefaultCompiledExpression) expressionManager.compileExpression(statement, config);
        boolean reeavluateWithLessJoin = false;
        if (maxJoinCount > 0) {
            for (CompiledExpression ce : compiledExpression.findExpressionsList(new TypeCompiledExpressionFilter(CompiledSelect.class))) {
                CompiledSelect cs = (CompiledSelect) ce;
                if (cs.getJoins().length >= maxJoinCount) {
                    log.warning("this query is very likely to fail. It uses " + cs.getJoins().length + " > " + maxJoinCount + " join tables :" + statement);
                    reeavluateWithLessJoin = true;
                    break;
                }
            }
            if (reeavluateWithLessJoin) {
                //reset expression
                config = new ExpressionCompilerConfig()
                        .setExpandEntityFilter(true)
                        .setExpandFieldFilter(defaultFieldFilter)
                        .setExpandFields(true)
                        .setValidate(true)
                        .setThisAlias(StringUtils.isNullOrEmpty(statement.getEntityAlias())?statement.getEntityName():statement.getEntityAlias());

                hints.put(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.SELECT);
                config.setHints(hints);
                compiledExpression = (DefaultCompiledExpression) expressionManager.compileExpression(baseExpression, config);
                reeavluateWithLessJoin = false;
                for (CompiledExpression ce : compiledExpression.findExpressionsList(new TypeCompiledExpressionFilter(CompiledSelect.class))) {
                    CompiledSelect cs = (CompiledSelect) ce;
                    if (cs.getJoins().length >= maxJoinCount) {
                        log.warning("this query is very likely to fail. It still uses " + cs.getJoins().length + " > " + maxJoinCount + " join tables :" + statement);
                        reeavluateWithLessJoin = true;
                        break;
                    }
                }
            }
        }

        Boolean noTypeTransformO = (Boolean) hints.get(QueryHints.NO_TYPE_TRANSFORM);
        boolean noTypeTransform = noTypeTransformO == null ? false : noTypeTransformO;

        NativeField[] ne = null;
        if (compiledExpression instanceof CompiledQueryStatement) {
            CompiledQueryStatement cquery = (CompiledQueryStatement) compiledExpression;
            ne = new NativeField[cquery.countFields()];
            for (int i = 0; i < ne.length; i++) {
                CompiledQueryField field = cquery.getField(i);
//                String fieldAlias = field.getAliasBinding();
                net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression expression1 = field.getExpression();
                String binding = field.getBinding();
//                if(binding==null){
//                    binding=field.getAlias();
//                }
                String exprString = expression1.toString();
                String validName = field.getName() != null ? field.getName() : expression1.toString();
                if (validName == null) {
                    validName = "#" + i;
                }

                DataTypeTransform tc = expression1 == null ? null : UPAUtils.resolveDataTypeTransform(expression1);
                DataTypeTransform c = null;
                if (tc == null) {
                    throw new IllegalArgumentException("Unable to resolve type for expression : " + expression1);
                }
                Field f = null;
                if (expression1 instanceof CompiledVar) {
                    CompiledVar v = (CompiledVar) expression1;
                    CompiledVarOrMethod leaf = v.getDeepChild();
                    Object referrer = leaf.getReferrer();
                    if (referrer instanceof Field) {
                        f = (Field) referrer;
                        c = UPAUtils.getTypeTransformOrIdentity(f);
                    }
                }
                if (c == null) {
                    c = tc;
                }
                boolean fieldNoTypeTransform = noTypeTransform;
                if (!noTypeTransform) {
                    if (f != null) {
                        String fieldKey = QueryHints.NO_TYPE_TRANSFORM + "." + f.getAbsoluteName();
                        fieldNoTypeTransform = (Boolean) (hints.get(fieldKey) == null ? false : hints.get(fieldKey));
                    }
                }
                DataTypeTransform baseTransform = c;
                c = fieldNoTypeTransform ? IdentityDataTypeTransform.forDataType(baseTransform.getSourceType()) : baseTransform;
//                String gn=StringUtils.isNullOrEmpty(validName)?validName:(binding+"."+validName);
                ne[i] = new NativeField(validName, binding, exprString, field.getIndex(), field.isExpanded(), f, c);
            }
        } else {
            ne = new NativeField[0];
        }

        String query = this.getSqlManager().getSQL(compiledExpression, context, new DefaultExpressionDeclarationList(null));

        List<CompiledParam> cvalues = compiledExpression.findExpressionsList(CompiledExpressionHelper.PARAM_FILTER);
        List<Parameter> values = new ArrayList<Parameter>();
        for (CompiledParam e : cvalues) {
            if (e.isUnspecified()) {
                throw new IllegalArgumentException("Unspecified Param " + e);
            }
            ExprTypeInfo ei = UPAUtils.resolveExprTypeInfo(e);
            Object objectValue = e.getValue();
            if (ei.getOldReferrer() != null) {
                Field oldField = (Field) ei.getOldReferrer();
                if (oldField.getDataType() instanceof ManyToOneType) {
                    ManyToOneType et = (ManyToOneType) oldField.getDataType();
                    objectValue = et.getRelationship().getTargetEntity().getBuilder().objectToId(objectValue);
                }
            }
            boolean fieldNoTypeTransform = noTypeTransform;
            if (ei.getReferrer() instanceof Field) {
                if (!noTypeTransform) {
                    Field field = (Field) ei.getReferrer();
                    String fieldKey = QueryHints.NO_TYPE_TRANSFORM + "." + field.getAbsoluteName();
                    fieldNoTypeTransform = (Boolean) (hints.get(fieldKey) == null ? false : hints.get(fieldKey));
                }
            }
            DataTypeTransform baseTransform = ei.getTypeTransform();
            DataTypeTransform preferedTransform = fieldNoTypeTransform ? IdentityDataTypeTransform.forDataType(baseTransform.getSourceType()) : baseTransform;

            values.add(new DefaultParameter(e.getName(), objectValue, preferedTransform));
        }
        return new DefaultQueryExecutor(
                context.getOperation() == ContextOperation.FIND ? NativeStatementType.SELECT : NativeStatementType.UPDATE,
                hints, query, values, context.getGeneratedValues()
                , this, context.getConnection(), ne, updatable, m
        );
    }

    //    @Override
//    public QueryExecutor queryExecutor(String query) throws SQLException {
//        //query = validateFunctions(query);
//        HashMap context = new HashMap(1);
//        query = getParser().simplify(query, context);
//        QueryExecutor queryExecutor = new DefaultQueryExecutor(NativeStatementType.SELECT);
//        queryExecutor.setPersistenceStore(this);
//        queryExecutor.addNativeStatement(new ReturnStatement(query));
//        queryExecutor.setQuery(query);
//        return queryExecutor;
//    }
//    public boolean warnings(SQLWarning warn)
//            throws UPAException {
//        if (!DO_WARNINGS) {
//            return false;
//        }
////        checkConnection();
//        boolean rc = false;
//        if (warn != null) {
//            String waringStr = "\n" + "*** Warning***" + "\n";
//            rc = true;
//            for (; warn != null; warn = warn.getNextWarning()) {
//                waringStr = waringStr + "SQL State : " + warn.getSQLState() + "\n" + "Message   : " + warn.getMessage() + "\n" + "Error Code: " + warn.getErrorCode() + "\n";
//            }
//
//            log.warn("-----SQL-WARNINIGS----- " + waringStr);
//        }
//        return rc;
//    }
    @Override
    public void close()
            throws UPAException {
//        TODO
//        try {
//            SessionImpl session = getSession();
//            Connection connection = session.getConnection(this);
//            session.setConnection(this, null);
//            if (connection != null && !connection.isClosed()) {
//                connection.close();
//            }
//        } catch (SQLException e) {
//            //Log.log(DB_ERROR_LOG, "-----SQL-ERROR-CLOSE-CONNECTION----- : " + e);
//            throw new UPAException(e, new I18NString("CloseFailed"));
//        }
    }

    //    private Connection getNativeConnection() throws UPAException {
//        Connection connection = getConnection();
//        if (connection instanceof ConnectionDelegate) {
//            connection = ((ConnectionDelegate) connection).getHandledConnection();
//        }
//        return connection;
//    }
    //    public StatementDelegate getStatement() {
//        return statement;
//    }
    //
//    public String toString() {
//        String ver = getDBVersion();
//        if ("*".equals(ver)) {
//            return getDBName() + ':' + getConnectionProfile().toString();
//        } else {
//            return getDBName() + '/' + getDBVersion() + ':' + getConnectionProfile().toString();
//        }
//
//    }
    //    @Override
    public String getFieldDeclaration(PrimitiveField field, net.vpc.upa.persistence.EntityExecutionContext entityPersistenceContext) throws UPAException {
//        FormatterInterface formatter = new StringFormatter(32);
        DataTypeTransform cr = UPAUtils.getTypeTransformOrIdentity(field);
//        Class sqlType = cr.getPlatformType();
//        int length = cr.getScale();
//        int precision = cr.getPrecision();
        Object defaultObject = field.getDefaultObject();
        StringBuilder sb = new StringBuilder(getValidIdentifier(getColumnName(field)));
        sb.append('\t');
        EntityExecutionContext context = ((DefaultPersistenceUnit) entityPersistenceContext.getPersistenceUnit()).createContext(ContextOperation.FIND, entityPersistenceContext.getHints());
        sb.append(sqlManager.getSQL(new CompiledTypeName(cr), context, new DefaultExpressionDeclarationList(null)));
        if (defaultObject == null && !cr.getTargetType().isNullable()) {
            defaultObject = cr.getTargetType().getDefaultValue();
            if (defaultObject == null) {
                defaultObject = cr.getTargetType().getDefaultNonNullValue();
            }
        }
        if (defaultObject != null && !(defaultObject instanceof CustomDefaultObject)) {
            sb.append(" Default ").append(sqlManager.getSQL(new CompiledLiteral(defaultObject, cr), context, new DefaultExpressionDeclarationList(null)));
        }

        if (!cr.getTargetType().isNullable()) {
            sb.append(" Not Null");
        }
        return sb.toString();
    }

    //    @Override
//    @Override
//    public String getDropTableStatement(Entity table) {
//        return !(table instanceof EntityView) || !getProperties().getBoolean("isViewSupported", false)
//                ? ("Drop Table " + table.getName())
//                : ("Drop View " + table.getName());
//    }
//
//    @Override
//    public String getDropViewForTableStatement(Entity table) {
//        return ("Drop View " + getImplicitViewName(table));
//    }
//
//    @Override
//    public String getDropViewStatement(Entity table) {
//        return ("Drop View " + getPersistenceName(table));
//    }
    //    @Override
    public String getCreateViewStatement(Entity entityManager, QueryStatement statement, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getTableName(entityManager))).append(" As ").append("\n").append("\t");
        net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression compiledExpression = (net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(statement, null);
        sb.append(sqlManager.getSQL(compiledExpression, executionContext, new DefaultExpressionDeclarationList(null)));
        return sb.toString();
    }

    //FIX ME
    //    @Override
    public String getCreateImplicitViewStatement(Entity table, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getImplicitViewName(table))).append(" As ").append("\n");
        List<PrimitiveField> keys = table.getPrimitiveFields();
        Select s = new Select();
        for (PrimitiveField key : keys) {
            FlagSet<FieldModifier> modifiers = key.getModifiers();
            if (modifiers.contains(FieldModifier.SELECT_STORED)) {
                Expression expression = ((ExpressionFormula) key.getSelectFormula()).getExpression();
                s.field(expression, getColumnName(key));
            } else if (modifiers.contains(FieldModifier.SELECT_DEFAULT)) {
                s.field(new Var(new Var(table.getName()), key.getName()));
            }
        }

        EntityExecutionContext qlContext = ((DefaultPersistenceUnit) executionContext.getPersistenceUnit()).createContext(ContextOperation.CREATE_PERSISTENCE_NAME, executionContext.getHints());
        net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression compiledExpression = (net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(s, null);
        sb.append(sqlManager.getSQL(compiledExpression, qlContext, new DefaultExpressionDeclarationList(null)));
        return (sb.toString());
    }

    //    @Override
    public String getCreateRelationshipStatement(Relationship relation) throws UPAException {
        StringBuilder sb = new StringBuilder();
        RelationshipRole detailRole = relation.getSourceRole();
        Entity table = detailRole.getEntity();
        if (isView(table)) {
            return null;
        } else if (relation.getRelationshipType() != RelationshipType.TRANSIENT) {
            sb.append("Alter Table ").append(getValidIdentifier(getTableName(table))).append(" Add Constraint ").append(getValidIdentifier(getRelationshipName(relation))).append(" Foreign Key (");
            boolean first1 = true;
            for (int i = 0; i < relation.size(); i++) {
                List<PrimitiveField> fields = detailRole.getEntity().toPrimitiveFields(Arrays.asList((EntityPart) detailRole.getField(i)));
                for (Field field : fields) {
                    if (first1) {
                        first1 = false;
                    } else {
                        sb.append(',');
                    }
                    sb.append(getValidIdentifier(getColumnName(field)));
                }
            }
            RelationshipRole masterRole = relation.getTargetRole();
            sb.append(") References ").append(getValidIdentifier(getTableName(masterRole.getEntity()))).append(" (");
            first1 = true;
            for (int i = 0; i < relation.size(); i++) {
                List<PrimitiveField> fields = masterRole.getEntity().toPrimitiveFields(Arrays.asList((EntityPart) masterRole.getField(i)));
                for (Field field : fields) {
                    if (first1) {
                        first1 = false;
                    } else {
                        sb.append(',');
                    }
                    sb.append(getValidIdentifier(getColumnName(field)));
                }
            }
            sb.append(")");
            return (sb.toString());
        }
        return null;
    }

    @Override
    public void setIdentityConstraintsEnabled(Entity entity, boolean enable, EntityExecutionContext context) {
        UConnection connection = context.getConnection();
        connection.setProperty("IdentityConstraintsEnabled." + entity.getName(), enable);
        if (enable) {
            String s = getEnableIdentityConstraintsStatement(entity);
            if (!StringUtils.isNullOrEmpty(s)) {
                connection.executeNonQuery(s, null, null);
            }
        } else {
            String s = getDisableIdentityConstraintsStatement(entity);
            if (!StringUtils.isNullOrEmpty(s)) {
                connection.executeNonQuery(s, null, null);
            }
        }
    }

    //    @Override
    public String getDisableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    //    @Override
    public String getEnableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    //    @Override
    public String getDropRelationshipStatement(Relationship relation) throws UPAException {
        StringBuilder sb = new StringBuilder();
        Entity table = relation.getSourceRole().getEntity();
        sb.append("Alter Table ").append(getValidIdentifier(getTableName(table))).append(" Drop Constraint ").append(getValidIdentifier(getRelationshipName(relation)));
        return (sb.toString());
    }

    //    @Override
    public String getDropTablePKConstraintStatement(Entity entity) throws UPAException {
        StringBuilder sb = new StringBuilder();
        if (!entity.getShield().isTransient()) {
            List<Field> pk = entity.getFields(FieldFilters.id());
            if (pk.size() > 0) {
                sb.append("Alter Table ").append(getValidIdentifier(getTableName(entity))).append(" Drop Constraint ").append(getValidIdentifier(getTablePKName(entity)));
                return (sb.toString());
            }
        }
        return null;
    }

    public String getDropIndexStatement(Index index) throws UPAException {
        StringBuilder sb = new StringBuilder("Drop");
        sb.append(" Index ");
        sb.append(getValidIdentifier(getIndexName(index)));
        return sb.toString();
    }

    //    @Override
    public String getCreateIndexStatement(Index index) throws UPAException {
        StringBuilder sb = new StringBuilder("Create");
        if (index.isUnique()) {
            sb.append(" Clustered");
        } else {
            sb.append(" NonClustered");
        }
        sb.append(" Index ");
        sb.append(getValidIdentifier(getIndexName(index)));
        sb.append(" On ");
        sb.append(getValidIdentifier(getTableName(index.getEntity())));
        sb.append("(");
        boolean first = true;
        List<PrimitiveField> primitiveFields = index.getEntity().getPrimitiveFields(
                FieldFilters.regular().and(FieldFilters.byList(index.getFields())));
        for (PrimitiveField field : primitiveFields) {
            if (first) {
                first = false;
            } else {
                sb.append(", ");
            }
            sb.append(getColumnName(field));
        }
        sb.append(")");
        return (sb.toString());
    }

    //    public String getCreateTableStatement(Table entity) {
//        StringBuffer sb = new StringBuffer();
//        if (!entity.isTransientTable()) {
//            sb.append("CREATE TABLE ").append(entity.getPersistenceName()).append('(').append("\n").append("\t");
//            Field[] keys = entity.getFields(FieldFilters.PERSISTENT);
//            boolean firstElement = true;
//            for (int j = 0; j < keys.length; j++) {
//                if (firstElement)
//                    firstElement = false;
//                else
//                    sb.append(",").append("\n").append("\t");
//                sb.append(getFieldDeclaration(keys[j]));
//            }
//
//            Field[] pk = entity.getPrimaryFields();
//            if (pk.length > 0) {
//                if (firstElement)
//                    firstElement = false;
//                else
//                    sb.append(",").append("\n").append("\t");
//                sb.append("defineId KEY (");
//                for (int i = 0; i < pk.length; i++) {
//                    if (i > 0)
//                        sb.append(',');
//                    sb.append(pk[i].getName());
//                }
//
//                sb.append(')');
//            }
////            if (getProperties().get("isReferencingSupported", true)) {
////                Collection rel = database.getRelationsForDetail(entity);
////                for (Iterator e = rel.iterator(); e.hasNext();) {
////                    Relationship r = (Relationship) e.next();
////                    Field f = r.getSourceRole().getFields()[0];
////                    if (!f.isTransient() && !f.isFormula()) {
////                        if (firstElement)
////                            firstElement = false;
////                        else
////                            sb.append(",").append("\n").append("\t");
////                        sb.append("defineForeign KEY (");
////                        for (int i = 0; i < r.getSourceRole().getFields().length; i++) {
////                            if (i > 0)
////                                sb.append(',');
////                            sb.append(r.getSourceRole().getFields()[i].getName());
////                        }
////
////                        sb.append(") REFERENCES ").append(r.getMasterTable().getPersistenceName());
////                    }
////                }
////
////            }
//            sb.append("\n").append(')');
//            return sb.toString();
//        }
//        return null;
//    }
//    @Override
    private void fillPrimitiveField(Field f, List<PrimitiveField> list) {
        if (f instanceof PrimitiveField) {
            PrimitiveField pf = (PrimitiveField) f;
            DataType d = pf.getDataType();
            if (d instanceof ManyToOneType) {
                ManyToOneType rd = (ManyToOneType) d;
                for (Field field : rd.getRelationship().getSourceRole().getFields()) {
                    fillPrimitiveField(field, list);
                }
            } else {
                list.add(pf);
            }
        } else if (f instanceof CompoundField) {
            CompoundField c = (CompoundField) f;
            for (PrimitiveField t : c.getFields()) {
                fillPrimitiveField(t, list);
            }
        }
    }

    public ColumnDesc loadColumnDesc(PrimitiveField field, Connection connection) throws UPAException {
        ColumnDesc c = new ColumnDesc();
        String tableName = null;
        String columnName = null;
        try {
            /**
             * @PortabilityHint(target = "C#", name = "todo")
             */
            {
                ResultSet rs = null;
                try {
                    tableName = getPersistenceName(field.getEntity());
                    columnName = getPersistenceName(field);
//                    Connection connection = getConnection().getNativeConnection();
                    String catalog = connection.getCatalog();
                    String schema = connection.getSchema();
                    rs = connection.getMetaData().getColumns(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName), getIdentifierStoreTranslator().translateIdentifier(columnName));
                    if (rs.next()) {
                        c.setCatalogName(rs.getString("TABLE_CAT"));
                        c.setSchemaName(rs.getString("TABLE_SCHEM"));
                        c.setTableName(rs.getString("TABLE_NAME"));
                        c.setColumnName(rs.getString("COLUMN_NAME"));
                        c.setDefaultExpression(rs.getString("COLUMN_DEF"));
                        c.setSqlTypeCode(rs.getInt("DATA_TYPE"));
                        c.setSqlTypeName(rs.getString("TYPE_NAME"));
                        c.setColumnSize(rs.getInt("COLUMN_SIZE"));
                        c.setDecimalDigits(rs.getInt("DECIMAL_DIGITS"));
                        c.setAutoIncrement(yesNoToBoolean(rs.getString("IS_AUTOINCREMENT")));
                        c.setGenerated(yesNoToBoolean(rs.getString("IS_GENERATEDCOLUMN")));
                        switch (rs.getInt("NULLABLE")) {
                            case DatabaseMetaData.columnNoNulls: {
                                c.setNullable(false);
                                break;
                            }
                            case DatabaseMetaData.columnNullable: {
                                c.setNullable(true);
                                break;
                            }
                        }
                    }
                } finally {
                    if (rs != null) {
                        rs.close();
                    }
                }
            }
            return c;
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToLoadColumnDesc", "Column " + tableName + "." + columnName);
        }
    }

    private Boolean yesNoToBoolean(String s) {
        if (s == null) {
            return null;
        }
        if ("yes".equalsIgnoreCase(s) || "y".equalsIgnoreCase(s) || "true".equalsIgnoreCase(s)) {
            return true;
        }
        if ("no".equalsIgnoreCase(s) || "n".equalsIgnoreCase(s) || "false".equalsIgnoreCase(s)) {
            return false;
        }
        return null;
    }

    public String getAlterTableAlterColumnNullStatement(PrimitiveField field, boolean nullable) throws UPAException {
        StringBuilder sb = new StringBuilder();
        sb.append("Alter Table ").append(getValidIdentifier(getTableName(field.getEntity())))
                .append(" Alter Column ").append(getValidIdentifier(getColumnName(field)))
                .append(nullable ? " NULL" : " NOT NULL");
        return sb.toString();
    }

    public String getCreateTablePKConstraintStatement(Entity entityManager) throws UPAException {
        StringBuilder sb = new StringBuilder();
        if (!entityManager.getShield().isTransient()) {
            List<PrimitiveField> pk = new ArrayList<PrimitiveField>();
            for (PrimitiveField primitiveField : entityManager.getPrimitiveFields(FieldFilters.id())) {
                fillPrimitiveField(primitiveField, pk);
            }
            if (pk.size() > 0) {
                sb.append("Alter Table ").append(getValidIdentifier(getTableName(entityManager))).append(" Add Constraint ").append(getValidIdentifier(getTablePKName(entityManager))).append(" Primary Key (");
                boolean first = true;
                for (PrimitiveField primitiveField : pk) {
                    if (first) {
                        first = !first;
                    } else {
                        sb.append(',');
                    }
                    sb.append(getValidIdentifier(getColumnName(primitiveField)));
                }
                sb.append(')');
                return (sb.toString());
            }
        }
        return null;
    }

    public String getAlterTableAddColumnStatement(PrimitiveField field, EntityExecutionContext context) throws UPAException {
        StringBuilder s = new StringBuilder("Alter Table ")
                .append(getTableName(field.getEntity()))
                .append(" Add Column ")
                .append(getFieldDeclaration(field, context));
        return s.toString();
    }

    //    @Override
    public String getCreateTableStatement(Entity entity, EntityExecutionContext context) throws UPAException {
        StringBuilder sb = new StringBuilder();
        if (!entity.getShield().isTransient()) {
            sb.append("Create Table ").append(getValidIdentifier(getTableName(entity))).append('(').append("\n").append("\t");
            List<PrimitiveField> keys = entity.getPrimitiveFields(FieldFilters.byModifiersNoneOf(FieldModifier.TRANSIENT));
            boolean firstElement = true;
            for (PrimitiveField key : keys) {
                if (key.getModifiers().contains(FieldModifier.SELECT_LIVE)) {
                    //live fields are not stored
                } else if ((key.getDataType() instanceof ManyToOneType)) {
                    //relation 'object' fields are not stored
                } else {
                    if (firstElement) {
                        firstElement = false;
                    } else {
                        sb.append(",").append("\n").append("\t");
                    }
                    sb.append(getFieldDeclaration(key, context));
                }
            }

            sb.append("\n").append(')');
            return (sb.toString());
        }
        return null;
    }

    @Override
    public Query createQuery(Entity entity, EntityStatement query, EntityExecutionContext executionContext) throws UPAException {
        DefaultQuery q = new DefaultQuery(query, entity, executionContext);
        configureQuery(q, executionContext);
        return q;
    }

    @Override
    public Query createQuery(EntityStatement query, EntityExecutionContext executionContext) throws UPAException {
        DefaultQuery q = new DefaultQuery(query, null, executionContext);
        configureQuery(q, executionContext);
        return q;
    }

    protected void configureQuery(Query q, EntityExecutionContext executionContext) {
        boolean lazyListLoadingEnabled = executionContext.getPersistenceUnit().getProperties().getBoolean("Query.LazyListLoadingEnabled", true);
        q.setLazyListLoadingEnabled(lazyListLoadingEnabled);
    }

//    @Override
//    public int executeNonQuery(NonQueryStatement query, EntityExecutionContext executionContext) throws UPAException {
//        if (query instanceof Delete) {
//            return executeDelete((Delete) query, executionContext);
//        } else if (query instanceof InsertSelection) {
//            return executeInsertSelection((InsertSelection) query, executionContext);
//        } else if (query instanceof Update) {
//            return executeUpdate((Update) query, executionContext);
//        } else if (query instanceof Insert) {
//            return executeInsert((Insert) query, executionContext);
//        }
//        return defaultExecuteNonQuery(query, executionContext);
//    }

//    public int executeUpdate(Update query, EntityExecutionContext executionContext) throws UPAException {
//        if (isUpdateComplexValuesIncludingUpdatedTableSupported) {
//            return defaultExecuteNonQuery(query, executionContext);
//        } else {
//            PersistenceUnit pu = executionContext.getPersistenceUnit();
//            Entity entity = pu.getEntity(query.getEntityName());
//            final String entityName = entity.getName();
//            List<VarVal> complexVals = new ArrayList<VarVal>();
//            for (int i = query.countFields() - 1; i >= 0; i--) {
//                VarVal varVal = query.getVarVal(i);
//                Field field = entity.getField(varVal.getVar().getName());
//
//                String complexSelectKey = COMPLEX_SELECT_MERGE;
////                String complexSelectString = field.getProperties().getString(complexSelectKey, null);
//                boolean complexSelect = false;
////                if (complexSelectString == null) {
//                Expression fieldExpression = varVal.getVal();
//                if (null != fieldExpression.findOne(new ComplexUpdateExpressionFilter(entityName, isUpdateComplexValuesStatementSupported))) {
//                    complexSelect = true;
//                }
////                    field.getProperties().setString(complexSelectKey, String.valueOf(complexSelect));
////                } else {
////                    complexSelect = Boolean.valueOf(complexSelectString);
////                }
//                if (complexSelect) {
//                    //complex expression
//                    complexVals.add(varVal);
//                    query.removeFieldAt(i);
//                }
//            }
//            int c1 = 0;
//            int c2 = 0;
//            if (query.countFields() > 0) {
//                c1 = defaultExecuteNonQuery(query, executionContext);
//            }
//            if (complexVals.size() > 0) {
//                Select q = new Select();
//                for (Field primaryField : entity.getPrimaryFields()) {
//                    q.field(primaryField.getName());
//                }
//                String oldAlias = query.getEntityAlias();
//                if (oldAlias == null) {
//                    oldAlias = entity.getName();
//                }
//                boolean replaceThis = !"this".equals(oldAlias);
//                for (VarVal f : complexVals) {
//                    Expression fieldExpression = f.getVal();
//                    if (replaceThis) {
//                        UQLUtils.replaceThisVar(fieldExpression, oldAlias, executionContext.getPersistenceUnit());
//                    }
//                    q.field(fieldExpression, f.getVar().getName());
//                }
//                q.from(entity.getName(), oldAlias);
//                Expression cond = query.getCondition();
//                q.setWhere(cond == null ? null : cond.copy());
//
//                EntityBuilder eb = entity.getBuilder();
//
//                for (Record record : entity.getPersistenceUnit().createQuery(q).getRecordList()) {
//                    Update u2 = new Update();
//                    u2.entity(entityName);
//                    for (VarVal f : complexVals) {
//                        String fname = f.getVar().getName();
//                        u2.set(fname, record.getObject(fname));
//                    }
//                    Expression exprId = eb.objectToIdExpression(record, oldAlias);
//                    u2.where(exprId);
//                    c2 += defaultExecuteNonQuery(u2, executionContext);
//                }
//            }
//            return Math.max(c1, c2);
//        }
//    }
//
//    public int executeInsert(Insert query, EntityExecutionContext executionContext) throws UPAException {
//        return defaultExecuteNonQuery(query, executionContext);
//    }
//
//    public int executeInsertSelection(InsertSelection query, EntityExecutionContext executionContext) throws UPAException {
//        return defaultExecuteNonQuery(query, executionContext);
//    }
//
//    public int executeDelete(Delete query, EntityExecutionContext executionContext) throws UPAException {
//        return defaultExecuteNonQuery(query, executionContext);
//    }
//
//    public int defaultExecuteNonQuery(NonQueryStatement query, EntityExecutionContext executionContext) throws UPAException {
//        requireTransaction(executionContext);
//        QueryExecutor queryExecutor = createExecutor(query, null, executionContext);
//        queryExecutor.execute();
//        return queryExecutor.getResultCount();
//    }

    @Override
    public void createStructure(PersistenceUnit persistenceUnit, EntityExecutionContext executionContext) throws UPAException {
        QueryScript script = new QueryScript();
        List<Entity> entities = persistenceUnit.getEntities();
        List<Entity> queries = new ArrayList<Entity>();
        List<Entity> unions = new ArrayList<Entity>();
        List<Entity> updatableQueries = new ArrayList<Entity>();
        List<Entity> viewForEntities = new ArrayList<Entity>();
        for (Entity entity : entities) {
            if (entity.getExtensionDefinitions(FilterEntityExtensionDefinition.class).size() > 0) {
                updatableQueries.add(entity);
            } else if (entity.getExtensionDefinitions(ViewEntityExtensionDefinition.class).size() > 0) {
                queries.add(entity);
            } else if (entity.getExtensionDefinitions(UnionEntityExtensionDefinition.class).size() > 0) {
                unions.add(entity);
            } else {
                script.addStatement(getCreateTableStatement(entity, executionContext));
                if (entity.needsView()) {
                    viewForEntities.add(entity);
                }
                List<Index> indexes = entity.getIndexes(null);
                for (Index index : indexes) {
                    script.addStatement(getCreateIndexStatement(index));
                }
            }
        }
        for (Entity entity : entities) {
            script.addStatement(getCreateTablePKConstraintStatement(entity));
        }
        if (isReferencingSupported()) {
            for (Relationship relation : persistenceUnit.getRelationships()) {
                script.addStatement(getCreateRelationshipStatement(relation));
            }
        }
        if (isViewSupported()) {
            for (Entity entity : viewForEntities) {
                script.addStatement(getCreateImplicitViewStatement(entity, executionContext));
            }
            for (Entity entity : updatableQueries) {
                //not yet supported
            }
            for (Entity entity : queries) {
                ViewEntityExtension specSupport = (ViewEntityExtension) entity.getExtension(ViewEntityExtension.class);
                script.addStatement(getCreateViewStatement(entity, specSupport.getQuery(), executionContext));
            }
            for (Entity entity : unions) {
                UnionEntityExtension specSupport = (UnionEntityExtension) entity.getExtension(UnionEntityExtension.class);
                script.addStatement(getCreateViewStatement(entity, specSupport.getQuery(), executionContext));
            }
        }
        executionContext.getConnection().executeScript(script, true);
    }

    protected QueryScript getCreateRelationshipsScript(PersistenceUnit persistenceUnit) throws UPAException {
        QueryScript script = new QueryScript();
        for (Relationship relation : persistenceUnit.getRelationships()) {
            if (!relation.isTransient()) {
                script.addStatement(getCreateRelationshipStatement(relation));
            }
        }
        return script;
    }

    protected QueryScript getDisableConstraintsScript(PersistenceUnit persistenceUnit) throws UPAException {
        QueryScript script = new QueryScript();
//        QueryScript disableConstraintsScript = getDisableConstraintsScript();
//        if (disableConstraintsScript != null) {
//            script.addScript(disableConstraintsScript);
//        }
        QueryScript dropRelationsScript = getDropRelationshipsScript(persistenceUnit);
        if (dropRelationsScript != null) {
            script.addScript(dropRelationsScript);
        }
//        Script disableIdentityConstraintsScript = getDisableIdentityConstraintsScript();
//        if (disableIdentityConstraintsScript != null) {
//            script.addScript(disableIdentityConstraintsScript);
//        }
        return script;
    }

    protected QueryScript getEnableConstraintsScript(PersistenceUnit persistenceUnit) throws UPAException {
        QueryScript script = new QueryScript();
//        QueryScript enableIdentityConstraintsScript = getEnableIdentityConstraintsScript(database);
//        if (enableIdentityConstraintsScript != null) {
//            script.addScript(enableIdentityConstraintsScript);
//        }
        QueryScript createRelationsScript = getCreateRelationshipsScript(persistenceUnit);
        if (createRelationsScript != null) {
            script.addScript(createRelationsScript);
        }
//        QueryScript enableConstraintsScript = getEnableConstraintsScript();
//        if (enableConstraintsScript != null) {
//            script.addScript(enableConstraintsScript);
//        }
        return script;
    }

    //    @Override
    public QueryScript getDropRelationshipsScript(PersistenceUnit persistenceUnit) throws UPAException {
        QueryScript script = new QueryScript();
        for (Relationship relation : persistenceUnit.getRelationships()) {
            if (!relation.isTransient()) {
                Entity table = relation.getSourceRole().getEntity();
                if (!isView(table)) {
                    script.addStatement(getDropRelationshipStatement(relation));
                }
            }
        }
        return script;
    }

    //    //    @Override
//    public QueryScript getEnableIdentityConstraintsScript(PersistenceUnitFilter database) {
//        QueryScript script = new QueryScript();
//        for (Entity entity : database.getEntities()) {
//            if (entity.isAutoIncrement()) {
//                script.addStatement(getEnableIdentityConstraintsStatement(entity));
//            }
//        }
//        return script;
//    }
    protected void requireTransaction(EntityExecutionContext executionContext) throws UPAException {
        Session currentSession = executionContext.getPersistenceUnit().getCurrentSession();
        if (currentSession != null) {
            Transaction transaction = currentSession.getParam(executionContext.getPersistenceUnit(), Transaction.class, SessionParams.TRANSACTION, null);
            if (transaction != null) {
                return;
            }
        }
        throw new TransactionException(new I18NString("TransactionMandatoryException"));
    }

    public String getEntityNameFromImplicitViewName(String viewName) {
        return viewName.substring(3);
    }

    public boolean isImplicitViewName(String s) {
        return s.startsWith("_V_");
    }

    public boolean isReservedKeyword(String name) {
        return reservedWords.contains(name.toUpperCase());
    }

    protected Set<String> getCustomReservedKeywords() {
        return null;
    }

    @Override
    public void setNativeConstraintsEnabled(PersistenceUnit persistenceUnit, boolean enable) throws UPAException {
        if (enable) {
            persistenceUnit.getConnection().executeScript(getEnableConstraintsScript(persistenceUnit), false);
        } else {
            persistenceUnit.getConnection().executeScript(getDisableConstraintsScript(persistenceUnit), false);
        }
    }

    public boolean isReadOnly() {
        return readOnly;
    }

    public void setReadOnly(boolean readOnly) {
        this.readOnly = readOnly;
    }

    @Override
    public String getPersistenceName(UPAObject persistentObject) throws UPAException {
        return getPersistenceName(new UPAObjectAndSpec(persistentObject, null));
    }

    @Override
    public String getPersistenceName(UPAObject persistentObject, PersistenceNameType spec) throws UPAException {
        return getPersistenceName(new UPAObjectAndSpec(persistentObject, spec));
    }

    @Override
    public String getPersistenceName(String name, PersistenceNameType spec) throws UPAException {
        return getPersistenceName(new UPAObjectAndSpec(name, spec));
    }

    protected String getPersistenceName(UPAObjectAndSpec e) throws UPAException {
        String persistenceName = persistenceNamesMap.get(e);
        if (persistenceName == null) {
            Object object = e.getObject();
            persistenceName = persistenceNameStrategy.getPersistenceName(object, e.getSpec());
            persistenceNamesMap.put(e, persistenceName);
        }
        return persistenceName;
    }

    public PersistenceNameStrategy getPersistenceNameStrategy() {
        return persistenceNameStrategy;
    }

    public void setPersistenceNameStrategy(PersistenceNameStrategy persistenceNameStrategy) {
        if (this.persistenceNameStrategy != null) {
            this.persistenceNameStrategy.close();
        }
        this.persistenceNameStrategy = persistenceNameStrategy;
        if (this.persistenceNameStrategy != null) {
            this.persistenceNameStrategy.init(this, nameConfig);
        }
    }

    public String getTablePKName(Entity o) throws UPAException {
        return getPersistenceName(o, PersistenceNameType.PK_CONSTRAINT);
    }

    public String getTableName(Entity o) throws UPAException {
        return getPersistenceName(o);
    }

    public String getRelationshipName(Relationship o) throws UPAException {
        return getPersistenceName(o);
    }

    public String getIndexName(Index o) throws UPAException {
        return getPersistenceName(o);
    }

    public String getColumnName(Field o) throws UPAException {
        return getPersistenceName(o);
    }

    public String getImplicitViewName(Entity o) throws UPAException {
        return getPersistenceName(o, PersistenceNameType.IMPLICIT_VIEW);
    }

    public boolean isView(Entity entity) {
        if (entity.getExtensionDefinitions(FilterEntityExtensionDefinition.class).size() > 0) {
            return true;
        } else if (entity.getExtensionDefinitions(ViewEntityExtensionDefinition.class).size() > 0) {
            return true;
        } else if (entity.getExtensionDefinitions(UnionEntityExtensionDefinition.class).size() > 0) {
            return true;
        }
        return false;
    }

    @Override
    public void alterPersistenceUnitAddObject(UPAObject object) throws UPAException {
        commitManager.alterPersistenceUnitAddObject(object);
    }

    @Override
    public void alterPersistenceUnitRemoveObject(UPAObject object) throws UPAException {
        throw new IllegalArgumentException("No supported");
//        StructureStrategy option = persistenceManager.getConnectionProfile().getStructureStrategy();
//        switch (option) {
//            case DROP:
//            case CREATE:
//            case MANDATORY:
//            case IGNORE:
//            {
//                //do noting
//                break;
//            }
//            case SYNCHRONIZE: {
//                switch (persistenceManager.getPersistenceState(object, persistentObjectType)){
//                    case UNKNOWN:{
//                        persistenceManager.alterPersistenceUnitRemoveObject(object);
//                        object.getParameters().setString("persistence.PersistenceAction", "REMOVE");
//                        break;
//                    }
//                    case VALID:{
//                        //do nothing
//                        break;
//                    }
//                    case DIRTY:{
//                        persistenceManager.alterPersistenceUnitRemoveObject(object);
//                        object.getParameters().setString("persistence.PersistenceAction", "REMOVE");
//                        break;
//                    }
//                    case TRANSIENT:{
//                        // do nothing
//                        break;
//                    }
//                }
//                break;
//            }
//        }
    }

    @Override
    public void alterPersistenceUnitUpdateObject(UPAObject oldObject, UPAObject newObject, Set<String> updates) throws UPAException {
        throw new IllegalArgumentException("No supported");
//        StructureStrategy option = persistenceManager.getConnectionProfile().getStructureStrategy();
//        switch (option) {
//            case DROP:
//            case MANDATORY:
//            case IGNORE:
//            {
//                //do noting
//                break;
//            }
//            case CREATE:{
//                switch (persistenceManager.getPersistenceState(object, persistentObjectType)){
//                    case UNKNOWN:{
//                        persistenceManager.alterPersistenceUnitAddObject(object);
//                        object.getParameters().setString("persistence.PersistenceAction", "ADD");
//                        break;
//                    }
//                    case VALID:{
//                        //do nothing
//                        break;
//                    }
//                    case DIRTY:{
//                        throw new UPAException(new I18NString("DirtyObject"),object);
//                    }
//                    case TRANSIENT:{
//                        // do nothing
//                        break;
//                    }
//                }
//                break;
//            }
//            case SYNCHRONIZE: {
//                switch (persistenceManager.getPersistenceState(object, persistentObjectType)){
//                    case UNKNOWN:{
//                        persistenceManager.alterPersistenceUnitAddObject(object);
//                        object.getParameters().setString("persistence.PersistenceAction", "ADD");
//                        break;
//                    }
//                    case VALID:{
//                        //do nothing
//                        break;
//                    }
//                    case DIRTY:{
//                        persistenceManager.alterPersistenceUnitUpdateObject(old,object,updates);
//                        object.getParameters().setString("persistence.PersistenceAction", "UPDATE");
//                        break;
//                    }
//                    case TRANSIENT:{
//                        // do nothing
//                        break;
//                    }
//                }
//                break;
//            }
//        }
    }

    @Override
    public boolean commitStorage() throws UPAException {
        return commitManager.commitStructure();
    }

    @Override
    public PersistenceState getPersistenceState(UPAObject object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext) throws UPAException {
        return getPersistenceState(object, spec, entityExecutionContext, entityExecutionContext.getConnection().getMetadataAccessibleConnection());
    }

    private PersistenceState getPersistenceState(UPAObject object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        if (object instanceof Entity) {
            return getEntityPersistenceState((Entity) object, spec, entityExecutionContext, connection);
        }
        if (object instanceof Field) {
            return getFieldPersistenceState((Field) object, spec, entityExecutionContext, connection);
        }
        if (object instanceof Relationship) {
            return getRelationshipPersistenceState((Relationship) object, spec, entityExecutionContext, connection);
        }
        if (object instanceof Index) {
            return getIndexPersistenceState((Index) object, spec, entityExecutionContext, connection);
        }
        throw new IllegalArgumentException("Unknown type " + object);
        //log.log(Level.FINE,"getPersistenceState " + object + " " + PersistenceState.TRANSIENT);
        //return PersistenceState.TRANSIENT;
    }

    public PersistenceState getEntityPersistenceState(Entity object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        String persistenceName = getPersistenceName(object, spec);
        if (spec == null) {
            PersistenceState persistenceState = PersistenceState.UNKNOWN;
            if (tableExists(persistenceName, entityExecutionContext)) {
                persistenceState = PersistenceState.VALID;
            }
            //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
            return persistenceState;
        } else if (PersistenceNameType.IMPLICIT_VIEW.equals(spec)) {
            PersistenceState persistenceState = PersistenceState.UNKNOWN;
            if (viewExists(persistenceName, entityExecutionContext)) {
                persistenceState = PersistenceState.VALID;
            }
            //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
            return persistenceState;
        } else if (PersistenceNameType.PK_CONSTRAINT.equals(spec)) {
            PersistenceState persistenceState = PersistenceState.UNKNOWN;
            if (pkConstraintsExists(getPersistenceName(object, null), persistenceName, entityExecutionContext)) {
                persistenceState = PersistenceState.VALID;
            }
            return persistenceState;
        } else {
            throw new IllegalArgumentException("Unknown Spec for Entity : " + spec);
        }
    }

    public PersistenceState getIndexPersistenceState(Index object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        if (spec == null) {
            ResultSet rs = null;
            PersistenceState status = PersistenceState.UNKNOWN;
            String indexName = getPersistenceName(object, spec);
            String tableName = getPersistenceName(object.getEntity(), null);
            boolean unique = object.isUnique();
            {
                try {
                    /**
                     * @PortabilityHint(target = "C#", name = "todo")
                     * System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                     * System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, indexName});
                     * return (found.Rows.Count != 0)?Net.Vpc.Upa.PersistenceState.VALID:Net.Vpc.Upa.PersistenceState.DIRTY;
                     */
                    try {
//                    Connection connection = getConnection().getNativeConnection();
                        String catalog = connection.getCatalog();
                        String schema = connection.getSchema();
                        rs = connection.getMetaData().getIndexInfo(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName), false, true);
                        while (rs.next()) {
                            String n = rs.getString("INDEX_NAME");
                            boolean u = !rs.getBoolean("NON_UNIQUE");
                            if (getIdentifierStoreTranslator().translateIdentifier(indexName).equals(n)) {
                                if (u != unique) {
                                    log.log(Level.SEVERE, "Index {0} found but its unicity is invalid (expected={1})", new Object[]{indexName, unique});
                                    status = PersistenceState.DIRTY;
                                } else {
                                    status = PersistenceState.VALID;
                                }
                                break;
                            }
                        }
                    } finally {
                        if (rs != null) {
                            rs.close();
                        }
                    }
                } catch (SQLException ex) {
                    throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Index " + tableName + "." + indexName);
                }
            }
            //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
            return status;
        } else {
            throw new IllegalArgumentException("Unknown Spec for Entity : " + spec);
        }
    }

    public PersistenceState getFieldPersistenceState(Field object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        PersistenceState status = PersistenceState.UNKNOWN;
        FlagSet<FieldModifier> fieldModifiers = object.getModifiers();
        if ((object.getDataType() instanceof ManyToOneType)) {
//            status = PersistenceState.VALID;
            status = PersistenceState.TRANSIENT;
        } else if (fieldModifiers.contains(FieldModifier.TRANSIENT)) {
            status = PersistenceState.TRANSIENT;
        } else {
            String tableName = getPersistenceName(object.getEntity());
            String columnName = getPersistenceName(object);
            status = PersistenceState.UNKNOWN;
            /**
             * @PortabilityHint(target = "C#", name = "todo")
             */
            try {
                ResultSet rs = null;
                try {
//                    Connection connection = getConnection().getNativeConnection();
                    String catalog = connection.getCatalog();
                    String schema = connection.getSchema();
                    rs = connection.getMetaData().getColumns(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName), getIdentifierStoreTranslator().translateIdentifier(columnName));
                    if (rs.next()) {
                        String COLUMN_NAME = rs.getString("COLUMN_NAME");
                        int DATA_TYPE = rs.getInt("DATA_TYPE");
                        //TODO, check datatype and constraints
                        status = PersistenceState.VALID;
                    }
                } finally {
                    if (rs != null) {
                        rs.close();
                    }
                }
            } catch (SQLException ex) {
                throw createUPAException(ex, "UnableToGetEntityStorageStatus", "Column " + tableName + "." + columnName);
            }
        }
        if (status != PersistenceState.VALID && status != PersistenceState.TRANSIENT) {
            log.log(Level.FINE, "FieldStorageStatus {0} {1}", new Object[]{object, status});
        }
        return status;
    }

    public PersistenceState getRelationshipPersistenceState(Relationship object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        PersistenceState status = PersistenceState.UNKNOWN;
        if (isView(object.getTargetRole().getEntity()) || isView(object.getSourceRole().getEntity())) {
            status = PersistenceState.TRANSIENT;
        } else {
            String tablePersistenceName = getPersistenceName(object.getSourceRole().getEntity());
            String persistenceName = getPersistenceName(object);
            if (foreignKeyExists(tablePersistenceName, persistenceName, entityExecutionContext)) {
                status = PersistenceState.VALID;
            }
        }
        if (status != PersistenceState.VALID) {
            log.log(Level.FINE, "getRelationPersistenceState {0} {1}", new Object[]{object, status});
        }
        return status;
    }

    protected UPAException createUPAException(SQLException ex, String mgId, Object... parameters) {
        return new UPAException(ex, new I18NString(mgId), parameters);
    }

    public void revalidateModel() throws UPAException {
    }

    public final SQLManager getSqlManager() {
        return sqlManager;
    }

    public IdentifierStoreTranslator createIdentifierStoreTranslator(UConnection connection) throws SQLException {
        /**
         *  @PortabilityHint(target = "C#", name = "todo")
         */
        {
            DatabaseMetaData m = connection.getMetadataAccessibleConnection().getMetaData();
            if (m.storesMixedCaseIdentifiers()) {
                return IdentifierStoreTranslators.MIXED;
            }
            if (m.storesUpperCaseIdentifiers()) {
                return IdentifierStoreTranslators.UPPER;
            }
            if (m.storesLowerCaseIdentifiers()) {
                return IdentifierStoreTranslators.LOWER;
            }
        }
        return IdentifierStoreTranslators.UPPER;
    }

    protected boolean tableExists(String persistenceName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             *        System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
             *        if (connection is System.Data.Common.DbConnection)
             *        {
             *          System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
             *          System.Data.DataTable found = dconnection.GetSchema("Tables", new string[] { null, null, persistenceName, "BASE TYPE" });
             *          return (found.Rows.Count != 0);
             *        }
             */
            try {
                Connection connection = entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                //connection.getMetaData().storesLowerCaseIdentifiers();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getTables(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(persistenceName), null);
                if (rs.next()) {
                    String n = rs.getString("TABLE_NAME");
                    String t = rs.getString("TYPE_NAME");
                    return true;
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceName);
        }
        return false;
    }

    public IdentifierStoreTranslator getIdentifierStoreTranslator() throws SQLException {
        return identifierStoreTranslator;
    }

    protected boolean viewExists(String persistenceName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             *  System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
             *  if (connection is System.Data.Common.DbConnection)
             *  {
             *    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
             *    System.Data.DataTable found = dconnection.GetSchema("Tables", new string[] { null, null, persistenceName, "VIEW" });
             *    return (found.Rows.Count != 0);
             *  }
             */
            try {
                Connection connection = entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getTables(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(persistenceName), null);
                if (rs.next()) {
                    String n = rs.getString("TABLE_NAME");
                    String t = rs.getString("TYPE_NAME");
                    return true;
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceName);
        }
        return false;
    }

    protected boolean pkConstraintsExists(String tableName, String constraintsName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
            System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
            if (connection is System.Data.Common.DbConnection)
            {
            System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
            System.Data.DataTable found = dconnection.GetSchema("IndexColumns", new string[] { connection.Database, null, tableName, constraintsName, null });
            return (found.Rows.Count != 0);
            }
             */
            try {
                Connection connection = entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getPrimaryKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                while (rs.next()) {
                    String n = rs.getString("PK_NAME");
                    String expectedName = getIdentifierStoreTranslator().translateIdentifier(constraintsName);
                    if (expectedName.equals(n)) {
                        return true;
                    } else {
                        log.log(Level.WARNING, "Found Conflicting PK Constraints " + n + " instead of " + expectedName);
                        return true;
                    }
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "PK Constraints " + tableName + "." + constraintsName);
        }
        return false;
    }

    protected boolean foreignKeyExists(String tableName, String constraintName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
            System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
            if (connection is System.Data.Common.DbConnection)
            {
            System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
            System.Data.DataTable found = dconnection.GetSchema("ForeignKeys", new string[] { connection.Database, null, tableName, constraintName });
            return (found.Rows.Count != 0);
            }
             */
            try {
                Connection connection = entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getImportedKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                while (rs.next()) {
                    String FK_NAME = rs.getString("FK_NAME");
                    if (getIdentifierStoreTranslator().translateIdentifier(constraintName).equals(FK_NAME)) {
                        return true;
                    }
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Column " + tableName + "." + constraintName);
        }
        return false;
    }

    public String getIdentifierQuoteString() throws UPAException {
        return identifierQuoteString;
    }

    public String getValidIdentifier(String s) throws UPAException {
        if (isReservedKeyword(s)) {
            String r = getIdentifierQuoteString();
            if (r != null) {
                return r + identifierStoreTranslator.translateIdentifier(s) + r;
            }
        }
        return s;
    }

    public boolean isAccessible(ConnectionProfile connectionProfile) {
        Connection c = null;
        try {
            c = createNativeConnection(connectionProfile);
            return true;
        } catch (Exception e) {
            return false;
        } finally {
            if (c != null) {
                try {
                    c.close();
                } catch (SQLException ex) {
                    log.log(Level.SEVERE, null, ex);
                }
            }
        }
    }

    public void checkAccessible(ConnectionProfile connectionProfile) {
        Connection c = null;
        try {
            c = createNativeConnection(connectionProfile);
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("StoreNotAccessibleException"), connectionProfile);
        } finally {
            if (c != null) {
                try {
                    c.close();
                } catch (SQLException ex) {
                    log.log(Level.SEVERE, null, ex);
                }
            }
        }
    }

    /**
     *
     *
     *
     protected internal virtual bool IndexExists(string tableName, string indexName,bool unique)
     {
     try
     {
     System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
     if (connection is System.Data.Common.DbConnection)
     {
     System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
     System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, indexName});
     return (found.Rows.Count != 0);
     }
     }
     catch (System.Exception ex)
     {
     throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + tableName);
     }
     return false;
     }

     protected internal virtual bool ColumnExists(string tableName, string columnName)
     {
     try
     {
     System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
     if (connection is System.Data.Common.DbConnection)
     {
     System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
     System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, columnName });
     return (found.Rows.Count != 0);
     }
     }
     catch (System.Exception ex)
     {
     throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + tableName);
     }
     return false;
     }     */
}
