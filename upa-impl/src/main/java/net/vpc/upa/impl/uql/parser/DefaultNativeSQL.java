package net.vpc.upa.impl.uql.parser;

import net.vpc.upa.types.I18NString;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.impl.persistence.*;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.UConnection;

import java.sql.SQLException;
import java.util.*;
import java.util.logging.Logger;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.jdbc:
//            NativeStatement, NativeExecutionContext
public class DefaultNativeSQL implements NativeSQL {

    static Logger log = Logger.getLogger(DefaultNativeSQL.class.getName());
    //    public static final int SELECT = 1;
//    public static final int UPDATE = 2;
//    public static final int BATCH = 3;
    private ArrayList<NativeStatement> statements;
    private Map<String,Object> hints;
    //    private NativeStatementType type;
    private String query;
    private UConnection connection;
    private MarshallManager marshallManager;

    private PersistenceStore persistenceStore;
    //    private Statement statement;
    private net.vpc.upa.impl.persistence.NativeStatementType type;
    private String currentQuery;
    private String currentQueryInfo;
    private HashMap<String, Object> execVars;
    private HashMap<String, String> parameters;
//    private Stack structStack;
    private Object returnValue;
    private int currentStatementIndex;
    private String errorTrace;
    //    private PropertiesFormatter formatter;
    private List<Param> queryParameters;
    private NativeField[] fields;
    private boolean updatable;

    @Override
    public String getQuery() {
        return query;
    }

    @Override
    public void setQuery(String query) {
        this.query = query;
    }

//    public NativeSQL() {
//        this(1);
//    }
    public DefaultNativeSQL(NativeStatementType type,Map<String,Object> hints) {
        statements = new ArrayList<NativeStatement>();
        this.type = type;

        execVars = new HashMap<String, Object>();
        parameters = new HashMap<String, String>();
        this.hints=hints;
//        formatter = new PropertiesFormatter(PropertyFormat.BRACES, parameters);
    }

    @Override
    public NativeStatementType getStatementType() {
        return type;
    }

    @Override
    public void setStatementType(NativeStatementType type) {
        this.type = type;
    }

    @Override
    public int size() {
        return statements.size();
    }

    @Override
    public NativeStatement getStatement(int i) {
        return statements.get(i);
    }

    @Override
    public void addNativeStatement(NativeStatement s) {
        statements.add(s);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("BEGIN NATIVE_SQL");
        sb.append("\n");
        sb.append("# ").append(statements.size()).append(" statement(s).");
        sb.append("\n");
        for (int i = 0; i < statements.size(); i++) {
            if (i > 0) {
                sb.append("\n");
            }
            sb.append(" ");
            sb.append(statements.get(i).toString());
            sb.append(';');
        }

        sb.append("\n");
        sb.append("parameters=").append(parameters);
        sb.append("\n");
        sb.append("END NATIVE_SQL");
        return sb.toString();
    }

    public void dispose() {
        try {
            for (int i = statements.size() - 1; i >= 0; i--) {
                (statements.get(i)).dispose();
            }
        } catch (SQLException e) {
            throw new UPAException(e, new I18NString("NativeException"));
        }
    }

    @Override
    public String getErrorTrace() {
        return errorTrace;
    }

    @Override
    public int getCurrentStatementIndex() {
        return currentStatementIndex;
    }

//    public String format(String expression) {
//        return formatter.format(expression);
//    }
    @Override
    public int executeUpdate() throws SQLException {
        execute();
        return getResultCount();
    }

    @Override
    public QueryResult executeQuery() throws SQLException {
        execute();
        return getQueryResult();
    }

