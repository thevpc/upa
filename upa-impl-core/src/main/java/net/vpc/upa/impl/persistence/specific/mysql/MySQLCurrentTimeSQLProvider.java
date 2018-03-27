package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.impl.persistence.specific.derby.*;
import net.vpc.upa.PortabilityHint;

import java.util.Map;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentTime;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLCurrentTimeSQLProvider extends DerbyFunctionSQLProvider {
    MySQLCurrentTimeSQLProvider() {
        super(CompiledCurrentTime.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{}, params);
        return "CURRENT_TIME";
    }
}