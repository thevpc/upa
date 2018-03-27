package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledI2V;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyI2VSQLProvider extends DerbyFunctionSQLProvider {
    DerbyI2VSQLProvider() {
        super(CompiledI2V.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return "TRIM(CAST(CAST((" + params[0] + ") AS CHAR(30)) AS VARCHAR(30)))";
    }
}
