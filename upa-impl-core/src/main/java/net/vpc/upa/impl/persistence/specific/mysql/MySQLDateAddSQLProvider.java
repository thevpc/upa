package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.impl.persistence.specific.derby.*;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledDateAdd;

import java.util.Map;

/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 17:26:10 To
 * change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLDateAddSQLProvider extends DerbyFunctionSQLProvider {

    public MySQLDateAddSQLProvider() {
        super(CompiledDateAdd.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"format", "count", "start_date"}, params);
        String format = params[0].toLowerCase();
        String count = params[1];
        String date1 = params[2];
        /**
         * SQL_TSI_DAY SQL_TSI_FRAC_SECOND SQL_TSI_HOUR SQL_TSI_MINUTE
         * SQL_TSI_MONTH SQL_TSI_QUARTER SQL_TSI_SECOND SQL_TSI_WEEK
         * SQL_TSI_YEAR
         */
        String mySqlType="";
        if ("week".equals(format)) {
            mySqlType="WEEK";
        } else if ("day".equals(format)) {
            mySqlType="DAY";
        } else if ("year".equals(format)) {
            mySqlType="YEAR";
        } else if ("day_of_year".equals(format)) {
            mySqlType="DAY";
        } else if ("month".equals(format)) {
            mySqlType="MONTH";
        } else if ("hour".equals(format)) {
            mySqlType="HOUR";
        } else if ("minute".equals(format)) {
            mySqlType="MINUTE";
        } else if ("second".equals(format)) {
            mySqlType="SECOND";
        } else if ("millisecond".equals(format)) {
            mySqlType="MICROSECOND";
            count="("+count+")*1000";
        } else {
            throw new RuntimeException("Adapter : incorrect format '" + format + "' for function 'dateadd'");
        }
        return "{fn DATE_ADD(("+date1+"), INTERVAL (" + count + ") " + mySqlType + ")}";
        //throw new RuntimeException("Adapter : incorrect format '"+format+"' for function 'dateadd'");
        //return  "dateadd("+format+","+count+","+date1+")";
    }
}
