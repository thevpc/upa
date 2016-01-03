package net.vpc.upa.impl.persistence.specific.mysql;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import net.vpc.upa.Properties;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.shared.NullValANSISQLProvider;

import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.logging.Level;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.DriverNotFoundException;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.ConnectionOption;
import net.vpc.upa.persistence.ConnectionProfile;
import net.vpc.upa.types.I18NString;

@PortabilityHint(target = "C#", name = "suppress")
public class MySQLPersistenceStore extends DefaultPersistenceStore {

    private List<Param> queryParameters;

    public MySQLPersistenceStore() {
        Properties map = getProperties();
        map.setBoolean("isComplexSelectSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInDeleteStatementSupported", Boolean.FALSE);
        map.setBoolean("isReferencingSupported", Boolean.TRUE);
        map.setBoolean("isViewSupported", Boolean.FALSE);
        getSqlManager().register(new MySQLCoalesceSQLProvider());
        getSqlManager().register(new MySQLDatePartSQLProvider());
        getSqlManager().register(new MySQLIfSQLProvider());
        getSqlManager().register(new MySQLCastSQLProvider());
        getSqlManager().register(new MySQLLenSQLProvider());
        getSqlManager().register(new MySQLI2VSQLProvider());
        getSqlManager().register(new MySQLD2VSQLProvider());
        getSqlManager().register(new NullValANSISQLProvider());
        getSqlManager().register(new MySQLTypeNameSQLProvider());
        getSqlManager().register(new MySQLSelectSQLProvider());
    }

    @Override
    protected Set<String> getCustomReservedKeywords() {
        String resourcePath = null;
        /**
         * @PortabilityHint(target="C#",name="replace") resourcePath = "Persistence.MySQLKeywords.txt";
         */
        resourcePath = "net/vpc/upa/impl/persistence/MySQLKeywords.txt";
        return UPAUtils.loadLinesSet(resourcePath);
    }

    public Connection createNativeCustomNativeConnection(ConnectionProfile p) throws UPAException {
        try {
            String connectionDriver = p.getConnectionDriver();
            if (connectionDriver == null || connectionDriver.trim().isEmpty()) {
                connectionDriver = DRIVER_TYPE_DEFAULT;
            }
            Map<String, String> properties = p.getProperties();
            String userName = properties.get(ConnectionOption.USER_NAME);
            String password = properties.get(ConnectionOption.PASSWORD);
//            String driverKind = properties.get(ConnectionOption.DRIVER);
            //jdbc:mysql://localhost:3306/mysql?zeroDateTimeBehavior=convertToNull
            if (DRIVER_TYPE_DEFAULT.equalsIgnoreCase(connectionDriver)) {
                String url = "jdbc:mysql://";

                String server = properties.get(ConnectionOption.SERVER_ADDRESS);
                if (server == null || server.length() == 0) {
                    server = "localhost";
                }
                url += server;
                String port = properties.get(ConnectionOption.SERVER_PORT);
                if (port != null && port.trim().length() > 0) {
                    url += ":" + port;
                }
                String path = properties.get(ConnectionOption.DATABASE_PATH);
                if (path == null) {
                    path = "";
                }
                if (path.length() > 0 && !path.equals("/")) {
                    url += path;
                }
                String dbName = properties.get(ConnectionOption.DATABASE_NAME);
                if (dbName != null && dbName.length() > 0) {
                    url += "/" + dbName;
                }
                url += "?zeroDateTimeBehavior=convertToNull";
                String driverClass = "com.mysql.jdbc.Driver";
                log.log(Level.FINER, "Creating Connection \n\tProfile : {0} \n\tURL :{1}\n\tDriver :{2}\n\tUser :{3}", new Object[]{p, url, driverClass, userName});
                try {
                    PlatformUtils.forName(driverClass);
                } catch (Exception cls) {
                    throw new DriverNotFoundException(driverClass);
                }
                return DriverManager.getConnection(url, userName, password);
            }
        } catch (UPAException e) {
            throw e;
        } catch (SQLException e) {
//            if (e.getErrorCode() == 40000) {
//                throw new DatabaseNotFoundException(e, p.getProperties().get(ConnectionOption.DATABASE_NAME));
//            }
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        } catch (Exception e) {
            //
            throw new UPAException(e, new I18NString("CreateNativeConnectionFailed"));
        }
        throw new UPAException("Unknown driver");
    }

