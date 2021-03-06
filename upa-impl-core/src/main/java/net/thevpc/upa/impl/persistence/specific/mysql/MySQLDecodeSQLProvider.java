package net.thevpc.upa.impl.persistence.specific.mysql;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.specific.derby.DerbyFunctionSQLProvider;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDecode;
import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.impl.persistence.specific.derby.*;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLDecodeSQLProvider extends DerbyFunctionSQLProvider {
    MySQLDecodeSQLProvider() {
        super(CompiledDecode.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 4 || params.length % 2 != 0) {
            throw new IllegalUPAArgumentException("bad number of params for function '" + functionName + "' .\n Error near " + functionName + "(" + StringUtils.format(params) + ")");
        }
        StringBuilder sb = new StringBuilder("case");
        for (int i = 1; i < params.length; i += 2) {
            if (i == params.length - 1) {
                sb.append(" else ").append(params[i]).append(" end case");
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
