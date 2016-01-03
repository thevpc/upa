//
//package net.vpc.upa.impl.persistence;
//
//import java.sql.*;
//import java.util.Map;
//import java.util.Properties;
//import java.util.concurrent.Executor;
//
//public class ConnectionHandler implements Connection {
//
//    private Connection handledInstance;
//
//    public Connection getHandledConnection() {
//        return handledInstance;
//    }
//
//    public ConnectionHandler(Connection some_instance) {
//        handledInstance = null;
//        handledInstance = some_instance;
//    }
//
//    public boolean getAutoCommit()
//            throws SQLException {
//        return handledInstance.getAutoCommit();
//    }
//
//    public boolean isClosed()
//            throws SQLException {
//        return handledInstance.isClosed();
//    }
//
//    public boolean isReadOnly()
//            throws SQLException {
//        return handledInstance.isReadOnly();
//    }
//
//    public int getHoldability()
//            throws SQLException {
//        return handledInstance.getHoldability();
//    }
//
//    public int getTransactionIsolation()
//            throws SQLException {
//        return handledInstance.getTransactionIsolation();
//    }
//
//    public String getCatalog()
//            throws SQLException {
//        return handledInstance.getCatalog();
//    }
//
//    public String nativeSQL(String param_1)
//            throws SQLException {
//        return handledInstance.nativeSQL(param_1);
//    }
//
//    public CallableStatement prepareCall(String param_1)
//            throws SQLException {
//        return handledInstance.prepareCall(param_1);
//    }
//
//    public CallableStatement prepareCall(String param_1, int param_2, int param_3)
//            throws SQLException {
//        return handledInstance.prepareCall(param_1, param_2, param_3);
//    }
//
//    public CallableStatement prepareCall(String param_1, int param_2, int param_3, int param_4)
//            throws SQLException {
//        return handledInstance.prepareCall(param_1, param_2, param_3, param_4);
//    }
//
//    public DatabaseMetaData getMetaData()
//            throws SQLException {
//        return handledInstance.getMetaData();
//    }
//
//    public PreparedStatement prepareStatement(String param_1)
//            throws SQLException {
//        return handledInstance.prepareStatement(param_1);
//    }
//
//    public PreparedStatement prepareStatement(String param_1, int param_2)
//            throws SQLException {
//        return handledInstance.prepareStatement(param_1, param_2);
//    }
//
//    public PreparedStatement prepareStatement(String param_1, int param_2, int param_3)
//            throws SQLException {
//        return handledInstance.prepareStatement(param_1, param_2, param_3);
//    }
//
//    public PreparedStatement prepareStatement(String param_1, int param_2, int param_3, int param_4)
//            throws SQLException {
//        return handledInstance.prepareStatement(param_1, param_2, param_3, param_4);
//    }
//
//    public PreparedStatement prepareStatement(String param_1, int[] param_2)
//            throws SQLException {
//        return handledInstance.prepareStatement(param_1, param_2);
//    }
//
//    public PreparedStatement prepareStatement(String param_1, String[] param_2)
//            throws SQLException {
//        return handledInstance.prepareStatement(param_1, param_2);
//    }
//
//    public SQLWarning getWarnings()
//            throws SQLException {
//        return handledInstance.getWarnings();
//    }
//
//    public Savepoint setSavepoint()
//            throws SQLException {
//        return handledInstance.setSavepoint();
//    }
//
//    public Savepoint setSavepoint(String param_1)
//            throws SQLException {
//        return handledInstance.setSavepoint(param_1);
//    }
//
//    public Statement createStatement()
//            throws SQLException {
//        return handledInstance.createStatement();
//    }
//
//    public Statement createStatement(int param_1, int param_2)
//            throws SQLException {
//        return handledInstance.createStatement(param_1, param_2);
//    }
//
//    public Statement createStatement(int param_1, int param_2, int param_3)
//            throws SQLException {
//        return handledInstance.createStatement(param_1, param_2, param_3);
//    }
//
//    public Map<String,Class<?>> getTypeMap()
//            throws SQLException {
//        return handledInstance.getTypeMap();
//    }
//
//    public void clearWarnings()
//            throws SQLException {
//        handledInstance.clearWarnings();
//    }
//
//    public void close()
//            throws SQLException {
//        handledInstance.close();
//    }
//
//    public void commit()
//            throws SQLException {
//        handledInstance.commit();
//    }
//
//    public void releaseSavepoint(Savepoint param_1)
//            throws SQLException {
//        handledInstance.releaseSavepoint(param_1);
//    }
//
//    public void rollback()
//            throws SQLException {
//        handledInstance.rollback();
//    }
//
//    public void rollback(Savepoint param_1)
//            throws SQLException {
//        handledInstance.rollback(param_1);
//    }
//
//    public void setAutoCommit(boolean param_1)
//            throws SQLException {
//        handledInstance.setAutoCommit(param_1);
//    }
//
//    public void setCatalog(String param_1)
//            throws SQLException {
//        handledInstance.setCatalog(param_1);
//    }
//
//    public void setHoldability(int param_1)
//            throws SQLException {
//        handledInstance.setHoldability(param_1);
//    }
//
//    public void setReadOnly(boolean param_1)
//            throws SQLException {
//        handledInstance.setReadOnly(param_1);
//    }
//
//    public void setTransactionIsolation(int param_1)
//            throws SQLException {
//        handledInstance.setTransactionIsolation(param_1);
//    }
//
////    public void setTypeMap(Map param_1)
////            throws SQLException {
////        handledInstance.setTypeMap(param_1);
////    }
//
//    ///1.6
//
//    public <T> T unwrap(Class<T> iface) throws SQLException {
//        return handledInstance.unwrap(iface);
//    }
//
//    public boolean isWrapperFor(Class<?> iface) throws SQLException {
//        return handledInstance.isWrapperFor(iface);
//    }
//
//    public void setTypeMap(Map<String, Class<?>> map) throws SQLException {
//        handledInstance.setTypeMap(map);
//    }
//
//    public Clob createClob() throws SQLException {
//        return handledInstance.createClob();
//    }
//
//    public Blob createBlob() throws SQLException {
//        return handledInstance.createBlob();
//    }
//
//    public NClob createNClob() throws SQLException {
//        return handledInstance.createNClob();
//    }
//
//    public SQLXML createSQLXML() throws SQLException {
//        return handledInstance.createSQLXML();
//    }
//
//    public boolean isValid(int timeout) throws SQLException {
//        return handledInstance.isValid(timeout);
//    }
//
//    public void setClientInfo(String name, String value) throws SQLClientInfoException {
//        handledInstance.setClientInfo(name, value);
//    }
//
//    public void setClientInfo(Properties properties) throws SQLClientInfoException {
//        handledInstance.setClientInfo(properties);
//    }
//
//    public String getClientInfo(String name) throws SQLException {
//        return handledInstance.getClientInfo(name);
//    }
//
//    public Properties getClientInfo() throws SQLException {
//        return handledInstance.getClientInfo();
//    }
//
//    public Array createArrayOf(String typeName, Object[] elements) throws SQLException {
//        return handledInstance.createArrayOf(typeName, elements);
//    }
//
//    public Struct createStruct(String typeName, Object[] attributes) throws SQLException {
//        return handledInstance.createStruct(typeName, attributes);
//    }
//
//    public void setSchema(String schema) throws SQLException {
//        handledInstance.setSchema(schema);
//    }
//
//    public String getSchema() throws SQLException {
//        return handledInstance.getPersistenceUnit();
//    }
//
//    public void abort(Executor executor) throws SQLException {
//        handledInstance.abort(executor);
//    }
//
//    public void setNetworkTimeout(Executor executor, int milliseconds) throws SQLException {
//        handledInstance.setNetworkTimeout(executor, milliseconds);
//    }
//
//    public int getNetworkTimeout() throws SQLException {
//        return handledInstance.getNetworkTimeout();
//    }
//}
