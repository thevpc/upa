package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDecode;
import net.vpc.upa.impl.util.StringUtils;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyDecodeSQLProvider extends DerbyFunctionSQLProvider {
    DerbyDecodeSQLProvider() {
        super(CompiledDecode.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 4 || params.length % 2 != 0) {
            throw new UPAIllegalArgumentException("bad number of params for function '" + functionName + "' .\n Error near " + functionName + "(" + StringUtils.format(params) + ")");
        }
        StringBuilder sb = new StringBuilder("case");
        for (int i = 1; i < params.length; i += 2) {
            if (i == params.length - 1) {
                sb.append(" else ").append(params[i]).append(" end");
            } else {
                String v = "("+params[i]+")";
                sb.append(" when ").append("(").append(params[0]).append(")");
                if ("NULL".equalsIgnoreCase(v)) {
                    sb.append(" is ").append(v);
                } else {
                    sb.append(" = ").append(v);
                }
                sb.append(" then ").append("(").append(params[i + 1]).append(")");
            }
        }
        return sb.toString();
    }
}
