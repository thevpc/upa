package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentTimestamp;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
class MSSQLServerSystemDateTimeSQLProvider extends MSSQLServerFunctionSQLProvider{
    public MSSQLServerSystemDateTimeSQLProvider() {
        super(CompiledCurrentTimestamp.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{}, params);
        return "getDate()";
    }
}
