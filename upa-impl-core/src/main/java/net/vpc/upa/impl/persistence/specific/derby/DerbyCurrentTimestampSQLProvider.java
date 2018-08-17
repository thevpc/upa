package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentTimestamp;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyCurrentTimestampSQLProvider extends DerbyFunctionSQLProvider {
    DerbyCurrentTimestampSQLProvider() {
        super(CompiledCurrentTimestamp.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{}, params);
        return "CURRENT_TIMESTAMP";
    }
}