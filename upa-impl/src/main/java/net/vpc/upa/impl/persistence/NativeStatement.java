package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;

import java.sql.SQLException;

public interface NativeStatement {

    void execute(QueryExecutor queryExecutor)
            throws SQLException, UPAException;

    void dispose()
            throws SQLException, UPAException;
}
