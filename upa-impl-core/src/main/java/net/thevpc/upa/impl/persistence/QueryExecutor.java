package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.UConnection;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.QueryResult;
import net.thevpc.upa.persistence.ResultMetaData;

import java.util.Map;

public interface QueryExecutor {

    QueryResult getQueryResult();

    Map<String, Object> getHints();

    int getResultCount();

    NativeField[] getFields();

    QueryExecutor execute() throws UPAException;

    ResultMetaData getMetaData();

    UConnection getConnection();

    void setConnection(UConnection connection);

    void setParam(int index, Object value);

    void setParam(String name, Object value);

    void setContext(EntityExecutionContext context);
}
