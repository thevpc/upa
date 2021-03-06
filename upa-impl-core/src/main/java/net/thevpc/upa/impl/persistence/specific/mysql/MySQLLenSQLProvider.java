package net.thevpc.upa.impl.persistence.specific.mysql;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledStrLen;

import java.util.Map;


/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLLenSQLProvider extends MySQLFunctionSQLProvider {
    MySQLLenSQLProvider() {
        super(CompiledStrLen.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return "length(" + params[0] + ")";
    }
}
