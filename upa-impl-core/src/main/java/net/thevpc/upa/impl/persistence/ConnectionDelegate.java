//
//package net.thevpc.upa.impl.persistence;
//
//import net.thevpc.upa.persistence.PersistenceUnitManager;
//
//import java.sql.Connection;
//
//public class ConnectionDelegate extends ConnectionHandler {
//    private PersistenceUnitManager adapter;
//
//    public ConnectionDelegate(PersistenceUnitManager adapter, Connection conn) {
//        super(conn);
//        this.adapter = adapter;
//    }
//
//    public PersistenceUnitManager getPersistenceManager() {
//        return adapter;
//    }
//
////    @Override
////    public Statement createStatement()
////            throws SQLException {
////        return getHandledConnection().createStatement();
////        //return new StatementDelegate(s, this);
////    }
//
////    private Object transactionKey;
////    public boolean isInTransaction(){
////        return transactionKey!=null;
////    }
////
////    public Object tryBeginTransaction(){
////        if(transactionKey==null){
////            transactionKey=new Object();
////            return transactionKey;
////        }else{
////            return null;
////        }
////    }
////
////    public boolean tryCommitTransaction(Object o) throws SQLException{
////        if(transactionKey==o){
////            transactionKey=null;
////            commit();
////            return true;
////        }else{
////            return false;
////        }
////    }
////
////    public boolean tryRollbackTransaction(Object o) throws SQLException{
////        if(transactionKey==o){
////            transactionKey=null;
////            rollback();
////            return true;
////        }else{
////            return false;
////        }
////    }
////
////    public boolean tryFinalizeTransaction(boolean succeded,Object o) throws SQLException{
////        if(transactionKey==o){
////            transactionKey=null;
////            if(succeded){
////                commit();
////            }else{
////                rollback();
////            }
////            return true;
////        }else{
////            return false;
////        }
////    }
//
//}
