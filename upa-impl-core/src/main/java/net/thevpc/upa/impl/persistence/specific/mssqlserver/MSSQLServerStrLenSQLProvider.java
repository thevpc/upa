package net.thevpc.upa.impl.persistence.specific.mssqlserver;

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
@PortabilityHint(target = "C#",name = "suppress")
public class MSSQLServerStrLenSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerStrLenSQLProvider() {
        super(CompiledStrLen.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return "len(" + params[0] + ")";
    }
}
