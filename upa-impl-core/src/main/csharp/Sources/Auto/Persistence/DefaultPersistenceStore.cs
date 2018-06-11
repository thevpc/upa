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



namespace Net.Vpc.Upa.Impl.Persistence
{



    public partial class DefaultPersistenceStore : Net.Vpc.Upa.Persistence.PersistenceStore {

        public const string DRIVER_TYPE_EMBEDDED = "EMBEDDED";

        public const string DRIVER_TYPE_DEFAULT = "DEFAULT";

        public const string DRIVER_TYPE_DATASOURCE = "DATASOURCE";

        public const string DRIVER_TYPE_GENERIC = "GENERIC";

        public const string DRIVER_TYPE_ODBC = "ODBC";

        protected internal static readonly Net.Vpc.Upa.Impl.Persistence.TypeMarshaller SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER = new Net.Vpc.Upa.Impl.Persistence.Shared.DefaultSerializablePlatformObjectMarshaller();

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore)).FullName);

        protected internal const string COMPLEX_SELECT_PERSIST = "Store.COMPLEX_SELECT_PERSIST";

        protected internal const string COMPLEX_SELECT_MERGE = "Store.COMPLEX_SELECT_MERGE";

        public static bool DO_WARNINGS = false;

        private bool readOnly;

        private string persistenceUnitName;

        private Net.Vpc.Upa.ObjectFactory factory;

        private Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator identifierStoreTranslator;









        private Net.Vpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy;

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec , string> persistenceNamesMap = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec , string>();

        private Net.Vpc.Upa.Properties parameters = new Net.Vpc.Upa.Impl.DefaultProperties();

        private Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager commitManager = new Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager();

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        private Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager;

        private string identifierQuoteString;

        private Net.Vpc.Upa.Persistence.PersistenceNameConfig nameConfig;

        private System.Collections.Generic.HashSet<string> reservedWords;

        private static System.Collections.Generic.HashSet<string> SQL2003_RESERVED_WORDS = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(new[]{"ADD", "ALL", "ALLOCATE", "ALTER", "AND", "ANY", "ARE", "ARRAY", "AS", "ASENSITIVE", "ASYMMETRIC", "AT", "ATOMIC", "AUTHORIZATION", "BEGIN", "BETWEEN", "BIGINT", "BINARY", "BLOB", "BOOLEAN", "BOTH", "BY", "CALL", "CALLED", "CASCADED", "CASE", "CAST", "CHAR", "CHARACTER", "CHECK", "CLOB", "CLOSE", "COLLATE", "COLUMN", "COMMIT", "CONNECT", "CONSTRAINT", "CONTINUE", "CORRESPONDING", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_DATE", "CURRENT_DEFAULT_TRANSFORM_GROUP", "CURRENT_PATH", "CURRENT_ROLE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_TRANSFORM_GROUP_FOR_TYPE", "CURRENT_USER", "CURSOR", "CYCLE", "DATE", "DAY", "DEALLOCATE", "DEC", "DECIMAL", "DECLARE", "DEFAULT", "DELETE", "DEREF", "DESCRIBE", "DETERMINISTIC", "DISCONNECT", "DISTINCT", "DOUBLE", "DROP", "DYNAMIC", "EACH", "ELEMENT", "ELSE", "END", "END-EXEC", "ESCAPE", "EXCEPT", "EXEC", "EXECUTE", "EXISTS", "EXTERNAL", "FALSE", "FETCH", "FILTER", "FLOAT", "FOR", "FOREIGN", "FREE", "FROM", "FULL", "FUNCTION", "GET", "GLOBAL", "GRANT", "GROUP", "GROUPING", "HAVING", "HOLD", "HOUR", "IDENTITY", "IMMEDIATE", "IN", "INDICATOR", "INNER", "INOUT", "INPUT", "INSENSITIVE", "INSERT", "INT", "INTEGER", "INTERSECT", "INTERVAL", "INTO", "IS", "ISOLATION", "JOIN", "LANGUAGE", "LARGE", "LATERAL", "LEADING", "LEFT", "LIKE", "LOCAL", "LOCALTIME", "LOCALTIMESTAMP", "MATCH", "MEMBER", "MERGE", "METHOD", "MINUTE", "MODIFIES", "MODULE", "MONTH", "MULTISET", "NATIONAL", "NATURAL", "NCHAR", "NCLOB", "NEXT", "NEW", "NO", "NONE", "NOT", "NULL", "NUMERIC", "OF", "OLD", "ON", "ONLY", "OPEN", "OR", "ORDER", "OUT", "OUTER", "OUTPUT", "OVER", "OVERLAPS", "PARAMETER", "PARTITION", "PRECISION", "PREPARE", "PRIMARY", "PROCEDURE", "RANGE", "READS", "REAL", "RECURSIVE", "REF", "REFERENCES", "REFERENCING", "REGR_AVGX", "REGR_AVGY", "REGR_COUNT", "REGR_INTERCEPT", "REGR_R2", "REGR_SLOPE", "REGR_SXX", "REGR_SXY", "REGR_SYY", "RELEASE", "RESULT", "RETURN", "RETURNS", "REVOKE", "RIGHT", "ROLLBACK", "ROLLUP", "ROW", "ROWS", "SAVEPOINT", "SCROLL", "SEARCH", "SECOND", "SELECT", "SENSITIVE", "SESSION_USER", "SET", "SIMILAR", "SMALLINT", "SOME", "SPECIFIC", "SPECIFICTYPE", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "START", "STATIC", "SUBMULTISET", "SYMMETRIC", "SYSTEM", "SYSTEM_USER", "TABLE", "THEN", "TIME", "TIMESTAMP", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TRAILING", "TRANSLATION", "TREAT", "TRIGGER", "TRUE", "UESCAPE", "UNION", "UNIQUE", "UNKNOWN", "UNNEST", "UPDATE", "UPPER", "USER", "USING", "VALUE", "VALUES", "VAR_POP", "VAR_SAMP", "VARCHAR", "VARYING", "WHEN", "WHENEVER", "WHERE", "WIDTH_BUCKET", "WINDOW", "WITH", "WITHIN", "WITHOUT", "YEAR"}));

        private Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile;

        internal bool isUpdateComplexValuesStatementSupported;

        internal bool isUpdateComplexValuesIncludingUpdatedTableSupported;


        public virtual void Init(Net.Vpc.Upa.PersistenceUnit persistenceUnit, bool readOnly, Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.Vpc.Upa.Persistence.PersistenceNameConfig nameConfig) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            this.persistenceUnitName = persistenceUnit.ToString();
            this.nameConfig = nameConfig;
            this.readOnly = readOnly;
            this.connectionProfile = connectionProfile;
            Net.Vpc.Upa.Persistence.PersistenceNameStrategy c = persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.Persistence.PersistenceNameStrategy>(typeof(Net.Vpc.Upa.Persistence.PersistenceNameStrategy));
            SetPersistenceNameStrategy(c);
            Net.Vpc.Upa.BeanType b = Net.Vpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(persistenceNameStrategy.GetType());
            b.Inject(persistenceNameStrategy, "persistenceStore", this);
            b.Inject(persistenceNameStrategy, "persistenceUnit", persistenceUnit);
            commitManager.Init(persistenceUnit, this);
        }

        public Net.Vpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager() {
            return marshallManager;
        }


        public virtual System.Collections.Generic.ISet<string> GetSupportedDrivers() {
            return new System.Collections.Generic.HashSet<string>();
        }

        public DefaultPersistenceStore() {
            parameters = new Net.Vpc.Upa.Impl.DefaultProperties();
            Net.Vpc.Upa.Properties map = parameters;
            map.SetBoolean("isComplexSelectSupported", false);
            map.SetBoolean("isUpdateComplexValuesStatementSupported", false);
            map.SetBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
            map.SetBoolean("isFromClauseInUpdateStatementSupported", false);
            map.SetBoolean("isFromClauseInDeleteStatementSupported", false);
            map.SetBoolean("isReferencingSupported", true);
            map.SetBoolean("isViewSupported", false);
            map.SetBoolean("isTopSupported", false);
            //        this.parser = (new SQLParser());
            marshallManager = new Net.Vpc.Upa.Impl.Persistence.DefaultMarshallManager();
            sqlManager = new Net.Vpc.Upa.Impl.Persistence.DefaultSQLManager(marshallManager);
            //        setWrapper(java.util.Date.class,DATETIME);
            //        setWrapper(java.sql.Date.class,DATE);
            //        setWrapper(java.sql.Time.class,TIME);
            //        setWrapper(java.sql.Timestamp.class,TIMESTAMP);
            GetMarshallManager().SetTypeMarshaller(typeof(object), SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.FileData), SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.DataType), SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            Net.Vpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory blobfactory = new Net.Vpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory(SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Date), Net.Vpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_DATE);
            GetMarshallManager().SetTypeMarshallerFactory(typeof(Net.Vpc.Upa.Types.ImageType), blobfactory);
            GetMarshallManager().SetTypeMarshallerFactory(typeof(Net.Vpc.Upa.Types.FileType), blobfactory);
            GetMarshallManager().SetTypeMarshallerFactory(typeof(Net.Vpc.Upa.Types.DataType), blobfactory);
        }

        public virtual bool IsComplexSelectSupported() {
            return GetProperties().GetBoolean("isComplexSelectSupported", false);
        }

        public virtual bool IsFromClauseInUpdateStatementSupported() {
            return GetProperties().GetBoolean("isFromClauseInUpdateStatementSupported", false);
        }

        public virtual bool IsFromClauseInDeleteStatementSupported() {
            return GetProperties().GetBoolean("isFromClauseInDeleteStatementSupported", false);
        }

        public virtual bool IsReferencingSupported() {
            return GetProperties().GetBoolean("isReferencingSupported", false);
        }

        public virtual bool IsViewSupported() {
            return GetProperties().GetBoolean("isViewSupported", false);
        }

        public virtual bool IsTopSupported() {
            return GetProperties().GetBoolean("isTopSupported", false);
        }

        public virtual Net.Vpc.Upa.Persistence.FieldPersister CreatePersistSequenceGenerator(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedException", "createInsertSequenceGenerator");
        }

        public virtual Net.Vpc.Upa.Persistence.FieldPersister CreateUpdateSequenceGenerator(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedException", "createUpdateSequenceGenerator");
        }


        public virtual void CreateStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Persistence.UConnection executor = null;
                try {
                    executor = CreateRootUConnection(context);
                    executor.ExecuteNonQuery("Create Database " + Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(GetConnectionProfile().GetProperties(),Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_NAME), null, null);
                } finally {
                    if (executor != null) {
                        executor.Close();
                    }
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.CreatePersistenceUnitException(e, new Net.Vpc.Upa.Types.I18NString("CreateSchemaFailed"));
            }
        }


        public virtual void DropStorage(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Persistence.UConnection executor = null;
                try {
                    executor = CreateRootUConnection(context);
                    executor.ExecuteNonQuery("Create Database " + Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(GetConnectionProfile().GetProperties(),Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_NAME), null, null);
                } finally {
                    if (executor != null) {
                        executor.Close();
                    }
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.DropPersistenceUnitException(e, new Net.Vpc.Upa.Types.I18NString("DropSchemaFailed"));
            }
        }

        public virtual bool IsDelegationConnectionManagement() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.ConnectionProfile p = GetConnectionProfile();
            string connectionDriver = p.GetConnectionDriver();
            if (connectionDriver == null || (connectionDriver.Trim().Length==0)) {
                connectionDriver = DRIVER_TYPE_DEFAULT;
            }
            //        Map<String, String> properties = p.getProperties();
            if (DRIVER_TYPE_DATASOURCE.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                return true;
            }
            if (DRIVER_TYPE_GENERIC.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                return true;
            }
            if (DRIVER_TYPE_ODBC.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                return true;
            }
            return false;
        }


        public virtual bool IsCreatedStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.UConnection c = null;
            try {
                try {
                    c = CreateConnection();
                } finally {
                    if (c != null) {
                        c.Close();
                    }
                }
                return true;
            } catch (System.Exception e) {
                return false;
            }
        }


        public virtual Net.Vpc.Upa.Properties GetProperties() {
            return parameters;
        }


        public virtual Net.Vpc.Upa.Persistence.ConnectionProfile GetConnectionProfile() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return connectionProfile;
        }

        public virtual System.Data.IDbConnection CreateNativeRootConnection(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser connectionProfileParser = new Net.Vpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser();
            Net.Vpc.Upa.Impl.DefaultProperties p2 = new Net.Vpc.Upa.Impl.DefaultProperties(context.GetPersistenceUnit().GetProperties());
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionProfile> all = connectionProfileParser.ParseEnabled(p2, context.GetPersistenceUnit().GetRootConnectionConfigs(), Net.Vpc.Upa.UPA.ROOT_CONNECTION_STRING);
            if ((all).Count == 0) {
                throw new Net.Vpc.Upa.Exceptions.RootConnectionStringNotFoundException();
            }
            System.Collections.Generic.IList<object[]> errors = new System.Collections.Generic.List<object[]>();
            foreach (Net.Vpc.Upa.Persistence.ConnectionProfile cp in all) {
                try {
                    return CreateNativeConnection(cp);
                } catch (System.Exception e) {
                    errors.Add(new object[] { cp, e });
                }
            }
            foreach (object[] objects in errors) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("RootProfile " + objects[0] + " failed because of " + ((System.Exception) objects[1]).ToString(),null,((System.Exception) objects[1])));
            }
            throw new Net.Vpc.Upa.Exceptions.ConnectionException("CreateNativeRootConnectionFailed");
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection WrapConnection(System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.Persistence.DefaultUConnection(persistenceUnitName, connection, GetMarshallManager());
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection CreateRootUConnection(Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return WrapConnection(CreateNativeRootConnection(context));
        }

        protected internal virtual void PrepareNativeConnection(Net.Vpc.Upa.Persistence.UConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        protected internal virtual void DisposeNativeConnection(System.Data.IDbConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection CreateConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Data.IDbConnection nativeConnection = CreateNativeConnection();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Connection Created {0}",null,nativeConnection));
            System.Collections.Generic.IDictionary<string , object> customAttributes = new System.Collections.Generic.Dictionary<string , object>();
            Net.Vpc.Upa.Persistence.UConnection connection = WrapConnection(nativeConnection);
            PrepareNativeConnection(connection, customAttributes);
            ReconfigureStore(connection);
            return connection;
        }

        protected internal virtual void ReconfigureStore(Net.Vpc.Upa.Persistence.UConnection connection) {
            if (!GetProperties().ContainsKey("configured")) {
                
                isUpdateComplexValuesStatementSupported = GetProperties().GetBoolean("isUpdateComplexValuesStatementSupported", false);
                isUpdateComplexValuesIncludingUpdatedTableSupported = GetProperties().GetBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
            }
        }

        public virtual System.Data.IDbConnection CreateNativeConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateNativeConnection(GetConnectionProfile());
        }

        public virtual System.Data.IDbConnection CreateNativeConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                string connectionDriver = p.GetConnectionDriver();
                if (connectionDriver == null || (connectionDriver.Trim().Length==0)) {
                    connectionDriver = DRIVER_TYPE_DEFAULT;
                }
                if (DRIVER_TYPE_GENERIC.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                    return CreateNativeGenericConnection(p);
                }
                if (DRIVER_TYPE_ODBC.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                    return CreateNativeOdbcConnection(p);
                }
                return CreateCustomPlatformConnection(p);
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }







        protected internal virtual System.Data.IDbConnection CreateNativeGenericConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                System.Collections.Generic.IDictionary<string , string> properties = p.GetProperties();
                string driver = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DRIVER);
                string url = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.URL);
                string user = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.USER_NAME);
                string password = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.PASSWORD);
                return CreatePlatformConnection(driver, url, user, password, properties);
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        protected internal virtual System.Data.IDbConnection CreatePlatformConnection(string driver, string url, string user, string password, System.Collections.Generic.IDictionary<string , string> properties) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                // pooling is managed virtually in C#
                return new System.Data.OleDb.OleDbConnection(url);
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        protected internal virtual System.Data.IDbConnection CreateNativeOdbcConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                System.Collections.Generic.IDictionary<string , string> properties = p.GetProperties();
                string user = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.USER_NAME);
                string password = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.PASSWORD);
                string odbcDriver = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DRIVER);
                string trustedString = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.TRUSTED);
                bool trustedBoolean = false;
                if (trustedString != null) {
                    string trustredLowered = trustedString.ToLower();
                    if (trustredLowered.Equals("true") || trustredLowered.Equals("on") || trustredLowered.Equals("yes")) {
                        trustedBoolean = true;
                    }
                }
                string odbcURL = "jdbc:odbc:";
                if (odbcDriver == null) {
                    string dbname = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_NAME);
                    odbcURL += dbname;
                } else if (odbcDriver.Equals("mdb")) {
                    odbcURL += "Driver={Microsoft Access Driver (*.mdb)}";
                    string dbname = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_PATH);
                    odbcURL += ";DBQ=" + dbname;
                } else if (odbcDriver.Equals("xls")) {
                    odbcURL += "Driver={Microsoft Excel Driver (*.xls)}";
                    string dbname = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_PATH);
                    odbcURL += ";DBQ=" + dbname;
                } else if (odbcDriver.Equals("oracle")) {
                    odbcURL += "Driver={Microsoft ODBC for Oracle}";
                    string server = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS);
                    if (server == null) {
                        server = "localhost";
                    }
                    odbcURL += ";Server=" + server;
                    if (trustedBoolean) {
                        odbcURL += ";Trusted_Connection=Yes";
                    }
                } else if (odbcDriver.Equals("mssqlserver")) {
                    odbcURL += "Driver={SQL Server}";
                    string server = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS);
                    if (server == null) {
                        server = "(local)";
                    }
                    odbcURL += ";Server=" + server;
                    if (trustedBoolean) {
                        odbcURL += ";Trusted_Connection=Yes";
                    }
                }
                return CreatePlatformConnection(null, odbcURL, user, password, properties);
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        public virtual System.Data.IDbConnection CreateCustomPlatformConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("CreateCustomNativeConnectionNotSupported"));
        }

        protected internal virtual int GetMaxJoinCount() {
            return GetProperties().GetInt("maxQueryJoinCount", -1);
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor CreateExecutor(Net.Vpc.Upa.Expressions.Expression baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.Vpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (isUpdateComplexValuesIncludingUpdatedTableSupported || !(baseExpression is Net.Vpc.Upa.Expressions.Update)) {
                return CreateDefaultExecutor(baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context);
            }
            return CreateCustomUpdateExecutor((Net.Vpc.Upa.Expressions.Update) baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context);
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor CreateCustomUpdateExecutor(Net.Vpc.Upa.Expressions.Update baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.Vpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.ExpressionManager expressionManager = context.GetPersistenceUnit().GetExpressionManager();
            Net.Vpc.Upa.Persistence.ResultMetaData metadata = expressionManager.CreateMetaData((Net.Vpc.Upa.Expressions.EntityStatement) baseExpression, defaultFieldFilter);
            System.Collections.Generic.IDictionary<string , object> hints = context.GetHints();
            if (hints == null) {
                hints = new System.Collections.Generic.Dictionary<string , object>();
            }
            Net.Vpc.Upa.Expressions.Update update2 = (Net.Vpc.Upa.Expressions.Update) baseExpression.Copy();
            Net.Vpc.Upa.PersistenceUnit pu = context.GetPersistenceUnit();
            Net.Vpc.Upa.Entity entity = pu.GetEntity(update2.GetEntityName());
            string entityName = entity.GetName();
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.VarVal> complexVals = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.VarVal>();
            for (int i = update2.CountFields() - 1; i >= 0; i--) {
                Net.Vpc.Upa.Expressions.VarVal varVal = update2.GetVarVal(i);
                bool complexSelect = false;
                Net.Vpc.Upa.Expressions.Expression fieldExpression = varVal.GetVal();
                if (null != fieldExpression.FindOne(new Net.Vpc.Upa.Impl.Persistence.ComplexUpdateExpressionFilter(entityName, isUpdateComplexValuesStatementSupported))) {
                    complexSelect = true;
                }
                if (complexSelect) {
                    //complex expression
                    complexVals.Add(varVal);
                    update2.RemoveFieldAt(i);
                }
            }
            System.Collections.Generic.IDictionary<string , object> finalHints = hints;
            return new Net.Vpc.Upa.Impl.Persistence.CustomUpdateQueryExecutor(this, finalHints, update2, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context, complexVals, entity, entityName, metadata);
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.QueryExecutor CreateDefaultExecutor(Net.Vpc.Upa.Expressions.Expression baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.Vpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (defaultFieldFilter == null) {
                defaultFieldFilter = Net.Vpc.Upa.Impl.Util.Filters.Fields2.READ;
            }
            Net.Vpc.Upa.ExpressionManager expressionManager = context.GetPersistenceUnit().GetExpressionManager();
            Net.Vpc.Upa.Persistence.ResultMetaData m = expressionManager.CreateMetaData((Net.Vpc.Upa.Expressions.EntityStatement) baseExpression, defaultFieldFilter);
            Net.Vpc.Upa.Expressions.EntityStatement statement = m.GetStatement();
            //apply parameters
            if (parametersByName != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(parametersByName)) {
                    string name = (entry).Key;
                    object @value = (entry).Value;
                    System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> @params = statement.FindAll(Net.Vpc.Upa.Impl.Uql.Filters.ExpressionFilterFactory.ForParam(name));
                    if ((@params.Count==0)) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Parameter not found " + name);
                    }
                    foreach (Net.Vpc.Upa.Expressions.Expression e in @params) {
                        Net.Vpc.Upa.Expressions.Param p = (Net.Vpc.Upa.Expressions.Param) e;
                        p.SetValue(@value);
                        p.SetUnspecified(false);
                    }
                }
            }
            if (parametersByIndex != null && !(parametersByIndex.Count==0)) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> @params = statement.FindAll(Net.Vpc.Upa.Impl.Uql.Filters.ExpressionFilterFactory.PARAM_FILTER);
                foreach (System.Collections.Generic.KeyValuePair<int? , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<int?,object>>(parametersByIndex)) {
                    int? index = (entry).Key;
                    object @value = (entry).Value;
                    if ((@params).Count <= index) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Parameter not found " + index);
                    }
                    Net.Vpc.Upa.Expressions.Param p = (Net.Vpc.Upa.Expressions.Param) @params[(index).Value];
                    if (p == null) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Parameter not found " + index);
                    }
                    p.SetValue(@value);
                    p.SetUnspecified(false);
                }
            }
            System.Collections.Generic.IDictionary<string , object> hints = context.GetHints();
            if (hints == null) {
                hints = new System.Collections.Generic.Dictionary<string , object>();
            }
            int maxJoinCount = GetMaxJoinCount();
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetExpandEntityFilter(true);
            config.SetExpandFieldFilter(defaultFieldFilter);
            config.SetExpandFields(true);
            config.SetValidate(true);
            config.SetHints(hints);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(statement, config);
            bool reeavluateWithLessJoin = false;
            if (maxJoinCount > 0) {
                foreach (Net.Vpc.Upa.Expressions.CompiledExpression ce in compiledExpression.FindExpressionsList<T>(new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect)))) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect cs = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) ce;
                    if (cs.GetJoins().Length >= maxJoinCount) {
                        log.Warning("this query is very likely to fail. It uses " + cs.GetJoins().Length + " > " + maxJoinCount + " join tables :" + statement);
                        reeavluateWithLessJoin = true;
                        break;
                    }
                }
                if (reeavluateWithLessJoin) {
                    //reset expression
                    config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig().SetExpandEntityFilter(true).SetExpandFieldFilter(defaultFieldFilter).SetExpandFields(true).SetValidate(true);
                    hints[Net.Vpc.Upa.QueryHints.FETCH_STRATEGY]=Net.Vpc.Upa.QueryFetchStrategy.SELECT;
                    config.SetHints(hints);
                    compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(baseExpression, config);
                    reeavluateWithLessJoin = false;
                    foreach (Net.Vpc.Upa.Expressions.CompiledExpression ce in compiledExpression.FindExpressionsList<T>(new Net.Vpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect)))) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect cs = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) ce;
                        if (cs.GetJoins().Length >= maxJoinCount) {
                            log.Warning("this query is very likely to fail. It still uses " + cs.GetJoins().Length + " > " + maxJoinCount + " join tables :" + statement);
                            reeavluateWithLessJoin = true;
                            break;
                        }
                    }
                }
            }
            bool? noTypeTransformO = (bool?) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,Net.Vpc.Upa.QueryHints.NO_TYPE_TRANSFORM);
            bool noTypeTransform = noTypeTransformO == null ? ((bool)(false)) : noTypeTransformO;
            Net.Vpc.Upa.Impl.Persistence.NativeField[] ne = null;
            if (compiledExpression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement cquery = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) compiledExpression;
                ne = new Net.Vpc.Upa.Impl.Persistence.NativeField[cquery.CountFields()];
                for (int i = 0; i < ne.Length; i++) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = cquery.GetField(i);
                    //                String fieldAlias = field.getAliasBinding();
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression1 = field.GetExpression();
                    string binding = field.GetBinding();
                    //                if(binding==null){
                    //                    binding=field.getAlias();
                    //                }
                    string exprString = expression1.ToString();
                    string validName = field.GetName() != null ? field.GetName() : expression1.ToString();
                    if (validName == null) {
                        validName = "#" + i;
                    }
                    Net.Vpc.Upa.Types.DataTypeTransform tc = expression1 == null ? null : Net.Vpc.Upa.Impl.Util.UPAUtils.ResolveDataTypeTransform(expression1);
                    Net.Vpc.Upa.Types.DataTypeTransform c = null;
                    if (tc == null) {
                        throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unable to resolve type for expression : " + expression1);
                    }
                    Net.Vpc.Upa.Field f = null;
                    if (expression1 is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression1;
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod leaf = v.GetDeepChild();
                        object referrer = leaf.GetReferrer();
                        if (referrer is Net.Vpc.Upa.Field) {
                            f = (Net.Vpc.Upa.Field) referrer;
                            c = Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f);
                        }
                    }
                    if (c == null) {
                        c = tc;
                    }
                    bool fieldNoTypeTransform = noTypeTransform;
                    if (!noTypeTransform) {
                        if (f != null) {
                            string fieldKey = Net.Vpc.Upa.QueryHints.NO_TYPE_TRANSFORM + "." + f.GetAbsoluteName();
                            fieldNoTypeTransform = ((bool?) (System.Collections.Generic.EqualityComparer<object>.Default.Equals(Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey),null) ? ((bool?)(false)) : Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey))).Value;
                        }
                    }
                    Net.Vpc.Upa.Types.DataTypeTransform baseTransform = c;
                    c = fieldNoTypeTransform ? ((Net.Vpc.Upa.Types.DataTypeTransform)(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForDataType(baseTransform.GetSourceType()))) : baseTransform;
                    //                String gn=StringUtils.isNullOrEmpty(validName)?validName:(binding+"."+validName);
                    ne[i] = new Net.Vpc.Upa.Impl.Persistence.NativeField(validName, binding, exprString, field.GetIndex(), field.IsExpanded(), f, c);
                }
            } else {
                ne = new Net.Vpc.Upa.Impl.Persistence.NativeField[0];
            }
            string query = this.GetSqlManager().GetSQL(compiledExpression, context, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null));
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> cvalues = compiledExpression.FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.PARAM_FILTER);
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> values = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.Parameter>();
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam e in cvalues) {
                if (e.IsUnspecified()) {
                    throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unspecified Param " + e);
                }
                Net.Vpc.Upa.Impl.Util.ExprTypeInfo ei = Net.Vpc.Upa.Impl.Util.UPAUtils.ResolveExprTypeInfo(e);
                object objectValue = e.GetValue();
                if (ei.GetOldReferrer() != null) {
                    Net.Vpc.Upa.Field oldField = (Net.Vpc.Upa.Field) ei.GetOldReferrer();
                    if (oldField.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType) {
                        Net.Vpc.Upa.Types.ManyToOneType et = (Net.Vpc.Upa.Types.ManyToOneType) oldField.GetDataType();
                        objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().ObjectToId(objectValue);
                    }
                }
                bool fieldNoTypeTransform = noTypeTransform;
                if (ei.GetReferrer() is Net.Vpc.Upa.Field) {
                    if (!noTypeTransform) {
                        Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) ei.GetReferrer();
                        string fieldKey = Net.Vpc.Upa.QueryHints.NO_TYPE_TRANSFORM + "." + field.GetAbsoluteName();
                        fieldNoTypeTransform = ((bool?) (System.Collections.Generic.EqualityComparer<object>.Default.Equals(Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey),null) ? ((bool?)(false)) : Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey))).Value;
                    }
                }
                Net.Vpc.Upa.Types.DataTypeTransform baseTransform = ei.GetTypeTransform();
                Net.Vpc.Upa.Types.DataTypeTransform preferedTransform = fieldNoTypeTransform ? ((Net.Vpc.Upa.Types.DataTypeTransform)(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForDataType(baseTransform.GetSourceType()))) : baseTransform;
                values.Add(new Net.Vpc.Upa.Persistence.DefaultParameter(e.GetName(), objectValue, preferedTransform));
            }
            return new Net.Vpc.Upa.Impl.Persistence.DefaultQueryExecutor(context.GetOperation() == Net.Vpc.Upa.Persistence.ContextOperation.FIND ? Net.Vpc.Upa.Impl.Persistence.NativeStatementType.SELECT : Net.Vpc.Upa.Impl.Persistence.NativeStatementType.UPDATE, hints, query, values, context.GetGeneratedValues(), this, context.GetConnection(), ne, updatable, m);
        }


        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual string GetFieldDeclaration(Net.Vpc.Upa.PrimitiveField field, Net.Vpc.Upa.Persistence.EntityExecutionContext entityPersistenceContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        FormatterInterface formatter = new StringFormatter(32);
            Net.Vpc.Upa.Types.DataTypeTransform cr = Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field);
            //        Class sqlType = cr.getPlatformType();
            //        int length = cr.getScale();
            //        int precision = cr.getPrecision();
            object defaultObject = field.GetDefaultObject();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(GetValidIdentifier(GetColumnName(field)));
            sb.Append('\t');
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = ((Net.Vpc.Upa.Impl.DefaultPersistenceUnit) entityPersistenceContext.GetPersistenceUnit()).CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.FIND, entityPersistenceContext.GetHints());
            sb.Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(cr), context, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            if (defaultObject == null && !cr.GetTargetType().IsNullable()) {
                defaultObject = cr.GetTargetType().GetDefaultValue();
                if (defaultObject == null) {
                    defaultObject = cr.GetTargetType().GetDefaultNonNullValue();
                }
            }
            if (defaultObject != null && !(defaultObject is Net.Vpc.Upa.CustomDefaultObject)) {
                sb.Append(" Default ").Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(defaultObject, cr), context, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            }
            if (!cr.GetTargetType().IsNullable()) {
                sb.Append(" Not Null");
            }
            return sb.ToString();
        }

        public virtual string GetCreateViewStatement(Net.Vpc.Upa.Entity entityManager, Net.Vpc.Upa.Expressions.QueryStatement statement, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Create View ").Append(GetValidIdentifier(GetTableName(entityManager))).Append(" As ").Append("\n").Append("\t");
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) executionContext.GetPersistenceUnit().GetExpressionManager().CompileExpression(statement, null);
            sb.Append(sqlManager.GetSQL(compiledExpression, executionContext, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            return sb.ToString();
        }

        public virtual string GetCreateImplicitViewStatement(Net.Vpc.Upa.Entity table, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Create View ").Append(GetValidIdentifier(GetImplicitViewName(table))).Append(" As ").Append("\n");
            System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> keys = table.GetPrimitiveFields();
            Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select();
            foreach (Net.Vpc.Upa.PrimitiveField key in keys) {
                Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiers = key.GetModifiers();
                if (modifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_STORED)) {
                    Net.Vpc.Upa.Expressions.Expression expression = ((Net.Vpc.Upa.ExpressionFormula) key.GetSelectFormula()).GetExpression();
                    s.Field(expression, GetColumnName(key));
                } else if (modifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT)) {
                    s.Field(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(table.GetName()), key.GetName()));
                }
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext = ((Net.Vpc.Upa.Impl.DefaultPersistenceUnit) executionContext.GetPersistenceUnit()).CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CREATE_PERSISTENCE_NAME, executionContext.GetHints());
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) executionContext.GetPersistenceUnit().GetExpressionManager().CompileExpression(s, null);
            sb.Append(sqlManager.GetSQL(compiledExpression, qlContext, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            return (sb.ToString());
        }

        public virtual string GetCreateRelationshipStatement(Net.Vpc.Upa.Relationship relation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Net.Vpc.Upa.RelationshipRole detailRole = relation.GetSourceRole();
            Net.Vpc.Upa.Entity table = detailRole.GetEntity();
            if (IsView(table)) {
                return null;
            } else if (relation.GetRelationshipType() != Net.Vpc.Upa.RelationshipType.TRANSIENT) {
                sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(table))).Append(" Add Constraint ").Append(GetValidIdentifier(GetRelationshipName(relation))).Append(" Foreign Key (");
                bool first1 = true;
                for (int i = 0; i < relation.Size(); i++) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> fields = detailRole.GetEntity().ToPrimitiveFields<Net.Vpc.Upa.EntityPart>(new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(new[]{(Net.Vpc.Upa.EntityPart) detailRole.GetField(i)}));
                    foreach (Net.Vpc.Upa.Field field in fields) {
                        if (first1) {
                            first1 = false;
                        } else {
                            sb.Append(',');
                        }
                        sb.Append(GetValidIdentifier(GetColumnName(field)));
                    }
                }
                Net.Vpc.Upa.RelationshipRole masterRole = relation.GetTargetRole();
                sb.Append(") References ").Append(GetValidIdentifier(GetTableName(masterRole.GetEntity()))).Append(" (");
                first1 = true;
                for (int i = 0; i < relation.Size(); i++) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> fields = masterRole.GetEntity().ToPrimitiveFields<Net.Vpc.Upa.EntityPart>(new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(new[]{(Net.Vpc.Upa.EntityPart) masterRole.GetField(i)}));
                    foreach (Net.Vpc.Upa.Field field in fields) {
                        if (first1) {
                            first1 = false;
                        } else {
                            sb.Append(',');
                        }
                        sb.Append(GetValidIdentifier(GetColumnName(field)));
                    }
                }
                sb.Append(")");
                return (sb.ToString());
            }
            return null;
        }


        public virtual void SetIdentityConstraintsEnabled(Net.Vpc.Upa.Entity entity, bool enable, Net.Vpc.Upa.Persistence.EntityExecutionContext context) {
            Net.Vpc.Upa.Persistence.UConnection connection = context.GetConnection();
            connection.SetProperty("IdentityConstraintsEnabled." + entity.GetName(), enable);
            if (enable) {
                string s = GetEnableIdentityConstraintsStatement(entity);
                if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(s)) {
                    connection.ExecuteNonQuery(s, null, null);
                }
            } else {
                string s = GetDisableIdentityConstraintsStatement(entity);
                if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(s)) {
                    connection.ExecuteNonQuery(s, null, null);
                }
            }
        }

        public virtual string GetDisableIdentityConstraintsStatement(Net.Vpc.Upa.Entity table) {
            return null;
        }

        public virtual string GetEnableIdentityConstraintsStatement(Net.Vpc.Upa.Entity table) {
            return null;
        }

        public virtual string GetDropRelationshipStatement(Net.Vpc.Upa.Relationship relation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Net.Vpc.Upa.Entity table = relation.GetSourceRole().GetEntity();
            sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(table))).Append(" Drop Constraint ").Append(GetValidIdentifier(GetRelationshipName(relation)));
            return (sb.ToString());
        }

        public virtual string GetDropTablePKConstraintStatement(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entity.GetShield().IsTransient()) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> pk = entity.GetFields(Net.Vpc.Upa.Filters.Fields.Id());
                if ((pk).Count > 0) {
                    sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(entity))).Append(" Drop Constraint ").Append(GetValidIdentifier(GetTablePKName(entity)));
                    return (sb.ToString());
                }
            }
            return null;
        }

        public virtual string GetDropIndexStatement(Net.Vpc.Upa.Index index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Drop");
            sb.Append(" Index ");
            sb.Append(GetValidIdentifier(GetIndexName(index)));
            return sb.ToString();
        }

        public virtual string GetCreateIndexStatement(Net.Vpc.Upa.Index index) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Create");
            if (index.IsUnique()) {
                sb.Append(" Clustered");
            } else {
                sb.Append(" NonClustered");
            }
            sb.Append(" Index ");
            sb.Append(GetValidIdentifier(GetIndexName(index)));
            sb.Append(" On ");
            sb.Append(GetValidIdentifier(GetTableName(index.GetEntity())));
            sb.Append("(");
            bool first = true;
            System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> primitiveFields = index.GetEntity().GetPrimitiveFields(Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByList(index.GetFields())));
            foreach (Net.Vpc.Upa.PrimitiveField field in primitiveFields) {
                if (first) {
                    first = false;
                } else {
                    sb.Append(", ");
                }
                sb.Append(GetColumnName(field));
            }
            sb.Append(")");
            return (sb.ToString());
        }

        private void FillPrimitiveField(Net.Vpc.Upa.Field f, System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> list) {
            if (f is Net.Vpc.Upa.PrimitiveField) {
                Net.Vpc.Upa.PrimitiveField pf = (Net.Vpc.Upa.PrimitiveField) f;
                Net.Vpc.Upa.Types.DataType d = pf.GetDataType();
                if (d is Net.Vpc.Upa.Types.ManyToOneType) {
                    Net.Vpc.Upa.Types.ManyToOneType rd = (Net.Vpc.Upa.Types.ManyToOneType) d;
                    foreach (Net.Vpc.Upa.Field field in rd.GetRelationship().GetSourceRole().GetFields()) {
                        FillPrimitiveField(field, list);
                    }
                } else {
                    list.Add(pf);
                }
            } else if (f is Net.Vpc.Upa.CompoundField) {
                Net.Vpc.Upa.CompoundField c = (Net.Vpc.Upa.CompoundField) f;
                foreach (Net.Vpc.Upa.PrimitiveField t in c.GetFields()) {
                    FillPrimitiveField(t, list);
                }
            }
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.ColumnDesc LoadColumnDesc(Net.Vpc.Upa.PrimitiveField field, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Persistence.ColumnDesc c = new Net.Vpc.Upa.Impl.Persistence.ColumnDesc();
            string tableName = null;
            string columnName = null;
            try {
                
                return c;
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "UnableToLoadColumnDesc", "Column " + tableName + "." + columnName);
            }
        }

        private bool? YesNoToBoolean(string s) {
            if (s == null) {
                return null;
            }
            if ("yes".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "y".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "true".Equals(s,System.StringComparison.InvariantCultureIgnoreCase)) {
                return true;
            }
            if ("no".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "n".Equals(s,System.StringComparison.InvariantCultureIgnoreCase) || "false".Equals(s,System.StringComparison.InvariantCultureIgnoreCase)) {
                return false;
            }
            return null;
        }

        public virtual string GetAlterTableAlterColumnNullStatement(Net.Vpc.Upa.PrimitiveField field, bool nullable) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(field.GetEntity()))).Append(" Alter Column ").Append(GetValidIdentifier(GetColumnName(field))).Append(nullable ? " NULL" : " NOT NULL");
            return sb.ToString();
        }

        public virtual string GetCreateTablePKConstraintStatement(Net.Vpc.Upa.Entity entityManager) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entityManager.GetShield().IsTransient()) {
                System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> pk = new System.Collections.Generic.List<Net.Vpc.Upa.PrimitiveField>();
                foreach (Net.Vpc.Upa.PrimitiveField primitiveField in entityManager.GetPrimitiveFields(Net.Vpc.Upa.Filters.Fields.Id())) {
                    FillPrimitiveField(primitiveField, pk);
                }
                if ((pk).Count > 0) {
                    sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(entityManager))).Append(" Add Constraint ").Append(GetValidIdentifier(GetTablePKName(entityManager))).Append(" Primary Key (");
                    bool first = true;
                    foreach (Net.Vpc.Upa.PrimitiveField primitiveField in pk) {
                        if (first) {
                            first = !first;
                        } else {
                            sb.Append(',');
                        }
                        sb.Append(GetValidIdentifier(GetColumnName(primitiveField)));
                    }
                    sb.Append(')');
                    return (sb.ToString());
                }
            }
            return null;
        }

        public virtual string GetAlterTableAddColumnStatement(Net.Vpc.Upa.PrimitiveField field, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Alter Table ").Append(GetTableName(field.GetEntity())).Append(" Add Column ").Append(GetFieldDeclaration(field, context));
            return s.ToString();
        }

        public virtual string GetCreateTableStatement(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entity.GetShield().IsTransient()) {
                sb.Append("Create Table ").Append(GetValidIdentifier(GetTableName(entity))).Append('(').Append("\n").Append("\t");
                System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> keys = entity.GetPrimitiveFields(Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.TRANSIENT));
                bool firstElement = true;
                foreach (Net.Vpc.Upa.PrimitiveField key in keys) {
                    if (key.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.SELECT_LIVE)) {
                    } else if ((key.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType)) {
                    } else {
                        if (firstElement) {
                            firstElement = false;
                        } else {
                            sb.Append(",").Append("\n").Append("\t");
                        }
                        sb.Append(GetFieldDeclaration(key, context));
                    }
                }
                sb.Append("\n").Append(')');
                return (sb.ToString());
            }
            return null;
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Persistence.DefaultQuery q = new Net.Vpc.Upa.Impl.Persistence.DefaultQuery(query, entity, executionContext);
            ConfigureQuery(q, executionContext);
            return q;
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Persistence.DefaultQuery q = new Net.Vpc.Upa.Impl.Persistence.DefaultQuery(query, null, executionContext);
            ConfigureQuery(q, executionContext);
            return q;
        }

        protected internal virtual void ConfigureQuery(Net.Vpc.Upa.Query q, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) {
            bool lazyListLoadingEnabled = executionContext.GetPersistenceUnit().GetProperties().GetBoolean("Query.LazyListLoadingEnabled", true);
            q.SetLazyListLoadingEnabled(lazyListLoadingEnabled);
        }


        public virtual void CreateStructure(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.QueryScript script = new Net.Vpc.Upa.Expressions.QueryScript();
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> entities = persistenceUnit.GetEntities();
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> queries = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> unions = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> updatableQueries = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            System.Collections.Generic.IList<Net.Vpc.Upa.Entity> viewForEntities = new System.Collections.Generic.List<Net.Vpc.Upa.Entity>();
            foreach (Net.Vpc.Upa.Entity entity in entities) {
                if ((entity.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition))).Count > 0) {
                    updatableQueries.Add(entity);
                } else if ((entity.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0) {
                    queries.Add(entity);
                } else if ((entity.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition))).Count > 0) {
                    unions.Add(entity);
                } else {
                    script.AddStatement(GetCreateTableStatement(entity, executionContext));
                    if (entity.NeedsView()) {
                        viewForEntities.Add(entity);
                    }
                    System.Collections.Generic.IList<Net.Vpc.Upa.Index> indexes = entity.GetIndexes(null);
                    foreach (Net.Vpc.Upa.Index index in indexes) {
                        script.AddStatement(GetCreateIndexStatement(index));
                    }
                }
            }
            foreach (Net.Vpc.Upa.Entity entity in entities) {
                script.AddStatement(GetCreateTablePKConstraintStatement(entity));
            }
            if (IsReferencingSupported()) {
                foreach (Net.Vpc.Upa.Relationship relation in persistenceUnit.GetRelationships()) {
                    script.AddStatement(GetCreateRelationshipStatement(relation));
                }
            }
            if (IsViewSupported()) {
                foreach (Net.Vpc.Upa.Entity entity in viewForEntities) {
                    script.AddStatement(GetCreateImplicitViewStatement(entity, executionContext));
                }
                foreach (Net.Vpc.Upa.Entity entity in updatableQueries) {
                }
                //not yet supported
                foreach (Net.Vpc.Upa.Entity entity in queries) {
                    Net.Vpc.Upa.Persistence.ViewEntityExtension specSupport = (Net.Vpc.Upa.Persistence.ViewEntityExtension) entity.GetExtension<Net.Vpc.Upa.Persistence.ViewEntityExtension>(typeof(Net.Vpc.Upa.Persistence.ViewEntityExtension));
                    script.AddStatement(GetCreateViewStatement(entity, specSupport.GetQuery(), executionContext));
                }
                foreach (Net.Vpc.Upa.Entity entity in unions) {
                    Net.Vpc.Upa.Persistence.UnionEntityExtension specSupport = (Net.Vpc.Upa.Persistence.UnionEntityExtension) entity.GetExtension<Net.Vpc.Upa.Persistence.UnionEntityExtension>(typeof(Net.Vpc.Upa.Persistence.UnionEntityExtension));
                    script.AddStatement(GetCreateViewStatement(entity, specSupport.GetQuery(), executionContext));
                }
            }
            executionContext.GetConnection().ExecuteScript(script, true);
        }

        protected internal virtual Net.Vpc.Upa.Expressions.QueryScript GetCreateRelationshipsScript(Net.Vpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.QueryScript script = new Net.Vpc.Upa.Expressions.QueryScript();
            foreach (Net.Vpc.Upa.Relationship relation in persistenceUnit.GetRelationships()) {
                if (!relation.IsTransient()) {
                    script.AddStatement(GetCreateRelationshipStatement(relation));
                }
            }
            return script;
        }

        protected internal virtual Net.Vpc.Upa.Expressions.QueryScript GetDisableConstraintsScript(Net.Vpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.QueryScript script = new Net.Vpc.Upa.Expressions.QueryScript();
            //        QueryScript disableConstraintsScript = getDisableConstraintsScript();
            //        if (disableConstraintsScript != null) {
            //            script.addScript(disableConstraintsScript);
            //        }
            Net.Vpc.Upa.Expressions.QueryScript dropRelationsScript = GetDropRelationshipsScript(persistenceUnit);
            if (dropRelationsScript != null) {
                script.AddScript(dropRelationsScript);
            }
            //        Script disableIdentityConstraintsScript = getDisableIdentityConstraintsScript();
            //        if (disableIdentityConstraintsScript != null) {
            //            script.addScript(disableIdentityConstraintsScript);
            //        }
            return script;
        }

        protected internal virtual Net.Vpc.Upa.Expressions.QueryScript GetEnableConstraintsScript(Net.Vpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.QueryScript script = new Net.Vpc.Upa.Expressions.QueryScript();
            //        QueryScript enableIdentityConstraintsScript = getEnableIdentityConstraintsScript(database);
            //        if (enableIdentityConstraintsScript != null) {
            //            script.addScript(enableIdentityConstraintsScript);
            //        }
            Net.Vpc.Upa.Expressions.QueryScript createRelationsScript = GetCreateRelationshipsScript(persistenceUnit);
            if (createRelationsScript != null) {
                script.AddScript(createRelationsScript);
            }
            //        QueryScript enableConstraintsScript = getEnableConstraintsScript();
            //        if (enableConstraintsScript != null) {
            //            script.addScript(enableConstraintsScript);
            //        }
            return script;
        }

        public virtual Net.Vpc.Upa.Expressions.QueryScript GetDropRelationshipsScript(Net.Vpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Expressions.QueryScript script = new Net.Vpc.Upa.Expressions.QueryScript();
            foreach (Net.Vpc.Upa.Relationship relation in persistenceUnit.GetRelationships()) {
                if (!relation.IsTransient()) {
                    Net.Vpc.Upa.Entity table = relation.GetSourceRole().GetEntity();
                    if (!IsView(table)) {
                        script.AddStatement(GetDropRelationshipStatement(relation));
                    }
                }
            }
            return script;
        }

        protected internal virtual void RequireTransaction(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session currentSession = executionContext.GetPersistenceUnit().GetCurrentSession();
            if (currentSession != null) {
                Net.Vpc.Upa.Transaction transaction = currentSession.GetParam<T>(executionContext.GetPersistenceUnit(), typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
                if (transaction != null) {
                    return;
                }
            }
            throw new Net.Vpc.Upa.Exceptions.TransactionException(new Net.Vpc.Upa.Types.I18NString("TransactionMandatoryException"));
        }

        public virtual string GetEntityNameFromImplicitViewName(string viewName) {
            return viewName.Substring(3);
        }

        public virtual bool IsImplicitViewName(string s) {
            return s.StartsWith("_V_");
        }

        public virtual bool IsReservedKeyword(string name) {
            return reservedWords.Contains(name.ToUpper());
        }

        protected internal virtual System.Collections.Generic.ISet<string> GetCustomReservedKeywords() {
            return null;
        }


        public virtual void SetNativeConstraintsEnabled(Net.Vpc.Upa.PersistenceUnit persistenceUnit, bool enable) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (enable) {
                persistenceUnit.GetConnection().ExecuteScript(GetEnableConstraintsScript(persistenceUnit), false);
            } else {
                persistenceUnit.GetConnection().ExecuteScript(GetDisableConstraintsScript(persistenceUnit), false);
            }
        }

        public virtual bool IsReadOnly() {
            return readOnly;
        }

        public virtual void SetReadOnly(bool readOnly) {
            this.readOnly = readOnly;
        }


        public virtual string GetPersistenceName(Net.Vpc.Upa.UPAObject persistentObject) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(new Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec(persistentObject, null));
        }


        public virtual string GetPersistenceName(Net.Vpc.Upa.UPAObject persistentObject, Net.Vpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(new Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec(persistentObject, spec));
        }


        public virtual string GetPersistenceName(string name, Net.Vpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(new Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec(name, spec));
        }

        protected internal virtual string GetPersistenceName(Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec e) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string persistenceNameFormat = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec,string>(persistenceNamesMap,e);
            if (persistenceNameFormat == null) {
                object @object = e.GetObject();
                persistenceNameFormat = persistenceNameStrategy.GetPersistenceName(@object, e.GetSpec());
                persistenceNamesMap[e]=persistenceNameFormat;
            }
            return persistenceNameFormat;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceNameStrategy GetPersistenceNameStrategy() {
            return persistenceNameStrategy;
        }

        public virtual void SetPersistenceNameStrategy(Net.Vpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy) {
            if (this.persistenceNameStrategy != null) {
                this.persistenceNameStrategy.Close();
            }
            this.persistenceNameStrategy = persistenceNameStrategy;
            if (this.persistenceNameStrategy != null) {
                this.persistenceNameStrategy.Init(this, nameConfig);
            }
        }

        public virtual string GetTablePKName(Net.Vpc.Upa.Entity o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o, Net.Vpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT);
        }

        public virtual string GetTableName(Net.Vpc.Upa.Entity o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetRelationshipName(Net.Vpc.Upa.Relationship o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetIndexName(Net.Vpc.Upa.Index o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetColumnName(Net.Vpc.Upa.Field o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetImplicitViewName(Net.Vpc.Upa.Entity o) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o, Net.Vpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW);
        }

        public virtual bool IsView(Net.Vpc.Upa.Entity entity) {
            if ((entity.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition))).Count > 0) {
                return true;
            } else if ((entity.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0) {
                return true;
            } else if ((entity.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.UnionEntityExtensionDefinition))).Count > 0) {
                return true;
            }
            return false;
        }


        public virtual void AlterPersistenceUnitAddObject(Net.Vpc.Upa.UPAObject @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            commitManager.AlterPersistenceUnitAddObject(@object);
        }


        public virtual void AlterPersistenceUnitRemoveObject(Net.Vpc.Upa.UPAObject @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("No supported");
        }


        public virtual void AlterPersistenceUnitUpdateObject(Net.Vpc.Upa.UPAObject oldObject, Net.Vpc.Upa.UPAObject newObject, System.Collections.Generic.ISet<string> updates) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("No supported");
        }


        public virtual bool CommitStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return commitManager.CommitStructure();
        }


        public virtual Net.Vpc.Upa.PersistenceState GetPersistenceState(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceState(@object, spec, entityExecutionContext, entityExecutionContext.GetConnection().GetMetadataAccessibleConnection());
        }

        private Net.Vpc.Upa.PersistenceState GetPersistenceState(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.Vpc.Upa.Entity) {
                return GetEntityPersistenceState((Net.Vpc.Upa.Entity) @object, spec, entityExecutionContext, connection);
            }
            if (@object is Net.Vpc.Upa.Field) {
                return GetFieldPersistenceState((Net.Vpc.Upa.Field) @object, spec, entityExecutionContext, connection);
            }
            if (@object is Net.Vpc.Upa.Relationship) {
                return GetRelationshipPersistenceState((Net.Vpc.Upa.Relationship) @object, spec, entityExecutionContext, connection);
            }
            if (@object is Net.Vpc.Upa.Index) {
                return GetIndexPersistenceState((Net.Vpc.Upa.Index) @object, spec, entityExecutionContext, connection);
            }
            throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unknown type " + @object);
        }

        public virtual Net.Vpc.Upa.PersistenceState GetEntityPersistenceState(Net.Vpc.Upa.Entity @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string persistenceNameFormat = GetPersistenceName(@object, spec);
            if (spec == null) {
                Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                if (TableExists(persistenceNameFormat, entityExecutionContext)) {
                    persistenceState = Net.Vpc.Upa.PersistenceState.VALID;
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return persistenceState;
            } else if (Net.Vpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW.Equals(spec)) {
                Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                if (ViewExists(persistenceNameFormat, entityExecutionContext)) {
                    persistenceState = Net.Vpc.Upa.PersistenceState.VALID;
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return persistenceState;
            } else if (Net.Vpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT.Equals(spec)) {
                Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                if (PkConstraintsExists(GetPersistenceName(@object, null), persistenceNameFormat, entityExecutionContext)) {
                    persistenceState = Net.Vpc.Upa.PersistenceState.VALID;
                }
                return persistenceState;
            } else {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unknown Spec for Entity : " + spec);
            }
        }

        public virtual Net.Vpc.Upa.PersistenceState GetIndexPersistenceState(Net.Vpc.Upa.Index @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (spec == null) {
                System.Data.IDataReader rs = null;
                Net.Vpc.Upa.PersistenceState status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                string indexName = GetPersistenceName(@object, spec);
                string tableName = GetPersistenceName(@object.GetEntity(), null);
                bool unique = @object.IsUnique();
                {
                    try {
                        System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                        System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, indexName});
                        return (found.Rows.Count != 0)?Net.Vpc.Upa.PersistenceState.VALID:Net.Vpc.Upa.PersistenceState.DIRTY;
                    } catch (System.Exception ex) {
                        throw CreateUPAException(ex, "UnableToGetEntityPersistenceState", "Index " + tableName + "." + indexName);
                    }
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return status;
            } else {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unknown Spec for Entity : " + spec);
            }
        }

        public virtual Net.Vpc.Upa.PersistenceState GetFieldPersistenceState(Net.Vpc.Upa.Field @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceState status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> fieldModifiers = @object.GetModifiers();
            if ((@object.GetDataType() is Net.Vpc.Upa.Types.ManyToOneType)) {
                //            status = PersistenceState.VALID;
                status = Net.Vpc.Upa.PersistenceState.TRANSIENT;
            } else if (fieldModifiers.Contains(Net.Vpc.Upa.FieldModifier.TRANSIENT)) {
                status = Net.Vpc.Upa.PersistenceState.TRANSIENT;
            } else {
                string tableName = GetPersistenceName(@object.GetEntity());
                string columnName = GetPersistenceName(@object);
                status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                
            }
            if (status != Net.Vpc.Upa.PersistenceState.VALID && status != Net.Vpc.Upa.PersistenceState.TRANSIENT) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("FieldStorageStatus {0} {1}",null,new object[] { @object, status }));
            }
            return status;
        }

        public virtual Net.Vpc.Upa.PersistenceState GetRelationshipPersistenceState(Net.Vpc.Upa.Relationship @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceState status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
            if (IsView(@object.GetTargetRole().GetEntity()) || IsView(@object.GetSourceRole().GetEntity())) {
                status = Net.Vpc.Upa.PersistenceState.TRANSIENT;
            } else {
                string tablePersistenceName = GetPersistenceName(@object.GetSourceRole().GetEntity());
                string persistenceNameFormat = GetPersistenceName(@object);
                if (ForeignKeyExists(tablePersistenceName, persistenceNameFormat, entityExecutionContext)) {
                    status = Net.Vpc.Upa.PersistenceState.VALID;
                }
            }
            if (status != Net.Vpc.Upa.PersistenceState.VALID) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("getRelationPersistenceState {0} {1}",null,new object[] { @object, status }));
            }
            return status;
        }

        protected internal virtual Net.Vpc.Upa.Exceptions.UPAException CreateUPAException(System.Exception ex, string mgId, params object [] parameters) {
            return new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString(mgId), parameters);
        }

        public virtual void RevalidateModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public Net.Vpc.Upa.Impl.Persistence.SQLManager GetSqlManager() {
            return sqlManager;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator CreateIdentifierStoreTranslator(Net.Vpc.Upa.Persistence.UConnection connection) /* throws System.Exception */  {
            
            return Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslators.UPPER;
        }

        protected internal virtual bool TableExists(string persistenceNameFormat, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            try {
                System.Data.IDataReader rs = null;
                System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                System.Data.DataTable found = dconnection.GetSchema("Tables", new string[] { null, null, persistenceNameFormat, "BASE TYPE" });
                return (found.Rows.Count != 0);
                }
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceNameFormat);
            }
            return false;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator GetIdentifierStoreTranslator() /* throws System.Exception */  {
            return identifierStoreTranslator;
        }

        protected internal virtual bool ViewExists(string persistenceNameFormat, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            try {
                System.Data.IDataReader rs = null;
                System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                System.Data.DataTable found = dconnection.GetSchema("Tables", new string[] { null, null, persistenceNameFormat, "VIEW" });
                return (found.Rows.Count != 0);
                }
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "UnableToGetEntityPersistenceState", "Table " + persistenceNameFormat);
            }
            return false;
        }

        protected internal virtual bool PkConstraintsExists(string tableName, string constraintsName, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            try {
                System.Data.IDataReader rs = null;
                System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                System.Data.DataTable found = dconnection.GetSchema("IndexColumns", new string[] { connection.Database, null, tableName, constraintsName, null });
                return (found.Rows.Count != 0);
                }
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "UnableToGetEntityPersistenceState", "PK Constraints " + tableName + "." + constraintsName);
            }
            return false;
        }

        protected internal virtual bool ForeignKeyExists(string tableName, string constraintName, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            try {
                System.Data.IDataReader rs = null;
                System.Data.IDbConnection connection = entityExecutionContext.GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                System.Data.DataTable found = dconnection.GetSchema("ForeignKeys", new string[] { connection.Database, null, tableName, constraintName });
                return (found.Rows.Count != 0);
                }
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "UnableToGetEntityPersistenceState", "Column " + tableName + "." + constraintName);
            }
            return false;
        }

        public virtual string GetIdentifierQuoteString() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return identifierQuoteString;
        }

        public virtual string GetValidIdentifier(string s) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (IsReservedKeyword(s)) {
                string r = GetIdentifierQuoteString();
                if (r != null) {
                    return r + identifierStoreTranslator.TranslateIdentifier(s) + r;
                }
            }
            return s;
        }

        public virtual bool IsAccessible(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile) {
            System.Data.IDbConnection c = null;
            try {
                c = CreateNativeConnection(connectionProfile);
                return true;
            } catch (System.Exception e) {
                return false;
            } finally {
                if (c != null) {
                    try {
                        c.Close();
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                }
            }
        }

        public virtual void CheckAccessible(Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile) {
            System.Data.IDbConnection c = null;
            try {
                c = CreateNativeConnection(connectionProfile);
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("StoreNotAccessibleException"), connectionProfile);
            } finally {
                if (c != null) {
                    try {
                        c.Close();
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                }
            }
        }
    }
}
