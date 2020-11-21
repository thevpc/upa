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



namespace Net.TheVpc.Upa.Impl.Persistence
{



    public partial class DefaultPersistenceStore : Net.TheVpc.Upa.Persistence.PersistenceStore {

        public const string DRIVER_TYPE_EMBEDDED = "EMBEDDED";

        public const string DRIVER_TYPE_DEFAULT = "DEFAULT";

        public const string DRIVER_TYPE_DATASOURCE = "DATASOURCE";

        public const string DRIVER_TYPE_GENERIC = "GENERIC";

        public const string DRIVER_TYPE_ODBC = "ODBC";

        protected internal static readonly Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER = new Net.TheVpc.Upa.Impl.Persistence.Shared.DefaultSerializablePlatformObjectMarshaller();

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore)).FullName);

        protected internal const string COMPLEX_SELECT_PERSIST = "Store.COMPLEX_SELECT_PERSIST";

        protected internal const string COMPLEX_SELECT_MERGE = "Store.COMPLEX_SELECT_MERGE";

        public static bool DO_WARNINGS = false;

        private bool readOnly;

        private string persistenceUnitName;

        private Net.TheVpc.Upa.ObjectFactory factory;

        private Net.TheVpc.Upa.Impl.Persistence.IdentifierStoreTranslator identifierStoreTranslator;









        private Net.TheVpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy;

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec , string> persistenceNamesMap = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec , string>();

        private Net.TheVpc.Upa.Properties parameters = new Net.TheVpc.Upa.Impl.DefaultProperties();

        private Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager commitManager = new Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager();

        private Net.TheVpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        private Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager;

        private string identifierQuoteString;

        private Net.TheVpc.Upa.Persistence.PersistenceNameConfig nameConfig;

        private System.Collections.Generic.HashSet<string> reservedWords;

        private static System.Collections.Generic.HashSet<string> SQL2003_RESERVED_WORDS = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(new[]{"ADD", "ALL", "ALLOCATE", "ALTER", "AND", "ANY", "ARE", "ARRAY", "AS", "ASENSITIVE", "ASYMMETRIC", "AT", "ATOMIC", "AUTHORIZATION", "BEGIN", "BETWEEN", "BIGINT", "BINARY", "BLOB", "BOOLEAN", "BOTH", "BY", "CALL", "CALLED", "CASCADED", "CASE", "CAST", "CHAR", "CHARACTER", "CHECK", "CLOB", "CLOSE", "COLLATE", "COLUMN", "COMMIT", "CONNECT", "CONSTRAINT", "CONTINUE", "CORRESPONDING", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_DATE", "CURRENT_DEFAULT_TRANSFORM_GROUP", "CURRENT_PATH", "CURRENT_ROLE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_TRANSFORM_GROUP_FOR_TYPE", "CURRENT_USER", "CURSOR", "CYCLE", "DATE", "DAY", "DEALLOCATE", "DEC", "DECIMAL", "DECLARE", "DEFAULT", "DELETE", "DEREF", "DESCRIBE", "DETERMINISTIC", "DISCONNECT", "DISTINCT", "DOUBLE", "DROP", "DYNAMIC", "EACH", "ELEMENT", "ELSE", "END", "END-EXEC", "ESCAPE", "EXCEPT", "EXEC", "EXECUTE", "EXISTS", "EXTERNAL", "FALSE", "FETCH", "FILTER", "FLOAT", "FOR", "FOREIGN", "FREE", "FROM", "FULL", "FUNCTION", "GET", "GLOBAL", "GRANT", "GROUP", "GROUPING", "HAVING", "HOLD", "HOUR", "IDENTITY", "IMMEDIATE", "IN", "INDICATOR", "INNER", "INOUT", "INPUT", "INSENSITIVE", "INSERT", "INT", "INTEGER", "INTERSECT", "INTERVAL", "INTO", "IS", "ISOLATION", "JOIN", "LANGUAGE", "LARGE", "LATERAL", "LEADING", "LEFT", "LIKE", "LOCAL", "LOCALTIME", "LOCALTIMESTAMP", "MATCH", "MEMBER", "MERGE", "METHOD", "MINUTE", "MODIFIES", "MODULE", "MONTH", "MULTISET", "NATIONAL", "NATURAL", "NCHAR", "NCLOB", "NEXT", "NEW", "NO", "NONE", "NOT", "NULL", "NUMERIC", "OF", "OLD", "ON", "ONLY", "OPEN", "OR", "ORDER", "OUT", "OUTER", "OUTPUT", "OVER", "OVERLAPS", "PARAMETER", "PARTITION", "PRECISION", "PREPARE", "PRIMARY", "PROCEDURE", "RANGE", "READS", "REAL", "RECURSIVE", "REF", "REFERENCES", "REFERENCING", "REGR_AVGX", "REGR_AVGY", "REGR_COUNT", "REGR_INTERCEPT", "REGR_R2", "REGR_SLOPE", "REGR_SXX", "REGR_SXY", "REGR_SYY", "RELEASE", "RESULT", "RETURN", "RETURNS", "REVOKE", "RIGHT", "ROLLBACK", "ROLLUP", "ROW", "ROWS", "SAVEPOINT", "SCROLL", "SEARCH", "SECOND", "SELECT", "SENSITIVE", "SESSION_USER", "SET", "SIMILAR", "SMALLINT", "SOME", "SPECIFIC", "SPECIFICTYPE", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "START", "STATIC", "SUBMULTISET", "SYMMETRIC", "SYSTEM", "SYSTEM_USER", "TABLE", "THEN", "TIME", "TIMESTAMP", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TRAILING", "TRANSLATION", "TREAT", "TRIGGER", "TRUE", "UESCAPE", "UNION", "UNIQUE", "UNKNOWN", "UNNEST", "UPDATE", "UPPER", "USER", "USING", "VALUE", "VALUES", "VAR_POP", "VAR_SAMP", "VARCHAR", "VARYING", "WHEN", "WHENEVER", "WHERE", "WIDTH_BUCKET", "WINDOW", "WITH", "WITHIN", "WITHOUT", "YEAR"}));

        private Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile;

        internal bool isUpdateComplexValuesStatementSupported;

        internal bool isUpdateComplexValuesIncludingUpdatedTableSupported;


        public virtual void Init(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, bool readOnly, Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile, Net.TheVpc.Upa.Persistence.PersistenceNameConfig nameConfig) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            this.persistenceUnitName = persistenceUnit.ToString();
            this.nameConfig = nameConfig;
            this.readOnly = readOnly;
            this.connectionProfile = connectionProfile;
            Net.TheVpc.Upa.Persistence.PersistenceNameStrategy c = persistenceUnit.GetFactory().CreateObject<Net.TheVpc.Upa.Persistence.PersistenceNameStrategy>(typeof(Net.TheVpc.Upa.Persistence.PersistenceNameStrategy));
            SetPersistenceNameStrategy(c);
            Net.TheVpc.Upa.BeanType b = Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository.GetInstance().GetBeanType(persistenceNameStrategy.GetType());
            b.Inject(persistenceNameStrategy, "persistenceStore", this);
            b.Inject(persistenceNameStrategy, "persistenceUnit", persistenceUnit);
            commitManager.Init(persistenceUnit, this);
        }

        public Net.TheVpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager() {
            return marshallManager;
        }


        public virtual System.Collections.Generic.ISet<string> GetSupportedDrivers() {
            return new System.Collections.Generic.HashSet<string>();
        }

        public DefaultPersistenceStore() {
            parameters = new Net.TheVpc.Upa.Impl.DefaultProperties();
            Net.TheVpc.Upa.Properties map = parameters;
            map.SetBoolean("isComplexSelectSupported", false);
            map.SetBoolean("isUpdateComplexValuesStatementSupported", false);
            map.SetBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
            map.SetBoolean("isFromClauseInUpdateStatementSupported", false);
            map.SetBoolean("isFromClauseInDeleteStatementSupported", false);
            map.SetBoolean("isReferencingSupported", true);
            map.SetBoolean("isViewSupported", false);
            map.SetBoolean("isTopSupported", false);
            //        this.parser = (new SQLParser());
            marshallManager = new Net.TheVpc.Upa.Impl.Persistence.DefaultMarshallManager();
            sqlManager = new Net.TheVpc.Upa.Impl.Persistence.DefaultSQLManager(marshallManager);
            //        setWrapper(java.util.Date.class,DATETIME);
            //        setWrapper(java.sql.Date.class,DATE);
            //        setWrapper(java.sql.Time.class,TIME);
            //        setWrapper(java.sql.Timestamp.class,TIMESTAMP);
            GetMarshallManager().SetTypeMarshaller(typeof(object), SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            GetMarshallManager().SetTypeMarshaller(typeof(Net.TheVpc.Upa.Types.FileData), SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            GetMarshallManager().SetTypeMarshaller(typeof(Net.TheVpc.Upa.Types.DataType), SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            Net.TheVpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory blobfactory = new Net.TheVpc.Upa.Impl.Persistence.Shared.ConstantDataMarshallerFactory(SERIALIZABLE_OBJECT_PLATFORM_MARSHALLER);
            GetMarshallManager().SetTypeMarshaller(typeof(Net.TheVpc.Upa.Types.Date), Net.TheVpc.Upa.Impl.Persistence.Shared.TypeMarshallerUtils.SQL_DATE);
            GetMarshallManager().SetTypeMarshallerFactory(typeof(Net.TheVpc.Upa.Types.ImageType), blobfactory);
            GetMarshallManager().SetTypeMarshallerFactory(typeof(Net.TheVpc.Upa.Types.FileType), blobfactory);
            GetMarshallManager().SetTypeMarshallerFactory(typeof(Net.TheVpc.Upa.Types.DataType), blobfactory);
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

        public virtual Net.TheVpc.Upa.Persistence.FieldPersister CreatePersistSequenceGenerator(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            throw new Net.TheVpc.Upa.Exceptions.UPAException("UnsupportedException", "createInsertSequenceGenerator");
        }

        public virtual Net.TheVpc.Upa.Persistence.FieldPersister CreateUpdateSequenceGenerator(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            throw new Net.TheVpc.Upa.Exceptions.UPAException("UnsupportedException", "createUpdateSequenceGenerator");
        }


        public virtual void CreateStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                Net.TheVpc.Upa.Persistence.UConnection executor = null;
                try {
                    executor = CreateRootUConnection(context);
                    executor.ExecuteNonQuery("Create Database " + Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(GetConnectionProfile().GetProperties(),Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_NAME), null, null);
                } finally {
                    if (executor != null) {
                        executor.Close();
                    }
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.CreatePersistenceUnitException(e, new Net.TheVpc.Upa.Types.I18NString("CreateSchemaFailed"));
            }
        }


        public virtual void DropStorage(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                Net.TheVpc.Upa.Persistence.UConnection executor = null;
                try {
                    executor = CreateRootUConnection(context);
                    executor.ExecuteNonQuery("Create Database " + Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(GetConnectionProfile().GetProperties(),Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_NAME), null, null);
                } finally {
                    if (executor != null) {
                        executor.Close();
                    }
                }
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.DropPersistenceUnitException(e, new Net.TheVpc.Upa.Types.I18NString("DropSchemaFailed"));
            }
        }

        public virtual bool IsDelegationConnectionManagement() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.ConnectionProfile p = GetConnectionProfile();
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


        public virtual bool IsCreatedStorage() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.UConnection c = null;
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


        public virtual Net.TheVpc.Upa.Properties GetProperties() {
            return parameters;
        }


        public virtual Net.TheVpc.Upa.Persistence.ConnectionProfile GetConnectionProfile() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return connectionProfile;
        }

        public virtual System.Data.IDbConnection CreateNativeRootConnection(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser connectionProfileParser = new Net.TheVpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser();
            Net.TheVpc.Upa.Impl.DefaultProperties p2 = new Net.TheVpc.Upa.Impl.DefaultProperties(context.GetPersistenceUnit().GetProperties());
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ConnectionProfile> all = connectionProfileParser.ParseEnabled(p2, context.GetPersistenceUnit().GetRootConnectionConfigs(), Net.TheVpc.Upa.UPA.ROOT_CONNECTION_STRING);
            if ((all).Count == 0) {
                throw new Net.TheVpc.Upa.Exceptions.RootConnectionStringNotFoundException();
            }
            System.Collections.Generic.IList<object[]> errors = new System.Collections.Generic.List<object[]>();
            foreach (Net.TheVpc.Upa.Persistence.ConnectionProfile cp in all) {
                try {
                    return CreateNativeConnection(cp);
                } catch (System.Exception e) {
                    errors.Add(new object[] { cp, e });
                }
            }
            foreach (object[] objects in errors) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("RootProfile " + objects[0] + " failed because of " + ((System.Exception) objects[1]).ToString(),null,((System.Exception) objects[1])));
            }
            throw new Net.TheVpc.Upa.Exceptions.ConnectionException("CreateNativeRootConnectionFailed");
        }

        public virtual Net.TheVpc.Upa.Persistence.UConnection WrapConnection(System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return new Net.TheVpc.Upa.Impl.Persistence.DefaultUConnection(persistenceUnitName, connection, GetMarshallManager());
        }

        public virtual Net.TheVpc.Upa.Persistence.UConnection CreateRootUConnection(Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return WrapConnection(CreateNativeRootConnection(context));
        }

        protected internal virtual void PrepareNativeConnection(Net.TheVpc.Upa.Persistence.UConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }

        protected internal virtual void DisposeNativeConnection(System.Data.IDbConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.TheVpc.Upa.Persistence.UConnection CreateConnection() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Data.IDbConnection nativeConnection = CreateNativeConnection();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Connection Created {0}",null,nativeConnection));
            System.Collections.Generic.IDictionary<string , object> customAttributes = new System.Collections.Generic.Dictionary<string , object>();
            Net.TheVpc.Upa.Persistence.UConnection connection = WrapConnection(nativeConnection);
            PrepareNativeConnection(connection, customAttributes);
            ReconfigureStore(connection);
            return connection;
        }

        protected internal virtual void ReconfigureStore(Net.TheVpc.Upa.Persistence.UConnection connection) {
            if (!GetProperties().ContainsKey("configured")) {
                
                isUpdateComplexValuesStatementSupported = GetProperties().GetBoolean("isUpdateComplexValuesStatementSupported", false);
                isUpdateComplexValuesIncludingUpdatedTableSupported = GetProperties().GetBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
            }
        }

        public virtual System.Data.IDbConnection CreateNativeConnection() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return CreateNativeConnection(GetConnectionProfile());
        }

        public virtual System.Data.IDbConnection CreateNativeConnection(Net.TheVpc.Upa.Persistence.ConnectionProfile p) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }







        protected internal virtual System.Data.IDbConnection CreateNativeGenericConnection(Net.TheVpc.Upa.Persistence.ConnectionProfile p) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                System.Collections.Generic.IDictionary<string , string> properties = p.GetProperties();
                string driver = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.DRIVER);
                string url = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.URL);
                string user = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.USER_NAME);
                string password = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.PASSWORD);
                return CreatePlatformConnection(driver, url, user, password, properties);
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        protected internal virtual System.Data.IDbConnection CreatePlatformConnection(string driver, string url, string user, string password, System.Collections.Generic.IDictionary<string , string> properties) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                // pooling is managed virtually in C#
                return new System.Data.OleDb.OleDbConnection(url);
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        protected internal virtual System.Data.IDbConnection CreateNativeOdbcConnection(Net.TheVpc.Upa.Persistence.ConnectionProfile p) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            try {
                System.Collections.Generic.IDictionary<string , string> properties = p.GetProperties();
                string user = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.USER_NAME);
                string password = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.PASSWORD);
                string odbcDriver = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.DRIVER);
                string trustedString = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.TRUSTED);
                bool trustedBoolean = false;
                if (trustedString != null) {
                    string trustredLowered = trustedString.ToLower();
                    if (trustredLowered.Equals("true") || trustredLowered.Equals("on") || trustredLowered.Equals("yes")) {
                        trustedBoolean = true;
                    }
                }
                string odbcURL = "jdbc:odbc:";
                if (odbcDriver == null) {
                    string dbname = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_NAME);
                    odbcURL += dbname;
                } else if (odbcDriver.Equals("mdb")) {
                    odbcURL += "Driver={Microsoft Access Driver (*.mdb)}";
                    string dbname = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PATH);
                    odbcURL += ";DBQ=" + dbname;
                } else if (odbcDriver.Equals("xls")) {
                    odbcURL += "Driver={Microsoft Excel Driver (*.xls)}";
                    string dbname = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.DATABASE_PATH);
                    odbcURL += ";DBQ=" + dbname;
                } else if (odbcDriver.Equals("oracle")) {
                    odbcURL += "Driver={Microsoft ODBC for Oracle}";
                    string server = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS);
                    if (server == null) {
                        server = "localhost";
                    }
                    odbcURL += ";Server=" + server;
                    if (trustedBoolean) {
                        odbcURL += ";Trusted_Connection=Yes";
                    }
                } else if (odbcDriver.Equals("mssqlserver")) {
                    odbcURL += "Driver={SQL Server}";
                    string server = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.TheVpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS);
                    if (server == null) {
                        server = "(local)";
                    }
                    odbcURL += ";Server=" + server;
                    if (trustedBoolean) {
                        odbcURL += ";Trusted_Connection=Yes";
                    }
                }
                return CreatePlatformConnection(null, odbcURL, user, password, properties);
            } catch (Net.TheVpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        public virtual System.Data.IDbConnection CreateCustomPlatformConnection(Net.TheVpc.Upa.Persistence.ConnectionProfile p) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            throw new Net.TheVpc.Upa.Exceptions.UPAException(new Net.TheVpc.Upa.Types.I18NString("CreateCustomNativeConnectionNotSupported"));
        }

        protected internal virtual int GetMaxJoinCount() {
            return GetProperties().GetInt("maxQueryJoinCount", -1);
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor CreateExecutor(Net.TheVpc.Upa.Expressions.Expression baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.TheVpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (isUpdateComplexValuesIncludingUpdatedTableSupported || !(baseExpression is Net.TheVpc.Upa.Expressions.Update)) {
                return CreateDefaultExecutor(baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context);
            }
            return CreateCustomUpdateExecutor((Net.TheVpc.Upa.Expressions.Update) baseExpression, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context);
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor CreateCustomUpdateExecutor(Net.TheVpc.Upa.Expressions.Update baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.TheVpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.ExpressionManager expressionManager = context.GetPersistenceUnit().GetExpressionManager();
            Net.TheVpc.Upa.Persistence.ResultMetaData metadata = expressionManager.CreateMetaData((Net.TheVpc.Upa.Expressions.EntityStatement) baseExpression, defaultFieldFilter);
            System.Collections.Generic.IDictionary<string , object> hints = context.GetHints();
            if (hints == null) {
                hints = new System.Collections.Generic.Dictionary<string , object>();
            }
            Net.TheVpc.Upa.Expressions.Update update2 = (Net.TheVpc.Upa.Expressions.Update) baseExpression.Copy();
            Net.TheVpc.Upa.PersistenceUnit pu = context.GetPersistenceUnit();
            Net.TheVpc.Upa.Entity entity = pu.GetEntity(update2.GetEntityName());
            string entityName = entity.GetName();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.VarVal> complexVals = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.VarVal>();
            for (int i = update2.CountFields() - 1; i >= 0; i--) {
                Net.TheVpc.Upa.Expressions.VarVal varVal = update2.GetVarVal(i);
                bool complexSelect = false;
                Net.TheVpc.Upa.Expressions.Expression fieldExpression = varVal.GetVal();
                if (null != fieldExpression.FindOne(new Net.TheVpc.Upa.Impl.Persistence.ComplexUpdateExpressionFilter(entityName, isUpdateComplexValuesStatementSupported))) {
                    complexSelect = true;
                }
                if (complexSelect) {
                    //complex expression
                    complexVals.Add(varVal);
                    update2.RemoveFieldAt(i);
                }
            }
            System.Collections.Generic.IDictionary<string , object> finalHints = hints;
            return new Net.TheVpc.Upa.Impl.Persistence.CustomUpdateQueryExecutor(this, finalHints, update2, parametersByName, parametersByIndex, updatable, defaultFieldFilter, context, complexVals, entity, entityName, metadata);
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor CreateDefaultExecutor(Net.TheVpc.Upa.Expressions.Expression baseExpression, System.Collections.Generic.IDictionary<string , object> parametersByName, System.Collections.Generic.IDictionary<int? , object> parametersByIndex, bool updatable, Net.TheVpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (defaultFieldFilter == null) {
                defaultFieldFilter = Net.TheVpc.Upa.Impl.Util.Filters.Fields2.READ;
            }
            Net.TheVpc.Upa.ExpressionManager expressionManager = context.GetPersistenceUnit().GetExpressionManager();
            Net.TheVpc.Upa.Persistence.ResultMetaData m = expressionManager.CreateMetaData((Net.TheVpc.Upa.Expressions.EntityStatement) baseExpression, defaultFieldFilter);
            Net.TheVpc.Upa.Expressions.EntityStatement statement = m.GetStatement();
            //apply parameters
            if (parametersByName != null) {
                foreach (System.Collections.Generic.KeyValuePair<string , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<string,object>>(parametersByName)) {
                    string name = (entry).Key;
                    object @value = (entry).Value;
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> @params = statement.FindAll(Net.TheVpc.Upa.Impl.Uql.Filters.ExpressionFilterFactory.ForParam(name));
                    if ((@params.Count==0)) {
                        throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Parameter not found " + name);
                    }
                    foreach (Net.TheVpc.Upa.Expressions.Expression e in @params) {
                        Net.TheVpc.Upa.Expressions.Param p = (Net.TheVpc.Upa.Expressions.Param) e;
                        p.SetValue(@value);
                        p.SetUnspecified(false);
                    }
                }
            }
            if (parametersByIndex != null && !(parametersByIndex.Count==0)) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> @params = statement.FindAll(Net.TheVpc.Upa.Impl.Uql.Filters.ExpressionFilterFactory.PARAM_FILTER);
                foreach (System.Collections.Generic.KeyValuePair<int? , object> entry in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<int?,object>>(parametersByIndex)) {
                    int? index = (entry).Key;
                    object @value = (entry).Value;
                    if ((@params).Count <= index) {
                        throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Parameter not found " + index);
                    }
                    Net.TheVpc.Upa.Expressions.Param p = (Net.TheVpc.Upa.Expressions.Param) @params[(index).Value];
                    if (p == null) {
                        throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Parameter not found " + index);
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
            Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetExpandEntityFilter(true);
            config.SetExpandFieldFilter(defaultFieldFilter);
            config.SetExpandFields(true);
            config.SetValidate(true);
            config.SetHints(hints);
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(statement, config);
            bool reeavluateWithLessJoin = false;
            if (maxJoinCount > 0) {
                foreach (Net.TheVpc.Upa.Expressions.CompiledExpression ce in compiledExpression.FindExpressionsList<T>(new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect)))) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect cs = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) ce;
                    if (cs.GetJoins().Length >= maxJoinCount) {
                        log.Warning("this query is very likely to fail. It uses " + cs.GetJoins().Length + " > " + maxJoinCount + " join tables :" + statement);
                        reeavluateWithLessJoin = true;
                        break;
                    }
                }
                if (reeavluateWithLessJoin) {
                    //reset expression
                    config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig().SetExpandEntityFilter(true).SetExpandFieldFilter(defaultFieldFilter).SetExpandFields(true).SetValidate(true);
                    hints[Net.TheVpc.Upa.QueryHints.FETCH_STRATEGY]=Net.TheVpc.Upa.QueryFetchStrategy.SELECT;
                    config.SetHints(hints);
                    compiledExpression = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) expressionManager.CompileExpression(baseExpression, config);
                    reeavluateWithLessJoin = false;
                    foreach (Net.TheVpc.Upa.Expressions.CompiledExpression ce in compiledExpression.FindExpressionsList<T>(new Net.TheVpc.Upa.Impl.Uql.Compiledfilters.TypeCompiledExpressionFilter(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect)))) {
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect cs = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) ce;
                        if (cs.GetJoins().Length >= maxJoinCount) {
                            log.Warning("this query is very likely to fail. It still uses " + cs.GetJoins().Length + " > " + maxJoinCount + " join tables :" + statement);
                            reeavluateWithLessJoin = true;
                            break;
                        }
                    }
                }
            }
            bool? noTypeTransformO = (bool?) Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,Net.TheVpc.Upa.QueryHints.NO_TYPE_TRANSFORM);
            bool noTypeTransform = noTypeTransformO == null ? ((bool)(false)) : noTypeTransformO;
            Net.TheVpc.Upa.Impl.Persistence.NativeField[] ne = null;
            if (compiledExpression is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) {
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement cquery = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) compiledExpression;
                ne = new Net.TheVpc.Upa.Impl.Persistence.NativeField[cquery.CountFields()];
                for (int i = 0; i < ne.Length; i++) {
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = cquery.GetField(i);
                    //                String fieldAlias = field.getAliasBinding();
                    Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression1 = field.GetExpression();
                    string binding = field.GetBinding();
                    //                if(binding==null){
                    //                    binding=field.getAlias();
                    //                }
                    string exprString = expression1.ToString();
                    string validName = field.GetName() != null ? field.GetName() : expression1.ToString();
                    if (validName == null) {
                        validName = "#" + i;
                    }
                    Net.TheVpc.Upa.Types.DataTypeTransform tc = expression1 == null ? null : Net.TheVpc.Upa.Impl.Util.UPAUtils.ResolveDataTypeTransform(expression1);
                    Net.TheVpc.Upa.Types.DataTypeTransform c = null;
                    if (tc == null) {
                        throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Unable to resolve type for expression : " + expression1);
                    }
                    Net.TheVpc.Upa.Field f = null;
                    if (expression1 is Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression1;
                        Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod leaf = v.GetDeepChild();
                        object referrer = leaf.GetReferrer();
                        if (referrer is Net.TheVpc.Upa.Field) {
                            f = (Net.TheVpc.Upa.Field) referrer;
                            c = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f);
                        }
                    }
                    if (c == null) {
                        c = tc;
                    }
                    bool fieldNoTypeTransform = noTypeTransform;
                    if (!noTypeTransform) {
                        if (f != null) {
                            string fieldKey = Net.TheVpc.Upa.QueryHints.NO_TYPE_TRANSFORM + "." + f.GetAbsoluteName();
                            fieldNoTypeTransform = ((bool?) (System.Collections.Generic.EqualityComparer<object>.Default.Equals(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey),null) ? ((bool?)(false)) : Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey))).Value;
                        }
                    }
                    Net.TheVpc.Upa.Types.DataTypeTransform baseTransform = c;
                    c = fieldNoTypeTransform ? ((Net.TheVpc.Upa.Types.DataTypeTransform)(Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForDataType(baseTransform.GetSourceType()))) : baseTransform;
                    //                String gn=StringUtils.isNullOrEmpty(validName)?validName:(binding+"."+validName);
                    ne[i] = new Net.TheVpc.Upa.Impl.Persistence.NativeField(validName, binding, exprString, field.GetIndex(), field.IsExpanded(), f, c);
                }
            } else {
                ne = new Net.TheVpc.Upa.Impl.Persistence.NativeField[0];
            }
            string query = this.GetSqlManager().GetSQL(compiledExpression, context, new Net.TheVpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null));
            System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> cvalues = compiledExpression.FindExpressionsList<T>(Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.PARAM_FILTER);
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> values = new System.Collections.Generic.List<Net.TheVpc.Upa.Persistence.Parameter>();
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledParam e in cvalues) {
                if (e.IsUnspecified()) {
                    throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Unspecified Param " + e);
                }
                Net.TheVpc.Upa.Impl.Util.ExprTypeInfo ei = Net.TheVpc.Upa.Impl.Util.UPAUtils.ResolveExprTypeInfo(e);
                object objectValue = e.GetValue();
                if (ei.GetOldReferrer() != null) {
                    Net.TheVpc.Upa.Field oldField = (Net.TheVpc.Upa.Field) ei.GetOldReferrer();
                    if (oldField.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                        Net.TheVpc.Upa.Types.ManyToOneType et = (Net.TheVpc.Upa.Types.ManyToOneType) oldField.GetDataType();
                        objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().ObjectToId(objectValue);
                    }
                }
                bool fieldNoTypeTransform = noTypeTransform;
                if (ei.GetReferrer() is Net.TheVpc.Upa.Field) {
                    if (!noTypeTransform) {
                        Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) ei.GetReferrer();
                        string fieldKey = Net.TheVpc.Upa.QueryHints.NO_TYPE_TRANSFORM + "." + field.GetAbsoluteName();
                        fieldNoTypeTransform = ((bool?) (System.Collections.Generic.EqualityComparer<object>.Default.Equals(Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey),null) ? ((bool?)(false)) : Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(hints,fieldKey))).Value;
                    }
                }
                Net.TheVpc.Upa.Types.DataTypeTransform baseTransform = ei.GetTypeTransform();
                Net.TheVpc.Upa.Types.DataTypeTransform preferedTransform = fieldNoTypeTransform ? ((Net.TheVpc.Upa.Types.DataTypeTransform)(Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForDataType(baseTransform.GetSourceType()))) : baseTransform;
                values.Add(new Net.TheVpc.Upa.Persistence.DefaultParameter(e.GetName(), objectValue, preferedTransform));
            }
            return new Net.TheVpc.Upa.Impl.Persistence.DefaultQueryExecutor(context.GetOperation() == Net.TheVpc.Upa.Persistence.ContextOperation.FIND ? Net.TheVpc.Upa.Impl.Persistence.NativeStatementType.SELECT : Net.TheVpc.Upa.Impl.Persistence.NativeStatementType.UPDATE, hints, query, values, context.GetGeneratedValues(), this, context.GetConnection(), ne, updatable, m);
        }


        public virtual void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }

        public virtual string GetFieldDeclaration(Net.TheVpc.Upa.PrimitiveField field, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityPersistenceContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //        FormatterInterface formatter = new StringFormatter(32);
            Net.TheVpc.Upa.Types.DataTypeTransform cr = Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field);
            //        Class sqlType = cr.getPlatformType();
            //        int length = cr.getScale();
            //        int precision = cr.getPrecision();
            object defaultObject = field.GetDefaultObject();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(GetValidIdentifier(GetColumnName(field)));
            sb.Append('\t');
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = ((Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) entityPersistenceContext.GetPersistenceUnit()).CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.FIND, entityPersistenceContext.GetHints());
            sb.Append(sqlManager.GetSQL(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(cr), context, new Net.TheVpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            if (defaultObject == null && !cr.GetTargetType().IsNullable()) {
                defaultObject = cr.GetTargetType().GetDefaultValue();
                if (defaultObject == null) {
                    defaultObject = cr.GetTargetType().GetDefaultNonNullValue();
                }
            }
            if (defaultObject != null && !(defaultObject is Net.TheVpc.Upa.CustomDefaultObject)) {
                sb.Append(" Default ").Append(sqlManager.GetSQL(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(defaultObject, cr), context, new Net.TheVpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            }
            if (!cr.GetTargetType().IsNullable()) {
                sb.Append(" Not Null");
            }
            return sb.ToString();
        }

        public virtual string GetCreateViewStatement(Net.TheVpc.Upa.Entity entityManager, Net.TheVpc.Upa.Expressions.QueryStatement statement, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Create View ").Append(GetValidIdentifier(GetTableName(entityManager))).Append(" As ").Append("\n").Append("\t");
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) executionContext.GetPersistenceUnit().GetExpressionManager().CompileExpression(statement, null);
            sb.Append(sqlManager.GetSQL(compiledExpression, executionContext, new Net.TheVpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            return sb.ToString();
        }

        public virtual string GetCreateImplicitViewStatement(Net.TheVpc.Upa.Entity table, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Create View ").Append(GetValidIdentifier(GetImplicitViewName(table))).Append(" As ").Append("\n");
            System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> keys = table.GetPrimitiveFields();
            Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select();
            foreach (Net.TheVpc.Upa.PrimitiveField key in keys) {
                Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> modifiers = key.GetModifiers();
                if (modifiers.Contains(Net.TheVpc.Upa.FieldModifier.SELECT_STORED)) {
                    Net.TheVpc.Upa.Expressions.Expression expression = ((Net.TheVpc.Upa.ExpressionFormula) key.GetSelectFormula()).GetExpression();
                    s.Field(expression, GetColumnName(key));
                } else if (modifiers.Contains(Net.TheVpc.Upa.FieldModifier.SELECT_DEFAULT)) {
                    s.Field(new Net.TheVpc.Upa.Expressions.Var(new Net.TheVpc.Upa.Expressions.Var(table.GetName()), key.GetName()));
                }
            }
            Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext = ((Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) executionContext.GetPersistenceUnit()).CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.CREATE_PERSISTENCE_NAME, executionContext.GetHints());
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) executionContext.GetPersistenceUnit().GetExpressionManager().CompileExpression(s, null);
            sb.Append(sqlManager.GetSQL(compiledExpression, qlContext, new Net.TheVpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            return (sb.ToString());
        }

        public virtual string GetCreateRelationshipStatement(Net.TheVpc.Upa.Relationship relation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Net.TheVpc.Upa.RelationshipRole detailRole = relation.GetSourceRole();
            Net.TheVpc.Upa.Entity table = detailRole.GetEntity();
            if (IsView(table)) {
                return null;
            } else if (relation.GetRelationshipType() != Net.TheVpc.Upa.RelationshipType.TRANSIENT) {
                sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(table))).Append(" Add Constraint ").Append(GetValidIdentifier(GetRelationshipName(relation))).Append(" Foreign Key (");
                bool first1 = true;
                for (int i = 0; i < relation.Size(); i++) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> fields = detailRole.GetEntity().ToPrimitiveFields<Net.TheVpc.Upa.EntityPart>(new System.Collections.Generic.List<Net.TheVpc.Upa.EntityPart>(new[]{(Net.TheVpc.Upa.EntityPart) detailRole.GetField(i)}));
                    foreach (Net.TheVpc.Upa.Field field in fields) {
                        if (first1) {
                            first1 = false;
                        } else {
                            sb.Append(',');
                        }
                        sb.Append(GetValidIdentifier(GetColumnName(field)));
                    }
                }
                Net.TheVpc.Upa.RelationshipRole masterRole = relation.GetTargetRole();
                sb.Append(") References ").Append(GetValidIdentifier(GetTableName(masterRole.GetEntity()))).Append(" (");
                first1 = true;
                for (int i = 0; i < relation.Size(); i++) {
                    System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> fields = masterRole.GetEntity().ToPrimitiveFields<Net.TheVpc.Upa.EntityPart>(new System.Collections.Generic.List<Net.TheVpc.Upa.EntityPart>(new[]{(Net.TheVpc.Upa.EntityPart) masterRole.GetField(i)}));
                    foreach (Net.TheVpc.Upa.Field field in fields) {
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


        public virtual void SetIdentityConstraintsEnabled(Net.TheVpc.Upa.Entity entity, bool enable, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) {
            Net.TheVpc.Upa.Persistence.UConnection connection = context.GetConnection();
            connection.SetProperty("IdentityConstraintsEnabled." + entity.GetName(), enable);
            if (enable) {
                string s = GetEnableIdentityConstraintsStatement(entity);
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(s)) {
                    connection.ExecuteNonQuery(s, null, null);
                }
            } else {
                string s = GetDisableIdentityConstraintsStatement(entity);
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(s)) {
                    connection.ExecuteNonQuery(s, null, null);
                }
            }
        }

        public virtual string GetDisableIdentityConstraintsStatement(Net.TheVpc.Upa.Entity table) {
            return null;
        }

        public virtual string GetEnableIdentityConstraintsStatement(Net.TheVpc.Upa.Entity table) {
            return null;
        }

        public virtual string GetDropRelationshipStatement(Net.TheVpc.Upa.Relationship relation) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Net.TheVpc.Upa.Entity table = relation.GetSourceRole().GetEntity();
            sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(table))).Append(" Drop Constraint ").Append(GetValidIdentifier(GetRelationshipName(relation)));
            return (sb.ToString());
        }

        public virtual string GetDropTablePKConstraintStatement(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entity.GetShield().IsTransient()) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.Field> pk = entity.GetFields(Net.TheVpc.Upa.Filters.Fields.Id());
                if ((pk).Count > 0) {
                    sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(entity))).Append(" Drop Constraint ").Append(GetValidIdentifier(GetTablePKName(entity)));
                    return (sb.ToString());
                }
            }
            return null;
        }

        public virtual string GetDropIndexStatement(Net.TheVpc.Upa.Index index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Drop");
            sb.Append(" Index ");
            sb.Append(GetValidIdentifier(GetIndexName(index)));
            return sb.ToString();
        }

        public virtual string GetCreateIndexStatement(Net.TheVpc.Upa.Index index) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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
            System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> primitiveFields = index.GetEntity().GetPrimitiveFields(Net.TheVpc.Upa.Filters.Fields.Regular().And(Net.TheVpc.Upa.Filters.Fields.ByList(index.GetFields())));
            foreach (Net.TheVpc.Upa.PrimitiveField field in primitiveFields) {
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

        private void FillPrimitiveField(Net.TheVpc.Upa.Field f, System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> list) {
            if (f is Net.TheVpc.Upa.PrimitiveField) {
                Net.TheVpc.Upa.PrimitiveField pf = (Net.TheVpc.Upa.PrimitiveField) f;
                Net.TheVpc.Upa.Types.DataType d = pf.GetDataType();
                if (d is Net.TheVpc.Upa.Types.ManyToOneType) {
                    Net.TheVpc.Upa.Types.ManyToOneType rd = (Net.TheVpc.Upa.Types.ManyToOneType) d;
                    foreach (Net.TheVpc.Upa.Field field in rd.GetRelationship().GetSourceRole().GetFields()) {
                        FillPrimitiveField(field, list);
                    }
                } else {
                    list.Add(pf);
                }
            } else if (f is Net.TheVpc.Upa.CompoundField) {
                Net.TheVpc.Upa.CompoundField c = (Net.TheVpc.Upa.CompoundField) f;
                foreach (Net.TheVpc.Upa.PrimitiveField t in c.GetFields()) {
                    FillPrimitiveField(t, list);
                }
            }
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.ColumnDesc LoadColumnDesc(Net.TheVpc.Upa.PrimitiveField field, System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Persistence.ColumnDesc c = new Net.TheVpc.Upa.Impl.Persistence.ColumnDesc();
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

        public virtual string GetAlterTableAlterColumnNullStatement(Net.TheVpc.Upa.PrimitiveField field, bool nullable) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(field.GetEntity()))).Append(" Alter Column ").Append(GetValidIdentifier(GetColumnName(field))).Append(nullable ? " NULL" : " NOT NULL");
            return sb.ToString();
        }

        public virtual string GetCreateTablePKConstraintStatement(Net.TheVpc.Upa.Entity entityManager) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entityManager.GetShield().IsTransient()) {
                System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> pk = new System.Collections.Generic.List<Net.TheVpc.Upa.PrimitiveField>();
                foreach (Net.TheVpc.Upa.PrimitiveField primitiveField in entityManager.GetPrimitiveFields(Net.TheVpc.Upa.Filters.Fields.Id())) {
                    FillPrimitiveField(primitiveField, pk);
                }
                if ((pk).Count > 0) {
                    sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(entityManager))).Append(" Add Constraint ").Append(GetValidIdentifier(GetTablePKName(entityManager))).Append(" Primary Key (");
                    bool first = true;
                    foreach (Net.TheVpc.Upa.PrimitiveField primitiveField in pk) {
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

        public virtual string GetAlterTableAddColumnStatement(Net.TheVpc.Upa.PrimitiveField field, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Alter Table ").Append(GetTableName(field.GetEntity())).Append(" Add Column ").Append(GetFieldDeclaration(field, context));
            return s.ToString();
        }

        public virtual string GetCreateTableStatement(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entity.GetShield().IsTransient()) {
                sb.Append("Create Table ").Append(GetValidIdentifier(GetTableName(entity))).Append('(').Append("\n").Append("\t");
                System.Collections.Generic.IList<Net.TheVpc.Upa.PrimitiveField> keys = entity.GetPrimitiveFields(Net.TheVpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.TheVpc.Upa.FieldModifier.TRANSIENT));
                bool firstElement = true;
                foreach (Net.TheVpc.Upa.PrimitiveField key in keys) {
                    if (key.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.SELECT_LIVE)) {
                    } else if ((key.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType)) {
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


        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Expressions.EntityStatement query, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Persistence.DefaultQuery q = new Net.TheVpc.Upa.Impl.Persistence.DefaultQuery(query, entity, executionContext);
            ConfigureQuery(q, executionContext);
            return q;
        }


        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Expressions.EntityStatement query, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Persistence.DefaultQuery q = new Net.TheVpc.Upa.Impl.Persistence.DefaultQuery(query, null, executionContext);
            ConfigureQuery(q, executionContext);
            return q;
        }

        protected internal virtual void ConfigureQuery(Net.TheVpc.Upa.Query q, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) {
            bool lazyListLoadingEnabled = executionContext.GetPersistenceUnit().GetProperties().GetBoolean("Query.LazyListLoadingEnabled", true);
            q.SetLazyListLoadingEnabled(lazyListLoadingEnabled);
        }


        public virtual void CreateStructure(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.QueryScript script = new Net.TheVpc.Upa.Expressions.QueryScript();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> entities = persistenceUnit.GetEntities();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> queries = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> unions = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> updatableQueries = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> viewForEntities = new System.Collections.Generic.List<Net.TheVpc.Upa.Entity>();
            foreach (Net.TheVpc.Upa.Entity entity in entities) {
                if ((entity.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition))).Count > 0) {
                    updatableQueries.Add(entity);
                } else if ((entity.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0) {
                    queries.Add(entity);
                } else if ((entity.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition))).Count > 0) {
                    unions.Add(entity);
                } else {
                    script.AddStatement(GetCreateTableStatement(entity, executionContext));
                    if (entity.NeedsView()) {
                        viewForEntities.Add(entity);
                    }
                    System.Collections.Generic.IList<Net.TheVpc.Upa.Index> indexes = entity.GetIndexes(null);
                    foreach (Net.TheVpc.Upa.Index index in indexes) {
                        script.AddStatement(GetCreateIndexStatement(index));
                    }
                }
            }
            foreach (Net.TheVpc.Upa.Entity entity in entities) {
                script.AddStatement(GetCreateTablePKConstraintStatement(entity));
            }
            if (IsReferencingSupported()) {
                foreach (Net.TheVpc.Upa.Relationship relation in persistenceUnit.GetRelationships()) {
                    script.AddStatement(GetCreateRelationshipStatement(relation));
                }
            }
            if (IsViewSupported()) {
                foreach (Net.TheVpc.Upa.Entity entity in viewForEntities) {
                    script.AddStatement(GetCreateImplicitViewStatement(entity, executionContext));
                }
                foreach (Net.TheVpc.Upa.Entity entity in updatableQueries) {
                }
                //not yet supported
                foreach (Net.TheVpc.Upa.Entity entity in queries) {
                    Net.TheVpc.Upa.Persistence.ViewEntityExtension specSupport = (Net.TheVpc.Upa.Persistence.ViewEntityExtension) entity.GetExtension<Net.TheVpc.Upa.Persistence.ViewEntityExtension>(typeof(Net.TheVpc.Upa.Persistence.ViewEntityExtension));
                    script.AddStatement(GetCreateViewStatement(entity, specSupport.GetQuery(), executionContext));
                }
                foreach (Net.TheVpc.Upa.Entity entity in unions) {
                    Net.TheVpc.Upa.Persistence.UnionEntityExtension specSupport = (Net.TheVpc.Upa.Persistence.UnionEntityExtension) entity.GetExtension<Net.TheVpc.Upa.Persistence.UnionEntityExtension>(typeof(Net.TheVpc.Upa.Persistence.UnionEntityExtension));
                    script.AddStatement(GetCreateViewStatement(entity, specSupport.GetQuery(), executionContext));
                }
            }
            executionContext.GetConnection().ExecuteScript(script, true);
        }

        protected internal virtual Net.TheVpc.Upa.Expressions.QueryScript GetCreateRelationshipsScript(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.QueryScript script = new Net.TheVpc.Upa.Expressions.QueryScript();
            foreach (Net.TheVpc.Upa.Relationship relation in persistenceUnit.GetRelationships()) {
                if (!relation.IsTransient()) {
                    script.AddStatement(GetCreateRelationshipStatement(relation));
                }
            }
            return script;
        }

        protected internal virtual Net.TheVpc.Upa.Expressions.QueryScript GetDisableConstraintsScript(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.QueryScript script = new Net.TheVpc.Upa.Expressions.QueryScript();
            //        QueryScript disableConstraintsScript = getDisableConstraintsScript();
            //        if (disableConstraintsScript != null) {
            //            script.addScript(disableConstraintsScript);
            //        }
            Net.TheVpc.Upa.Expressions.QueryScript dropRelationsScript = GetDropRelationshipsScript(persistenceUnit);
            if (dropRelationsScript != null) {
                script.AddScript(dropRelationsScript);
            }
            //        Script disableIdentityConstraintsScript = getDisableIdentityConstraintsScript();
            //        if (disableIdentityConstraintsScript != null) {
            //            script.addScript(disableIdentityConstraintsScript);
            //        }
            return script;
        }

        protected internal virtual Net.TheVpc.Upa.Expressions.QueryScript GetEnableConstraintsScript(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.QueryScript script = new Net.TheVpc.Upa.Expressions.QueryScript();
            //        QueryScript enableIdentityConstraintsScript = getEnableIdentityConstraintsScript(database);
            //        if (enableIdentityConstraintsScript != null) {
            //            script.addScript(enableIdentityConstraintsScript);
            //        }
            Net.TheVpc.Upa.Expressions.QueryScript createRelationsScript = GetCreateRelationshipsScript(persistenceUnit);
            if (createRelationsScript != null) {
                script.AddScript(createRelationsScript);
            }
            //        QueryScript enableConstraintsScript = getEnableConstraintsScript();
            //        if (enableConstraintsScript != null) {
            //            script.addScript(enableConstraintsScript);
            //        }
            return script;
        }

        public virtual Net.TheVpc.Upa.Expressions.QueryScript GetDropRelationshipsScript(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Expressions.QueryScript script = new Net.TheVpc.Upa.Expressions.QueryScript();
            foreach (Net.TheVpc.Upa.Relationship relation in persistenceUnit.GetRelationships()) {
                if (!relation.IsTransient()) {
                    Net.TheVpc.Upa.Entity table = relation.GetSourceRole().GetEntity();
                    if (!IsView(table)) {
                        script.AddStatement(GetDropRelationshipStatement(relation));
                    }
                }
            }
            return script;
        }

        protected internal virtual void RequireTransaction(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Session currentSession = executionContext.GetPersistenceUnit().GetCurrentSession();
            if (currentSession != null) {
                Net.TheVpc.Upa.Transaction transaction = currentSession.GetParam<T>(executionContext.GetPersistenceUnit(), typeof(Net.TheVpc.Upa.Transaction), Net.TheVpc.Upa.Impl.SessionParams.TRANSACTION, null);
                if (transaction != null) {
                    return;
                }
            }
            throw new Net.TheVpc.Upa.Exceptions.TransactionException(new Net.TheVpc.Upa.Types.I18NString("TransactionMandatoryException"));
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


        public virtual void SetNativeConstraintsEnabled(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, bool enable) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
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


        public virtual string GetPersistenceName(Net.TheVpc.Upa.UPAObject persistentObject) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(new Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec(persistentObject, null));
        }


        public virtual string GetPersistenceName(Net.TheVpc.Upa.UPAObject persistentObject, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(new Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec(persistentObject, spec));
        }


        public virtual string GetPersistenceName(string name, Net.TheVpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(new Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec(name, spec));
        }

        protected internal virtual string GetPersistenceName(Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec e) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            string persistenceNameFormat = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.Impl.Persistence.UPAObjectAndSpec,string>(persistenceNamesMap,e);
            if (persistenceNameFormat == null) {
                object @object = e.GetObject();
                persistenceNameFormat = persistenceNameStrategy.GetPersistenceName(@object, e.GetSpec());
                persistenceNamesMap[e]=persistenceNameFormat;
            }
            return persistenceNameFormat;
        }

        public virtual Net.TheVpc.Upa.Persistence.PersistenceNameStrategy GetPersistenceNameStrategy() {
            return persistenceNameStrategy;
        }

        public virtual void SetPersistenceNameStrategy(Net.TheVpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy) {
            if (this.persistenceNameStrategy != null) {
                this.persistenceNameStrategy.Close();
            }
            this.persistenceNameStrategy = persistenceNameStrategy;
            if (this.persistenceNameStrategy != null) {
                this.persistenceNameStrategy.Init(this, nameConfig);
            }
        }

        public virtual string GetTablePKName(Net.TheVpc.Upa.Entity o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o, Net.TheVpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT);
        }

        public virtual string GetTableName(Net.TheVpc.Upa.Entity o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetRelationshipName(Net.TheVpc.Upa.Relationship o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetIndexName(Net.TheVpc.Upa.Index o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetColumnName(Net.TheVpc.Upa.Field o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o);
        }

        public virtual string GetImplicitViewName(Net.TheVpc.Upa.Entity o) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceName(o, Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW);
        }

        public virtual bool IsView(Net.TheVpc.Upa.Entity entity) {
            if ((entity.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition))).Count > 0) {
                return true;
            } else if ((entity.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.ViewEntityExtensionDefinition))).Count > 0) {
                return true;
            } else if ((entity.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.UnionEntityExtensionDefinition))).Count > 0) {
                return true;
            }
            return false;
        }


        public virtual void AlterPersistenceUnitAddObject(Net.TheVpc.Upa.UPAObject @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            commitManager.AlterPersistenceUnitAddObject(@object);
        }


        public virtual void AlterPersistenceUnitRemoveObject(Net.TheVpc.Upa.UPAObject @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("No supported");
        }


        public virtual void AlterPersistenceUnitUpdateObject(Net.TheVpc.Upa.UPAObject oldObject, Net.TheVpc.Upa.UPAObject newObject, System.Collections.Generic.ISet<string> updates) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("No supported");
        }


        public virtual bool CommitStorage() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return commitManager.CommitStructure();
        }


        public virtual Net.TheVpc.Upa.PersistenceState GetPersistenceState(Net.TheVpc.Upa.UPAObject @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceState(@object, spec, entityExecutionContext, entityExecutionContext.GetConnection().GetMetadataAccessibleConnection());
        }

        private Net.TheVpc.Upa.PersistenceState GetPersistenceState(Net.TheVpc.Upa.UPAObject @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.TheVpc.Upa.Entity) {
                return GetEntityPersistenceState((Net.TheVpc.Upa.Entity) @object, spec, entityExecutionContext, connection);
            }
            if (@object is Net.TheVpc.Upa.Field) {
                return GetFieldPersistenceState((Net.TheVpc.Upa.Field) @object, spec, entityExecutionContext, connection);
            }
            if (@object is Net.TheVpc.Upa.Relationship) {
                return GetRelationshipPersistenceState((Net.TheVpc.Upa.Relationship) @object, spec, entityExecutionContext, connection);
            }
            if (@object is Net.TheVpc.Upa.Index) {
                return GetIndexPersistenceState((Net.TheVpc.Upa.Index) @object, spec, entityExecutionContext, connection);
            }
            throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Unknown type " + @object);
        }

        public virtual Net.TheVpc.Upa.PersistenceState GetEntityPersistenceState(Net.TheVpc.Upa.Entity @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            string persistenceNameFormat = GetPersistenceName(@object, spec);
            if (spec == null) {
                Net.TheVpc.Upa.PersistenceState persistenceState = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
                if (TableExists(persistenceNameFormat, entityExecutionContext)) {
                    persistenceState = Net.TheVpc.Upa.PersistenceState.VALID;
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return persistenceState;
            } else if (Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW.Equals(spec)) {
                Net.TheVpc.Upa.PersistenceState persistenceState = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
                if (ViewExists(persistenceNameFormat, entityExecutionContext)) {
                    persistenceState = Net.TheVpc.Upa.PersistenceState.VALID;
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return persistenceState;
            } else if (Net.TheVpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT.Equals(spec)) {
                Net.TheVpc.Upa.PersistenceState persistenceState = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
                if (PkConstraintsExists(GetPersistenceName(@object, null), persistenceNameFormat, entityExecutionContext)) {
                    persistenceState = Net.TheVpc.Upa.PersistenceState.VALID;
                }
                return persistenceState;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Unknown Spec for Entity : " + spec);
            }
        }

        public virtual Net.TheVpc.Upa.PersistenceState GetIndexPersistenceState(Net.TheVpc.Upa.Index @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (spec == null) {
                System.Data.IDataReader rs = null;
                Net.TheVpc.Upa.PersistenceState status = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
                string indexName = GetPersistenceName(@object, spec);
                string tableName = GetPersistenceName(@object.GetEntity(), null);
                bool unique = @object.IsUnique();
                {
                    try {
                        System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                        System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, indexName});
                        return (found.Rows.Count != 0)?Net.TheVpc.Upa.PersistenceState.VALID:Net.TheVpc.Upa.PersistenceState.DIRTY;
                    } catch (System.Exception ex) {
                        throw CreateUPAException(ex, "UnableToGetEntityPersistenceState", "Index " + tableName + "." + indexName);
                    }
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return status;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.IllegalArgumentException("Unknown Spec for Entity : " + spec);
            }
        }

        public virtual Net.TheVpc.Upa.PersistenceState GetFieldPersistenceState(Net.TheVpc.Upa.Field @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceState status = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
            Net.TheVpc.Upa.FlagSet<Net.TheVpc.Upa.FieldModifier> fieldModifiers = @object.GetModifiers();
            if ((@object.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType)) {
                //            status = PersistenceState.VALID;
                status = Net.TheVpc.Upa.PersistenceState.TRANSIENT;
            } else if (fieldModifiers.Contains(Net.TheVpc.Upa.FieldModifier.TRANSIENT)) {
                status = Net.TheVpc.Upa.PersistenceState.TRANSIENT;
            } else {
                string tableName = GetPersistenceName(@object.GetEntity());
                string columnName = GetPersistenceName(@object);
                status = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
                
            }
            if (status != Net.TheVpc.Upa.PersistenceState.VALID && status != Net.TheVpc.Upa.PersistenceState.TRANSIENT) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("FieldStorageStatus {0} {1}",null,new object[] { @object, status }));
            }
            return status;
        }

        public virtual Net.TheVpc.Upa.PersistenceState GetRelationshipPersistenceState(Net.TheVpc.Upa.Relationship @object, Net.TheVpc.Upa.Persistence.PersistenceNameType spec, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, System.Data.IDbConnection connection) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PersistenceState status = Net.TheVpc.Upa.PersistenceState.UNKNOWN;
            if (IsView(@object.GetTargetRole().GetEntity()) || IsView(@object.GetSourceRole().GetEntity())) {
                status = Net.TheVpc.Upa.PersistenceState.TRANSIENT;
            } else {
                string tablePersistenceName = GetPersistenceName(@object.GetSourceRole().GetEntity());
                string persistenceNameFormat = GetPersistenceName(@object);
                if (ForeignKeyExists(tablePersistenceName, persistenceNameFormat, entityExecutionContext)) {
                    status = Net.TheVpc.Upa.PersistenceState.VALID;
                }
            }
            if (status != Net.TheVpc.Upa.PersistenceState.VALID) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("getRelationPersistenceState {0} {1}",null,new object[] { @object, status }));
            }
            return status;
        }

        protected internal virtual Net.TheVpc.Upa.Exceptions.UPAException CreateUPAException(System.Exception ex, string mgId, params object [] parameters) {
            return new Net.TheVpc.Upa.Exceptions.UPAException(ex, new Net.TheVpc.Upa.Types.I18NString(mgId), parameters);
        }

        public virtual void RevalidateModel() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }

        public Net.TheVpc.Upa.Impl.Persistence.SQLManager GetSqlManager() {
            return sqlManager;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.IdentifierStoreTranslator CreateIdentifierStoreTranslator(Net.TheVpc.Upa.Persistence.UConnection connection) /* throws System.Exception */  {
            
            return Net.TheVpc.Upa.Impl.Persistence.IdentifierStoreTranslators.UPPER;
        }

        protected internal virtual bool TableExists(string persistenceNameFormat, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
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

        public virtual Net.TheVpc.Upa.Impl.Persistence.IdentifierStoreTranslator GetIdentifierStoreTranslator() /* throws System.Exception */  {
            return identifierStoreTranslator;
        }

        protected internal virtual bool ViewExists(string persistenceNameFormat, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
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

        protected internal virtual bool PkConstraintsExists(string tableName, string constraintsName, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
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

        protected internal virtual bool ForeignKeyExists(string tableName, string constraintName, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
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

        public virtual string GetIdentifierQuoteString() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return identifierQuoteString;
        }

        public virtual string GetValidIdentifier(string s) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (IsReservedKeyword(s)) {
                string r = GetIdentifierQuoteString();
                if (r != null) {
                    return r + identifierStoreTranslator.TranslateIdentifier(s) + r;
                }
            }
            return s;
        }

        public virtual bool IsAccessible(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile) {
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
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                }
            }
        }

        public virtual void CheckAccessible(Net.TheVpc.Upa.Persistence.ConnectionProfile connectionProfile) {
            System.Data.IDbConnection c = null;
            try {
                c = CreateNativeConnection(connectionProfile);
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("StoreNotAccessibleException"), connectionProfile);
            } finally {
                if (c != null) {
                    try {
                        c.Close();
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(null,ex));
                    }
                }
            }
        }
    }
}
