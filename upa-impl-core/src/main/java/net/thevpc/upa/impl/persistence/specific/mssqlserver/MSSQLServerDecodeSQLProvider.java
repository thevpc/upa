package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDecode;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerDecodeSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerDecodeSQLProvider() {
        super(CompiledDecode.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 3 || params.length % 2 == 0) {
            return error("bad number of params", params);
        }
        StringBuilder sb = new StringBuilder("case");
        sb.append("(").append(params[0]).append(")");
        for (int i = 1; i < params.length; i += 2) {
            if (i == params.length - 1) {
                sb.append(" else ").append("(").append(params[i]).append(")").append(" end");
            } else {
                sb.append(" when ").append("(").append(params[i]).append(")").append(" then ").append("(").append(params[i + 1]).append(")");
            }
        }
        return sb.toString();
    }
}
