package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledMonthEnd;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerMonthEndSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerMonthEndSQLProvider() {
        super(CompiledMonthEnd.class);
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
        count = "(" + count + ")+1";

        return "dateadd(day,0-datepart(day,dateadd(month," + count + "," + date + ")),dateadd(month," + count + "," + date + "))";
    }
}
