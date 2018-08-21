package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.QueryScript;
import net.vpc.upa.impl.UPAImplDefaults;
import net.vpc.upa.impl.UPAImplKeys;
import net.vpc.upa.impl.persistence.connection.CloseListenerSupport;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.upql.util.UPQLUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.impl.util.UPADeadLock;
import net.vpc.upa.persistence.Parameter;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.UConnection;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.I18NString;

import java.lang.reflect.Field;
import java.sql.*;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/3/12 11:07 PM
 */
public abstract class AbstractUConnection implements UConnection {

    protected String name;
    protected String nameDebugString;
    protected Properties perfProperties;
    protected Connection metadataAccessibleConnection;
    protected MarshallManager marshallManager;
    protected CloseListenerSupport support;
    protected Map<String, Object> properties;
    protected boolean closed = false;
    private static final Logger log = Logger.getLogger(AbstractUConnection.class.getName());
    protected static final List<UConnection> activeConnections = new ArrayList<UConnection>();
    protected static int activeConnectionsMaxCount = 0;

    public AbstractUConnection(String name, MarshallManager marshallManager, Properties perfProperties) {
        this.name = name;
        this.perfProperties = perfProperties;
        this.marshallManager = marshallManager;
        this.support = new CloseListenerSupport();
        nameDebugString = StringUtils.isNullOrEmpty(name) ? "[]" : ("[" + name + "]");
        synchronized (activeConnections) {
            activeConnections.add(this);
            activeConnectionsMaxCount = Math.max(activeConnectionsMaxCount, activeConnections.size());
            log.log(Level.FINE, "Active Connections {0}/{1}", new Object[]{activeConnections.size(), activeConnectionsMaxCount});
        }
    }

    public String resolveMainTableFromSQLQuery(String query) {
        return UPQLUtils.resolveMainTableFromSQLQuery(query);
    }

    @Override
    public QueryResult executeQuery(String query, DataTypeTransform[] types, List<Parameter> queryParameters, boolean updatable) throws UPAException {
        if (closed) {
            throw new IllegalUPAArgumentException("Connection closed");
        }
        if (UPAImplDefaults.DEBUG_MODE) {
            perfProperties.setLong(UPAImplKeys.System_Perf_Connection_Query, perfProperties.getLong(UPAImplKeys.System_Perf_Connection_Query, 0) + 1);
            perfProperties.setLong(UPAImplKeys.System_Perf_Connection_Statement, perfProperties.getLong(UPAImplKeys.System_Perf_Connection_Statement, 0) + 1);
        }
        String tableDebugString = "[" + resolveMainTableFromSQLQuery(query) + "]";
        long startTime = System.currentTimeMillis();
        Exception error = null;
//        log.log(Level.FINE, "{0} BEFORE executeQuery    {1} :: parameters = {2}", new Object[]{nameDebugString + tableDebugString, query, queryParameters});
        try {
            try {
                return executeQueryImpl(query, tableDebugString, types, queryParameters, updatable);
            } catch (Exception ee) {
                error = ee;
                throw ee;
            } finally {
                if (log.isLoggable(Level.FINE)) {
                    if (error != null) {
                        log.log(Level.SEVERE, nameDebugString + tableDebugString + " [Error] executeQuery " + query + " :: parameters = " + queryParameters, error);
                    } else {
                        log.log(Level.FINE, "{0} executeQuery    {1} :: parameters = {2} ;; time = {3}", new Object[]{nameDebugString + tableDebugString, query, queryParameters, (System.currentTimeMillis() - startTime)});
                    }
                }
//                long endTime = System.currentTimeMillis();
//            Log.log(PersistenceUnitManager.DB_NATIVE_QUERY_LOG,"[TIME="+Log.DELTA_FORMAT.format(endTime-startTime)+"] "+debug+" :=" + currentQuery);
            }
        } catch (Exception ex) {
            throw createUPAException(ex, "ExecuteQueryFailedException", query);
        }
    }

    public abstract QueryResult executeQueryImpl(String query, String tableDebugString, DataTypeTransform[] types, List<Parameter> queryParameters, boolean updatable) throws Exception;

    public int executeNonQuery(String query, List<Parameter> queryParameters, List<Parameter> generatedKeys) throws UPAException {
        if (closed) {
            throw new IllegalUPAArgumentException("Connection closed");
        }
        if (UPAImplDefaults.DEBUG_MODE) {
            perfProperties.setLong(UPAImplKeys.System_Perf_Connection_NonQuery, perfProperties.getLong(UPAImplKeys.System_Perf_Connection_NonQuery, 0) + 1);
            perfProperties.setLong(UPAImplKeys.System_Perf_Connection_Statement, perfProperties.getLong(UPAImplKeys.System_Perf_Connection_Statement, 0) + 1);
        }
        Exception error = null;
        int count = -1;
        boolean gen = generatedKeys != null && generatedKeys.size() > 0;
        long startTime = System.currentTimeMillis();
        String tableDebugString = "[" + resolveMainTableFromSQLQuery(query) + "]";
        try {
            count = executeNonQueryImpl(query, queryParameters, generatedKeys);
        } catch (Exception ee) {
            error = ee;
//            Log.log(PersistenceUnitManager.DB_ERROR_LOG,"[Error] "+currentQueryInfo+" :=" + currentQuery);
            throw createUPAException(ee, "ExecuteUpdateFailedException", query);
        } finally {
            if (log.isLoggable(Level.FINE)) {
                if (error != null) {
                    log.log(Level.SEVERE, nameDebugString + " [Error] executeNonQuery " + query + ((queryParameters != null && !queryParameters.isEmpty()) ? (" ;; parameters=" + queryParameters) : ""), error);
                } else {
                    log.log(Level.FINE, "{0} executeNonQuery {1}" + ((queryParameters != null && !queryParameters.isEmpty())
                            ? " ;; parameters = {2}" : "") + " ;; time = {3}", new Object[]{nameDebugString +tableDebugString, query, queryParameters, (System.currentTimeMillis() - startTime)});
                }
            }
//            Log.log(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG,"[TIME="+Log.DELTA_FORMAT.format(endTime-startTime)+" ; COUNT="+count+"] "+debug+" :=" + currentQuery);
        }
        return count;
    }

