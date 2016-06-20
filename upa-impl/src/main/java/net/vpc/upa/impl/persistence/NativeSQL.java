package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.UConnection;

import java.sql.SQLException;
import java.util.List;
import java.util.Map;

public interface NativeSQL {

    public UConnection getConnection();

    public void setConnection(UConnection connection);

    public MarshallManager getMarshallManager();

    public void setMarshallManager(MarshallManager marshallManager);

    public QueryResult getQueryResult();

    public Map<String,Object> getHints();

    //
    public NativeField[] getFields();

    public void setFields(NativeField[] fields);

    public int getResultCount();

    public void execute() throws UPAException;

    String getQuery();

    void setQuery(String query);

    NativeStatementType getStatementType();

    void setStatementType(NativeStatementType type);

    int size();

    NativeStatement getStatement(int i);

    void addNativeStatement(NativeStatement s);

    String getErrorTrace();

    int getCurrentStatementIndex();

    int executeUpdate() throws SQLException;

    QueryResult executeQuery() throws SQLException;

    String getCurrentQuery();

    void setCurrentQuery(String currentQuery);

    NativeStatement getCurrentStatement();

    void setQueryResult(QueryResult r);

    void setResultCount(int r);

    PersistenceStore getPersistenceManager();

    Object getVar(String varName);

    void setVar(String varName, Object value);

    Map<String,Object> getVars();

    String getParameter(String paramName);

    void setParameter(String paramName, String value);

    Map<String,String> getParameters();

    void setPersistenceStore(PersistenceStore persistenceStore);

    String getCurrentQueryInfo();

    void setCurrentQueryInfo(String currentQueryInfo);

    List<Param> getQueryParameters();

    void setQueryParameters(List<Param> queryParameters);
    void setUpdatable(boolean updatable);
    boolean isUpdatable();
}
