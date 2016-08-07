package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledD2V;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleD2VSQLProvider extends OracleFunctionSQLProvider {
    public OracleD2VSQLProvider() {
        super(CompiledD2V.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return params[0];
    }
}
