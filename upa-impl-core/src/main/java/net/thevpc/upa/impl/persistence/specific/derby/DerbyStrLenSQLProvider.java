package net.thevpc.upa.impl.persistence.specific.derby;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledStrLen;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DerbyStrLenSQLProvider extends DerbyFunctionSQLProvider {
    public DerbyStrLenSQLProvider() {
        super(CompiledStrLen.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return "length(" + params[0] + ")";
    }
}