package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.*;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.I18NString;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.UPAUtils;

import java.sql.SQLException;
import java.util.*;
import java.util.logging.Logger;

public class DefaultQueryExecutor implements QueryExecutor {

    static Logger log = Logger.getLogger(DefaultQueryExecutor.class.getName());
    private Map<String,Object> hints;
    private String query;
    private UConnection connection;

    private PersistenceStore persistenceStore;
    private net.vpc.upa.impl.persistence.NativeStatementType type;
    private HashMap<String, String> parameters;
    private Object returnValue;
    private int currentStatementIndex;
    private boolean updatable;
    private String errorTrace;
    private NativeField[] fields;
    private ResultMetaData metaData;
    private List<Parameter> queryParameters;
    private List<Parameter> generatedKeys;
    public DefaultQueryExecutor(NativeStatementType type, Map<String, Object> hints,
                                String query, List<Parameter> queryParameters, List<Parameter> generatedKeys,
                                PersistenceStore persistenceStore,UConnection connection,
                                NativeField[] nativeFields,boolean updatable,ResultMetaData metaData
                                ) {
        this.type = type;
        this.updatable = updatable;
        this.metaData = metaData;
        this.query = query;
        this.fields = nativeFields;
        this.queryParameters = queryParameters;
        this.generatedKeys = generatedKeys;
        this.persistenceStore = persistenceStore;
        this.connection = connection;

        parameters = new HashMap<String, String>();
        this.hints=hints;
    }

    public NativeStatementType getStatementType() {
        return type;
    }

    @Override
    public String toString() {
        return "BEGIN NATIVE_SQL" + "\n" + query + "\n" + "parameters=" + parameters + "\n" + "END NATIVE_SQL";
    }

    public void dispose() {
//        try {
//            for (int i = statements.size() - 1; i >= 0; i--) {
//                (statements.get(i)).dispose();
//            }
//        } catch (SQLException e) {
//            throw new UPAException(e, new I18NString("NativeException"));
//        }
    }

    public String getErrorTrace() {
        return errorTrace;
    }

    public int getCurrentStatementIndex() {
        return currentStatementIndex;
    }

    public QueryExecutor execute()
            throws UPAException {
        String logString = null;
        try {
            errorTrace = null;
            this.currentStatementIndex = 0;
//        log.log(Level.FINE,"NATIVE QUERY : " + query);
//        Log.log(PersistenceUnitManager.DB_QUERY_LOG, "RETURN :=" + query);
            switch (getStatementType()) {
                case SELECT: {
                    DataTypeTransform[] types = new DataTypeTransform[fields.length];
                    for (int i = 0; i < types.length; i++) {
                        types[i] = fields[i].getTypeTransform();
                    }
                    setQueryResult(connection.executeQuery(query, types, queryParameters, updatable));
                    break;
                }
                case UPDATE: {
                    if (generatedKeys != null && generatedKeys.size() > 0) {
                        int updates = connection.executeNonQuery(query, queryParameters, generatedKeys);
                        setResultCount(updates);
                    } else {
                        setResultCount(connection.executeNonQuery(query, queryParameters, null));
                    }
                    break;
                }
                default:
                    throw new SQLException("Unexpected QueryExecutor type " + getStatementType());
            }

        } catch (Exception e) {
            errorTrace
                    = "--ERROR-EXEC--" + "\n"
                    + "        full query =" + query + "\n"
                    + "   statement index =" + getCurrentStatementIndex() + "\n"
                    + " execution-context =" + this + "\n"
                    + "         exception =" + e + "\n"
                    + "        stacktrace =" + "\n";

            /**
             * @PortabilityHint(target="C#",name="suppress")
             */
            if (true) {
                errorTrace += UPAUtils.getStackTrace(e);
            }
//            Log.log(PersistenceUnitManager.DB_ERROR_LOG,errorTrace);
            throw new UPAException(e, new I18NString("NativeException"),errorTrace);
        } finally {
//            if (errorTrace == null){
//                switch (createExecutor.getDataType()) {
//                    case 2: // '\002'
//                        Log.log(DatabaseAdapter.DB_UPDATE_LOG,"[COUNT=?] " + getResultCount());
//                        break;
//                }
//            }
            dispose();
        }
        return this;
    }



    public void setQueryResult(QueryResult r) {
        returnValue = r;
    }

    public void setResultCount(int r) {
        returnValue = r;
    }

    public QueryResult getQueryResult() {
        return (QueryResult) returnValue;
    }

    public int getResultCount() {
        return (Integer) returnValue;
    }

    public void setParameter(String paramName, String value) {
        parameters.put(paramName, value);
    }

    public Map<String, String> getParameters() {
        return parameters;
    }

    public Map<String, Object> getHints() {
        return hints;
    }

    public ResultMetaData getMetaData() {
        return metaData;
    }

    @Override
    public NativeField[] getFields() {
        return fields;
    }

    @Override
    public UConnection getConnection() {
        return connection;
    }
}
