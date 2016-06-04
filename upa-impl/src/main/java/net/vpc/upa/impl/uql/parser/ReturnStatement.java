package net.vpc.upa.impl.uql.parser;

import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.*;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.persistence.Parameter;
import net.vpc.upa.persistence.UConnection;

import java.sql.SQLException;
import java.util.List;
import java.util.Map;

import net.vpc.upa.types.DataTypeTransform;

/**
 * User: taha Date: 25 juin 2003 Time: 17:30:36
 */
public class ReturnStatement implements NativeStatement {

    private String query;
    private List<Parameter> queryParameters;
    private List<Parameter> generatedKeys;
    private Map<String,Object> hints;

    public ReturnStatement(String query, List<Parameter> queryParameters, List<Parameter> generatedKeys,Map<String,Object> hints) {
        this.query = query;
        this.queryParameters = queryParameters;
        this.generatedKeys = generatedKeys;
        this.hints = hints;
    }

    public void execute(NativeSQL nativeSQL)
            throws SQLException, UPAException {
        nativeSQL.setCurrentQueryInfo("RETURN");
        nativeSQL.setCurrentQuery(query);
        UConnection connection = nativeSQL.getConnection();
//        log.log(Level.FINE,"NATIVE QUERY : " + query);
//        Log.log(PersistenceUnitManager.DB_QUERY_LOG, "RETURN :=" + query);
        switch (nativeSQL.getStatementType()) {
            case SELECT: {
                NativeField[] fields = nativeSQL.getFields();
                DataTypeTransform[] types = new DataTypeTransform[fields.length];
                boolean noTypeTransform = (hints==null || hints.get("NoTypeTransform")==null)?false:(Boolean) hints.get("NoTypeTransform");
                for (int i = 0; i < types.length; i++) {
                    boolean fieldNoTypeTransform=noTypeTransform;
                    if(hints!=null) {
                        if (!noTypeTransform) {
                            Field field = fields[i].getField();
                            if(field!=null) {
                                String fieldKey = "NoTypeTransform." + field.getAbsoluteName();
                                fieldNoTypeTransform = hints.get(fieldKey) == null ? false : (Boolean) hints.get(fieldKey);
                            }
                        }
                    }
                    DataTypeTransform baseTransform = fields[i].getTypeTransform();
                    types[i] = fieldNoTypeTransform? IdentityDataTypeTransform.forDataType(baseTransform.getSourceType()):baseTransform;
                }
                nativeSQL.setQueryResult(connection.executeQuery(nativeSQL.getQuery(), types, queryParameters, nativeSQL.isUpdatable()));
                break;
            }
            case UPDATE: {
                if (generatedKeys != null && generatedKeys.size() > 0) {
                    int updates = connection.executeNonQuery(nativeSQL.getQuery(), queryParameters, generatedKeys);
                    nativeSQL.setResultCount(updates);
                } else {
                    nativeSQL.setResultCount(connection.executeNonQuery(nativeSQL.getQuery(), queryParameters, null));
                }
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
