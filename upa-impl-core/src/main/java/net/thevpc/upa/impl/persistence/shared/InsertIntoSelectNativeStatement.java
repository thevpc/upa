//package net.thevpc.upa.impl.persistence.shared;
//
//import net.thevpc.upa.exception.UPAException;
//import net.thevpc.upa.expression.Param;
//import net.thevpc.upa.impl.persistence.NativeStatement;
//import net.thevpc.upa.impl.persistence.parser.SQLToken;
//import net.thevpc.upa.persistence.PersistenceUnitManager;
//
//import java.sql.ResultSet;
//import java.sql.ResultSetMetaData;
//import java.sql.SQLException;
//import java.sql.Types;
//import java.util.List;
//
//*
// * @author Taha BEN SALAH <taha.bensalah@gmail.com>
// * @creationdate 8/26/12 8:52 PM
//
//
//public class InsertIntoSelectNativeStatement implements NativeStatement {
//    //    private Statement stmt;
////    private ResultSet rs;
//    private String insertIntoString;
//    private String selectString;
//    private List<Param> queryParameters;
//
//    public InsertIntoSelectNativeStatement(String query, List<Param> queryParameters) {
//        SQLToken t = SQLToken.findForwardToken(query.toUpperCase(), 0, "SELECT", 2, 0, false);
//        insertIntoString = query.substring(0, t.getStart() - 1);
//        selectString = query.substring(t.getStart());
//        this.queryParameters = queryParameters;
//    }
//
//    public void execute() throws SQLException, UPAException {
//        ResultSet rs = null;
//        long startTime = System.currentTimeMillis();
//        try {
//            PersistenceUnitManager persistenceManager = context.getPersistenceManager();
//            try {
//                rs = persistenceManager.executeNativeQuery(selectString);
//            } finally {
//                long endTime = System.currentTimeMillis();
////                Log.log(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG, "[TIME=" + Log.DELTA_FORMAT.format(endTime - startTime) + "] InsertIntoSelectNativeStatement :=" + selectString);
//            }
//            ResultSetMetaData rsmd = rs.getMetaData();
//            int max = rsmd.getColumnCount();
//            int inserted;
//            int count = -1;
//            for (inserted = 0; rs.next(); inserted += count) {
//                StringBuilder sb = new StringBuilder(" values (");
//                for (int i = 0; i < max; i++) {
//                    int sqlType = rsmd.getColumnType(i + 1);
//                    Object val = null;
//                    switch (sqlType) {
//                        case Types.LONGVARCHAR:
//                        case Types.CHAR: // '\001'
//                        case Types.VARCHAR: // '\f'
//                        case Types.BLOB:
//                            val = rs.getString(i + 1);
//                            break;
//
//                        default:
//                            val = rs.getString(i + 1);
//                            break;
//                    }
//                    if (i > 0)
//                        sb.append(", ");
//                    sb.append(persistenceManager.formatSqlValue(val));
//                }
//
//                sb.append(")");
//                context.setCurrentQuery(insertIntoString + sb);
//                context.setCurrentQueryInfo("MySQLAdapter.InsertIntoSelectNativeStatement");
//                count = executeNonQuery(context.getQuery(), queryParameters);
//            }
//
//            context.setResultCount(inserted);
//        } finally {
//            if (rs != null) {
//                rs.close();
//            }
//        }
//    }
//
//
//    public void dispose() throws SQLException {
//    }
//
//    @Override
//    public String toString() {
//        return "InsertIntoSelectNativeStatement : {" + insertIntoString + "," + selectString + "}";
//    }
//
//}