    public void execute()
            throws UPAException {
//        if (isCheckSecurity()) {
//            getShield().checkLoad();
//        }
        String logString = null;
        try {
            errorTrace = null;
            this.currentStatementIndex = 0;
            int sqlsize = size();
            switch (getStatementType()) {
                case SELECT: {
                    if (sqlsize > 1) {
                        logString = "[size=" + sqlsize + "] " + getQuery();
                    } else {
                        logString = getQuery();
                    }

                    break;
                }
                case UPDATE: {
                    if (sqlsize > 1) {
                        logString = "[size=" + sqlsize + "] " + getQuery();
                    } else {
                        logString = getQuery();
                    }

                    break;
                }
                default: {
                    throw new RuntimeException("WouldNeverBeThrownException");
//                    if(sqlsize>1){
//                        logString = "[size=" + sqlsize + "] " + nativeSQL.getQuery();
//                    }else{
//                        logString = nativeSQL.getQuery();
//                    }
//
//                    Log.log(DatabaseAdapter.DB_EXEC_LOG, logString);
//                    break;
                }
            }
            int currentStatementIndex = 0;
            for (currentStatementIndex = 0; currentStatementIndex < sqlsize; currentStatementIndex++) {
                NativeStatement stm = getStatement(currentStatementIndex);
                stm.execute(this);
            }

        } catch (Exception e) {
            errorTrace
                    = "--ERROR-EXEC--" + "\n"
                    + "        full query =" + getQuery() + "\n"
                    + "   statement index =" + getCurrentStatementIndex() + "\n"
                    + "         statement =" + getCurrentStatement() + "\n"
                    + "             query =" + getCurrentQuery() + "\n"
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
//                switch (nativeSQL.getDataType()) {
//                    case 2: // '\002'
//                        Log.log(DatabaseAdapter.DB_UPDATE_LOG,"[COUNT=?] " + getResultCount());
//                        break;
//                }
//            }
            dispose();
        }
    }

    @Override
    public String getCurrentQuery() {
        return currentQuery;
    }

    @Override
    public void setCurrentQuery(String currentQuery) {
        this.currentQuery = currentQuery;// format(currentQuery);
    }

    @Override
    public NativeStatement getCurrentStatement() {
        return getStatement(getCurrentStatementIndex());
    }

    @Override
    public void setQueryResult(QueryResult r) {
        returnValue = r;
    }

    @Override
    public void setResultCount(int r) {
        returnValue = r;
    }

    public QueryResult getQueryResult() {
        return (QueryResult) returnValue;
    }

    public int getResultCount() {
        return (Integer) returnValue;
    }

    @Override
    public PersistenceStore getPersistenceManager() {
        return persistenceStore;
    }

    @Override
    public Object getVar(String varName) {
        return execVars.get(varName);
    }

    @Override
    public void setVar(String varName, Object value) {
        execVars.put(varName, value);
    }

    @Override
    public Map<String, Object> getVars() {
        return execVars;
    }

    @Override
    public String getParameter(String paramName) {
        return parameters.get(paramName);
    }

    @Override
    public void setParameter(String paramName, String value) {
        parameters.put(paramName, value);
    }

    @Override
    public Map<String, String> getParameters() {
        return parameters;
    }

    @Override
    public void setPersistenceStore(PersistenceStore persistenceStore) {
        this.persistenceStore = persistenceStore;
    }

    @Override
    public String getCurrentQueryInfo() {
        return currentQueryInfo;
    }

    @Override
    public void setCurrentQueryInfo(String currentQueryInfo) {
        this.currentQueryInfo = currentQueryInfo;
    }

    @Override
    public List<Param> getQueryParameters() {
        return queryParameters;
    }

    @Override
    public void setQueryParameters(List<Param> queryParameters) {
        this.queryParameters = queryParameters;
    }

    public NativeField[] getFields() {
        return fields;
    }

    public void setFields(NativeField[] fields) {
        this.fields = fields;
    }

    @Override
    public UConnection getConnection() {
        return connection;
    }

    @Override
    public void setConnection(UConnection connection) {
        this.connection = connection;
    }

    @Override
    public MarshallManager getMarshallManager() {
        return marshallManager;
    }

    @Override
    public void setMarshallManager(MarshallManager marshallManager) {
        this.marshallManager = marshallManager;
    }

    public boolean isUpdatable() {
        return updatable;
    }

    public void setUpdatable(boolean updatable) {
        this.updatable = updatable;
    }

    @Override
    public Map<String, Object> getHints() {
        return hints;
    }
}
