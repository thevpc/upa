package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDateDiff;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerDateDiffSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerDateDiffSQLProvider() {
        super(CompiledDateDiff.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"format", "start_date", "end_date"}, params);
        String format = params[0];
        String date1 = params[1];
        String date2 = params[2];

        if ("week".equals(format)) {
        } else if ("day".equals(format)) {
        } else if ("year".equals(format)) {
        } else if ("day_of_year".equals(format)) {
            format = "dayofyear";
        } else if ("month".equals(format)) {
        } else if ("hour".equals(format)) {
        } else if ("minute".equals(format)) {
        } else if ("second".equals(format)) {
        } else if ("millisecond".equals(format)) {
        } else {
            throw new RuntimeException("Adapter : incorrect format '" + format + "' for function 'datediff'");
        }
        return "datediff(" + format + ",(" + date1 + "),(" + date2 + "))";
    }
}
