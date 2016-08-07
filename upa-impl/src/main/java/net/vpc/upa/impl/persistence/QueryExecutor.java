package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.persistence.PersistenceStore;
import net.vpc.upa.persistence.QueryResult;
import net.vpc.upa.persistence.ResultMetaData;
import net.vpc.upa.persistence.UConnection;

import java.sql.SQLException;
import java.util.List;
import java.util.Map;

public interface QueryExecutor {

    public QueryResult getQueryResult();

    public Map<String,Object> getHints();

    public int getResultCount();

    public NativeField[] getFields();

    public QueryExecutor execute() throws UPAException;

    ResultMetaData getMetaData();

    UConnection getConnection();
}
