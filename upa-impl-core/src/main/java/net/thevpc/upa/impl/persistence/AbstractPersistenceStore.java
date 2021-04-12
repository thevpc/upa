package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.*;
import net.thevpc.upa.Properties;
import net.thevpc.upa.exceptions.*;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.impl.upql.ext.expr.CompiledQueryField;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledQueryStatement;
import net.thevpc.upa.impl.upql.ext.expr.CompiledTypeName;
import net.thevpc.upa.types.*;

import net.thevpc.upa.config.PersistenceNameType;
import net.thevpc.upa.exceptions.*;
import net.thevpc.upa.expressions.*;
import net.thevpc.upa.filters.FieldFilter;
import net.thevpc.upa.filters.FieldFilters;
import net.thevpc.upa.impl.DefaultProperties;
import net.thevpc.upa.impl.SessionParams;
import net.thevpc.upa.impl.UPAImplKeys;
import net.thevpc.upa.impl.ext.PersistenceUnitExt;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.thevpc.upa.impl.persistence.connection.ConnectionProfileParser;
import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.upql.BindingId;
import net.thevpc.upa.impl.upql.DefaultExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.filters.TypeCompiledExpressionFilter;
import net.thevpc.upa.impl.upql.filters.ExpressionFilterFactory;
import net.thevpc.upa.impl.util.*;
import net.thevpc.upa.impl.util.filters.FieldFilters2;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.types.*;

import java.sql.*;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceColumn;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceForeignKey;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceIndex;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceNode;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistencePrimaryKey;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceTable;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceTree;
import net.thevpc.upa.impl.persistence.tree.NativeObjectPersistenceView;

//@PortabilityHint(target = "C#", name = "partial")
public abstract class AbstractPersistenceStore implements PersistenceStoreExt {

    public static final String PARAM_MAX_QUERY_COLUMN_COUNT = "maxQueryColumnsCount";
    public static final String PARAM_MAX_QUERY_JOIN_COUNT = "maxQueryJoinCount";
    public static final String PARAM_IS_COMPLEX_SELECT_SUPPORTED = "isComplexSelectSupported";
    public static final String PARAM_IS_UPDATE_COMPLEX_VALUES_STATEMENT_SUPPORTED = "isUpdateComplexValuesStatementSupported";
    public static final String PARAM_IS_UPDATE_COMPLEX_VALUES_INCLUDING_UPDATED_TABLE_SUPPORTED = "isUpdateComplexValuesIncludingUpdatedTableSupported";
    public static final String PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED = "isFromClauseInUpdateStatementSupported";
    public static final String PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED = "isFromClauseInDeleteStatementSupported";
    public static final String PARAM_IS_REFERENCING_SUPPORTED = "isReferencingSupported";
    public static final String PARAM_IS_VIEW_SUPPORTED = "isViewSupported";
    public static final String PARAM_IS_TOP_SUPPORTED = "isTopSupported";

    public static final String DRIVER_TYPE_EMBEDDED = "EMBEDDED";
    public static final String DRIVER_TYPE_DEFAULT = "DEFAULT";
    public static final String DRIVER_TYPE_DATASOURCE = "DATASOURCE";
    public static final String DRIVER_TYPE_GENERIC = "GENERIC";
    public static final String DRIVER_TYPE_ODBC = "ODBC";
    //    protected static final TypeMarshaller SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER = new DefaultSerializablePlatformObjectMarshaller();
    protected static final String COMPLEX_SELECT_PERSIST = "Store.COMPLEX_SELECT_PERSIST";
    protected static final String COMPLEX_SELECT_MERGE = "Store.COMPLEX_SELECT_MERGE";
    protected static Logger log = Logger.getLogger(AbstractPersistenceStore.class.getName());
    protected static HashSet<String> SQL2003_RESERVED_WORDS = new HashSet<String>(Arrays.asList(
            "ADD", "ALL", "ALLOCATE", "ALTER", "AND", "ANY", "ARE", "ARRAY", "AS", "ASENSITIVE", "ASYMMETRIC", "AT", "ATOMIC", "AUTHORIZATION", "BEGIN", "BETWEEN", "BIGINT", "BINARY", "BLOB", "BOOLEAN", "BOTH", "BY", "CALL", "CALLED", "CASCADED", "CASE", "CAST", "CHAR", "CHARACTER", "CHECK", "CLOB", "CLOSE", "COLLATE", "COLUMN", "COMMIT", "CONNECT", "CONSTRAINT", "CONTINUE", "CORRESPONDING", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_DATE", "CURRENT_DEFAULT_TRANSFORM_GROUP", "CURRENT_PATH", "CURRENT_ROLE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_TRANSFORM_GROUP_FOR_TYPE", "CURRENT_USER", "CURSOR", "CYCLE", "DATE", "DAY", "DEALLOCATE", "DEC", "DECIMAL", "DECLARE", "DEFAULT", "DELETE", "DEREF", "DESCRIBE", "DETERMINISTIC", "DISCONNECT", "DISTINCT", "DOUBLE", "DROP", "DYNAMIC", "EACH", "ELEMENT", "ELSE", "END", "END-EXEC", "ESCAPE", "EXCEPT", "EXEC", "EXECUTE", "EXISTS", "EXTERNAL", "FALSE", "FETCH", "FILTER", "FLOAT", "FOR", "FOREIGN", "FREE", "FROM", "FULL", "FUNCTION", "GET", "GLOBAL", "GRANT", "GROUP", "GROUPING", "HAVING", "HOLD", "HOUR", "IDENTITY", "IMMEDIATE", "IN", "INDICATOR", "INNER", "INOUT", "INPUT", "INSENSITIVE", "INSERT", "INT", "INTEGER", "INTERSECT", "INTERVAL", "INTO", "IS", "ISOLATION", "JOIN", "LANGUAGE", "LARGE", "LATERAL", "LEADING", "LEFT", "LIKE", "LOCAL", "LOCALTIME", "LOCALTIMESTAMP", "MATCH", "MEMBER", "MERGE", "METHOD", "MINUTE", "MODIFIES", "MODULE", "MONTH", "MULTISET", "NATIONAL", "NATURAL", "NCHAR", "NCLOB", "NEXT", "NEW", "NO", "NONE", "NOT", "NULL", "NUMERIC", "OF", "OLD", "ON", "ONLY", "OPEN", "OR", "ORDER", "OUT", "OUTER", "OUTPUT", "OVER", "OVERLAPS", "PARAMETER", "PARTITION", "PRECISION", "PREPARE", "PRIMARY", "PROCEDURE", "RANGE", "READS", "REAL", "RECURSIVE", "REF", "REFERENCES", "REFERENCING", "REGR_AVGX", "REGR_AVGY", "REGR_COUNT", "REGR_INTERCEPT", "REGR_R2", "REGR_SLOPE", "REGR_SXX", "REGR_SXY", "REGR_SYY", "RELEASE", "RESULT", "RETURN", "RETURNS", "REVOKE", "RIGHT", "ROLLBACK", "ROLLUP", "ROW", "ROWS", "SAVEPOINT", "SCROLL", "SEARCH", "SECOND", "SELECT", "SENSITIVE", "SESSION_USER", "SET", "SIMILAR", "SMALLINT", "SOME", "SPECIFIC", "SPECIFICTYPE", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "START", "STATIC", "SUBMULTISET", "SYMMETRIC", "SYSTEM", "SYSTEM_USER", "TABLE", "THEN", "TIME", "TIMESTAMP", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TRAILING", "TRANSLATION", "TREAT", "TRIGGER", "TRUE", "UESCAPE", "UNION", "UNIQUE", "UNKNOWN", "UNNEST", "UPDATE", "UPPER", "USER", "USING", "VALUE", "VALUES", "VAR_POP", "VAR_SAMP", "VARCHAR", "VARYING", "WHEN", "WHENEVER", "WHERE", "WIDTH_BUCKET", "WINDOW", "WITH", "WITHIN", "WITHOUT", "YEAR"));
    @PortabilityHint(target = "C#", name = "suppress")
    boolean isUpdateComplexValuesStatementSupported;
    boolean isUpdateComplexValuesIncludingUpdatedTableSupported;

    private boolean readOnly;
    private ObjectFactory factory;
    protected IdentifierStoreTranslator identifierStoreTranslator;

    private Map<UPAObjectAndSpec, String> persistenceNamesMap = new HashMap<UPAObjectAndSpec, String>();
    //    private DefaultPersistenceNameStrategyManager defaultPersistenceNameStrategyManager;
    //    private String name;
    private Properties parameters = new DefaultProperties();
    protected Properties properties = new DefaultProperties();
    private DefaultPersistenceUnitCommitManager commitManager = new DefaultPersistenceUnitCommitManager();
    //    public static final DataWrapperFactory F_LIST = new ListDataMarshallerFactory();
    private MarshallManager marshallManager;
    private SQLManager sqlManager;
    protected String identifierQuoteString;
    protected PersistenceUnit persistenceUnit;
    protected HashSet<String> reservedWords;
    private ConnectionProfile connectionProfile;
    protected DatabaseProduct databaseProduct;
    protected PersistenceNameStrategy persistenceNameStrategy;
    protected String databaseVersion;

