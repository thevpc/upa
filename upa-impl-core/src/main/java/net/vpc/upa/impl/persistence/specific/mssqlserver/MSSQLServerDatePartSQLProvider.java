package net.vpc.upa.impl.persistence.specific.mssqlserver;

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
@PortabilityHint(target = "C#",name = "suppress")
class MSSQLServerDatePartSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerDatePartSQLProvider() {
        super(CompiledDatePart.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"format", "count"}, params);
        String format = params[0];
        String date = "("+params[1]+")";
        if ("date_time".equals(format)) {
            return "convert(char(19)," + date + ",120)";
        } else if ("time".equals(format)) {
            return "convert(char(8)," + date + ",8)";
        } else if ("date".equals(format)) {
            return "convert(char(10)," + date + ",120)";
        } else if ("year".equals(format)) {
            return "year(" + date + ")";
        } else if ("day_of_month".equals(format)) {
            return "day(" + date + ")";
        } else if ("day_of_year".equals(format)) {
            return "datepart(dayofyear," + date + ")";
        } else if ("day_of_week".equals(format)) {
            return "datepart(weekday," + date + ")";
        } else if ("day_of_week_name".equals(format)) {
            return "datename(weekday," + date + ")";
        } else if ("month".equals(format)) {
            return "month(" + date + ")";
        } else if ("month_name".equals(format)) {
            return "datename(month," + date + ")";
        } else if ("hour".equals(format)) {
            return "datepart(hour," + date + ")";
        } else if ("minute".equals(format)) {
            return "datepart(minute," + date + ")";
        } else if ("second".equals(format)) {
            return "datepart(second," + date + ")";
        }
        throw new RuntimeException("Adapter : incorrect format '" + format + "' for function 'datepart'");
    }
//    private String sql_format_int(String expr,int width){
//        return "replace(space("+width+"-len(ltrim(str("+expr+")))),' ','0')+ltrim(str("+expr+"))";
//        //return "cast("+expr+" as varchar)";
//    }

//    private String sql_format_string(String expr,int width){
//        return "replace(space("+width+"-len("+expr+")),' ','0')+"+expr;
//    }

}
