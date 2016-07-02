package net.vpc.upa.impl.persistence;

import net.vpc.upa.CloseListener;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.QueryScript;
import net.vpc.upa.impl.persistence.connection.CloseListenerSupport;
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
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.TypesFactory;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/3/12 11:07 PM
 */
public class DefaultUConnection implements UConnection {

    private static Set<String> _conn_attr_based_wrappers=new HashSet<String>(Arrays.asList(
            "org.apache.tomcat.dbcp.dbcp.PoolableConnection",
            "org.apache.tomcat.dbcp.dbcp.PoolingDataSource$PoolGuardConnectionWrapper",
            "org.apache.commons.dbcp.PoolableConnection",
            "org.apache.commons.dbcp.PoolingDataSource$PoolGuardConnectionWrapper"
    ));

    private String name;
    private String nameDebugString;
    private Connection connection;
    private Connection metadataAccessibleConnection;
    private MarshallManager marshallManager;
    private CloseListenerSupport support;
    private Map<String, Object> properties;
    private boolean closed = false;
    private static final Logger log = Logger.getLogger(DefaultUConnection.class.getName());

    public DefaultUConnection(String name,Connection connection, MarshallManager marshallManager) {
        this.name = name;
        this.connection = connection;
        this.marshallManager = marshallManager;
        this.support = new CloseListenerSupport();
        nameDebugString= StringUtils.isNullOrEmpty(name)?"[]":("["+name+"]");
    }

    public QueryResult executeQuery(String query, DataTypeTransform[] types, List<Parameter> queryParameters, boolean updatable) throws UPAException {
        if (closed) {
            throw new IllegalArgumentException("Connection closed");
        }
        long startTime =System.currentTimeMillis();
        SQLException error=null;
        try {
            try {


                PreparedStatement s = null;
                /**
                 * @PortabilityHint(target="C#",name="replace") s =
                 * connection.CreateCommand(); s.CommandText=query;
                 * s.CommandType=System.Data.CommandType.Text;
                 */
                s = connection.prepareStatement(query, ResultSet.TYPE_FORWARD_ONLY, updatable ? ResultSet.CONCUR_UPDATABLE : ResultSet.CONCUR_READ_ONLY);

                if (types == null) {
                    ResultSetMetaData metaData = s.getMetaData();
                    types = new DataTypeTransform[metaData.getColumnCount()];
                    for (int i = 0; i < types.length; i++) {
                        try {
                            types[i] = new IdentityDataTypeTransform(
                                    TypesFactory.forPlatformType(Class.forName(metaData.getColumnClassName(i + 1)))
                            );
                        } catch (ClassNotFoundException ex) {
                            Logger.getLogger(DefaultUConnection.class.getName()).log(Level.SEVERE, null, ex);
                            types[i] = new IdentityDataTypeTransform(
                                    TypesFactory.forPlatformType(Object.class)
                            );
                        }
                    }
                }
                int index = 1;
                TypeMarshaller[] marshallers = new TypeMarshaller[types.length];
                for (int i = 0; i < marshallers.length; i++) {
                    marshallers[i] = marshallManager.getTypeMarshaller(types[i]);
                }
                int mi = 0;
                if (queryParameters != null) {
                    for (Parameter value : queryParameters) {
                        DataTypeTransform transform = value.getTypeTransform();
                        TypeMarshaller marshaller = marshallManager.getTypeMarshaller(transform);
                        marshaller.write(value.getValue(), index, s);
                        index += marshaller.getSize();
                        mi++;
                    }
                }

//        Log.log(PersistenceUnitManager.DB_PRE_NATIVE_QUERY_LOG,"[BEFORE] "+currentQueryInfo+" :=" + currentQuery);
                return new DefaultQueryResult(s.executeQuery(), s, marshallers, types);
            } catch (SQLException ee) {
                error=ee;
                throw ee;
            } finally {
                if (log.isLoggable(Level.FINE)) {
                    if(error!=null) {
                        log.log(Level.SEVERE, nameDebugString+" [Error] executeQuery " + query + " :: parameters = " + queryParameters, error);
                    }else {
                        log.log(Level.FINE, "{0}   executeQuery    {1} ;; parameters = {2} ;; time = {3}", new Object[]{nameDebugString,query, queryParameters,(System.currentTimeMillis()-startTime)});
                    }
                }
//                long endTime = System.currentTimeMillis();
//            Log.log(PersistenceUnitManager.DB_NATIVE_QUERY_LOG,"[TIME="+Log.DELTA_FORMAT.format(endTime-startTime)+"] "+debug+" :=" + currentQuery);
            }
        } catch (SQLException ex) {
            throw createUPAException(ex, "ExecuteQueryFailedException", query);
        }
    }

