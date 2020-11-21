package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledCoalesce;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
public class MSSQLServerCoalesceSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerCoalesceSQLProvider() {
        super(CompiledCoalesce.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 2) {
            return error("requieres at least 2 arguments",params);
        } else {
            StringBuilder sb = new StringBuilder("(");
            for (int i = 0; i < params.length; i++) {
                if (i > 0) {
                    sb.append(',');
                }
                sb.append("(").append(params[i]).append(")");
            }
            sb.append(")");
            return sb.toString();
        }
    }
}
