package net.vpc.upa.impl.uql.parser;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.*;
import net.vpc.upa.persistence.Parameter;
import net.vpc.upa.persistence.UConnection;

import java.sql.SQLException;
import java.util.List;
import net.vpc.upa.types.DataTypeTransform;

/**
 * User: taha Date: 25 juin 2003 Time: 17:30:36
 */
public class ReturnQueryStatement implements NativeStatement {

    private String query;
    private List<Parameter> queryParameters;

    public ReturnQueryStatement(String query, List<Parameter> queryParameters) {
        this.query = query;
        this.queryParameters = queryParameters;
    }

    public void execute(NativeSQL nativeSQL)
            throws SQLException, UPAException {
        nativeSQL.setCurrentQueryInfo("RETURN");
        nativeSQL.setCurrentQuery(query);
//        Log.log(PersistenceUnitManager.DB_QUERY_LOG, "RETURN :=" + query);
//        log.log(Level.FINE,"NATIVE QUERY : " + query);
        switch (nativeSQL.getStatementType()) {
            case SELECT: {
                UConnection connection = nativeSQL.getConnection();
                NativeField[] fields = nativeSQL.getFields();
                DataTypeTransform[] types = new DataTypeTransform[fields.length];
                for (int i = 0; i < types.length; i++) {
                    types[i] = fields[i].getTypeTransform();
                }
                nativeSQL.setQueryResult(connection.executeQuery(nativeSQL.getQuery(), types, queryParameters, nativeSQL.isUpdatable()));
                break;
            }
            default:
                throw new SQLException("Unexpected NativeSQL type " + nativeSQL.getStatementType());
        }
    }

    public void dispose()
            throws SQLException {
    }

    @Override
    public String toString() {
        return "return " + query;
    }
}
