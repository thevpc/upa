package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledIf;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleIfSQLProvider extends OracleFunctionSQLProvider {
    public OracleIfSQLProvider() {
        super(CompiledIf.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 3 || params.length % 2 == 0) {
            return error("bad number of params", params);
        }
        StringBuilder sb = new StringBuilder("case ");
        for (int i = 0; i < params.length; i += 2) {
            if (i == params.length - 1) {
                sb.append(" else ").append(params[i]).append(" end");
            } else {
                sb.append(" when ").append(params[i]).append(" then ").append(params[i + 1]);
            }
        }
        return sb.toString();
    }
}
