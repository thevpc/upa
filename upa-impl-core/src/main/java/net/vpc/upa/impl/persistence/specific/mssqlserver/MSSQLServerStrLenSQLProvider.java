package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledStrLen;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
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