    public int executeNonQuery(String query, List<Parameter> queryParameters, List<Parameter> generatedKeys) throws UPAException {
        if (closed) {
            throw new IllegalArgumentException("Connection closed");
        }
        SQLException error=null;
        int count = -1;
        boolean gen = generatedKeys != null && generatedKeys.size() > 0;
        long startTime = System.currentTimeMillis();
        try {
            PreparedStatement s = null;
            /**
             * @PortabilityHint(target="C#",name="replace") s =
             * connection.CreateCommand(); s.CommandText=query;
             * s.CommandType=System.Data.CommandType.Text;
             */
            s = connection.prepareStatement(query, gen ? Statement.RETURN_GENERATED_KEYS : Statement.NO_GENERATED_KEYS);

            int index = 1;
            if (queryParameters != null) {
                for (Parameter value : queryParameters) {
                    DataTypeTransform chain = value.getTypeTransform();
                    TypeMarshaller typeMarshaller = marshallManager.getTypeMarshaller(chain);
                    typeMarshaller.write(value.getValue(), index, s);
                    index += typeMarshaller.getSize();
                }
            }
            count = s.executeUpdate();
            if (gen) {
                ResultSet rs = s.getGeneratedKeys();
                if (rs.next()) {
                    index = 1;
                    if (generatedKeys != null) {
                        for (Parameter entry : generatedKeys) {
                            DataTypeTransform chain = entry.getTypeTransform();
                            TypeMarshaller marshaller = marshallManager.getTypeMarshaller(chain);
                            entry.setValue(marshaller.read(index, rs));
                            index += marshaller.getSize();
                        }
                    }
                }
            }
        } catch (SQLException ee) {
            error=ee;
//            Log.log(PersistenceUnitManager.DB_ERROR_LOG,"[Error] "+currentQueryInfo+" :=" + currentQuery);
            throw createUPAException(ee, "ExecuteUpdateFailedException", query);
        } finally {
            if (log.isLoggable(Level.FINE)) {
                if(error!=null) {
                    log.log(Level.SEVERE, nameDebugString+" [Error] executeNonQuery " + query + " :: parameters = " + queryParameters, error);
                }else {
                    log.log(Level.FINE, "{0} executeNonQuery {1}" + ((queryParameters != null && !queryParameters.isEmpty())
                            ? "\n\tqueryParameters={2}" : "")+" ;; time = {3}", new Object[]{nameDebugString,query, queryParameters,(System.currentTimeMillis()-startTime)});
                }
            }
//            Log.log(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG,"[TIME="+Log.DELTA_FORMAT.format(endTime-startTime)+" ; COUNT="+count+"] "+debug+" :=" + currentQuery);
        }
        return count;
    }

    public int executeScript(QueryScript script, boolean exitOnError) throws UPAException {
        if (closed) {
            throw new IllegalArgumentException("Connection closed");
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
                    log.log(Level.SEVERE, nameDebugString+" [Error] executeNonQuery @" + i + " : " + script.getStatement(i) /*+ " :: parameters = " + queryParameters*/, sqle);
//                    log.log(Level.SEVERE,"Error @" + i + " : " + script.getStatement(i));
                    log.log(Level.SEVERE, "{0} Error @{1} : {2}", new Object[]{nameDebugString,i, script.getStatement(i)});
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
//            throw new IllegalArgumentException("Unsupported");
//        }
//    }
    private UPAException createUPAException(SQLException ex, String mgId, Object... parameters) {
        return new UPAException(ex, new I18NString(mgId), parameters);
    }

    public Connection getPlatformConnection() {
        return connection;
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
//        try {
//            connection.rollback();
//        } catch (SQLException e) {
//            throw createUPAException(e, "CloseFailed", connection);
//        }
        support.beforeClose(this);
        try {
            connection.commit();
        } catch (SQLException e) {
            throw createUPAException(e, "CloseFailed", connection);
        }
        try {
            connection.close();
        } catch (SQLException e) {
            throw createUPAException(e, "CloseFailed", connection);
        }
        closed = true;
        support.afterClose(this);
    }
    @Override
    public Connection getMetadataAccessibleConnection() throws UPAException {
        if(metadataAccessibleConnection==null) {
            Connection retConn = connection;
            while (true) {
                String connClassName = retConn.getClass().getName();
                if (_conn_attr_based_wrappers.contains(connClassName)) {
                    Field f;
                    try {
                        f = retConn.getClass().getSuperclass().getDeclaredField("_conn");
                        f.setAccessible(true);
                        retConn = (Connection) f.get(retConn);
                    } catch (Exception ex) {
                        log.log(Level.SEVERE, "Unable to retrieve MetadataAccessibleConnection from Pool Type " + connClassName + "", ex);
                        retConn = connection;
                        break;
                    }
                } else {
                    break;
                }
            }
            metadataAccessibleConnection=retConn;
        }
        return metadataAccessibleConnection;
    }

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
        return "UConnection{" + connection + '}';
    }

}
