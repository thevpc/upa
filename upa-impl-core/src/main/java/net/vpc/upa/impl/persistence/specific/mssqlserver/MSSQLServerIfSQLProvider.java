package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledIf;

import java.util.Map;


/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerIfSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerIfSQLProvider() {
        super(CompiledIf.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 3 || params.length % 2 == 0) {
            return error("bad number of params", params);
        }
        StringBuilder sb = new StringBuilder("case");
        for (int i = 0; i < params.length; i += 2) {
            String pi = "("+params[i]+")";
            if (i == params.length - 1) {
                sb.append(" else ").append(pi).append(" end");
            } else {
                String pi1 = "("+params[i + 1]+")";
                sb.append(" when ").append(pi).append(" then ").append(pi1);
            }
        }
        return sb.toString();
    }
}
