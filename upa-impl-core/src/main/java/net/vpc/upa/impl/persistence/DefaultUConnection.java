package net.vpc.upa.impl.persistence;

import net.vpc.upa.Properties;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.util.UPADeadLock;
import net.vpc.upa.persistence.Parameter;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.types.DataTypeTransform;

import java.lang.reflect.Field;
import java.sql.*;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.persistence.NativeResult;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/3/12 11:07 PM
 */
public class DefaultUConnection extends AbstractUConnection {

    private static final Logger log = Logger.getLogger(DefaultUConnection.class.getName());

    private static Set<String> _conn_attr_based_wrappers = new HashSet<String>(Arrays.asList(
            "org.apache.tomcat.dbcp.dbcp.PoolableConnection",
            "org.apache.tomcat.dbcp.dbcp.PoolingDataSource$PoolGuardConnectionWrapper",
            "org.apache.commons.dbcp.PoolableConnection",
            "org.apache.commons.dbcp.PoolingDataSource$PoolGuardConnectionWrapper"
    ));

    private Connection connection;
    private Connection metadataAccessibleConnection;

    public DefaultUConnection(String name, Connection connection, MarshallManager marshallManager, Properties perfProperties) {
        super(name, marshallManager, perfProperties);
        this.connection = connection;
    }

    public QueryResult executeQueryImpl(String query, String tableDebugString, DataTypeTransform[] types, List<Parameter> queryParameters, boolean updatable) throws Exception {
        PreparedSQLUQLStatement s = null;
        /**
         * @PortabilityHint(target="C#",name="replace") s
         * =connection.CreateCommand(); s.CommandText=query;
         * s.CommandType=System.Data.CommandType.Text;
         */
        s = new PreparedSQLUQLStatement(connection.prepareStatement(query, ResultSet.TYPE_FORWARD_ONLY, updatable ? ResultSet.CONCUR_UPDATABLE : ResultSet.CONCUR_READ_ONLY));

        int mi = 0;
        int index = 1;
        if (queryParameters != null) {
            for (Parameter value : queryParameters) {
                DataTypeTransform transform = value.getTypeTransform();
                TypeMarshaller marshaller = marshallManager.getTypeMarshaller(transform);
                marshaller.write(value.getValue(), index, s);
                index += marshaller.getSize();
                mi++;
            }
        }
        final PreparedSQLUQLStatement finalS = s;
        NativeResult resultSet = UPADeadLock.monitor("executeQuery " + tableDebugString, query, 20, new Throwable(), new UPADeadLock.TAction<NativeResult, RuntimeException>() {
            @Override
            public NativeResult run() throws RuntimeException {
                return finalS.executeQuery();
            }
        });
        if (types == null) {

            int columnCount;
            Class[] colTypes;
            /**
             * @PortabilityHint(target = "C#",name = "replace")
             * columnCount=resultSet.FieldCount; colTypes = new
             * System.Type[columnCount]; for (int i = 0; i < columnCount; i++) {
             * colTypes[i] = resultSet.GetFieldType(i); }
             */
            {
                columnCount = resultSet.getColumnCount();
                colTypes = new Class[columnCount];
                for (int i = 0; i < columnCount; i++) {
                    try {
                        colTypes[i] = Class.forName(resultSet.getColumnClassName(i + 1));
                    } catch (ClassNotFoundException ex) {
                        Logger.getLogger(DefaultUConnection.class.getName()).log(Level.SEVERE, null, ex);
                        colTypes[i] = Object.class;
                    }
                }
            }

            types = new DataTypeTransform[columnCount];
            for (int i = 0; i < types.length; i++) {
                types[i] = IdentityDataTypeTransform.ofType(colTypes[i]);
            }
        }
        TypeMarshaller[] marshallers = new TypeMarshaller[types.length];
        for (int i = 0; i < marshallers.length; i++) {
            marshallers[i] = marshallManager.getTypeMarshaller(types[i]);
        }

//        Log.log(PersistenceUnitManager.DB_PRE_NATIVE_QUERY_LOG,"[BEFORE] "+currentQueryInfo+" :=" + currentQuery);
        return new DefaultQueryResult(nameDebugString + tableDebugString, query, resultSet, marshallers, types);
    }

    @Override
    public int executeNonQueryImpl(String query, List<Parameter> queryParameters, List<Parameter> generatedKeys) throws Exception {
        boolean gen = generatedKeys != null && generatedKeys.size() > 0;
        net.vpc.upa.persistence.NativeStatement s = null;
        /**
         * @PortabilityHint(target="C#",name="replace") s =
         * connection.CreateCommand(); s.CommandText=query;
         * s.CommandType=System.Data.CommandType.Text;
         */
        s = new PreparedSQLUQLStatement(connection.prepareStatement(query, gen ? Statement.RETURN_GENERATED_KEYS : Statement.NO_GENERATED_KEYS));

        int index = 1;
        if (queryParameters != null) {
            for (Parameter value : queryParameters) {
                DataTypeTransform chain = value.getTypeTransform();
                TypeMarshaller typeMarshaller = marshallManager.getTypeMarshaller(chain);
                typeMarshaller.write(value.getValue(), index, s);
                index += typeMarshaller.getSize();
            }
        }
        int count = s.executeUpdate();

        /**
         * @PortabilityHint(target="C#",name="todo")
         */
        if (gen) {
            NativeResult rs = s.getGeneratedKeys();
            if (rs.next()) {
                index = 1;
                for (Parameter entry : generatedKeys) {
                    DataTypeTransform chain = entry.getTypeTransform();
                    TypeMarshaller marshaller = marshallManager.getTypeMarshaller(chain);
                    entry.setValue(marshaller.read(index, rs));
                    index += marshaller.getSize();
                }
            }
        }
        return count;
    }

    @Override
    protected void closePlatformConnection() throws Exception {
        connection.commit();
        connection.close();
    }

    @Override
    public Connection getMetadataAccessibleConnection() throws UPAException {
        if (metadataAccessibleConnection == null) {
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
            metadataAccessibleConnection = retConn;
        }
        return metadataAccessibleConnection;
    }

    @Override
    public Connection getPlatformConnection() throws UPAException {
        return connection;
    }

    @Override
    public void beginTransaction() {
        //
    }

    @Override
    public void commitTransaction() {
        try {
            connection.commit();
        } catch (SQLException ex) {
            throw new UPAException("CommitFailed", ex);
        }
    }

    @Override
    public void rollbackTransaction() {
        try {
            connection.rollback();
        } catch (SQLException ex) {
            throw new UPAException("RollbackFailed", ex);
        }
    }

}
