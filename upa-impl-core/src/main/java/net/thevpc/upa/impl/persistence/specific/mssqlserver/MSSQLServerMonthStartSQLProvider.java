package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledMonthStart;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerMonthStartSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerMonthStartSQLProvider() {
        super(CompiledMonthStart.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        String date = "getDate()";
        String count = "0";
        if (params.length == 0) {
            //
        } else if (params.length == 1) {
            count = "("+params[0]+")";
        } else if (params.length == 2) {
            date = "("+params[0]+")";
            count = "("+params[0]+")";
        } else {
            checkFunctionSignature(new String[]{"date", "diffCount"}, params);
        }
        return "dateadd(day,1-datepart(day,dateadd(month," + count + "," + date + ")),dateadd(month," + count + "," + date + "))";
    }
}
