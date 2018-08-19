package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledCoalesce;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DerbyCoalesceSQLProvider extends DerbyFunctionSQLProvider {
    public DerbyCoalesceSQLProvider() {
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