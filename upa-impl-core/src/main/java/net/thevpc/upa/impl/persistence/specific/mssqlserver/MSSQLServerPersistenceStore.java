package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.*;
import net.thevpc.upa.Properties;
import net.thevpc.upa.exceptions.DriverNotFoundException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.DefaultPersistenceStore;
import net.thevpc.upa.impl.persistence.DefaultViewKeyPersistenceDefinition;
import net.thevpc.upa.impl.persistence.SqlTypeName;
import net.thevpc.upa.impl.persistence.shared.sql.CastAsSQLProvider;
import net.thevpc.upa.impl.persistence.shared.sql.CoalesceANSISQLProvider;
import net.thevpc.upa.impl.persistence.shared.sql.NullValANSISQLProvider;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.util.UPAUtils;
import net.thevpc.upa.persistence.*;
import net.thevpc.upa.types.Date;
import net.thevpc.upa.persistence.*;

import net.thevpc.upa.types.DateTime;
import net.thevpc.upa.types.I18NString;
import net.thevpc.upa.types.Month;
import net.thevpc.upa.types.Year;

import java.sql.*;
import java.sql.Time;
import java.sql.Timestamp;
import java.util.*;
import java.util.logging.Level;

import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.DoubleType;
import net.thevpc.upa.types.EnumType;
import net.thevpc.upa.types.TemporalOption;
import net.thevpc.upa.types.TemporalType;

@PortabilityHint(target = "C#", name = "suppress")
public class MSSQLServerPersistenceStore extends DefaultPersistenceStore {

