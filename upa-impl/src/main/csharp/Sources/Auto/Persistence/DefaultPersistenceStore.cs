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

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore)).FullName);

        private static readonly Net.Vpc.Upa.Filters.FieldFilter ID = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersAllOf(Net.Vpc.Upa.FieldModifier.ID));

        private static readonly Net.Vpc.Upa.Filters.FieldFilter READABLE = Net.Vpc.Upa.Filters.Fields.Regular().And(Net.Vpc.Upa.Filters.Fields.ByModifiersAnyOf(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT, Net.Vpc.Upa.FieldModifier.SELECT_COMPILED, Net.Vpc.Upa.FieldModifier.SELECT_LIVE)).AndNot(Net.Vpc.Upa.Filters.Fields.ByAllAccessLevel(Net.Vpc.Upa.AccessLevel.PRIVATE));

        public static bool DO_WARNINGS = false;

        private bool readOnly;

        private Net.Vpc.Upa.ObjectFactory factory;

        private Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator identifierStoreTranslator;

        internal Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Persistence.PersistenceNameStrategy persistenceNameStrategy;

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec , string> persistenceNamesMap = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec , string>();

        private Net.Vpc.Upa.Properties parameters = new Net.Vpc.Upa.Impl.DefaultProperties();

        private Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager commitManager = new Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager();

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        private Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager;

        private string identifierQuoteString;

        private System.Collections.Generic.HashSet<string> reservedWords;

        private Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator createIdentifierStoreTranslator;

        private static System.Collections.Generic.HashSet<string> SQL2003_RESERVED_WORDS = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(new[]{"ADD", "ALL", "ALLOCATE", "ALTER", "AND", "ANY", "ARE", "ARRAY", "AS", "ASENSITIVE", "ASYMMETRIC", "AT", "ATOMIC", "AUTHORIZATION", "BEGIN", "BETWEEN", "BIGINT", "BINARY", "BLOB", "BOOLEAN", "BOTH", "BY", "CALL", "CALLED", "CASCADED", "CASE", "CAST", "CHAR", "CHARACTER", "CHECK", "CLOB", "CLOSE", "COLLATE", "COLUMN", "COMMIT", "CONNECT", "CONSTRAINT", "CONTINUE", "CORRESPONDING", "CREATE", "CROSS", "CUBE", "CURRENT", "CURRENT_DATE", "CURRENT_DEFAULT_TRANSFORM_GROUP", "CURRENT_PATH", "CURRENT_ROLE", "CURRENT_TIME", "CURRENT_TIMESTAMP", "CURRENT_TRANSFORM_GROUP_FOR_TYPE", "CURRENT_USER", "CURSOR", "CYCLE", "DATE", "DAY", "DEALLOCATE", "DEC", "DECIMAL", "DECLARE", "DEFAULT", "DELETE", "DEREF", "DESCRIBE", "DETERMINISTIC", "DISCONNECT", "DISTINCT", "DOUBLE", "DROP", "DYNAMIC", "EACH", "ELEMENT", "ELSE", "END", "END-EXEC", "ESCAPE", "EXCEPT", "EXEC", "EXECUTE", "EXISTS", "EXTERNAL", "FALSE", "FETCH", "FILTER", "FLOAT", "FOR", "FOREIGN", "FREE", "FROM", "FULL", "FUNCTION", "GET", "GLOBAL", "GRANT", "GROUP", "GROUPING", "HAVING", "HOLD", "HOUR", "IDENTITY", "IMMEDIATE", "IN", "INDICATOR", "INNER", "INOUT", "INPUT", "INSENSITIVE", "INSERT", "INT", "INTEGER", "INTERSECT", "INTERVAL", "INTO", "IS", "ISOLATION", "JOIN", "LANGUAGE", "LARGE", "LATERAL", "LEADING", "LEFT", "LIKE", "LOCAL", "LOCALTIME", "LOCALTIMESTAMP", "MATCH", "MEMBER", "MERGE", "METHOD", "MINUTE", "MODIFIES", "MODULE", "MONTH", "MULTISET", "NATIONAL", "NATURAL", "NCHAR", "NCLOB", "NEXT", "NEW", "NO", "NONE", "NOT", "NULL", "NUMERIC", "OF", "OLD", "ON", "ONLY", "OPEN", "OR", "ORDER", "OUT", "OUTER", "OUTPUT", "OVER", "OVERLAPS", "PARAMETER", "PARTITION", "PRECISION", "PREPARE", "PRIMARY", "PROCEDURE", "RANGE", "READS", "REAL", "RECURSIVE", "REF", "REFERENCES", "REFERENCING", "REGR_AVGX", "REGR_AVGY", "REGR_COUNT", "REGR_INTERCEPT", "REGR_R2", "REGR_SLOPE", "REGR_SXX", "REGR_SXY", "REGR_SYY", "RELEASE", "RESULT", "RETURN", "RETURNS", "REVOKE", "RIGHT", "ROLLBACK", "ROLLUP", "ROW", "ROWS", "SAVEPOINT", "SCROLL", "SEARCH", "SECOND", "SELECT", "SENSITIVE", "SESSION_USER", "SET", "SIMILAR", "SMALLINT", "SOME", "SPECIFIC", "SPECIFICTYPE", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "START", "STATIC", "SUBMULTISET", "SYMMETRIC", "SYSTEM", "SYSTEM_USER", "TABLE", "THEN", "TIME", "TIMESTAMP", "TIMEZONE_HOUR", "TIMEZONE_MINUTE", "TO", "TRAILING", "TRANSLATION", "TREAT", "TRIGGER", "TRUE", "UESCAPE", "UNION", "UNIQUE", "UNKNOWN", "UNNEST", "UPDATE", "UPPER", "USER", "USING", "VALUE", "VALUES", "VAR_POP", "VAR_SAMP", "VARCHAR", "VARYING", "WHEN", "WHENEVER", "WHERE", "WIDTH_BUCKET", "WINDOW", "WITH", "WITHIN", "WITHOUT", "YEAR"}));

        private Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile;


        public virtual void Init(Net.Vpc.Upa.PersistenceUnit persistenceUnit, bool readOnly, Net.Vpc.Upa.Persistence.ConnectionProfile connectionProfile) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            this.persistenceUnit = persistenceUnit;
            this.readOnly = readOnly;
            this.connectionProfile = connectionProfile;
            SetPersistenceNameStrategy(persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.Persistence.PersistenceNameStrategy>(typeof(Net.Vpc.Upa.Persistence.PersistenceNameStrategy)));
            Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter b = new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(persistenceNameStrategy);
            if (b.ContainsProperty("persistenceStore")) {
                b.SetProperty("persistenceStore", this);
            }
            if (b.ContainsProperty("persistenceUnit")) {
                b.SetProperty("persistenceUnit", persistenceUnit);
            }
            commitManager.Init(persistenceUnit, this);
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager() {
            return marshallManager;
        }


        public virtual System.Collections.Generic.ISet<string> GetSupportedDrivers() {
            return new System.Collections.Generic.HashSet<string>();
        }

        public DefaultPersistenceStore() {
            parameters = new Net.Vpc.Upa.Impl.DefaultProperties();
            Net.Vpc.Upa.Properties map = parameters;
            map.SetBoolean("isComplexSelectSupported", false);
            map.SetBoolean("isFromClauseInUpdateStatementSupported", false);
            map.SetBoolean("isFromClauseInDeleteStatementSupported", false);
            map.SetBoolean("isReferencingSupported", true);
            map.SetBoolean("isViewSupported", false);
            map.SetBoolean("isTopSupported", false);
            //        this.parser = (new SQLParser());
            marshallManager = new Net.Vpc.Upa.Impl.Persistence.DefaultMarshallManager();
            sqlManager = new Net.Vpc.Upa.Impl.Persistence.DefaultSQLManager(persistenceUnit, marshallManager);
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

        public virtual Net.Vpc.Upa.Persistence.FieldPersister CreateInsertSequenceGenerator(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedException", "createInsertSequenceGenerator");
        }

        public virtual Net.Vpc.Upa.Persistence.FieldPersister CreateUpdateSequenceGenerator(Net.Vpc.Upa.Field field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException("UnsupportedException", "createUpdateSequenceGenerator");
        }


        public virtual void CreateStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Persistence.UConnection executor = null;
                try {
                    executor = CreateRootUConnection();
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


        public virtual void DropStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                Net.Vpc.Upa.Persistence.UConnection executor = null;
                try {
                    executor = CreateRootUConnection();
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
            if (connectionDriver == null || connectionDriver.Trim().Length==0) {
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

        private Net.Vpc.Upa.Session GetSession() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceUnit().GetPersistenceGroup().GetCurrentSession();
        }

        public virtual System.Data.IDbConnection CreateNativeRootConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser connectionProfileParser = new Net.Vpc.Upa.Impl.Persistence.Connection.ConnectionProfileParser();
            Net.Vpc.Upa.Impl.DefaultProperties p2 = new Net.Vpc.Upa.Impl.DefaultProperties(GetPersistenceUnit().GetProperties());
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ConnectionProfile> all = connectionProfileParser.ParseEnabled(p2, GetPersistenceUnit().GetRootConnectionConfigs(), Net.Vpc.Upa.UPA.ROOT_CONNECTION_STRING);
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

        public virtual Net.Vpc.Upa.Persistence.UConnection CreateSQLNativeExecutor(System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.Persistence.DefaultUConnection(connection, GetMarshallManager());
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection CreateRootUConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return new Net.Vpc.Upa.Impl.Persistence.DefaultUConnection(CreateNativeRootConnection(), GetMarshallManager());
        }

        protected internal virtual void PrepareNativeConnection(Net.Vpc.Upa.Persistence.UConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        protected internal virtual void DisposeNativeConnection(System.Data.IDbConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection CreateConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Data.IDbConnection nativeConnection = CreateNativeConnection();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Connection Created {0}",null,nativeConnection));
            System.Collections.Generic.IDictionary<string , object> customAttributes = new System.Collections.Generic.Dictionary<string , object>();
            Net.Vpc.Upa.Impl.Persistence.DefaultUConnection connection = new Net.Vpc.Upa.Impl.Persistence.DefaultUConnection(nativeConnection, GetMarshallManager());
            PrepareNativeConnection(connection, customAttributes);
            return connection;
        }

        public virtual System.Data.IDbConnection CreateNativeConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return CreateNativeConnection(GetConnectionProfile());
        }

        public virtual System.Data.IDbConnection CreateNativeConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                string connectionDriver = p.GetConnectionDriver();
                if (connectionDriver == null || connectionDriver.Trim().Length==0) {
                    connectionDriver = DRIVER_TYPE_DEFAULT;
                }
                if (DRIVER_TYPE_GENERIC.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                    return CreateNativeGenericConnection(p);
                }
                if (DRIVER_TYPE_ODBC.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                    return CreateNativeOdbcConnection(p);
                }
                return CreateNativeCustomNativeConnection(p);
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }



        protected internal virtual System.Data.IDbConnection CreateNativeGenericConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            try {
                System.Collections.Generic.IDictionary<string , string> properties = p.GetProperties();
                string name = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DRIVER);
                string url = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.URL);
                string user = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.USER_NAME);
                string password = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.PASSWORD);
                return new System.Data.OleDb.OleDbConnection(oledbURL);
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
                 return new System.Data.Odbc.OdbcConnection(odbcURL);
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
        }

        public virtual System.Data.IDbConnection CreateNativeCustomNativeConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new Net.Vpc.Upa.Exceptions.UPAException(new Net.Vpc.Upa.Types.I18NString("CreateCustomNativeConnectionNotSupported"));
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.NativeSQL NativeSQL(Net.Vpc.Upa.Expressions.CompiledExpression expression, Net.Vpc.Upa.Filters.FieldFilter defaultFieldFilter, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (defaultFieldFilter == null) {
                defaultFieldFilter = READABLE;
            }
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            config.SetExpandEntityFilter(true);
            config.SetExpandFieldFilter(defaultFieldFilter);
            config.SetExpandFields(true);
            config.SetValidate(true);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ee = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) context.GetPersistenceUnit().GetExpressionManager().CompileExpression(expression, config);
            Net.Vpc.Upa.Impl.Persistence.NativeField[] ne = null;
            if (expression is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement cquery = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) expression;
                ne = new Net.Vpc.Upa.Impl.Persistence.NativeField[cquery.CountFields()];
                for (int i = 0; i < ne.Length; i++) {
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryField field = cquery.GetField(i);
                    Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression1 = field.GetExpression();
                    string validName = field.GetName() != null ? field.GetName() : expression1.ToString();
                    if (validName == null) {
                        validName = "#" + i;
                    }
                    Net.Vpc.Upa.Types.DataTypeTransform tc = expression1 == null ? null : Net.Vpc.Upa.Impl.Util.UPAUtils.ResolveDataTypeTransform(expression1);
                    Net.Vpc.Upa.Types.DataTypeTransform c = null;
                    if (tc == null) {
                        throw new System.ArgumentException ("Unable to resolve type for expression : " + expression1);
                    }
                    Net.Vpc.Upa.Field f = null;
                    string binding = field.GetBinding();
                    if (expression1 is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar v = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression1;
                        Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod leaf = v.GetDeepChild();
                        object referrer = leaf.GetReferrer();
                        if (referrer is Net.Vpc.Upa.Field) {
                            f = (Net.Vpc.Upa.Field) referrer;
                            c = Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(f);
                        }
                    }
                    //                    prefix = v.getParent() == null ? null : v.getParent().getName();
                    //                    if (prefix == null) {
                    //                        if (cquery instanceof CompiledSelect) {
                    //                            CompiledSelect s = (CompiledSelect) cquery;
                    //                            prefix = ((s.getEntity() instanceof CompiledEntityName) ? ((CompiledEntityName) (s.getEntity())).getName() : null);
                    //                        } else if (cquery instanceof CompiledUnion) {
                    //                            throw new IllegalArgumentException("Unsupported");
                    //                        }
                    //                    }
                    //                    Object referrer = v.getReferrer();
                    //                    if (referrer instanceof Field) {
                    //                        f = (Field) referrer;
                    //                    } else {
                    //                        if (prefix != null) {
                    //                            f = context.getPersistenceUnit().getEntity(prefix).getField(v.getName(), false);
                    //                        }
                    //                    }
                    if (c == null) {
                        c = tc;
                    }
                    ne[i] = new Net.Vpc.Upa.Impl.Persistence.NativeField(validName, binding, f, c);
                }
            } else {
                ne = new Net.Vpc.Upa.Impl.Persistence.NativeField[0];
            }
            string query = this.GetSqlManager().GetSQL(ee, context, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null));
            System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam> cvalues = ee.FindExpressionsList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionHelper.PARAM_FILTER);
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> values = new System.Collections.Generic.List<Net.Vpc.Upa.Persistence.Parameter>();
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam e in cvalues) {
                if (e.IsUnspecified()) {
                    throw new System.ArgumentException ("Unspecified Param " + e);
                }
                Net.Vpc.Upa.Impl.Util.ExprTypeInfo ei = Net.Vpc.Upa.Impl.Util.UPAUtils.ResolveExprTypeInfo(e);
                object objectValue = e.GetObject();
                if (ei.GetOldReferrer() != null) {
                    Net.Vpc.Upa.Field oldField = (Net.Vpc.Upa.Field) ei.GetOldReferrer();
                    if (oldField.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                        Net.Vpc.Upa.Types.EntityType et = (Net.Vpc.Upa.Types.EntityType) oldField.GetDataType();
                        objectValue = et.GetRelationship().GetTargetEntity().GetBuilder().EntityToId(objectValue);
                    }
                }
                values.Add(new Net.Vpc.Upa.Persistence.DefaultParameter(e.GetName(), objectValue, ei.GetTypeTransform()));
            }
            Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = new Net.Vpc.Upa.Impl.Uql.Parser.DefaultNativeSQL(context.GetOperation() == Net.Vpc.Upa.Persistence.ContextOperation.FIND ? Net.Vpc.Upa.Impl.Persistence.NativeStatementType.SELECT : Net.Vpc.Upa.Impl.Persistence.NativeStatementType.UPDATE);
            nativeSQL.SetPersistenceStore(this);
            Net.Vpc.Upa.Persistence.UConnection connection = this.GetConnection();
            nativeSQL.AddNativeStatement(new Net.Vpc.Upa.Impl.Uql.Parser.ReturnStatement(query, values, context.GetGeneratedValues()));
            nativeSQL.SetQuery(query);
            nativeSQL.SetFields(ne);
            nativeSQL.SetConnection(connection);
            nativeSQL.SetMarshallManager(this.GetMarshallManager());
            return nativeSQL;
        }


        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection GetMetadataConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session session = GetSession();
            Net.Vpc.Upa.Persistence.UConnection connection = session.GetParam<Net.Vpc.Upa.Persistence.UConnection>(persistenceUnit, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.METADATA_CONNECTION, null);
            if (connection == null) {
                connection = session.GetParam<Net.Vpc.Upa.Persistence.UConnection>(persistenceUnit, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.CONNECTION, null);
            }
            if (connection == null) {
                connection = CreateConnection();
                session.SetParam(persistenceUnit, Net.Vpc.Upa.Impl.SessionParams.CONNECTION, connection);
                session.AddSessionListener(new Net.Vpc.Upa.Impl.Persistence.CloseOnContextPopSessionListener(this, connection));
            }
            return connection;
        }

        public virtual Net.Vpc.Upa.Persistence.UConnection GetConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session session = GetSession();
            Net.Vpc.Upa.Persistence.UConnection connection = session.GetParam<Net.Vpc.Upa.Persistence.UConnection>(persistenceUnit, typeof(Net.Vpc.Upa.Persistence.UConnection), Net.Vpc.Upa.Impl.SessionParams.CONNECTION, null);
            if (connection == null) {
                connection = CreateConnection();
                session.SetParam(persistenceUnit, Net.Vpc.Upa.Impl.SessionParams.CONNECTION, connection);
                session.AddSessionListener(new Net.Vpc.Upa.Impl.Persistence.CloseOnContextPopSessionListener(this, connection));
            }
            return connection;
        }

        public virtual string GetFieldDeclaration(Net.Vpc.Upa.PrimitiveField field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        FormatterInterface formatter = new StringFormatter(32);
            Net.Vpc.Upa.Types.DataTypeTransform cr = Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field);
            //        Class sqlType = cr.getPlatformType();
            //        int length = cr.getScale();
            //        int precision = cr.getPrecision();
            object defaultObject = field.GetDefaultObject();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(GetValidIdentifier(GetColumnName(field)));
            sb.Append('\t');
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.FIND);
            sb.Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(cr), context, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            if (defaultObject != null && !(defaultObject is Net.Vpc.Upa.CustomDefaultObject)) {
                sb.Append(" Default ").Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(field.GetDefaultValue(), cr), context, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            }
            if (!cr.GetTargetType().IsNullable()) {
                sb.Append(" Not Null");
            }
            return sb.ToString();
        }

        public virtual string GetCreateViewStatement(Net.Vpc.Upa.Entity entityManager, Net.Vpc.Upa.Expressions.QueryStatement statement, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Create View ").Append(GetValidIdentifier(GetTableName(entityManager))).Append(" As ").Append("\n").Append("\t");
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(statement, null);
            sb.Append(sqlManager.GetSQL(compiledExpression, executionContext, new Net.Vpc.Upa.Impl.Uql.DefaultExpressionDeclarationList(null)));
            return sb.ToString();
        }

        public virtual Net.Vpc.Upa.Persistence.EntityExecutionContext CreateContext(Net.Vpc.Upa.Persistence.ContextOperation operation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        Session currentSession = persistenceUnit.getPersistenceGroup().getCurrentSession();
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = null;
            //        if (currentSession != null) {
            //            context = currentSession.getParam(persistenceUnit, ExecutionContext.class, SessionParams.EXECUTION_CONTEXT, null);
            //            if (context
            //                    == null) {
            //                context = persistenceUnit.getFactory().createObject(ExecutionContext.class, null);
            //                currentSession.setParam(persistenceUnit, SessionParams.EXECUTION_CONTEXT, context);
            //            }
            //        } else {
            //            context = persistenceUnit.getFactory().createObject(ExecutionContext.class, null);
            //        }
            context = persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.Persistence.EntityExecutionContext>(typeof(Net.Vpc.Upa.Persistence.EntityExecutionContext));
            context.InitPersistenceUnit(persistenceUnit, this, operation);
            return context;
        }

        public virtual string GetCreateImplicitViewStatement(Net.Vpc.Upa.Entity table, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Create View ").Append(GetValidIdentifier(GetImplicitViewName(table))).Append(" As ").Append("\n");
            System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> keys = table.GetPrimitiveFields();
            Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select();
            foreach (Net.Vpc.Upa.PrimitiveField key in keys) {
                Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> modifiers = key.GetModifiers();
                if (modifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_COMPILED)) {
                    Net.Vpc.Upa.Expressions.Expression expression = ((Net.Vpc.Upa.ExpressionFormula) key.GetSelectFormula()).GetExpression();
                    s.Field(expression, GetColumnName(key));
                } else if (modifiers.Contains(Net.Vpc.Upa.FieldModifier.SELECT_DEFAULT)) {
                    s.Field(new Net.Vpc.Upa.Expressions.Var(new Net.Vpc.Upa.Expressions.Var(table.GetName()), key.GetName()));
                }
            }
            Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext = CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CREATE_PERSISTENCE_NAME);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) persistenceUnit.GetExpressionManager().CompileExpression(s, null);
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
                sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(table))).Append(" Add Constraint ").Append(GetValidIdentifier(GetRelationshipName(relation))).Append("\n").Append(" Foreign Key (");
                bool first1 = true;
                for (int i = 0; i < relation.Size(); i++) {
                    System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> fields = detailRole.GetEntity().ToPrimitiveFields<T>(new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(new[]{(Net.Vpc.Upa.EntityPart) detailRole.GetField(i)}));
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
                    System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> fields = masterRole.GetEntity().ToPrimitiveFields<T>(new System.Collections.Generic.List<Net.Vpc.Upa.EntityPart>(new[]{(Net.Vpc.Upa.EntityPart) masterRole.GetField(i)}));
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

        public virtual string GetDisableIdentityConstraintsStatement(Net.Vpc.Upa.Entity table) {
            return null;
        }

        public virtual string GetEnableIdentityConstraintsStatement(Net.Vpc.Upa.Entity table) {
            return null;
        }

        public virtual string GetDropRelationshipStatement(Net.Vpc.Upa.Relationship relation) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Net.Vpc.Upa.Entity table = relation.GetSourceRole().GetEntity();
            if (IsView(table)) {
                return null;
            } else if (relation.GetRelationshipType() != Net.Vpc.Upa.RelationshipType.TRANSIENT) {
                sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(table))).Append(" Drop FOREIGN KEY ").Append(GetValidIdentifier(GetRelationshipName(relation)));
                return (sb.ToString());
            }
            return null;
        }

        public virtual string GetDropTablePKConstraintStatement(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entity.GetShield().IsTransient()) {
                System.Collections.Generic.IList<Net.Vpc.Upa.Field> pk = entity.GetFields(ID);
                if ((pk).Count > 0) {
                    sb.Append("Alter Table ").Append(GetValidIdentifier(GetTableName(entity))).Append(" Drop PRIMARY KEY ").Append(GetValidIdentifier(GetTablePKName(entity)));
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
                if (d is Net.Vpc.Upa.Types.EntityType) {
                    Net.Vpc.Upa.Types.EntityType rd = (Net.Vpc.Upa.Types.EntityType) d;
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
                System.Data.IDataReader rs = null;
                try {
                    tableName = GetPersistenceName(field.GetEntity());
                    columnName = GetPersistenceName(field);
                    //                    Connection connection = getConnection().getNativeConnection();
                    string catalog = connection.GetCatalog();
                    string schema = connection.GetSchema();
                    rs = connection.GetMetaData().GetColumns(catalog, schema, GetIdentifierStoreTranslator().TranslateIdentifier(tableName), GetIdentifierStoreTranslator().TranslateIdentifier(columnName));
                    if (rs.Next()) {
                        c.SetCatalogName(System.Convert.ToString(rs["TABLE_CAT"]));
                        c.SetSchemaName(System.Convert.ToString(rs["TABLE_SCHEM"]));
                        c.SetTableName(System.Convert.ToString(rs["TABLE_NAME"]));
                        c.SetColumnName(System.Convert.ToString(rs["COLUMN_NAME"]));
                        c.SetDefaultExpression(System.Convert.ToString(rs["COLUMN_DEF"]));
                        c.SetSqlTypeCode(System.Convert.ToInt32(rs["DATA_TYPE"]));
                        c.SetSqlTypeName(System.Convert.ToString(rs["TYPE_NAME"]));
                        c.SetColumnSize(System.Convert.ToInt32(rs["COLUMN_SIZE"]));
                        c.SetDecimalDigits(System.Convert.ToInt32(rs["DECIMAL_DIGITS"]));
                        c.SetAutoIncrement(YesNoToBoolean(System.Convert.ToString(rs["IS_AUTOINCREMENT"])));
                        c.SetGenerated(YesNoToBoolean(System.Convert.ToString(rs["IS_GENERATEDCOLUMN"])));
                        switch(System.Convert.ToInt32(rs["NULLABLE"])) {
                            case Java.Sql.DatabaseMetaData.columnNoNulls:
                                {
                                    c.SetNullable(false);
                                    break;
                                }
                            case Java.Sql.DatabaseMetaData.columnNullable:
                                {
                                    c.SetNullable(true);
                                    break;
                                }
                        }
                    }
                } finally {
                    if (rs != null) {
                        rs.Close();
                    }
                }
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
                foreach (Net.Vpc.Upa.PrimitiveField primitiveField in entityManager.GetPrimitiveFields(ID)) {
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

        public virtual string GetAlterTableAddColumnStatement(Net.Vpc.Upa.PrimitiveField field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Alter Table ").Append(GetTableName(field.GetEntity())).Append(" Add Column ").Append(GetFieldDeclaration(field));
            return s.ToString();
        }

        public virtual string GetCreateTableStatement(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!entity.GetShield().IsTransient()) {
                sb.Append("Create Table ").Append(GetValidIdentifier(GetTableName(entity))).Append('(').Append("\n").Append("\t");
                System.Collections.Generic.IList<Net.Vpc.Upa.PrimitiveField> keys = entity.GetPrimitiveFields(Net.Vpc.Upa.Filters.Fields.ByModifiersNoneOf(Net.Vpc.Upa.FieldModifier.TRANSIENT));
                bool firstElement = true;
                foreach (Net.Vpc.Upa.PrimitiveField key in keys) {
                    if (!(key.GetDataType() is Net.Vpc.Upa.Types.EntityType)) {
                        if (firstElement) {
                            firstElement = false;
                        } else {
                            sb.Append(",").Append("\n").Append("\t");
                        }
                        sb.Append(GetFieldDeclaration(key));
                    } else {
                    }
                }
                sb.Append("\n").Append(')');
                return (sb.ToString());
            }
            return null;
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            string alias = null;
            string ent = null;
            if (query is Net.Vpc.Upa.Expressions.Select) {
                Net.Vpc.Upa.Expressions.Select d = (Net.Vpc.Upa.Expressions.Select) query;
                string entityAlias = d.GetEntityAlias();
                Net.Vpc.Upa.Expressions.EntityName entityName = (d.GetEntity() is Net.Vpc.Upa.Expressions.EntityName) ? ((Net.Vpc.Upa.Expressions.EntityName) d.GetEntity()) : null;
                if (entityAlias != null) {
                    alias = entityAlias;
                    ent = entityName == null ? null : entityName.GetName();
                } else {
                    ent = entityName == null ? null : entityName.GetName();
                    alias = ent;
                }
            }
            if (alias != null) {
                config.SetThisAlias(alias);
            }
            config.SetExpandEntityFilter(false);
            config.SetExpandFields(false);
            config.SetValidate(false);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement) persistenceUnit.GetExpressionManager().CompileExpression(query, config);
            Net.Vpc.Upa.Impl.Persistence.DefaultQuery q = new Net.Vpc.Upa.Impl.Persistence.DefaultQuery(compiledExpression, entity, qlContext);
            ConfigureQuery(q);
            return q;
        }


        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            string alias = null;
            string ent = null;
            if (query is Net.Vpc.Upa.Expressions.Select) {
                Net.Vpc.Upa.Expressions.Select d = (Net.Vpc.Upa.Expressions.Select) query;
                string entityAlias = d.GetEntityAlias();
                Net.Vpc.Upa.Expressions.EntityName entityName = (d.GetEntity() is Net.Vpc.Upa.Expressions.EntityName) ? ((Net.Vpc.Upa.Expressions.EntityName) d.GetEntity()) : null;
                if (entityAlias != null) {
                    alias = entityAlias;
                    ent = entityName == null ? null : entityName.GetName();
                } else {
                    ent = entityName == null ? null : entityName.GetName();
                    alias = ent;
                }
            }
            if (alias != null) {
                config.SetThisAlias(alias);
            }
            config.SetExpandFields(false);
            config.SetExpandEntityFilter(false);
            config.SetValidate(true);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) persistenceUnit.GetExpressionManager().CompileExpression(query, config);
            Net.Vpc.Upa.Impl.Persistence.DefaultQuery q = new Net.Vpc.Upa.Impl.Persistence.DefaultQuery(compiledExpression, null, qlContext);
            ConfigureQuery(q);
            return q;
        }

        protected internal virtual void ConfigureQuery(Net.Vpc.Upa.Query q) {
            bool lazyListLoadingEnabled = GetPersistenceUnit().GetProperties().GetBoolean("Query.LazyListLoadingEnabled", true);
            q.SetLazyListLoadingEnabled(lazyListLoadingEnabled);
        }


        public virtual int ExecuteUpdate(Net.Vpc.Upa.Expressions.EntityStatement query, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            RequireTransaction();
            Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            string alias = null;
            string ent = null;
            if (query is Net.Vpc.Upa.Expressions.Delete) {
                Net.Vpc.Upa.Expressions.Delete d = (Net.Vpc.Upa.Expressions.Delete) query;
                string entityAlias = d.GetEntityAlias();
                Net.Vpc.Upa.Expressions.EntityName entity = d.GetEntity();
                if (entityAlias != null) {
                    alias = entityAlias;
                    ent = entity == null ? null : entity.GetName();
                } else {
                    ent = entity == null ? null : entity.GetName();
                    alias = ent;
                }
            } else if (query is Net.Vpc.Upa.Expressions.InsertSelection) {
                Net.Vpc.Upa.Expressions.InsertSelection d = (Net.Vpc.Upa.Expressions.InsertSelection) query;
                string entityAlias = null;
                //d.getEntityAlias();
                Net.Vpc.Upa.Expressions.EntityName entity = d.GetEntity();
                if (entityAlias != null) {
                    alias = entityAlias;
                    ent = entity == null ? null : entity.GetName();
                } else {
                    ent = entity == null ? null : entity.GetName();
                    alias = ent;
                }
            } else if (query is Net.Vpc.Upa.Expressions.Update) {
                Net.Vpc.Upa.Expressions.Update d = (Net.Vpc.Upa.Expressions.Update) query;
                string entityAlias = d.GetEntityAlias();
                Net.Vpc.Upa.Expressions.EntityName entity = d.GetEntity();
                if (entityAlias != null) {
                    alias = entityAlias;
                    ent = entity == null ? null : entity.GetName();
                } else {
                    ent = entity == null ? null : entity.GetName();
                    alias = ent;
                }
            } else if (query is Net.Vpc.Upa.Expressions.Insert) {
            }
            //this is not supported!!
            //            Insert d = (Insert) query;
            //            EntityName entity = d.getEntity();
            //            ent = entity == null ? null : entity.getName();
            //            alias = ent;
            if (alias != null) {
                config.SetThisAlias(alias);
            }
            config.SetExpandFields(false);
            config.SetExpandEntityFilter(false);
            config.SetValidate(true);
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement compiledExpression = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityStatement) persistenceUnit.GetExpressionManager().CompileExpression(query, config);
            Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL = NativeSQL(compiledExpression, null, qlContext);
            nativeSQL.Execute();
            return nativeSQL.GetResultCount();
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
                    script.AddStatement(GetCreateTableStatement(entity));
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
            GetConnection().ExecuteScript(script, true);
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
                    script.AddStatement(GetDropRelationshipStatement(relation));
                }
            }
            return script;
        }

        protected internal virtual void RequireTransaction() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Session currentSession = persistenceUnit.GetPersistenceGroup().GetCurrentSession();
            if (currentSession != null) {
                Net.Vpc.Upa.Transaction transaction = currentSession.GetParam<Net.Vpc.Upa.Transaction>(persistenceUnit, typeof(Net.Vpc.Upa.Transaction), Net.Vpc.Upa.Impl.SessionParams.TRANSACTION, null);
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
            if (reservedWords == null) {
                System.Collections.Generic.HashSet<string> r = new System.Collections.Generic.HashSet<string>();
                string rw = null;
                try {
                    Java.Sql.DatabaseMetaData metaData = GetConnection().GetMetadataAccessibleConnection().GetMetaData();
                    rw = metaData.GetSQLKeywords();
                    createIdentifierStoreTranslator = CreateIdentifierStoreTranslator();
                } catch (System.Exception ex) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString("getSQLKeywords"));
                }
                if (rw != null) {
                    foreach (string s in System.Text.RegularExpressions.Regex.Split(rw,", \n")) {
                        if ((s).Length > 0) {
                            r.Add(s.ToUpper());
                        }
                    }
                    Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(r, SQL2003_RESERVED_WORDS);
                    System.Collections.Generic.ISet<string> crw = GetCustomReservedKeywords();
                    if (crw != null) {
                        Net.Vpc.Upa.Impl.FwkConvertUtils.CollectionAddRange(r, crw);
                    }
                }
                reservedWords = r;
            }
            return reservedWords.Contains(name.ToUpper());
        }

        protected internal virtual System.Collections.Generic.ISet<string> GetCustomReservedKeywords() {
            return null;
        }


        public virtual void SetNativeConstraintsEnabled(Net.Vpc.Upa.PersistenceUnit database, bool enable) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (enable) {
                GetConnection().ExecuteScript(GetEnableConstraintsScript(database), false);
            } else {
                GetConnection().ExecuteScript(GetDisableConstraintsScript(database), false);
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
            string persistenceName = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec,string>(persistenceNamesMap,e);
            if (persistenceName == null) {
                object @object = e.GetObject();
                persistenceName = persistenceNameStrategy.GetPersistenceName(@object, e.GetSpec());
                persistenceNamesMap[e]=persistenceName;
            }
            return persistenceName;
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
                this.persistenceNameStrategy.Init(this, persistenceUnit.GetPersistenceNameConfig());
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
            throw new System.ArgumentException ("No supported");
        }


        public virtual void AlterPersistenceUnitUpdateObject(Net.Vpc.Upa.UPAObject oldObject, Net.Vpc.Upa.UPAObject newObject, System.Collections.Generic.ISet<string> updates) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new System.ArgumentException ("No supported");
        }


        public virtual bool CommitStorage() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return commitManager.CommitStructure();
        }


        public virtual Net.Vpc.Upa.PersistenceState GetPersistenceState(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return GetPersistenceState(@object, spec, GetConnection().GetMetadataAccessibleConnection());
        }

        public virtual Net.Vpc.Upa.PersistenceState GetPersistenceState(Net.Vpc.Upa.UPAObject @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.Vpc.Upa.Entity) {
                return GetEntityPersistenceState((Net.Vpc.Upa.Entity) @object, spec, connection);
            }
            if (@object is Net.Vpc.Upa.Field) {
                return GetFieldPersistenceState((Net.Vpc.Upa.Field) @object, spec, connection);
            }
            if (@object is Net.Vpc.Upa.Relationship) {
                return GetRelationshipPersistenceState((Net.Vpc.Upa.Relationship) @object, spec, connection);
            }
            if (@object is Net.Vpc.Upa.Index) {
                return GetIndexPersistenceState((Net.Vpc.Upa.Index) @object, spec, connection);
            }
            throw new System.ArgumentException ("Unknown type " + @object);
        }

        public virtual Net.Vpc.Upa.PersistenceState GetEntityPersistenceState(Net.Vpc.Upa.Entity @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string persistenceName = GetPersistenceName(@object, spec);
            if (spec == null) {
                Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                if (TableExists(persistenceName)) {
                    persistenceState = Net.Vpc.Upa.PersistenceState.VALID;
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return persistenceState;
            } else if (Net.Vpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW.Equals(spec)) {
                Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                if (ViewExists(persistenceName)) {
                    persistenceState = Net.Vpc.Upa.PersistenceState.VALID;
                }
                //log.log(Level.FINE,"getEntityPersistenceState " + object + " " + status);
                return persistenceState;
            } else if (Net.Vpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT.Equals(spec)) {
                Net.Vpc.Upa.PersistenceState persistenceState = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                if (PkConstraintsExists(GetPersistenceName(@object, null), persistenceName)) {
                    persistenceState = Net.Vpc.Upa.PersistenceState.VALID;
                }
                return persistenceState;
            } else {
                throw new System.ArgumentException ("Unknown Spec for Entity : " + spec);
            }
        }



        public virtual Net.Vpc.Upa.PersistenceState GetFieldPersistenceState(Net.Vpc.Upa.Field @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceState status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
            Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.FieldModifier> fieldModifiers = @object.GetModifiers();
            if ((@object.GetDataType() is Net.Vpc.Upa.Types.EntityType)) {
                //            status = PersistenceState.VALID;
                status = Net.Vpc.Upa.PersistenceState.TRANSIENT;
            } else if (fieldModifiers.Contains(Net.Vpc.Upa.FieldModifier.TRANSIENT)) {
                status = Net.Vpc.Upa.PersistenceState.TRANSIENT;
            } else {
                string tableName = GetPersistenceName(@object.GetEntity());
                string columnName = GetPersistenceName(@object);
                status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
                try {
                    System.Data.IDataReader rs = null;
                    try {
                        //                    Connection connection = getConnection().getNativeConnection();
                        string catalog = connection.GetCatalog();
                        string schema = connection.GetSchema();
                        rs = connection.GetMetaData().GetColumns(catalog, schema, GetIdentifierStoreTranslator().TranslateIdentifier(tableName), GetIdentifierStoreTranslator().TranslateIdentifier(columnName));
                        if (rs.Next()) {
                            string COLUMN_NAME = System.Convert.ToString(rs["COLUMN_NAME"]);
                            int DATA_TYPE = System.Convert.ToInt32(rs["DATA_TYPE"]);
                            //TODO, check datatype and constraints
                            status = Net.Vpc.Upa.PersistenceState.VALID;
                        }
                    } finally {
                        if (rs != null) {
                            rs.Close();
                        }
                    }
                } catch (System.Exception ex) {
                    throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Column " + tableName + "." + columnName);
                }
            }
            if (status != Net.Vpc.Upa.PersistenceState.VALID && status != Net.Vpc.Upa.PersistenceState.TRANSIENT) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("FieldStorageStatus {0} {1}",null,new object[] { @object, status }));
            }
            return status;
        }

        public virtual Net.Vpc.Upa.PersistenceState GetRelationshipPersistenceState(Net.Vpc.Upa.Relationship @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec, System.Data.IDbConnection connection) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PersistenceState status = Net.Vpc.Upa.PersistenceState.UNKNOWN;
            if (IsView(@object.GetTargetRole().GetEntity()) || IsView(@object.GetSourceRole().GetEntity())) {
                status = Net.Vpc.Upa.PersistenceState.TRANSIENT;
            } else {
                string tablePersistenceName = GetPersistenceName(@object.GetSourceRole().GetEntity());
                string persistenceName = GetPersistenceName(@object);
                if (ForeignKeyExists(tablePersistenceName, persistenceName)) {
                    status = Net.Vpc.Upa.PersistenceState.VALID;
                }
            }
            if (status != Net.Vpc.Upa.PersistenceState.VALID) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("getRelationPersistenceState {0} {1}",null,new object[] { @object, status }));
            }
            return status;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        protected internal virtual Net.Vpc.Upa.Exceptions.UPAException CreateUPAException(System.Exception ex, string mgId, params object [] parameters) {
            return new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString(mgId), parameters);
        }

        public virtual void RevalidateModel() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.SQLManager GetSqlManager() {
            return sqlManager;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator CreateIdentifierStoreTranslator() /* throws System.Exception */  {
            Java.Sql.DatabaseMetaData m = GetConnection().GetMetadataAccessibleConnection().GetMetaData();
            if (m.StoresMixedCaseIdentifiers()) {
                return Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslators.MIXED;
            }
            if (m.StoresUpperCaseIdentifiers()) {
                return Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslators.UPPER;
            }
            if (m.StoresLowerCaseIdentifiers()) {
                return Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslators.LOWER;
            }
            return Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslators.UPPER;
        }



        public virtual Net.Vpc.Upa.Impl.Persistence.IdentifierStoreTranslator GetIdentifierStoreTranslator() /* throws System.Exception */  {
            if (identifierStoreTranslator == null) {
                identifierStoreTranslator = CreateIdentifierStoreTranslator();
            }
            return identifierStoreTranslator;
        }







        public virtual string GetIdentifierQuoteString() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (identifierQuoteString == null) {
                try {
                    identifierQuoteString = GetConnection().GetMetadataAccessibleConnection().GetMetaData().GetIdentifierQuoteString();
                } catch (System.Exception ex) {
                    throw new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString("getIdentifierQuoteString"));
                }
            }
            return identifierQuoteString;
        }

        public virtual string GetValidIdentifier(string s) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (IsReservedKeyword(s)) {
                string r = GetIdentifierQuoteString();
                if (r != null) {
                    return r + createIdentifierStoreTranslator.TranslateIdentifier(s) + r;
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
