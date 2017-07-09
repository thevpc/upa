package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.*;

import java.util.List;
import java.util.Map;

public interface QueryExecutor {

    QueryResult getQueryResult();

    Map<String,Object> getHints();

    int getResultCount();

    NativeField[] getFields();

    QueryExecutor execute() throws UPAException;

    ResultMetaData getMetaData();

    void setConnection(UConnection connection);

    UConnection getConnection();

    void setParam(int index,Object value);
    void setParam(String name,Object value);

    void setContext(EntityExecutionContext context);
}