    private Set<String> keywords;

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if (p == DatabaseProduct.MSSQLSERVER) {
            return 10;
        }
        return -1;
    }

    public void configureStore() {
        super.configureStore();
        String resourcePath = null;

        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath =
         * "Persistence.DerbyKeywords.txt";
         */
        resourcePath = "net/thevpc/upa/impl/persistence/MSSQLServerKeywords.txt";

        keywords = UPAUtils.loadLinesSet(resourcePath);

        Properties map = getStoreParameters();
        map.setBoolean(PARAM_IS_COMPLEX_SELECT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_UPDATE_STATMENT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_FROM_CLAUSE_IN_DELETE_STATMENT_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_REFERENCING_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_VIEW_SUPPORTED, Boolean.TRUE);
        map.setBoolean(PARAM_IS_TOP_SUPPORTED, Boolean.TRUE);
        getSqlManager().register(new CoalesceANSISQLProvider());
        getSqlManager().register(new CastAsSQLProvider());
        getSqlManager().register(new MSSQLServerConcatSQLProvider());
        getSqlManager().register(new MSSQLServerDatePartSQLProvider());
        getSqlManager().register(new MSSQLServerDateDiffSQLProvider());
        getSqlManager().register(new MSSQLServerDateAddSQLProvider());
        getSqlManager().register(new MSSQLServerIfSQLProvider());
        getSqlManager().register(new MSSQLServerStrLenSQLProvider());
        getSqlManager().register(new MSSQLServerSystemDateTimeSQLProvider());
        getSqlManager().register(new MSSQLServerD2VSQLProvider());
        getSqlManager().register(new MSSQLServerMonthStartSQLProvider());
        getSqlManager().register(new MSSQLServerMonthEndSQLProvider());
        getSqlManager().register(new MSSQLServerCoalesceSQLProvider());
        getSqlManager().register(new NullValANSISQLProvider());
        getSqlManager().register(new MSSQLServerSelectSQLProvider());
        getSqlManager().register(new MSSQLServerDateTruncSQLProvider());
        getSqlManager().register(new MSSQLServerDecodeSQLProvider());
        getMarshallManager().setTypeMarshaller(Date.class, new MSSQLServerDateOnlyMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(Month.class, new MSSQLServerMonthYearMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(Year.class, new MSSQLServerYearMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(net.thevpc.upa.types.Time.class, new MSSQLServerTimeMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(DateTime.class, new MSSQLServerDateTimeMarshaller(getMarshallManager()));

        getMarshallManager().setTypeMarshaller(Date.class, new MSSQLServerDateOnlyMarshaller(getMarshallManager()));

        getMarshallManager().setTypeMarshaller(Month.class, new MSSQLServerMonthYearMarshaller(getMarshallManager()));

        getMarshallManager().setTypeMarshaller(Year.class, new MSSQLServerYearMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(DateTime.class, new MSSQLServerDateTimeMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(Time.class, new MSSQLServerTimeMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(Timestamp.class, new MSSQLServerTimeStampMarshaller(getMarshallManager()));
    }

    @Override
    protected Set<String> getCustomReservedKeywords() {
        String resourcePath = null;
        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath =
         * "Persistence.MSSQLServerKeywords.txt";
         */
        resourcePath = "net/thevpc/upa/impl/persistence/MSSQLServerKeywords.txt";
        return UPAUtils.loadLinesSet(resourcePath);
    }

//    private String sql_format_int(String expr,int width){
//        return "replace(space("+width+"-len(ltrim(str("+expr+")))),' ','0')+ltrim(str("+expr+"))";
//        //return "cast("+expr+" as varchar)";
//    }
//    private String sql_format_string(String expr,int width){
//        return "replace(space("+width+"-len("+expr+")),' ','0')+"+expr;
//    }
    @Override
    public String getColumnDeclaration(PrimitiveField field, EntityExecutionContext executionContext) throws UPAException {
        String s = super.getColumnDeclaration(field, executionContext);
        Entity table = field.getEntity();
        if (field.isId() && UPAUtils.getPersistFormula(field) instanceof Sequence) {
            Sequence seq = (Sequence) UPAUtils.getPersistFormula(field);
            s += " Identity(" + seq.getInitialValue() + "," + seq.getAllocationSize() + ")";
        }
        return s;
    }

    @Override
    public Connection createCustomPlatformConnection(ConnectionProfile p) throws UPAException {
        log.log(Level.FINE, "createCustomPlatformConnection");
        try {
            String connectionDriver = p.getConnectionDriver();
            if (connectionDriver == null || connectionDriver.trim().isEmpty()) {
                connectionDriver = DRIVER_TYPE_DEFAULT;
            }
//            Map<String, String> properties = p.getProperties();
            if (DRIVER_TYPE_DEFAULT.equalsIgnoreCase(connectionDriver)) {
                String url = "jdbc:microsoft:sqlserver://";

                String server = p.getProperty(ConnectionOption.SERVER_ADDRESS);
                if (server == null || server.length() == 0) {
                    server = "localhost";
                }
                url += server;

                String instance = p.getProperty(ConnectionOption.DATABASE_PATH);
                if (instance != null && instance.length() > 0) {
                    url += "\\" + instance;
                }

                String port = p.getProperty(ConnectionOption.SERVER_PORT);
                if (port != null && port.length() > 0) {
                    url += ":" + port;
                }
                String dbName = p.getProperty(ConnectionOption.DATABASE_NAME);
                if (dbName != null && dbName.length() > 0) {
                    url += ";databaseName=" + dbName;
                }
                //force cursors
                url += ";SelectMethod=cursor";
                String driverClass = "com.microsoft.jdbc.sqlserver.SQLServerDriver";
                try {
                    PlatformUtils.forName(driverClass);
                } catch (Exception cls) {
                    throw new DriverNotFoundException(driverClass);
                }
                return DriverManager.getConnection(url, p.getProperty(ConnectionOption.USER_NAME), p.getProperty(ConnectionOption.PASSWORD));
            }
            if ("JTDS".equals(connectionDriver)) {
                String url = "jdbc:jtds:sqlserver://";

                String server = p.getProperty(ConnectionOption.SERVER_ADDRESS);
                if (server == null || server.length() == 0) {
                    server = "localhost";
                }
                url += server;

                String port = p.getProperty(ConnectionOption.SERVER_PORT);
                if (port != null && port.length() > 0) {
                    url += ":" + port;
                }
                String dbName = p.getProperty(ConnectionOption.DATABASE_NAME);
                if (dbName != null && dbName.length() > 0) {
                    url += "/" + dbName;
                } else {
                    url += "/";
                }
                String instance = p.getProperty(ConnectionOption.DATABASE_PATH);
                if (instance != null && instance.length() > 0) {
                    url += ";instance=" + instance;
                }

                //force cursors
                //url+=";SelectMethod=cursor";
                String driverClass = "net.sourceforge.jtds.jdbc.Driver";
                String user = p.getProperty(ConnectionOption.USER_NAME);
                String password = p.getProperty(ConnectionOption.PASSWORD);
                return createPlatformConnection(driverClass, url, user, password, p.getProperties());
            }
        } catch (UPAException e) {
            throw e;
        } catch (Exception e) {
            //
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
        throw new UPAException("Unknown driver");
    }

    @Override
    protected void prepareNativeConnection(UConnection connection, Map<String, Object> customAttributes, ConnectionProfile connectionProfile) throws UPAException {
        super.prepareNativeConnection(connection, customAttributes, connectionProfile);
        String dbname = connectionProfile.getProperty(ConnectionOption.DATABASE_NAME);
        if (dbname != null) {
            connection.executeNonQuery("use " + dbname, null, null);
        }
        connection.executeNonQuery("Set DATEFORMAT ymd", null, null);
    }

//    public boolean addPersistenceUnit() throws UPAException {
//        StructureStrategy option = connectionProfile.getCreateSchemaOption();
//        String masterDbName = "master";
//        String databaseName = connectionProfile.getDatabaseName();
//        try {
//            switch (option) {
//                case MANDATORY: {
//                    Connection c = null;
//                    try {
//                        c = createNativeConnection();
//                    } catch (SQLException e) {
//                        e.printStackTrace();
//                        NoSuchPersistenceUnitException d = new NoSuchPersistenceUnitException(databaseName, e);
//                        throw d;
//                    } finally {
//                        if (c != null) {
//                            c.close();
//                        }
//                    }
//                    break;
//                }
//                case DROP: {
//                    if (DatabaseProduct.PROFILE_ODBC.equals(connectionProfile.getProfileName())) {
//                        throw new DropPersistenceUnitException("option " + option + " not supported in Odbc", null);
//                    }
//                    Statement st = null;
//                    Connection c = createMasterConnection(masterDbName, connectionProfile.getLogin(), connectionProfile.getPassword(), properties, windowMode);
//                    st = c.createStatement();
//                    boolean dbExists = false;
//                    try {
//                        st.executeUpdate("use " + databaseName);
//                        dbExists = true;
//                        st.executeUpdate("use " + masterDbName);
//                    } catch (SQLException e) {
//                        // do nothing
//                    }
//                    try {
//                        if (dbExists) {
//                            st.executeUpdate("drop database " + databaseName);
//                            c.commit();
//                        }
//                    } catch (SQLException e) {
//                        throw new DropPersistenceUnitException(databaseName, e);
//                    }
//                    try {
//                        st.executeUpdate("create database " + databaseName);
//                        c.commit();
//                    } catch (SQLException e) {
//                        throw new CreatePersistenceUnitException(databaseName, e);
//                    }
//                    break;
//                }
//                case CREATE: {
//                    if (DatabaseProduct.PROFILE_ODBC.equals(connectionProfile.getProfileName())) {
//                        throw new DropPersistenceUnitException("option " + option + " not supported in Odbc", null);
//                    }
//                    Statement st = null;
//                    Connection c = createMasterConnection(masterDbName, connectionProfile.getLogin(), connectionProfile.getPassword(), properties, windowMode);
//                    st = c.createStatement();
//                    boolean dbExists = false;
//                    try {
//                        st.executeUpdate("use " + databaseName);
//                        dbExists = true;
//                        st.executeUpdate("use " + masterDbName);
//                    } catch (SQLException e) {
//                        // do nothing
//                    }
//                    if (dbExists) {
//                        throw new PersistenceUnitAlreadyExistsException(databaseName);
//                    }
//                    try {
//                        st.executeUpdate("create database " + databaseName);
//                        c.commit();
//                    } catch (SQLException e) {
//                        throw new CreatePersistenceUnitException(databaseName, e);
//                    }
//                    break;
//                }
//                case IGNORE: {
//                    Statement st = null;
//                    Connection c = createMasterConnection(masterDbName, connectionProfile.getLogin(), connectionProfile.getPassword(), properties, windowMode);
//                    st = c.createStatement();
//                    boolean dbExists = false;
//                    try {
//                        st.executeUpdate("use " + databaseName);
//                        dbExists = true;
//                        st.executeUpdate("use " + masterDbName);
//                    } catch (SQLException e) {
//                        // do nothing
//                    }
//                    if (!dbExists) {
//                        try {
//                            st.executeUpdate("create database " + databaseName);
//                            c.commit();
//                        } catch (SQLException e) {
//                            throw new CreatePersistenceUnitException(databaseName, e);
//                        }
//                    }
//                    break;
//                }
//            }
//        } catch (SQLException e) {
//            throw new UPAException(e, new I18NString("addPersistenceUnit"));
//        }
//        return true;
//    }
    @Override
    public String getDisableIdentityConstraintsStatement(Entity table) {
        List<Field> fields = table.getIdFields();
        for (Field field : fields) {
            if (UPAUtils.getPersistFormula(field) instanceof Sequence) {
                return ("Set Identity_Insert " + getValidIdentifier(getPersistenceName(table)) + " On");
            }
        }
        return null;
    }

    @Override
    public String getEnableIdentityConstraintsStatement(Entity table) {
        List<Field> fields = table.getIdFields();
        for (Field field : fields) {
            if (UPAUtils.getPersistFormula(field) instanceof Sequence) {
                return ("Set Identity_Insert " + getValidIdentifier(getPersistenceName(table)) + " Off");
            }
        }
        return null;
    }

//    public boolean isValidPersistenceUnit() throws UPAException {
//        Connection c = createMasterConnection("master", profile.getLogin(), profile.getPassword(), properties, windowMode);
//        String databaseName = profile.getDatabaseName();
//        Statement st = null;
//        try {
//            if (c != null) {
//                try {
//                    st = c.createStatement();
//                    st.executeUpdate("use " + databaseName);
//                    st.executeUpdate("use master");
//                    return true;
//                } catch (SQLException notFound) {
//                    return false;
//                } finally {
//                    c.close();
//                }
//            }
//        } catch (SQLException e) {
//            throw new UPAException(e, new I18NString("DropDatabaseFailed"), databaseName);
//        }
//        return false;
//    }
    static Timestamp toTimestamp(Object o) {
        if (o == null) {
            return null;
        } else if (o instanceof Timestamp) {
            return (Timestamp) o;
        } else {
            java.util.Date d = (java.util.Date) o;
            Calendar c = Calendar.getInstance();
            c.setTime(d);
            int ms = c.get(Calendar.MILLISECOND);
            int tens = (ms / 10) * 10;
            int units = ms % 10;
            switch (units) {
                case 0:
                case 1: {
                    units = 0;
                    break;
                }
                case 2:
                case 3:
                case 4: {
                    units = 3;
                    break;
                }
                default: {
                    units = 7;
                    break;
                }

            }
            c.set(Calendar.MILLISECOND, tens + units);
            return new Timestamp(c.getTime().getTime());
        }
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
                    String n = rs.getString("TABLE_NAME");
                    String t = rs.getString("TYPE_NAME");
                    return new DefaultViewKeyPersistenceDefinition(n, catalog, schema, getStoreViewDefinitionSQL(n, connection));
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

    protected String getStoreViewDefinitionSQL(String viewName, Connection conn) {
        String definition = null;
        PreparedStatement ps = null;
        ResultSet rs = null;
        try {
            try {
                ps = conn.prepareStatement(
                        "select definition\n"
                        + "from sys.objects     o\n"
                        + "join sys.sql_modules m on m.object_id = o.object_id\n"
                        + "where o.object_id = object_id( ?)\n"
                        + "  and o.type      = 'V'");
                ps.setString(1, conn.getSchema() + "." + viewName);
                rs = ps.executeQuery();
                if (rs.next()) {
                    definition = rs.getString(1);
                }
                rs.close();
            } finally {
                if (rs != null) {
                    rs.close();
                }
                if (ps != null) {
                    ps.close();
                }
            }
        } catch (SQLException ex) {
            throw new UPAException();
        }
        return definition;
    }

    public SqlTypeName getSqlTypeName(DataType datatype) {
        Class platformType = datatype.getPlatformType();
        int length = datatype.getScale();
        int precision = datatype.getPrecision();
        if (PlatformUtils.isString(platformType)) {
            if (length <= 0) {
                length = 255;
            }
            if (length <= 8000) {
                return new SqlTypeName("VARCHAR", length);
            } else {
                return new SqlTypeName("NTEXT");
            }
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
            if (datatype instanceof DoubleType) {
                DoubleType n = ((DoubleType) datatype);
                return n.isFixedDigits() ? new SqlTypeName("DECIMAL", (n.getMaximumIntegerDigits() + n.getMaximumFractionDigits()), n.getMaximumFractionDigits())
                        : new SqlTypeName("FLOAT");
            } else {
                return new SqlTypeName("FLOAT");
            }
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
        if (datatype instanceof EnumType) {
            //TODO should support marshalling types
            return new SqlTypeName("INT");
        }
        if (Object.class.equals(platformType) || PlatformUtils.isSerializable(platformType)) {
            return new SqlTypeName("IMAGE"); // serialized form
        }
        throw new IllegalUPAArgumentException("UNKNOWN_TYPE<" + platformType.getName() + "," + length + "," + precision + ">");
    }

    public String getAlterTableModifyColumnStatement(PrimitiveField field, EntityExecutionContext context) throws UPAException {
        String tableName = getPersistenceName(field.getEntity());
        String columnName = getPersistenceName(field);
        ColumnPersistenceDefinition persistenceDefinition = getStoreColumnDefinition(tableName, columnName, context, (Connection)context.getConnection().getPlatformConnection());
        ColumnPersistenceDefinition expected = getModelColumnPersistenceDefinition(field, context);
        StringBuilder sb = new StringBuilder("Alter Table ")
                .append(getTableName(field.getEntity()))
                .append(" Modify ")
                .append(getValidIdentifier(getColumnName(field)))
                .append(" ");
        DataTypeTransform cr = field.getEffectiveTypeTransform();
        if (!expected.getColumnTypeName().equals(persistenceDefinition.getColumnTypeName())
                || expected.getSize() != -1 && expected.getSize() != persistenceDefinition.getSize()
                || expected.getScale() != -1 && expected.getScale() != persistenceDefinition.getScale()) {
            sb.append(getSqlTypeName(cr.getTargetType()).getFullName());
        }
        return sb.toString();
    }

}
