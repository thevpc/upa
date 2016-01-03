package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.impl.uql.compiledexpression.CompiledD2V;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
class MSSQLServerD2VSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerD2VSQLProvider() {
        super(CompiledD2V.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return params[0];
    }
}
