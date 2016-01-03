package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMonthEnd;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleMonthEndSQLProvider extends OracleFunctionSQLProvider {
    public OracleMonthEndSQLProvider() {
        super(CompiledMonthEnd.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        String date = "sysdate";
        String count = "0";
        if (params.length == 0) {
            //
        } else if (params.length == 1) {
            count = params[0];
        } else if (params.length == 2) {
            date = params[0];
            count = params[0];
        } else {
            checkFunctionSignature(new String[]{"date", "diffCount"}, params);
        }
        return "(TO_DATE(TO_CHAR(ADD_MONTHS((" + date + "),(" + count + ")+1), 'YYYY-MM-')||'01','YYYY-MM-DD')-1)";
    }
}