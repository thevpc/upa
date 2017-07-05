package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.persistence.UConnection;

import java.util.Map;

public interface QueryExecutor {

    QueryResult getQueryResult();

    Map<String,Object> getHints();

    int getResultCount();

    NativeField[] getFields();

    QueryExecutor execute() throws UPAException;

    ResultMetaData getMetaData();

    UConnection getConnection();
}
