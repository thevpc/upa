//package net.thevpc.upa.impl.persistence;
//
//
//import net.thevpc.upa.impl.persistence.QueryExecutor;
//import net.thevpc.upa.persistence.PersistenceUnitManager;
//
//import java.sql.ResultSet;
//import java.sql.SQLException;
//import java.sql.Statement;
//
//
//public class ResultSetDelegate extends ResultSetHandler {
//
//    public ResultSetDelegate(ResultSet rs, StatementDelegate statement, QueryExecutor execContext) {
//        super(rs);
//        this.statement = statement;
//        this.execContext = execContext;
//    }
//
//    public QueryExecutor getContext() {
//        return execContext;
//    }
//
////    public void close()
////            throws SQLException {
////        super.close();
////        if (execContext != null) {
////            QueryExecutor c = execContext;
////            if (c != null) {
////                c.dispose();
////            }
////        }
////    }
//
////    public PersistenceUnitManager getPersistenceManager() {
////        return statement.getPersistenceManager();
////    }
//
//    @Override
//    public Statement getStatement()
//            throws SQLException {
//        return statement;
//    }
//
//    private Statement statement;
////    private QueryExecutor execContext;
//}
