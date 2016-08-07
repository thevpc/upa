package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCast;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLCastSQLProvider extends MySQLFunctionSQLProvider {
    MySQLCastSQLProvider() {
        super(CompiledCast.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"value", "type"}, params);
        return params[0]; // no cast is needed
    }
}