    public abstract int executeNonQueryImpl(String query, List<Parameter> queryParameters, List<Parameter> generatedKeys) throws Exception;

    public int executeScript(QueryScript script, boolean exitOnError) throws UPAException {
        if (closed) {
            throw new IllegalUPAArgumentException("Connection closed");
        }
        //ExecutionContext qlContext = createContext(ContextOperation.CREATE_PERSISTENCE_NAME);
        try {
            int max = script.size();
//            int groupPercent = 5;
            int errorsCount = 0;
//            int group = (int) (((double) max * (double) groupPercent) / 100D);
            for (int i = 0; i < max; i++) {
                try {
                    executeNonQuery(script.getStatement(i), null, null);
//                    if (listener != null) {
//                        listener.actionProgress(new ProgressEvent(this, null, script.getStatement(i), i, 0L, max, parentEvent));
//                    }
                } catch (UPAException sqle) {
                    errorsCount++;
                    log.log(Level.SEVERE, nameDebugString + " [Error] executeNonQuery @" + i + " : " + script.getStatement(i) /*+ " :: parameters = " + queryParameters*/, sqle);
//                    log.log(Level.SEVERE,"Error @" + i + " : " + script.getStatement(i));
                    log.log(Level.SEVERE, "{0} Error @{1} : {2}", new Object[]{nameDebugString, i, script.getStatement(i)});
                    if (exitOnError) {
                        throw sqle;
                    }
                }
            }

//            if (listener != null) {
//                listener.actionProgress(new ProgressEvent(this, null, null, max, 0L, max, parentEvent));
//            }
//            transactionSucceeded = true;
            return errorsCount;
        } finally {
//            getConnection().tryFinalizeTransaction(transactionSucceeded, transaction);
        }
    }

    //    protected ResultSet executeQuery(QueryStatement query) throws SQLException, UPAException {
//        if (query instanceof Select) {
//            Statement s = null;
//            try {
//                s = getConnection().createStatement();
//                query = (QueryStatement) getPersistenceUnit().compileExpression(query);
//                return s.executeQuery(getSQL(query, createContext(ContextOperation.FIND)));
//            } catch (SQLException e) {
//                if (s != null) {
//                    s.close();
//                }
//                throw e;
//            } catch (RuntimeException e) {
//                if (s != null) {
//                    s.close();
//                }
//                throw e;
//            }
//        } else if (query instanceof Union) {
//            List<QueryStatement> queries = ((Union) query).getQueryStatements();
//            ResultSet[] resultSets = new ResultSet[queries.size()];
//
//            try {
//                for (int i = 0; i < resultSets.length; i++) {
//                    resultSets[i] = executeQuery(queries.get(i));
//                }
//            } catch (SQLException e) {
//                for (ResultSet resultSet : resultSets) {
//                    if (resultSet != null) {
//                        resultSet.close();
//                    }
//                }
//                throw e;
//            }
//            return new UnionResultSetDelegate(resultSets, 1, true, null, null);
//        } else {
//            throw new IllegalUPAArgumentException("Unsupported");
//        }
//    }
    private UPAException createUPAException(Exception ex, String mgId, Object... parameters) {
        return new UPAException(ex, new I18NString(mgId), parameters);
    }

    @Override
    public void addCloseListener(CloseListener closeListener) {
        support.addCloseListener(closeListener);
    }

    @Override
    public void removeCloseListener(CloseListener closeListener) {
        support.removeCloseListener(closeListener);
    }

    @Override
    public void close() throws UPAException {
        synchronized (activeConnections) {
            activeConnections.remove(this);
            log.log(Level.FINE, "Active Connections {0}/{1}", new Object[]{activeConnections.size(), activeConnectionsMaxCount});
        }
//        try {
//            connection.rollback();
//        } catch (SQLException e) {
//            throw createUPAException(e, "CloseFailed", connection);
//        }
        support.beforeClose(this);
        /**
         * @PortabilityHint(target="C#",name="todo")
         */
        try {
            closePlatformConnection();
        } catch (Exception ex) {
            throw new IllegalUPAArgumentException("Connection could not be closed",ex);
        }
        closed = true;
        support.afterClose(this);
    }

    protected abstract void closePlatformConnection() throws Exception;

    @Override
    public Object getProperty(String name) throws UPAException {
        if (properties == null) {
            return null;
        }
        return properties.get(name);
    }

    @Override
    public Map<String, Object> getProperties() throws UPAException {
        if (properties == null) {
            return Collections.EMPTY_MAP;
        }
        return Collections.unmodifiableMap(properties);
    }

    @Override
    public void setProperty(String name, Object value) throws UPAException {
        if (value == null) {
            if (properties != null) {
                properties.remove(name);
            }
        } else {
            if (properties == null) {
                properties = new HashMap<String, Object>();
            }
            properties.put(name, value);
        }
    }

    @Override
    public String toString() {
        return "UConnection{" + name + '}';
    }

}
