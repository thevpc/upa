package net.thevpc.upa.impl.persistence.specific.mysql;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledCoalesce;

import java.util.Map;

/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 17:17:34 To
 * change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class MySQLCoalesceSQLProvider extends MySQLFunctionSQLProvider {

    public MySQLCoalesceSQLProvider() {
        super(CompiledCoalesce.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 1) {
            error("requires at least 1 argument", params);
        }
        StringBuilder sb = new StringBuilder("Coalesce(");
        for (int i = 0; i < params.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append("(");
            sb.append(params[i]);
            sb.append(")");
        }
        sb.append(")");
        return sb.toString();
    }
}
