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



namespace Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver
{


    public class MSSQLServerPersistenceStore : Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore {

        private System.Collections.Generic.ISet<string> keywords;

        public MSSQLServerPersistenceStore()  : base(){

            string resourcePath = null;
             resourcePath = "Persistence.DerbyKeywords.txt";
            keywords = Net.Vpc.Upa.Impl.Util.UPAUtils.LoadLinesSet(resourcePath);
            Net.Vpc.Upa.Properties map = GetProperties();
            map.SetBoolean("isComplexSelectSupported", (true).Value);
            map.SetBoolean("isFromClauseInUpdateStatementSupported", (true).Value);
            map.SetBoolean("isFromClauseInDeleteStatementSupported", (true).Value);
            map.SetBoolean("isReferencingSupported", (true).Value);
            map.SetBoolean("isViewSupported", (true).Value);
            map.SetBoolean("isTopSupported", (true).Value);
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Shared.CoalesceANSISQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Shared.CastAsSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerConcatSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDatePartSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateDiffSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateAddSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerIfSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerStrLenSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerSystemDateTimeSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerI2VSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerD2VSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerMonthStartSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerMonthEndSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerCoalesceSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Shared.NullValANSISQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerTypeNameSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerSelectSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateTruncSQLProvider());
            GetSqlManager().Register(new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDecodeSQLProvider());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Date), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateOnlyMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Month), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerMonthYearMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Year), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerYearMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Time), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerTimeMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.DateTime), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateTimeMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Date), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateOnlyMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Month), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerMonthYearMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Year), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerYearMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.DateTime), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerDateTimeMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Time), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerTimeMarshaller());
            GetMarshallManager().SetTypeMarshaller(typeof(Net.Vpc.Upa.Types.Timestamp), new Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerTimeStampMarshaller());
        }


        protected internal override System.Collections.Generic.ISet<string> GetCustomReservedKeywords() {
            string resourcePath = null;
             resourcePath = "Persistence.MSSQLServerKeywords.txt";
            return Net.Vpc.Upa.Impl.Util.UPAUtils.LoadLinesSet(resourcePath);
        }


        public override string GetFieldDeclaration(Net.Vpc.Upa.PrimitiveField field) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string s = base.GetFieldDeclaration(field);
            Net.Vpc.Upa.Entity table = field.GetEntity();
            if (field.IsId() && field.GetInsertFormula() is Net.Vpc.Upa.Sequence) {
                Net.Vpc.Upa.Sequence seq = (Net.Vpc.Upa.Sequence) field.GetInsertFormula();
                s += " Identity(" + seq.GetInitialValue() + "," + seq.GetAllocationSize() + ")";
            }
            return s;
        }


        public override System.Data.IDbConnection CreateNativeCustomNativeConnection(Net.Vpc.Upa.Persistence.ConnectionProfile p) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("createNativeCustomNativeConnection",null));
            try {
                string connectionDriver = p.GetConnectionDriver();
                if (connectionDriver == null || connectionDriver.Trim().Length==0) {
                    connectionDriver = DRIVER_TYPE_DEFAULT;
                }
                System.Collections.Generic.IDictionary<string , string> properties = p.GetProperties();
                if (DRIVER_TYPE_DEFAULT.Equals(connectionDriver,System.StringComparison.InvariantCultureIgnoreCase)) {
                    string url = "jdbc:microsoft:sqlserver://";
                    string server = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS);
                    if (server == null || (server).Length == 0) {
                        server = "localhost";
                    }
                    url += server;
                    string instance = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_PATH);
                    if (instance != null && (instance).Length > 0) {
                        url += "\\" + instance;
                    }
                    string port = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.SERVER_PORT);
                    if (port != null && (port).Length > 0) {
                        url += ":" + port;
                    }
                    string dbName = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_NAME);
                    if (dbName != null && (dbName).Length > 0) {
                        url += ";databaseName=" + dbName;
                    }
                    //force cursors
                    url += ";SelectMethod=cursor";
                    string driverClass = "com.microsoft.jdbc.sqlserver.SQLServerDriver";
                    try {
                        Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(driverClass);
                    } catch (System.Exception cls) {
                        throw new Net.Vpc.Upa.Exceptions.DriverNotFoundException(driverClass);
                    }
                    return Java.Sql.DriverManager.GetConnection(url, Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.USER_NAME), Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.PASSWORD));
                }
                if ("JTDS".Equals(connectionDriver)) {
                    string url = "jdbc:jtds:sqlserver://";
                    string server = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.SERVER_ADDRESS);
                    if (server == null || (server).Length == 0) {
                        server = "localhost";
                    }
                    url += server;
                    string port = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.SERVER_PORT);
                    if (port != null && (port).Length > 0) {
                        url += ":" + port;
                    }
                    string dbName = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_NAME);
                    if (dbName != null && (dbName).Length > 0) {
                        url += "/" + dbName;
                    } else {
                        url += "/";
                    }
                    string instance = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_PATH);
                    if (instance != null && (instance).Length > 0) {
                        url += ";instance=" + instance;
                    }
                    //force cursors
                    //url+=";SelectMethod=cursor";
                    string driverClass = "net.sourceforge.jtds.jdbc.Driver";
                    try {
                        Net.Vpc.Upa.Impl.Util.PlatformUtils.ForName(driverClass);
                    } catch (System.Exception cls) {
                        throw new Net.Vpc.Upa.Exceptions.DriverNotFoundException(driverClass);
                    }
                    return Java.Sql.DriverManager.GetConnection(url, Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.USER_NAME), Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(properties,Net.Vpc.Upa.Persistence.ConnectionOption.PASSWORD));
                }
            } catch (Net.Vpc.Upa.Exceptions.UPAException e) {
                throw e;
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            } catch (System.Exception e) {
                //
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("CreateNativeConnectionFailed"));
            }
            throw new Net.Vpc.Upa.Exceptions.UPAException("Unknown driver");
        }


        protected internal override void PrepareNativeConnection(Net.Vpc.Upa.Persistence.UConnection connection, System.Collections.Generic.IDictionary<string , object> customAttributes) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            base.PrepareNativeConnection(connection, customAttributes);
            string dbname = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(GetConnectionProfile().GetProperties(),Net.Vpc.Upa.Persistence.ConnectionOption.DATABASE_NAME);
            if (dbname != null) {
                connection.ExecuteNonQuery("use " + dbname, null, null);
            }
            connection.ExecuteNonQuery("Set DATEFORMAT ymd", null, null);
        }


        public override string GetDisableIdentityConstraintsStatement(Net.Vpc.Upa.Entity table) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = table.GetPrimaryFields();
            foreach (Net.Vpc.Upa.Field field in fields) {
                if (field.GetInsertFormula() is Net.Vpc.Upa.Sequence) {
                    return ("Set Identity_Insert " + table.GetPersistenceName() + " On");
                }
            }
            return null;
        }


        public override string GetEnableIdentityConstraintsStatement(Net.Vpc.Upa.Entity table) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields = table.GetPrimaryFields();
            foreach (Net.Vpc.Upa.Field field in fields) {
                if (field.GetInsertFormula() is Net.Vpc.Upa.Sequence) {
                    return ("Set Identity_Insert " + GetValidIdentifier(GetPersistenceName(table)) + " Off");
                }
            }
            return null;
        }

        internal static Net.Vpc.Upa.Types.Timestamp ToTimestamp(object o) {
            if (o == null) {
                return null;
            } else if (o is Net.Vpc.Upa.Types.Timestamp) {
                return (Net.Vpc.Upa.Types.Timestamp) o;
            } else {
                Net.Vpc.Upa.Types.Temporal d = (Net.Vpc.Upa.Types.Temporal) o;
                Net.Vpc.Upa.Types.Calendar c = Net.Vpc.Upa.Types.Calendar.GetInstance();
                c.SetTime(d);
                int ms = c.Get(Net.Vpc.Upa.Types.Calendar.MILLISECOND);
                int tens = (ms / 10) * 10;
                int units = ms % 10;
                switch(units) {
                    case 0:
                    case 1:
                        {
                            units = 0;
                            break;
                        }
                    case 2:
                    case 3:
                    case 4:
                        {
                            units = 3;
                            break;
                        }
                    default:
                        {
                            units = 7;
                            break;
                        }
                }
                c.Set(Net.Vpc.Upa.Types.Calendar.MILLISECOND, tens + units);
                return new Net.Vpc.Upa.Types.Timestamp(c.GetTime().GetTime());
            }
        }
    }
}
