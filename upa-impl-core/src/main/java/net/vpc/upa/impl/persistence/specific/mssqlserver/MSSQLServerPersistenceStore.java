package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.Properties;
import net.vpc.upa.persistence.*;
import net.vpc.upa.types.Date;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.DriverNotFoundException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.shared.sql.CastAsSQLProvider;
import net.vpc.upa.impl.persistence.shared.sql.CoalesceANSISQLProvider;
import net.vpc.upa.impl.persistence.shared.sql.NullValANSISQLProvider;
import net.vpc.upa.types.DateTime;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.types.Month;
import net.vpc.upa.types.Year;

import java.sql.*;
import java.sql.Time;
import java.sql.Timestamp;
import java.util.*;
import java.util.logging.Level;
import net.vpc.upa.impl.util.PlatformUtils;

@PortabilityHint(target = "C#",name = "suppress")
public class MSSQLServerPersistenceStore extends DefaultPersistenceStore {

    private Set<String> keywords;

    @Override
    public int getSupportLevel(ConnectionProfile connectionProfile, Properties parameters) {
        DatabaseProduct p = connectionProfile.getDatabaseProduct();
        if(p==DatabaseProduct.MSSQLSERVER){
            return 10;
        }
        return -1;
    }

    public void configureStore(){
        super.configureStore();
        String resourcePath = null;
        
        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath = "Persistence.DerbyKeywords.txt";
         */
        resourcePath="net/vpc/upa/impl/persistence/MSSQLServerKeywords.txt";
        
        keywords = UPAUtils.loadLinesSet(resourcePath);

        net.vpc.upa.Properties map = getStoreParameters();
        map.setBoolean("isComplexSelectSupported", Boolean.TRUE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", Boolean.TRUE);
        map.setBoolean("isFromClauseInDeleteStatementSupported", Boolean.TRUE);
        map.setBoolean("isReferencingSupported", Boolean.TRUE);
        map.setBoolean("isViewSupported", Boolean.TRUE);
        map.setBoolean("isTopSupported", Boolean.TRUE);
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
        getSqlManager().register(new MSSQLServerTypeNameSQLProvider());
        getSqlManager().register(new MSSQLServerSelectSQLProvider());
        getSqlManager().register(new MSSQLServerDateTruncSQLProvider());
        getSqlManager().register(new MSSQLServerDecodeSQLProvider());
        getMarshallManager().setTypeMarshaller(Date.class, new MSSQLServerDateOnlyMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(Month.class, new MSSQLServerMonthYearMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(Year.class, new MSSQLServerYearMarshaller(getMarshallManager()));
        getMarshallManager().setTypeMarshaller(net.vpc.upa.types.Time.class, new MSSQLServerTimeMarshaller(getMarshallManager()));
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
         * @PortabilityHint(target="C#",name="replace") resourcePath = "Persistence.MSSQLServerKeywords.txt";
         */
        resourcePath="net/vpc/upa/impl/persistence/MSSQLServerKeywords.txt";
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
    public String getFieldDeclaration(PrimitiveField field, net.vpc.upa.persistence.EntityExecutionContext executionContext) throws UPAException {
        String s = super.getFieldDeclaration(field,executionContext);
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

}
