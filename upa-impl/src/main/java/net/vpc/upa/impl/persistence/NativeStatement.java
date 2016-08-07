package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;

import java.sql.SQLException;

public interface NativeStatement {

    public abstract void execute(QueryExecutor queryExecutor)
            throws SQLException, UPAException;

    public abstract void dispose()
            throws SQLException, UPAException;
}
