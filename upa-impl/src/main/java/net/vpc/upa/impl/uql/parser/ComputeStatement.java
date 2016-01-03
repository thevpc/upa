package net.vpc.upa.impl.uql.parser;

//package net.vpc.upa.impl.persistence.parser;
//
//
//import net.vpc.upa.persistence.ContextOperation;
//import net.vpc.upa.impl.persistence.NativeStatement;
//import net.vpc.upa.expression.Literal;
//import net.vpc.upa.expression.Param;
//import DataType;
//
//import java.sql.ResultSet;
//import java.sql.SQLException;
//import java.util.List;
//import net.vpc.upa.exception.UPAException;
//
///**
// * User: taha
// * Date: 25 juin 2003
// * Time: 17:30:12
// */
//public class ComputeStatement
//        implements NativeStatement {
//    private List<Param> queryParameters;
//
//    private String varName;
//    private String expression;
//
//    public ComputeStatement(String varName, String expression,List<Param> queryParameters) {
//        this.expression = expression;
//        this.varName = varName;
//        this.queryParameters = queryParameters;
//    }
//
//    public void execute()
//            throws SQLException, UPAException{
//        ResultSet rs = null;
//        long startTime = System.currentTimeMillis();
//        try {
//            context.setCurrentQuery(expression);
//            rs = context.getPersistenceManager().executeNativeQuery(context.getQuery(),queryParameters);
//            boolean first = true;
//            StringBuilder value = new StringBuilder();
//            while (rs.next()) {
//                if (first) {
//                    first = false;
//                } else {
//                    value.append(",");
//                }
//                value.append(context.getPersistenceManager().getSQL(new Literal(rs.getObject(1), DataType.ANY_OBJECT), context.getPersistenceManager().createContext(ContextOperation.FIND)));
//            }
//            if (first)
//                context.setParameter(varName, null);
//            else
//                context.setParameter(varName, value.toString());
//        } finally {
//            long endTime = System.currentTimeMillis();
////            Log.log(PersistenceUnitManager.DB_QUERY_LOG, "[ADAPTER] COMPUTE{" + varName + "} := " + context.getParameter(varName) + " := " + expression);
////            Log.log(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG, "[TIME=" + Log.DELTA_FORMAT.format(endTime - startTime) + "] COMPUTE{" + varName + "} := " + context.getParameter(varName) + " := " + context.getCurrentQuery());
//            if (rs != null) {
//                rs.close();
//            }
//        }
//    }
//
//    public void dispose()
//            throws SQLException {
//    }
//
//    public String toString() {
//        return "set {" + varName + "} := " + expression;
//    }
//
//}
