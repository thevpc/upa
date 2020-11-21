package net.thevpc.upa.impl.persistence.specific.derby;

import net.thevpc.upa.PortabilityHint;

import java.util.Map;
import net.thevpc.upa.impl.upql.ext.expr.CompiledCurrentTime;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyCurrentTimeSQLProvider extends DerbyFunctionSQLProvider {
    DerbyCurrentTimeSQLProvider() {
        super(CompiledCurrentTime.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{}, params);
        return "CURRENT_TIME";
    }
}