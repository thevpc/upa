package net.vpc.upa.impl.persistence.specific.mysql;


import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDatePart;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLDatePartSQLProvider extends MySQLFunctionSQLProvider{

    MySQLDatePartSQLProvider() {
        super(CompiledDatePart.class);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"format", "date"}, params);
        String format = params[0];
        String date = params[1];
        if ("date_time".equals(format)) {
            return date;
        } else if ("time".equals(format)) {
            return "substring(" + date + ",11,19)";
        } else if ("date".equals(format)) {
            return "substring(" + date + ",0,10)";
        } else if ("year".equals(format)) {
            return "substring(" + date + ",0,4)";
        } else if ("day_of_month".equals(format)) {
            return "substring(" + date + ",8,10)";
        } else if ("day_of_year".equals(format)) {
            //not supported
        } else if ("day_of_week".equals(format)) {
            //not supported
        } else if ("day_of_week_name".equals(format)) {
            //not supported
        } else if ("month".equals(format)) {
            return "substring(" + date + ",5,7)";
        } else if ("month_name".equals(format)) {
            //not supported
        } else if ("hour".equals(format)) {
            return "substring(" + date + ",11,13)";
        } else if ("minute".equals(format)) {
            return "substring(" + date + ",14,16)";
        } else if ("second".equals(format)) {
            return "substring(" + date + ",17,19)";
        }
        throw new RuntimeException("Adapter : incorrect param for function 'datepart'");
    }
}
