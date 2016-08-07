package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.impl.persistence.specific.derby.*;
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
@PortabilityHint(target = "C#", name = "suppress")
public class MySQLStrLenSQLProvider extends DerbyFunctionSQLProvider {
    public MySQLStrLenSQLProvider() {
        super(CompiledStrLen.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(1, params);
        return "length(" + params[0] + ")";
    }
}