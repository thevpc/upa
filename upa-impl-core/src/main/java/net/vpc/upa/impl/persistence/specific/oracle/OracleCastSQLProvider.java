package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCast;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleCastSQLProvider extends OracleFunctionSQLProvider {
    public OracleCastSQLProvider() {
        super(CompiledCast.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"value", "type"}, params);
        return "cast(" + params[0] + " as " + params[1] + ")";
    }
}