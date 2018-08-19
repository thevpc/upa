package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledDateTrunc;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */

/**
 * truncate date to unathe date according to precision
 * precision may be
 * date ==> eliminates all time values
 * month ==> eliminates all day of the month and time values
 * year ==> eliminates all day of the month and time values
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleDateTruncSQLProvider extends OracleFunctionSQLProvider {
    public OracleDateTruncSQLProvider() {
        super(CompiledDateTrunc.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"date", "format"}, params);
        String format = params[0];
        String date1 = params[1];

        if ("date".equals(format)) {
            return "trunc(" + date1 + ",'HH')";
        } else if ("hour".equals(format)) {
            return "trunc(" + date1 + ",'HH')";
        } else if ("month".equals(format)) {
            return "trunc(" + date1 + ",'MM')";
        } else if ("year".equals(format)) {
            return "trunc(" + date1 + ",'YY')";
        }

        throw new RuntimeException("Adapter : incorrect format '" + format + "' for function 'dateadd'");
        //return  "dateadd("+format+","+count+","+date1+")";
    }
}
