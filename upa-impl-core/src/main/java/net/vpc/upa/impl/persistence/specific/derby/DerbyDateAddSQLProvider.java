package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledDateAdd;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyDateAddSQLProvider extends DerbyFunctionSQLProvider {

    public DerbyDateAddSQLProvider() {
        super(CompiledDateAdd.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"format", "count", "start_date"}, params);
        String format = params[0];
        String count = params[1];
        String date1 = params[2];
/**
 * SQL_TSI_DAY
 SQL_TSI_FRAC_SECOND
 SQL_TSI_HOUR
 SQL_TSI_MINUTE
 SQL_TSI_MONTH
 SQL_TSI_QUARTER
 SQL_TSI_SECOND
 SQL_TSI_WEEK
 SQL_TSI_YEAR
 */

        if ("week".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_WEEK," + count + "+" + date1 + ")}";
        } else if ("day".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_DAY," + count + "+" + date1 + ")}";
        } else if ("year".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_YEAR," + count + "+" + date1 + ")}";
        } else if ("day_of_year".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_YEAR," + count + "+" + date1 + ")}";
        } else if ("month".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_MONTH," + count + "+" + date1 + ")}";
        } else if ("hour".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_HOUR," + count + "+" + date1 + ")}";
        } else if ("minute".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_MINUTE," + count + "+" + date1 + ")}";
        } else if ("second".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_SECOND," + count + "+" + date1 + ")}";
        } else if ("millisecond".equals(format)) {
            return "{fn TIMESTAMPADD(SQL_TSI_FRAC_SECOND," + count + "+" + date1 + ")}";
        } else {
            throw new RuntimeException("Adapter : incorrect format '" + format + "' for function 'dateadd'");
        }
        //throw new RuntimeException("Adapter : incorrect format '"+format+"' for function 'dateadd'");
        //return  "dateadd("+format+","+count+","+date1+")";
    }
}