    /**
     * MSQL always names primary Key "PRIMARY" regardless of constraintsName
     *
     * @param tableName
     * @param constraintsName
     * @return
     */
    @PortabilityHint(target = "C#", name = "ignore")
    @Override
    protected boolean pkConstraintsExists(String tableName, String constraintsName) {
        try {
            ResultSet rs = null;
            try {
                Connection connection = getConnection().getMetadataAccessibleConnection();
                String catalog = connection.getCatalog();
                String schema = connection.getSchema();
                rs = connection.getMetaData().getPrimaryKeys(catalog, schema, getIdentifierStoreTranslator().translateIdentifier(tableName));
                while (rs.next()) {
                    String n = rs.getString("PK_NAME");
                    //n should be "PRIMARY"
                    //if PK exists than it is the one desire!
                    return true;
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

//    @Override
//    public NativeSQL nativeSQL(CompiledExpression expression, ExecutionContext qlContext, Map<String,DataType> generatedKeys) throws UPAException{
//        expression=getPersistenceUnit().compileExpression(expression);
//        String query = getSQL(expression, qlContext);
//        HashMap context = new HashMap(3);
//        query = getParser().simplify(query, context);
//        NativeSQL nativeSQL = new DefaultNativeSQL(NativeStatementType.SELECT);
//        SQLToken token = SQLToken.getForewardTokenAt(query, 0, false);
//        if ("INSERT".equalsIgnoreCase(token.getValue())) {
//            List<Param> values = ExpressionUtils.findExpressionsList(expression, new ExpressionFilter() {
//                @Override
//                public boolean accept(Expression e) {
//                    return e instanceof Param;
//                }
//            });
//            //TODO val list may be split according to query composition
//            SQLToken t = SQLToken.findForwardToken(query.toUpperCase(), token.getEnd(), "SELECT", 2, 0, false);
//            if (t == null) {
//                nativeSQL.addNativeStatement(new ReturnStatement(query, values,generatedKeys));
//            }
//            else {
//                nativeSQL.addNativeStatement(new InsertIntoSelectNativeStatement(query, values));
//            }
//        } else {
//            List<Param> values = ExpressionUtils.findExpressionsList(expression, new ExpressionFilter() {
//                @Override
//                public boolean accept(Expression e) {
//                    return e instanceof Param;
//                }
//            });
//            nativeSQL.addNativeStatement(new ReturnStatement(simplifyQuery(query, 0, query.length(), nativeSQL), values,generatedKeys));
//        }
//        return nativeSQL;
//    }
//    public static String simplifyQuery(String query, int startIndex, int endIndex, NativeSQL nativeSQL) {
////        System.out.println("simplifyExpression (\n" + query.substring(startIndex,endIndex)+"\n,startIndex="+startIndex+",endIndex="+endIndex+")");
//        StringBuilder sb = new StringBuilder();
//        for (int index = startIndex; index >= startIndex && index < endIndex; ) {
//            SQLToken t = SQLToken.getForewardTokenAt(query, index, true);
//            if (t == null) {
//                index = -1;
//                break;
//            }
//            if (t.accept(SQLToken.PAR)) {
//                sb.append('(');
//                sb.append(simplifyQuery(query, t.getStart() + 1, t.getEnd() - 1, nativeSQL));
//                sb.append(')');
//                index = t.getEnd();
//            } else {
//                sb.append(t.getValue());
//                index = t.getEnd();
//            }
//        }
//
//        String returned = null;
//        SQLToken lastToken = SQLToken.getForewardTokenAt(query, endIndex, true);
//        SQLToken firstToken = SQLToken.getForewardTokenAt(query, startIndex, true);
//        if (firstToken != null && firstToken.accept(SQLToken.KEYWORD) && "SELECT".equals(firstToken.getValue().toUpperCase())) {
//            SQLToken nextToken = lastToken;
//            SQLToken previousToken = firstToken;
//            boolean isVar = false;
//            do {
//                if (nextToken != null) {
//                    nextToken = SQLToken.nextToken(query, nextToken, true);
//                    if (nextToken != null && (nextToken.accept(SQLToken.OPERATOR) || nextToken.accept(SQLToken.SEPARATOR))) {
//                        isVar = true;
//                        break;
//                    }
//                    if (nextToken != null && (!nextToken.accept(SQLToken.PAR) && !nextToken.accept(SQLToken.WHITE) && !nextToken.accept(SQLToken.VAR) || nextToken.accept(SQLToken.KEYWORD))) {
//                        nextToken = null;
//                    }
//                }
//                if (previousToken == null) {
//                    continue;
//                }
//                previousToken = SQLToken.previousToken(query, previousToken, true);
//                if (previousToken != null && (previousToken.accept(SQLToken.OPERATOR) || previousToken.accept(SQLToken.SEPARATOR))) {
//                    isVar = true;
//                    break;
//                }
//                if (previousToken != null && (!previousToken.accept(SQLToken.PAR) && !previousToken.accept(SQLToken.WHITE) && !previousToken.accept(SQLToken.VAR) || previousToken.accept(SQLToken.KEYWORD))) {
//                    previousToken = null;
//                }
//            } while (nextToken != null || previousToken != null);
//            if (isVar) {
//                String computation = "VAR" + UUID.randomUUID().toString();
//                nativeSQL.addNativeStatement(new ComputeStatement(computation, sb.toString(), null));
//                return '{' + computation + '}';
//            }
//            returned = sb.toString();
//        } else {
//            returned = sb.toString();
//        }
//        return returned;
//    }
}