    //should use a max sized accessibleStores for cache!
    protected Set<String> knownCreatedStores = new HashSet<>();

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
    public AbstractPersistenceStore() {

    }

    public AbstractPersistenceStore(DatabaseProduct databaseProduct) {
        this.databaseProduct = databaseProduct;
    }

    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        return 1;
    }

    @Override
    public void init(PersistenceUnit persistenceUnit, boolean readOnly, ConnectionProfile connectionProfile) throws UPAException {
        parameters = new DefaultProperties();
        marshallManager = new DefaultMarshallManager();
        sqlManager = new DefaultSQLManager(marshallManager);
        this.persistenceUnit = persistenceUnit;
        this.persistenceNameStrategy = persistenceUnit.getPersistenceNameStrategy();
        this.readOnly = readOnly;
        this.connectionProfile = connectionProfile;
        configureStore();
        commitManager.init(this);
    }

    public void configureStore() {
        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, false);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_STATEMENT_SUPPORTED, false);
        map.setBoolean(PARAM_IS_UPDATE_COMPLEX_VALUES_INCLUDING_UPDATED_TABLE_SUPPORTED, false);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, false);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, false);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, true);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, false);
        map.setBoolean(PARAM_IS_TOP_SUPPORTED, false);
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

    public boolean isComplexSelectSupported() {
        return getStoreParameters().getBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, false);
    }

    public boolean isFromClauseInUpdateStatementSupported() {
        return getStoreParameters().getBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, false);
    }

    public boolean isFromClauseInDeleteStatementSupported() {
        return getStoreParameters().getBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, false);
    }

    public boolean isReferencingSupported() {
        return getStoreParameters().getBoolean(PARAM_IS_REFERENCING_SUPPORTED, false);
    }

    public boolean isViewSupported() {
        return getStoreParameters().getBoolean(PARAM_IS_VIEW_SUPPORTED, false);
    }

    public boolean isTopSupported() {
        return getStoreParameters().getBoolean(PARAM_IS_TOP_SUPPORTED, false);
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
                executor.executeNonQuery("Create Database " + getConnectionProfile().getProperty(ConnectionOption.DATABASE_NAME), null, null);
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
                executor.executeNonQuery("Drop Database " + getConnectionProfile().getProperty(ConnectionOption.DATABASE_NAME), null, null);
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
        if (knownCreatedStores.contains(connectionProfile.toString())) {
            return true;
        }
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
    public Properties getStoreParameters() {
        return parameters;
    }

    @Override
    public Properties getProperties() {
        return properties;
    }

    @Override
    public void setProperties(Properties properties) {
        this.properties = properties;
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
    public UConnection wrapConnection(Connection connection) throws UPAException {
        if (persistenceUnit == null) {
            //this most likely in PU.start() -> checkAccessible, when PU is not yer initialized!
            return new DefaultUConnection("<undefined>", connection, getMarshallManager(), new DefaultProperties(), persistenceUnit);
        }
        return new DefaultUConnection(persistenceUnit.toString(), connection, getMarshallManager(), persistenceUnit.getProperties(), persistenceUnit);
    }

    protected void prepareNativeConnection(UConnection connection, Map<String, Object> customAttributes, ConnectionProfile connectionProfile) throws UPAException {
    }

    protected int getMaxQueryJoinCount() {
        return getStoreParameters().getInt(PARAM_MAX_QUERY_JOIN_COUNT, -1);
    }

    protected int getMaxQueryColumnsCount() {
        return getStoreParameters().getInt(PARAM_MAX_QUERY_COLUMN_COUNT, -1);
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
            if (null != fieldExpression.findOne(new ComplexUpdateExpressionFilter(entityName, isUpdateComplexValuesStatementSupported, isUpdateComplexValuesIncludingUpdatedTableSupported))) {
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

    private void applyParameters(EntityStatement statement, Map<String, Object> parametersByName, Map<Integer, Object> parametersByIndex) {
        //apply parameters
        if (parametersByName != null) {
            for (Map.Entry<String, Object> entry : parametersByName.entrySet()) {
                String name = entry.getKey();
                Object value = entry.getValue();

                List<Expression> params = statement.findAll(ExpressionFilterFactory.forParam(name));
                if (params.isEmpty()) {
                    throw new IllegalUPAArgumentException("Parameter not found " + name);
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
                    throw new IllegalUPAArgumentException("Parameter not found " + index);
                }
                Param p = (Param) params.get(index);
                if (p == null) {
                    throw new IllegalUPAArgumentException("Parameter not found " + index);
                }
                p.setValue(value);
                p.setUnspecified(false);
            }
        }
    }

    public QueryExecutor createDefaultExecutor(
            Expression baseExpression,
            Map<String, Object> parametersByName,
            Map<Integer, Object> parametersByIndex,
            boolean updatable,
            FieldFilter defaultFieldFilter, EntityExecutionContext context) throws UPAException {

        if (defaultFieldFilter == null) {
            defaultFieldFilter = FieldFilters2.READ;
        }
        ExpressionManager expressionManager = context.getPersistenceUnit().getExpressionManager();
        ResultMetaData m = expressionManager.createMetaData(baseExpression, defaultFieldFilter);
        EntityStatement statement = m.getStatement();
        applyParameters(statement, parametersByName, parametersByIndex);

        Map<String, Object> hints = context.getHints();
        if (hints == null) {
            hints = new HashMap<String, Object>();
        }

        int maxQueryJoinCount = getMaxQueryJoinCount();
        int maxQueryColumnsCount = getMaxQueryColumnsCount();
        ExpressionCompilerConfig config = new ExpressionCompilerConfig();
        config.setExpandFieldFilter(defaultFieldFilter);
        config.setHints(hints);
        config.setResolveThis(true);
//        config.setThisAlias(StringUtils.isNullOrEmpty(statement.getEntityAlias())? UQLUtils.THIS:statement.getEntityAlias());

        int maxJoins = UPAUtils.convertToInt(config.getHint(QueryHints.MAX_JOINS), -1);
        if (maxJoins < 0 || maxJoins > maxQueryJoinCount) {
            maxJoins = maxQueryJoinCount;
        }
        hints.put(QueryHints.MAX_JOINS, maxJoins);

        int maxColumns = UPAUtils.convertToInt(config.getHint(UPAImplKeys.QueryHints_maxColumns), -1);
        if (maxColumns < 0 || maxColumns > maxQueryColumnsCount) {
            maxColumns = maxQueryColumnsCount;
        }
        hints.put(UPAImplKeys.QueryHints_maxColumns, maxColumns);

        CompiledExpressionExt compiledExpression = (CompiledExpressionExt) expressionManager.compileExpression(statement, config);
        boolean reeavluateWithLessJoin = false;
        if (maxQueryJoinCount > 0 || maxQueryColumnsCount > 0) {
            for (CompiledExpression ce : compiledExpression.findExpressionsList(new TypeCompiledExpressionFilter(CompiledSelect.class))) {
                CompiledSelect cs = (CompiledSelect) ce;
                if (maxQueryJoinCount > 0 && cs.getJoins().length > maxQueryJoinCount) {
                    log.warning("this query is very likely to fail. It uses " + cs.getJoins().length + " > " + maxQueryJoinCount + " join tables : " + statement);
                    reeavluateWithLessJoin = true;
                    break;
                } else if (maxQueryColumnsCount > 0 && cs.getFields().size() > maxQueryColumnsCount) {
                    log.warning("this query is very likely to fail. It uses " + cs.getFields().size() + " > " + maxQueryColumnsCount + " columns : " + statement);
                    reeavluateWithLessJoin = true;
                }
            }
            if (reeavluateWithLessJoin) {
                //reset expression
                config = new ExpressionCompilerConfig()
                        .setExpandFieldFilter(defaultFieldFilter)
                        .setThisAlias(StringUtils.isNullOrEmpty(statement.getEntityAlias()) ? statement.getEntityName() : statement.getEntityAlias());

                hints.put(QueryHints.FETCH_STRATEGY, QueryFetchStrategy.SELECT);
                config.setHints(hints);
                compiledExpression = (CompiledExpressionExt) expressionManager.compileExpression(baseExpression, config);
                reeavluateWithLessJoin = false;
                for (CompiledExpression ce : compiledExpression.findExpressionsList(new TypeCompiledExpressionFilter(CompiledSelect.class))) {
                    CompiledSelect cs = (CompiledSelect) ce;
                    if (maxQueryJoinCount > 0 && cs.getJoins().length > maxQueryJoinCount) {
                        log.warning("this query is very likely to fail. It STILL uses " + cs.getJoins().length + " > " + maxQueryJoinCount + " join tables : " + statement);
                        reeavluateWithLessJoin = true;
                        break;
                    } else if (maxQueryColumnsCount > 0 && cs.getFields().size() > maxQueryColumnsCount) {
                        log.warning("this query is very likely to fail. It STILL uses " + cs.getFields().size() + " > " + maxQueryColumnsCount + " columns : " + statement);
                        reeavluateWithLessJoin = true;
                    }
                }
            }
        }

        Boolean noTypeTransformO = (Boolean) hints.get(QueryHints.NO_TYPE_TRANSFORM);
        boolean noTypeTransform = noTypeTransformO == null ? false : noTypeTransformO;

        NativeField[] nativeFields = null;
        if (compiledExpression instanceof CompiledQueryStatement) {
            CompiledQueryStatement cquery = (CompiledQueryStatement) compiledExpression;
            nativeFields = new NativeField[cquery.countFields()];
            for (int i = 0; i < nativeFields.length; i++) {
                CompiledQueryField field = cquery.getField(i);
                boolean preferLoadLater = field.isPreferLoadLater();
                boolean partialObject = field.isPartialObject();
//                String fieldAlias = field.getAliasBinding();
                CompiledExpressionExt expression1 = field.getExpression();
                BindingId binding = field.getBinding();
                String validName = field.getName() != null ? field.getName() : expression1.toString();
                if (validName == null) {
                    validName = "#" + i;
                }
                Field referrerField = field.getReferrerField();
                DataTypeTransform c = null;
                if (referrerField != null) {
                    c = referrerField.getEffectiveTypeTransform();
                } else {
                    c = expression1 == null ? null : UPAUtils.resolveDataTypeTransform(expression1);
                }
                if (c == null) {
                    throw new IllegalUPAArgumentException("Unable to resolve type for expression : " + expression1);
                }

                boolean fieldNoTypeTransform = noTypeTransform;
                if (!noTypeTransform) {
                    if (referrerField != null) {
                        String fieldKey = QueryHints.NO_TYPE_TRANSFORM + "." + referrerField.getAbsoluteName();
                        fieldNoTypeTransform = (Boolean) (hints.get(fieldKey) == null ? false : hints.get(fieldKey));
                    }
                }
                DataTypeTransform baseTransform = c;
                c = fieldNoTypeTransform ? IdentityDataTypeTransform.ofType(baseTransform.getSourceType()) : baseTransform;
//                String gn=StringUtils.isNullOrEmpty(validName)?validName:(binding+"."+validName);
                nativeFields[i] = new NativeField(validName, binding, field.getIndex(), field.isExpanded(), field.getParentBindingEntity(), referrerField, c, preferLoadLater, partialObject);
            }
        } else {
            nativeFields = new NativeField[0];
        }

        return new DefaultQueryExecutor(baseExpression, compiledExpression,
                hints, nativeFields, updatable, m, noTypeTransform, context, getSqlManager()
        );
    }

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

    public ColumnPersistenceDefinition getModelColumnPersistenceDefinition(PrimitiveField field, EntityExecutionContext entityPersistenceContext) throws UPAException {
        String tableSchema = null; //TODO
        String tableCatalog = null; //TODO
        int columnDataType = -1; //TODO
        String tableName = getValidIdentifier(getTableName(field.getEntity()));
        String columnDefault = null;
        Object defaultObject = field.getDefaultObject();
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        SqlTypeName sqlTypeName = getSqlTypeName(cr.getTargetType());
        if (defaultObject == null && !cr.getTargetType().isNullable()) {
            columnDefault = (sqlManager.getSQL(new CompiledLiteral(
                    cr.getTargetType().getDefaultValue(),
                    IdentityDataTypeTransform.ofType(cr.getTargetType())), entityPersistenceContext, new DefaultExpressionDeclarationList(null)));
        } else if (defaultObject != null && !(defaultObject instanceof CustomDefaultObject)) {
            columnDefault = (sqlManager.getSQL(new CompiledLiteral(defaultObject, cr), entityPersistenceContext, new DefaultExpressionDeclarationList(null)));
        }
        Boolean columnNullable = cr.getTargetType().isNullable();
        Boolean columnAutoIncrement = field.isGeneratedId();
        return new DefaultColumnPersistenceDefinition(
                getValidIdentifier(getColumnName(field)),
                tableName, tableSchema, tableCatalog,
                columnDataType, sqlTypeName.getName(), sqlTypeName.getSize(), sqlTypeName.getScale(),
                columnNullable,
                columnAutoIncrement,
                columnDefault);
    }

    public String getColumnDeclaration(PrimitiveField field, EntityExecutionContext entityPersistenceContext) throws UPAException {
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        Object defaultObject = field.getDefaultObject();
        StringBuilder sb = new StringBuilder(getValidIdentifier(getColumnName(field)));
        sb.append('\t');
        EntityExecutionContext context = ((PersistenceUnitExt) entityPersistenceContext.getPersistenceUnit()).createContext(ContextOperation.FIND, entityPersistenceContext.getHints());
        sb.append(sqlManager.getSQL(new CompiledTypeName(cr), context, new DefaultExpressionDeclarationList(null)));
        String columnDefault = null;

        if (defaultObject == null && !cr.getTargetType().isNullable()) {
            columnDefault = (sqlManager.getSQL(new CompiledLiteral(
                    cr.getTargetType().getDefaultValue(),
                    IdentityDataTypeTransform.ofType(cr.getTargetType())), entityPersistenceContext, new DefaultExpressionDeclarationList(null)));
        } else if (defaultObject != null && !(defaultObject instanceof CustomDefaultObject)) {
            columnDefault = (sqlManager.getSQL(new CompiledLiteral(defaultObject, cr), entityPersistenceContext, new DefaultExpressionDeclarationList(null)));
        }

        if (columnDefault != null) {
            sb.append(" Default ").append(columnDefault);
        }

        if (!cr.getTargetType().isNullable()) {
            sb.append(" Not Null");
        }
        return sb.toString();
    }

    public String getCreateViewStatement(Entity entity, EntityExecutionContext executionContext) throws UPAException {
        QueryStatement statement = getViewQueryStatement(entity);
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getTableName(entity))).append(" As ").append("\n").append("\t");
        sb.append(toSQL(statement, executionContext));
        return sb.toString();
    }

    //FIX ME
    public String getCreateImplicitViewStatement(Entity entity, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder();
        sb.append("Create View ").append(getValidIdentifier(getImplicitViewName(entity))).append(" As ").append("\n");
        List<PrimitiveField> keys = entity.getPrimitiveFields();
        Select s = new Select();
        for (PrimitiveField key : keys) {
            FlagSet<FieldModifier> modifiers = key.getModifiers();
            if (modifiers.contains(FieldModifier.SELECT_COMPILED)) {
                Expression expression = ((ExpressionFormula) UPAUtils.getSelectFormula(key)).getExpression();
                s.field(expression, getColumnName(key));
            } else if (modifiers.contains(FieldModifier.SELECT_DEFAULT)) {
                s.field(new Var(new Var(entity.getName()), key.getName()));
            }
        }
        sb.append(toSQL(s, executionContext));
        return (sb.toString());
    }

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
                List<PrimitiveField> fields = detailRole.getEntity().toPrimitiveFields(Arrays.asList((EntityItem) detailRole.getField(i)));
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
                List<PrimitiveField> fields = masterRole.getEntity().toPrimitiveFields(Arrays.asList((EntityItem) masterRole.getField(i)));
                for (Field field : fields) {
                    Relationship manyToOneRelationship = field.getManyToOneRelationship();
                    if (manyToOneRelationship != null) {
                        for (Field field1 : manyToOneRelationship.getSourceRole().getFields()) {
                            if (first1) {
                                first1 = false;
                            } else {
                                sb.append(',');
                            }
                            sb.append(getValidIdentifier(getColumnName(field1)));
                        }
                    } else {
                        if (first1) {
                            first1 = false;
                        } else {
                            sb.append(',');
                        }
                        sb.append(getValidIdentifier(getColumnName(field)));
                    }
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

    public String getDropViewStatement(Entity entity, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder("Drop");
        sb.append(" View ");
        sb.append(getValidIdentifier(getTableName(entity)));
        return sb.toString();
    }

    public String getDropTableStatement(Entity entity, EntityExecutionContext executionContext) throws UPAException {
        StringBuilder sb = new StringBuilder("Drop");
        sb.append(" Table ");
        sb.append(getValidIdentifier(getTableName(entity)));
        return sb.toString();
    }

    private void fillPrimitiveField(Field f, List<PrimitiveField> list) {
        if (f instanceof PrimitiveField) {
            PrimitiveField pf = (PrimitiveField) f;
            DataType d = pf.getDataType();
            Relationship manyToOneRelationship = pf.getManyToOneRelationship();
            if (manyToOneRelationship != null) {
                ManyToOneType rd = (ManyToOneType) d;
                for (Field field : rd.getRelationship().getSourceRole().getFields()) {
                    fillPrimitiveField(field, list);
                }
            } else {
                Relationship oneToOneRelationship = pf.getOneToOneRelationship();
                if (oneToOneRelationship != null) {
                    OneToOneType rd = (OneToOneType) d;
                    for (Field field : rd.getRelationship().getSourceRole().getFields()) {
                        fillPrimitiveField(field, list);
                    }
                } else {
                    list.add(pf);
                }
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

    public String getCreateTablePKConstraintStatement(Entity entity) throws UPAException {
        StringBuilder sb = new StringBuilder();
        if (!entity.getShield().isTransient()) {
            List<PrimitiveField> pk = new ArrayList<PrimitiveField>();
            for (PrimitiveField primitiveField : entity.getPrimitiveFields(FieldFilters.id())) {
                fillPrimitiveField(primitiveField, pk);
            }
            if (pk.size() > 0) {
                sb.append("Alter Table ").append(getValidIdentifier(getTableName(entity))).append(" Add Constraint ").append(getValidIdentifier(getTablePKName(entity))).append(" Primary Key (");
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
                .append(getColumnDeclaration(field, context));
        return s.toString();
    }

    public String getAlterTableModifyColumnStatement(PrimitiveField field, EntityExecutionContext context) throws UPAException {
        String tableName = getPersistenceName(field.getEntity());
        String columnName = getPersistenceName(field);
        ColumnPersistenceDefinition persistenceDefinition = getStoreColumnDefinition(tableName, columnName, context, (Connection) context.getConnection().getPlatformConnection());
        ColumnPersistenceDefinition expected = getModelColumnPersistenceDefinition(field, context);
        StringBuilder sb = new StringBuilder("Alter Table ")
                .append(getTableName(field.getEntity()))
                .append(" Alter Column ")
                .append(getValidIdentifier(getColumnName(field)))
                .append(" ");
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        if (!expected.getColumnTypeName().equals(persistenceDefinition.getColumnTypeName())
                || expected.getSize() != -1 && expected.getSize() != persistenceDefinition.getSize()
                || expected.getScale() != -1 && expected.getScale() != persistenceDefinition.getScale()) {
            sb.append(" SET DATA TYPE ");
            sb.append(getSqlTypeName(cr.getTargetType()).getFullName());
        }

//        Object defaultObject = field.getDefaultObject();
//        sb.append(sqlManager.getSQL(new CompiledTypeName(cr), context, new DefaultExpressionDeclarationList(null)));
//        String columnDefault = null;
//
//        if (defaultObject == null && !cr.getTargetType().isNullable()) {
//            columnDefault = (sqlManager.getSQL(new CompiledLiteral(
//                    cr.getTargetType().getDefaultValue(),
//                    IdentityDataTypeTransform.ofType(cr.getTargetType())), entityPersistenceContext, new DefaultExpressionDeclarationList(null)));
//        } else if (defaultObject != null && !(defaultObject instanceof CustomDefaultObject)) {
//            columnDefault = (sqlManager.getSQL(new CompiledLiteral(defaultObject, cr), entityPersistenceContext, new DefaultExpressionDeclarationList(null)));
//        }
//
//        if (columnDefault != null) {
//            sb.append(" Default ").append(columnDefault);
//        }
//
//        if (!cr.getTargetType().isNullable()) {
//            sb.append(" Not Null");
//        }
        return sb.toString();
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
                } else if (key.isManyToOne()) {
                    //relation 'object' fields are not stored
                } else {
                    if (firstElement) {
                        firstElement = false;
                    } else {
                        sb.append(",").append("\n").append("\t");
                    }
                    sb.append(getColumnDeclaration(key, context));
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
        boolean lazyListLoadingEnabled = executionContext.getPersistenceUnit().getProperties().getBoolean("QueryHints.lazyListLoadingEnabled", true);
        q.setLazyListLoadingEnabled(lazyListLoadingEnabled);
    }

    @Override
    public void createStructure(EntityExecutionContext executionContext) throws UPAException {
        QueryScript script = new QueryScript();
        List<Entity> entities = persistenceUnit.getEntities();
        List<Entity> views = new ArrayList<Entity>();
        List<Entity> implicitViews = new ArrayList<Entity>();
        for (Entity entity : entities) {
            if (isView(entity)) {
                views.add(entity);
            } else {
                script.addStatement(getCreateTableStatement(entity, executionContext));
                if (entity.hasAssociatedView()) {
                    implicitViews.add(entity);
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
            for (Entity entity : implicitViews) {
                script.addStatement(getCreateImplicitViewStatement(entity, executionContext));
            }
            for (Entity entity : views) {
                script.addStatement(getCreateViewStatement(entity, executionContext));
            }
        }
        executionContext.getConnection().executeScript(script, true);
    }

    public QueryStatement getViewQueryStatement(Entity entity) {
        ViewEntityExtension specSupport = (ViewEntityExtension) entity.getExtension(ViewEntityExtension.class);
        if (specSupport != null) {
            return specSupport.getQuery();
        }
        UnionEntityExtension specSupport2 = (UnionEntityExtension) entity.getExtension(UnionEntityExtension.class);
        if (specSupport2 != null) {
            return specSupport2.getQuery();
        }
        FilterEntityExtension specSupport3 = (FilterEntityExtension) entity.getExtension(FilterEntityExtension.class);
        if (specSupport3 != null) {
//            return specSupport3.getQuery();
        }
        return null;
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

    protected void requireTransaction(EntityExecutionContext executionContext) throws UPAException {
        Session currentSession = executionContext.getPersistenceUnit().getCurrentSession();
        if (currentSession != null) {
            UTransactionHelper th = UTransactionHelper.get(currentSession, executionContext.getPersistenceUnit());
            if (th != null) {
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
    public void setNativeConstraintsEnabled(boolean enable) throws UPAException {
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

    protected String buildPersistenceName(UPAObjectAndSpec e) throws UPAException {
        Object object = e.getObject();
        DefaultPersistenceNameStrategyCondition condition = new DefaultPersistenceNameStrategyCondition(databaseProduct, getDatabaseVersion(), getStrategyName());
        if (object instanceof Entity) {
            Entity entity = (Entity) object;
            PersistenceNameType spec = e.getSpec();
            if (spec != null) {
                if (spec.equals(PersistenceNameType.PRIMARY_KEY_CONSTRAINT)) {
                    return persistenceNameStrategy.getTablePKPersistenceName(entity, spec, condition);
                } else if (spec.equals(PersistenceNameType.IMPLICIT_VIEW)) {
                    return persistenceNameStrategy.getImplicitViewPersistenceName(entity, spec, condition);
                } else if (spec.equals(PersistenceNameType.TABLE)) {
                    return persistenceNameStrategy.getTablePersistenceName(entity, spec, condition);
                } else {
                    //
                    return persistenceNameStrategy.getTablePersistenceName(entity, spec, condition);
                }
            } else {
                return persistenceNameStrategy.getTablePersistenceName(entity, spec, condition);
            }
        } else if (object instanceof Field) {
            return persistenceNameStrategy.getFieldPersistenceName((Field) object, e.getSpec(), condition);
        } else if (object instanceof Index) {
            return persistenceNameStrategy.getIndexPersistenceName((Index) object, e.getSpec(), condition);
        } else if (object instanceof Relationship) {
            return persistenceNameStrategy.getRelationshipPersistenceName((Relationship) object, e.getSpec(), condition);
        } else if (object instanceof String) {
            return persistenceNameStrategy.getIdentifierPersistenceName((String) object, e.getSpec(), condition);
        } else {
            throw new IllegalUPAArgumentException("UnsupportedPersistenceNameType");
        }

    }

    protected String getPersistenceName(UPAObjectAndSpec e) throws UPAException {
        String persistenceName = persistenceNamesMap.get(e);
        if (persistenceName == null) {
            persistenceName = buildPersistenceName(e);
            persistenceNamesMap.put(e, persistenceName);
        }
        return persistenceName;
    }

    public String getStrategyName() {
        return getConnectionProfile().getProperty("namingStrategy");
    }

    public String getDatabaseVersion() {
        return databaseVersion;
    }

    public String getTablePKName(Entity o) throws UPAException {
        return getPersistenceName(o, PersistenceNameType.PRIMARY_KEY_CONSTRAINT);
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
        throw new IllegalUPAArgumentException("No supported");
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
        throw new IllegalUPAArgumentException("No supported");
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
        return commitManager.commitStructure(persistenceUnit);
    }

    @Override
    public PersistenceState getPersistenceState(UPAObject object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext) throws UPAException {
        return getPersistenceState(object, spec, entityExecutionContext, (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection());
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
        throw new IllegalUPAArgumentException("Unknown type " + object);
        //log.log(Level.FINE,"getPersistenceState " + object + " " + PersistenceState.TRANSIENT);
        //return PersistenceState.TRANSIENT;
    }

    public PersistenceState getEntityPersistenceState(Entity entity, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        String persistenceName = getPersistenceName(entity, spec);
        if (null == spec) {
            throw new IllegalUPAArgumentException("Unknown Spec for Entity : " + spec);
        } else {
            switch (spec) {
                case TABLE:
                case VIEW: {
                    if (isView(entity)) {
                        ViewPersistenceDefinition d = getStoreViewDefinition(persistenceName, entityExecutionContext);
                        if (d == null) {
                            return PersistenceState.MISSING;
                        }
                        ViewPersistenceDefinition newDef = getModelViewDefinition(entity, entityExecutionContext);
                        return isNativeObjectPersistenceDefinitionMatch(d, newDef) ? PersistenceState.VALID : PersistenceState.DIRTY;
                    } else {
                        TablePersistenceDefinition tableDef = getStoreTableDefinition(persistenceName, entityExecutionContext);
                        if (tableDef == null) {
                            return PersistenceState.MISSING;
                        }
                        return PersistenceState.VALID;
                    }
                }
                case IMPLICIT_VIEW: {
                    ViewPersistenceDefinition d = getStoreViewDefinition(persistenceName, entityExecutionContext);
                    if (d == null) {
                        return PersistenceState.MISSING;
                    }
                    ViewPersistenceDefinition newDef = getModelImplicitViewDefinition(entity, entityExecutionContext);
                    return isNativeObjectPersistenceDefinitionMatch(d, newDef) ? PersistenceState.VALID : PersistenceState.DIRTY;
                }
                case PRIMARY_KEY_CONSTRAINT: {
                    PrimaryKeyPersistenceDefinition pkDef = getStorePrimaryKeyDefinition(getPersistenceName(entity, null), persistenceName, entityExecutionContext);
                    if (pkDef == null) {
                        return PersistenceState.MISSING;
                    }
                    return PersistenceState.VALID;
                }
                default: {
                    throw new IllegalUPAArgumentException("Unknown Spec for Entity : " + spec);
                }
            }
        }
    }

    public PersistenceState getIndexPersistenceState(Index object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        String indexName = getPersistenceName(object, spec);
        String tableName = getPersistenceName(object.getEntity(), null);
        boolean unique = object.isUnique();
        IndexPersistenceDefinition d = getStoreIndexDefinition(indexName, tableName, spec, entityExecutionContext, connection);
        if (d == null) {
            return PersistenceState.MISSING;
        }
        if (d.isUnique() != unique) {
            log.log(Level.SEVERE, "Index {0} found but its unicity is invalid (expected={1})", new Object[]{indexName, unique});
            return PersistenceState.DIRTY;
        }
        return PersistenceState.VALID;
    }

    public IndexPersistenceDefinition getStoreIndexDefinition(String indexName, String tableName, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        if (spec == PersistenceNameType.INDEX) {
            ResultSet rs = null;
            {
                try {
                    /**
                     * @PortabilityHint(target = "C#", name = "todo")
                     * System.Data.Common.DbConnection dconnection =
                     * (System.Data.Common.DbConnection)connection;
                     * System.Data.DataTable found =
                     * dconnection.GetSchema("Indexes", new string[] {
                     * connection.Database, null, tableName, indexName}); return
                     * (found.Rows.Count !=
                     * 0)?net.thevpc.upa.PersistenceState.VALID:net.thevpc.upa.PersistenceState.DIRTY;
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
                                return new DefaultIndexPersistenceDefinition(indexName, tableName, u);
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
            return null;
        } else {
            throw new IllegalUPAArgumentException("Unknown Spec for Entity : " + spec);
        }
    }

    public PersistenceState getFieldPersistenceState(Field field, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        PersistenceState state = PersistenceState.DEFAULT;
        ColumnPersistenceDefinition storedDef = null;
        ColumnPersistenceDefinition modelDef = null;
        if ((field instanceof DynamicField)) {
            state = PersistenceState.TRANSIENT;
        } else if ((field instanceof CompoundField)) {
            boolean transientField = false;
            boolean dirtyField = false;
            boolean notFoundField = false;
            state = PersistenceState.VALID;
            for (PrimitiveField field1 : ((CompoundField) field).getFields()) {
                PersistenceState s = getFieldPersistenceState(field1, spec, entityExecutionContext, connection);
                switch (s) {
                    case DEFAULT:
                    case MISSING: {
                        notFoundField = true;
                        break;
                    }
                    case TRANSIENT: {
                        transientField = true;
                        break;
                    }
                    case DIRTY: {
                        dirtyField = true;
                        break;
                    }
                }
                if (dirtyField) {
                    state = PersistenceState.DIRTY;
                } else if (notFoundField) {
                    state = PersistenceState.MISSING;
                } else if (transientField) {
                    state = PersistenceState.TRANSIENT;
                }
            }
        } else {
            FlagSet<FieldModifier> fieldModifiers = field.getModifiers();
            if (field.isManyToOne() || fieldModifiers.contains(FieldModifier.TRANSIENT)) {
                state = PersistenceState.TRANSIENT;
            } else {
                String tableName = getPersistenceName(field.getEntity());
                String columnName = getPersistenceName(field);
                storedDef = getStoreColumnDefinition(tableName, columnName, entityExecutionContext, connection);
                if (storedDef == null) {
                    state = PersistenceState.MISSING;
                } else {
                    modelDef = getModelColumnPersistenceDefinition((PrimitiveField) field, entityExecutionContext);
                    state = isNativeObjectPersistenceDefinitionMatch(storedDef, modelDef) ? PersistenceState.VALID : PersistenceState.DIRTY;
                }
            }
        }
        if (state == PersistenceState.DIRTY && storedDef != null && modelDef != null) {
            log.log(Level.CONFIG, "Field Persistence State {0} {1} \n\t Found    {2}\n\t Expected {3}", new Object[]{StringUtils.formatLeftAlign(state.toString(), 12), field, storedDef, modelDef});
        } else if (state != PersistenceState.VALID && state != PersistenceState.TRANSIENT) {
            log.log(Level.CONFIG, "Field Persistence State {0} {1}", new Object[]{StringUtils.formatLeftAlign(state.toString(), 12), field});
        }
        return state;
    }

    public ColumnPersistenceDefinition getStoreColumnDefinition(String tableName, String columnName, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         */
        try {
            ResultSet rs = null;
            try {
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getColumns(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName), getIdentifierStoreTranslator().translateIdentifier(columnName));
                if (rs.next()) {
                    String tableCat = rs.getString("TABLE_CAT");
                    String tableSchem = rs.getString("TABLE_SCHEM");
                    String tableSchem2 = rs.getString("TABLE_NAME");
                    String typeName = rs.getString("TYPE_NAME");
                    String columnName2 = rs.getString("COLUMN_NAME");
                    int columnSize = rs.getInt("COLUMN_SIZE");
                    int decimalDigits = rs.getInt("DECIMAL_DIGITS");
                    int nullable = rs.getInt("NULLABLE");
                    int dataType = rs.getInt("DATA_TYPE");
                    String columnDef = rs.getString("COLUMN_DEF");
                    String isAutoIncrement = rs.getString("IS_AUTOINCREMENT");
                    //TODO, check datatype and constraints
                    return new DefaultColumnPersistenceDefinition(columnName2, tableSchem2, tableSchem, tableCat,
                            dataType, typeName, columnSize, decimalDigits,
                            nullable == DatabaseMetaData.columnNoNulls ? Boolean.FALSE : nullable == DatabaseMetaData.columnNullable ? Boolean.TRUE : null,
                            "NO".equalsIgnoreCase(isAutoIncrement) ? Boolean.FALSE : "YES".equalsIgnoreCase(isAutoIncrement) ? Boolean.TRUE : null,
                            columnDef);
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityStorageStatus", "Column " + tableName + "." + columnName);
        }
        return null;
    }

    public PersistenceState getRelationshipPersistenceState(Relationship object, PersistenceNameType spec, EntityExecutionContext entityExecutionContext, Connection connection) throws UPAException {
        PersistenceState status = PersistenceState.MISSING;
        if (isView(object.getTargetRole().getEntity()) || isView(object.getSourceRole().getEntity())) {
            status = PersistenceState.TRANSIENT;
        } else {
            String tablePersistenceName = getPersistenceName(object.getSourceRole().getEntity());
            String persistenceName = getPersistenceName(object);
            ForeignKeyPersistenceDefinition d = getStoreForeignKeyDefinition(tablePersistenceName, persistenceName, entityExecutionContext);
            if (d != null) {
                status = PersistenceState.VALID;
            }
        }
        if (status != PersistenceState.VALID) {
            log.log(Level.FINE, "Persistence for Relation {0} is {1}", new Object[]{object, status});
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
         * @PortabilityHint(target = "C#", name = "todo")
         */
        {
            DatabaseMetaData m = ((Connection) connection.getMetadataAccessibleConnection()).getMetaData();
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

    protected TablePersistenceDefinition getStoreTableDefinition(String persistenceName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             * System.Data.IDbConnection connection =
             * entityExecutionContext.GetConnection().GetPlatformConnection();
             * if (connection is System.Data.Common.DbConnection) {
             * System.Data.Common.DbConnection dconnection =
             * (System.Data.Common.DbConnection)connection;
             * System.Data.DataTable found = dconnection.GetSchema("Tables", new
             * string[] { null, null, persistenceName, "BASE TYPE" }); return
             * (found.Rows.Count != 0); }
             */
            try {
                Connection connection = (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                //connection.getMetaData().storesLowerCaseIdentifiers();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getTables(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(persistenceName), null);
                if (rs.next()) {
                    String tableName = rs.getString("TABLE_NAME");
                    String typeName = rs.getString("TYPE_NAME");
                    return new DefaultTablePersistenceDefinition(tableName, catalog, schema);
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceName);
        }
        return null;
    }

    public IdentifierStoreTranslator getIdentifierStoreTranslator() throws SQLException {
        return identifierStoreTranslator;
    }

    protected ViewPersistenceDefinition getModelViewDefinition(Entity entity, EntityExecutionContext entityExecutionContext) {
        return new DefaultViewKeyPersistenceDefinition(getValidIdentifier(getPersistenceName(entity, PersistenceNameType.VIEW)), null, null,
                getCreateViewStatement(entity, entityExecutionContext));
    }

    protected ViewPersistenceDefinition getModelImplicitViewDefinition(Entity entity, EntityExecutionContext entityExecutionContext) {
        return new DefaultViewKeyPersistenceDefinition(getValidIdentifier(getPersistenceName(entity, PersistenceNameType.IMPLICIT_VIEW)), null, null,
                getCreateImplicitViewStatement(entity, entityExecutionContext));
    }

    protected ViewPersistenceDefinition getStoreViewDefinition(String persistenceName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             * System.Data.IDbConnection connection =
             * entityExecutionContext.GetConnection().GetPlatformConnection();
             * if (connection is System.Data.Common.DbConnection) {
             * System.Data.Common.DbConnection dconnection =
             * (System.Data.Common.DbConnection)connection;
             * System.Data.DataTable found = dconnection.GetSchema("Tables", new
             * string[] { null, null, persistenceName, "VIEW" }); return
             * (found.Rows.Count != 0); }
             */
            try {
                Connection connection = (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getTables(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(persistenceName), null);
                if (rs.next()) {
                    String tableName = rs.getString("TABLE_NAME");
//                    String typeName = rs.getString("TYPE_NAME");
                    return new DefaultViewKeyPersistenceDefinition(tableName, catalog, schema, null);
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceName);
        }
        return null;
    }

    protected PrimaryKeyPersistenceDefinition getStorePrimaryKeyDefinition(String tableName, String constraintsName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             * System.Data.IDbConnection connection =
             * entityExecutionContext.GetConnection().GetPlatformConnection();
             * if (connection is System.Data.Common.DbConnection) {
             * System.Data.Common.DbConnection dconnection =
             * (System.Data.Common.DbConnection)connection;
             * System.Data.DataTable found =
             * dconnection.GetSchema("IndexColumns", new string[] {
             * connection.Database, null, tableName, constraintsName, null });
             * return (found.Rows.Count != 0); }
             */
            try {
                Connection connection = (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getPrimaryKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                while (rs.next()) {
                    String tableName2 = rs.getString("TABLE_NAME");
                    String pkName = rs.getString("PK_NAME");
                    String expectedName = getIdentifierStoreTranslator().translateIdentifier(constraintsName);
                    if (expectedName.equals(pkName)) {
                        return new DefaultPrimaryKeyPersistenceDefinition(tableName2, pkName);
                    } else {
                        log.log(Level.WARNING, "Found Conflicting PK Constraints {0} instead of {1} in table {2}. Will use it anyway...", new Object[]{pkName, expectedName, tableName});
                        return new DefaultPrimaryKeyPersistenceDefinition(tableName2, pkName);
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
        return null;
    }

    protected ForeignKeyPersistenceDefinition getStoreForeignKeyDefinition(String tableName, String constraintName, EntityExecutionContext entityExecutionContext) {
        try {
            ResultSet rs = null;
            /**
             * @PortabilityHint(target = "C#", name = "replace")
             *
             * System.Data.IDbConnection connection =
             * entityExecutionContext.GetConnection().GetPlatformConnection();
             * if (connection is System.Data.Common.DbConnection) {
             * System.Data.Common.DbConnection dconnection =
             * (System.Data.Common.DbConnection)connection;
             * System.Data.DataTable found =
             * dconnection.GetSchema("ForeignKeys", new string[] {
             * connection.Database, null, tableName, constraintName }); return
             * (found.Rows.Count != 0); }
             */
            try {
                Connection connection = (Connection) entityExecutionContext.getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getImportedKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                String constraintNameIdentifier = getIdentifierStoreTranslator().translateIdentifier(constraintName);
                while (rs.next()) {
                    String fkpkTableName = rs.getString("PKTABLE_NAME");
                    String fkName = rs.getString("FK_NAME");
                    if (constraintNameIdentifier.equals(fkName)) {
                        return new DefaultForeignKeyPersistenceDefinition(fkpkTableName, fkName);
                    }
                }

                //should we check further if this name is used elsewhere ?
                //how to ?  TODO
//                rs.close();
//                rs = connection.getMetaData().getImportedKeys(catalog, schema, "%");
//                while (rs.next()) {
//                    String FK_NAME = rs.getString("FK_NAME");
//                    if (getIdentifierStoreTranslator().translateIdentifier(constraintName).equals(FK_NAME)) {
//                        return true;
//                    }
//                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState", "Column " + tableName + "." + constraintName);
        }
        return null;
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

    //@Override
    protected UConnection createRootUConnection(EntityExecutionContext context) throws UPAException {
        ConnectionProfileParser connectionProfileParser = new ConnectionProfileParser();
        Properties p2 = new DefaultProperties(getProperties());
        List<ConnectionProfile> all = connectionProfileParser.parse(p2, context.getPersistenceUnit().getRootConnectionConfigs(), UPA.ROOT_CONNECTION_STRING, true);
        if (all.size() == 0) {
            throw new RootConnectionStringNotFoundException();
        }
        UPAException lastEx = null;
        for (ConnectionProfile prof : all) {
            try {
                return createConnection(prof);
            } catch (UPAException ex) {
                if (lastEx == null) {
                    lastEx = ex;
                }
                //ignore
            }
        }
        throw lastEx;
    }

    @Override
    public UConnection createConnection() throws UPAException {
        return createConnection(getConnectionProfile());
    }

    public boolean isAccessible(ConnectionProfile connectionProfile) {
        try {
            checkAccessible(connectionProfile);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    public void checkAccessible(ConnectionProfile connectionProfile) {
        UConnection c = null;
        try {
            c = createConnection(connectionProfile);
        } catch (Exception e) {
            throw new UPAException(e, new I18NString("StoreNotAccessibleException"), connectionProfile);
        } finally {
            if (c != null) {
                try {
                    c.close();
                } catch (Exception ex) {
                    log.log(Level.SEVERE, null, ex);
                }
            }
        }
    }

    protected abstract UConnection createConnection(ConnectionProfile profile);

    public SqlTypeName getSqlTypeName(DataType datatype) {
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (platformType.equals(String.class)) {
            if (length <= 0) {
                length = 255;
            }
            return new SqlTypeName("VARCHAR", length);
        }
        if (PlatformUtils.isInt32(platformType)) {
            return new SqlTypeName("INT");
        }
        if (PlatformUtils.isInt8(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (PlatformUtils.isInt16(platformType)) {
            return new SqlTypeName("SMALLINT");
        }
        if (PlatformUtils.isInt64(platformType)) {
            return new SqlTypeName("NUMERIC");
        }
        if (PlatformUtils.isFloat32(platformType)) {
            return new SqlTypeName("FLOAT");
        }
        if (PlatformUtils.isFloat64(platformType)) {
            return new SqlTypeName("FLOAT");
        }
        if (PlatformUtils.isAnyNumber(platformType)) {
            return new SqlTypeName("NUMERIC");
        }
        if (PlatformUtils.isBool(platformType)) {
            return new SqlTypeName("INT");
        }

        if (datatype instanceof TemporalType) {
            TemporalOption temporalOption = ((TemporalType) datatype).getTemporalOption();
            if (temporalOption == null) {
                temporalOption = TemporalOption.DEFAULT;
            }
            switch (temporalOption) {
                case DATE:
                    return new SqlTypeName("DATE");
                case DATETIME:
                    return new SqlTypeName("DATETIME");
                case TIMESTAMP:
                    return new SqlTypeName("TIMESTAMP");
                case TIME:
                    return new SqlTypeName("TIME");
                case MONTH:
                    return new SqlTypeName("DATE");
                case YEAR:
                    return new SqlTypeName("DATE");
                default: {
                    throw new IllegalUPAArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
                }
            }
        }
        if (Object.class
                .equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return new SqlTypeName("BLOB"); // serialized form
        }
        throw new IllegalUPAArgumentException(
                "UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

    protected void getNativeObjectPersistenceTreeBuildStore(NativeObjectPersistenceTree tree, EntityExecutionContext executionContext) {
        try {
            Connection connection = (Connection) executionContext.getConnection().getMetadataAccessibleConnection();
            ResultSet rs = null;
            try {
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getTables(catalog, schema, "%", null);
                while (rs.next()) {
                    String tableName = rs.getString("TABLE_NAME");
                    String typeName = rs.getString("TYPE_NAME");
                    if ("VIEW".equals(typeName)) {
                        NativeObjectPersistenceView tab = new NativeObjectPersistenceView();
                        DefaultViewKeyPersistenceDefinition d = new DefaultViewKeyPersistenceDefinition(tableName, catalog, schema, getStoreViewDefinitionSQL(tableName, connection));
                        tab.setViewName(tableName);
                        tab.setStoreDefinition(d);
                        tab.setState(PersistenceState.SUPERFLUOUS);
                        tree.getViews().add(tab);
                    } else {
                        NativeObjectPersistenceTable tab = new NativeObjectPersistenceTable();
                        DefaultTablePersistenceDefinition d = new DefaultTablePersistenceDefinition(tableName, catalog, schema);
                        tab.setTableName(tableName);
                        tab.setStoreDefinition(d);
                        tab.setState(PersistenceState.SUPERFLUOUS);
                        tree.getTables().add(tab);
                    }
                }
            } finally {
                if (rs != null) {
                    rs.close();
                }
            }

            for (NativeObjectPersistenceTable table : tree.getTables()) {

                rs = null;
                try {
                    String catalog = connection.getCatalog();
                    String schema = connection.getSchema();
                    rs = connection.getMetaData().getColumns(catalog, schema, table.getTableName(), "%");
                    while (rs.next()) {
                        String tableCat = rs.getString("TABLE_CAT");
                        String tableSchem = rs.getString("TABLE_SCHEM");
                        String tableSchem2 = rs.getString("TABLE_NAME");
                        String typeName = rs.getString("TYPE_NAME");
                        String columnName2 = rs.getString("COLUMN_NAME");
                        int columnSize = rs.getInt("COLUMN_SIZE");
                        int decimalDigits = rs.getInt("DECIMAL_DIGITS");
                        int nullable = rs.getInt("NULLABLE");
                        int dataType = rs.getInt("DATA_TYPE");
                        String columnDef = rs.getString("COLUMN_DEF");
                        String isAutoIncrement = rs.getString("IS_AUTOINCREMENT");
                        //TODO, check datatype and constraints
                        DefaultColumnPersistenceDefinition d = new DefaultColumnPersistenceDefinition(columnName2, tableSchem2, tableSchem, tableCat,
                                dataType, typeName, columnSize, decimalDigits,
                                nullable == DatabaseMetaData.columnNoNulls ? Boolean.FALSE : nullable == DatabaseMetaData.columnNullable ? Boolean.TRUE : null,
                                "NO".equalsIgnoreCase(isAutoIncrement) ? Boolean.FALSE : "YES".equalsIgnoreCase(isAutoIncrement) ? Boolean.TRUE : null,
                                columnDef);
                        NativeObjectPersistenceColumn c = new NativeObjectPersistenceColumn();
                        c.setTableName(table.getTableName());
                        c.setColumnName(columnName2);
                        c.setStoreDefinition(d);
                        c.setState(PersistenceState.SUPERFLUOUS);
                        table.getColumns().add(c);
                    }
                } finally {
                    if (rs != null) {
                        rs.close();
                    }
                }

                try {
                    String catalog = connection.getCatalog();
                    String schema = connection.getSchema();
                    rs = connection.getMetaData().getImportedKeys(catalog, schema, table.getTableName());
                    while (rs.next()) {
                        String fkpkTableName = rs.getString("PKTABLE_NAME");
                        String fkName = rs.getString("FK_NAME");
                        DefaultForeignKeyPersistenceDefinition d = new DefaultForeignKeyPersistenceDefinition(fkpkTableName, fkName);
                        NativeObjectPersistenceForeignKey c = new NativeObjectPersistenceForeignKey(fkName, fkpkTableName);
                        c.setState(PersistenceState.SUPERFLUOUS);
                        c.setModelDefinition(d);
                        table.getForeignKeys().add(c);
                    }
                } finally {
                    if (rs != null) {
                        rs.close();
                    }
                }
                try {
                    String catalog = connection.getCatalog();
                    String schema = connection.getSchema();
                    rs = connection.getMetaData().getPrimaryKeys(catalog, schema, table.getTableName());
                    while (rs.next()) {
                        String pkName = rs.getString("PK_NAME");
                        DefaultPrimaryKeyPersistenceDefinition d = new DefaultPrimaryKeyPersistenceDefinition(table.getTableName(), pkName);
                        NativeObjectPersistencePrimaryKey c = new NativeObjectPersistencePrimaryKey(table.getTableName(), pkName);
                        c.setStoreDefinition(d);
                        if (table.getPrimaryKey() == null) {
                            table.setPrimaryKey(c);
                        }
                    }
                } finally {
                    if (rs != null) {
                        rs.close();
                    }
                }
                try {
//                    Connection connection = getConnection().getNativeConnection();
                    String catalog = connection.getCatalog();
                    String schema = connection.getSchema();
                    rs = connection.getMetaData().getIndexInfo(catalog, schema, table.getTableName(), false, true);
                    while (rs.next()) {
                        String indexName = rs.getString("INDEX_NAME");
                        boolean u = !rs.getBoolean("NON_UNIQUE");
                        DefaultIndexPersistenceDefinition d = new DefaultIndexPersistenceDefinition(indexName, table.getTableName(), u);
                        NativeObjectPersistenceIndex n = new NativeObjectPersistenceIndex(table.getTableName(), indexName);
                        n.setStoreDefinition(d);
                        table.getIndexes().add(n);
                    }
                } finally {
                    if (rs != null) {
                        rs.close();
                    }
                }
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "UnableToGetEntityPersistenceState");
        }
    }

    protected void getNativeObjectPersistenceTreeBuildModel(NativeObjectPersistenceTree tree, EntityExecutionContext executionContext) {
        Map<String, NativeObjectPersistenceNode> nodesByName = new HashMap<String, NativeObjectPersistenceNode>();
        for (NativeObjectPersistenceTable table : tree.getTables()) {
            nodesByName.put("Table:" + table.getTableName(), table);
            for (NativeObjectPersistenceColumn column : table.getColumns()) {
                nodesByName.put("Table:" + table.getTableName() + ".Column:" + column.getTableName(), column);
            }
            for (NativeObjectPersistenceIndex index : table.getIndexes()) {
                nodesByName.put("Table:" + table.getTableName() + ".Index:" + index.getIndexName(), index);
            }
            for (NativeObjectPersistenceForeignKey fk : table.getForeignKeys()) {
                nodesByName.put("Table:" + table.getTableName() + ".ForeignKey:" + fk.getForeignKeyName(), fk);
            }
        }
        for (NativeObjectPersistenceView view : tree.getViews()) {
            nodesByName.put("Table:" + view.getViewName(), view);
        }
        for (Entity entity : persistenceUnit.getEntities()) {
            if (isView(entity)) {
                String v = getPersistenceName(new UPAObjectAndSpec(entity, PersistenceNameType.VIEW));
                NativeObjectPersistenceNode m2 = nodesByName.get(v);
                NativeObjectPersistenceView t2 = null;
                if (m2 == null) {
                    t2 = new NativeObjectPersistenceView();
                    t2.setViewName(v);
                    nodesByName.put(v, t2);
                    tree.getViews().add(t2);
                    m2 = t2;
                } else if (m2 instanceof NativeObjectPersistenceView) {
                    t2 = (NativeObjectPersistenceView) m2;
                } else {
                    m2.setState(PersistenceState.ERRONOUS);
                }
                if (m2.getState() != PersistenceState.ERRONOUS) {
                    t2.setModelObject(entity);
                    t2.setModelObjectSpec(PersistenceNameType.IMPLICIT_VIEW);
                    QueryStatement q = getViewQueryStatement(entity);
                    t2.setModelDefinition(new DefaultViewKeyPersistenceDefinition(v, null, null, toSQL(getViewQueryStatement(entity), executionContext)));
                }
            } else {
                String tableName = getPersistenceName(new UPAObjectAndSpec(entity, PersistenceNameType.TABLE));
                String tmapKey = "Table:" + tableName;
                NativeObjectPersistenceNode m = nodesByName.get(tmapKey);
                NativeObjectPersistenceTable t = null;
                if (m == null) {
                    t = new NativeObjectPersistenceTable();
                    t.setTableName(tableName);
                    nodesByName.put(tmapKey, t);
                    tree.getTables().add(t);
                    m = t;
                } else if (m instanceof NativeObjectPersistenceTable) {
                    t = (NativeObjectPersistenceTable) m;
                } else {
                    m.setState(PersistenceState.ERRONOUS);
                }
                if (m.getState() != PersistenceState.ERRONOUS) {
                    t.setModelObject(entity);
                    t.setModelObjectSpec(PersistenceNameType.TABLE);
                    t.setModelDefinition(new DefaultTablePersistenceDefinition(tableName, null, null));
                }

                for (Index index : entity.getIndexes(null)) {
                    String v = getPersistenceName(new UPAObjectAndSpec(index, PersistenceNameType.INDEX));
                    String mapKey = "Table:" + tableName + ".Index:" + v;
                    NativeObjectPersistenceNode m2 = nodesByName.get(mapKey);
                    NativeObjectPersistenceIndex t2 = null;
                    if (m2 == null) {
                        t2 = new NativeObjectPersistenceIndex(tableName, v);
                        nodesByName.put(mapKey, t2);
                        t.getIndexes().add(t2);
                        m2 = t2;
                    } else if (m2 instanceof NativeObjectPersistenceIndex) {
                        t2 = (NativeObjectPersistenceIndex) m2;
                    } else {
                        m2.setState(PersistenceState.ERRONOUS);
                    }
                    if (m2.getState() != PersistenceState.ERRONOUS) {
                        t2.setModelObject(index);
                        t2.setModelObjectSpec(PersistenceNameType.COLUMN);
                        t2.setModelDefinition(getModelIndexPersistenceDefinition(index, executionContext));
                    }
                }

                for (PrimitiveField primitiveField : entity.getPrimitiveFields()) {
                    String v = getPersistenceName(new UPAObjectAndSpec(primitiveField, PersistenceNameType.COLUMN));
                    String cn = "Table:" + tableName + ".Column:" + v;
                    NativeObjectPersistenceNode m2 = nodesByName.get(cn);
                    NativeObjectPersistenceColumn t2 = null;
                    if (m2 == null) {
                        t2 = new NativeObjectPersistenceColumn();
                        t2.setTableName(tableName);
                        t2.setColumnName(v);
                        nodesByName.put(cn, t2);
                        t.getColumns().add(t2);
                        m2 = t2;
                    } else if (m2 instanceof NativeObjectPersistenceColumn) {
                        t2 = (NativeObjectPersistenceColumn) m2;
                    } else {
                        m2.setState(PersistenceState.ERRONOUS);
                    }
                    if (m2.getState() != PersistenceState.ERRONOUS) {
                        t2.setModelObject(primitiveField);
                        t2.setModelObjectSpec(PersistenceNameType.COLUMN);
                        t2.setModelDefinition(getModelColumnPersistenceDefinition(primitiveField, executionContext));
                    }
                }
                if (entity.getPrimitiveFields().size() > 0) {
                    String pkName = getPersistenceName(new UPAObjectAndSpec(entity, PersistenceNameType.PRIMARY_KEY_CONSTRAINT));
                    if (t.getPrimaryKey() == null) {
                        t.setPrimaryKey(new NativeObjectPersistencePrimaryKey(tableName, pkName));
                    }
                    t.getPrimaryKey().setModelDefinition(new DefaultPrimaryKeyPersistenceDefinition(tableName, pkName));
                }
                for (Relationship relationship : entity.getRelationshipsBySource()) {
                    if (!relationship.isTransient()) {
                        String fkName = getPersistenceName(new UPAObjectAndSpec(relationship, PersistenceNameType.FOREIGN_KEY_CONSTRAINT));
                        String cn = "Table:" + tableName + ".ForeignKey:" + fkName;
                        NativeObjectPersistenceNode m2 = nodesByName.get(cn);
                        NativeObjectPersistenceForeignKey t2 = null;
                        if (m2 == null) {
                            t2 = new NativeObjectPersistenceForeignKey(fkName, tableName);
                            nodesByName.put(cn, t2);
                            t.getForeignKeys().add(t2);
                            m2 = t2;
                        } else if (m2 instanceof NativeObjectPersistenceForeignKey) {
                            t2 = (NativeObjectPersistenceForeignKey) m2;
                        } else {
                            m2.setState(PersistenceState.ERRONOUS);
                        }
                        if (m2.getState() != PersistenceState.ERRONOUS) {
                            t2.setModelObject(relationship);
                            t2.setModelObjectSpec(PersistenceNameType.FOREIGN_KEY_CONSTRAINT);
                            t2.setModelDefinition(new DefaultForeignKeyPersistenceDefinition(tableName, fkName));
                        }
                    }
                }

                if (entity.hasAssociatedView()) {
                    String v = getPersistenceName(new UPAObjectAndSpec(entity, PersistenceNameType.IMPLICIT_VIEW));
                    String kk = "Table:" + v;
                    NativeObjectPersistenceNode m2 = nodesByName.get(kk);
                    NativeObjectPersistenceView t2 = null;
                    if (m2 == null) {
                        t2 = new NativeObjectPersistenceView();
                        t2.setViewName(v);
                        nodesByName.put(kk, t2);
                        tree.getViews().add(t2);
                        m2 = t2;
                    } else if (m2 instanceof NativeObjectPersistenceView) {
                        t2 = (NativeObjectPersistenceView) m2;
                    } else {
                        m2.setState(PersistenceState.ERRONOUS);
                    }
                    if (m2.getState() != PersistenceState.ERRONOUS) {
                        t2.setModelObject(entity);
                        t2.setModelObjectSpec(PersistenceNameType.IMPLICIT_VIEW);
                        QueryStatement q = getViewQueryStatement(entity);
                        t2.setModelDefinition(new DefaultViewKeyPersistenceDefinition(v, null, null, toSQL(getViewQueryStatement(entity), executionContext)));
                    }
                }
            }
        }
    }

    protected boolean isNativeObjectPersistenceDefinitionMatch(NativeObjectPersistenceDefinition store, NativeObjectPersistenceDefinition model) {
        if (store instanceof ColumnPersistenceDefinition) {
            ColumnPersistenceDefinition d = (ColumnPersistenceDefinition) store;
            ColumnPersistenceDefinition e = (ColumnPersistenceDefinition) model;
            if (!e.getColumnTypeName().equals(d.getColumnTypeName())) {
                return false;
            }
            if (e.getSize() != -1 && e.getSize() != d.getSize()) {
                return false;
            }
            if (e.getScale() != -1 && e.getScale() != d.getScale()) {
                return false;
            }
        }
        if (store instanceof ViewPersistenceDefinition) {
            ViewPersistenceDefinition d = (ViewPersistenceDefinition) store;
            ViewPersistenceDefinition e = (ViewPersistenceDefinition) model;
            return e.getViewDefinition().equals(d.getViewDefinition());
        }
        return true;
    }

    protected void rebuildNativeObjectPersistenceNodeState(NativeObjectPersistenceNode n) {
        if (n == null) {
            return;
        }
        if (n.getState() != PersistenceState.ERRONOUS && n.getState() != PersistenceState.TRANSIENT) {
            NativeObjectPersistenceDefinition store = n.getStoreDefinition();
            NativeObjectPersistenceDefinition model = n.getModelDefinition();

            if (model == null) {
                n.setState(PersistenceState.SUPERFLUOUS);
            } else if (store == null) {
                n.setState(PersistenceState.MISSING);
            } else if (isNativeObjectPersistenceDefinitionMatch(store, model)) {
                n.setState(PersistenceState.VALID);
            } else {
                n.setState(PersistenceState.DIRTY);
            }
        }
    }

    protected void getNativeObjectPersistenceTreeBuildDiff(NativeObjectPersistenceTree tree, EntityExecutionContext executionContext) {
        for (NativeObjectPersistenceTable table : tree.getTables()) {
            rebuildNativeObjectPersistenceNodeState(table);
            rebuildNativeObjectPersistenceNodeState(table.getPrimaryKey());
            for (NativeObjectPersistenceColumn column : table.getColumns()) {
                rebuildNativeObjectPersistenceNodeState(column);
            }
            for (NativeObjectPersistenceForeignKey fk : table.getForeignKeys()) {
                rebuildNativeObjectPersistenceNodeState(fk);
            }
            for (NativeObjectPersistenceIndex index : table.getIndexes()) {
                rebuildNativeObjectPersistenceNodeState(index);
            }
        }
        for (NativeObjectPersistenceView view : tree.getViews()) {
            rebuildNativeObjectPersistenceNodeState(view);
        }
    }

    public NativeObjectPersistenceTree getNativeObjectPersistenceTree() {
        NativeObjectPersistenceTree tree = new NativeObjectPersistenceTree();
        EntityExecutionContext executionContext = ((PersistenceUnitExt) persistenceUnit).createContext(ContextOperation.FIND, null);
        getNativeObjectPersistenceTreeBuildStore(tree, executionContext);
        getNativeObjectPersistenceTreeBuildModel(tree, executionContext);
        getNativeObjectPersistenceTreeBuildDiff(tree, executionContext);
        return tree;
    }

    public String toSQL(Expression s, EntityExecutionContext executionContext) {
        CompiledExpressionExt compiledExpression = (CompiledExpressionExt) executionContext.getPersistenceUnit().getExpressionManager().compileExpression(s, null);
        return getSqlManager().getSQL(compiledExpression, executionContext, new DefaultExpressionDeclarationList(null));
    }

    protected String getStoreViewDefinitionSQL(String viewName, Connection conn) {
        return null;
    }

    protected IndexPersistenceDefinition getModelIndexPersistenceDefinition(Index index, EntityExecutionContext executionContext) {
        return new DefaultIndexPersistenceDefinition(getPersistenceName(new UPAObjectAndSpec(index, PersistenceNameType.INDEX)),
                getPersistenceName(new UPAObjectAndSpec(index.getEntity(), PersistenceNameType.TABLE)),
                index.isUnique());
    }
}
