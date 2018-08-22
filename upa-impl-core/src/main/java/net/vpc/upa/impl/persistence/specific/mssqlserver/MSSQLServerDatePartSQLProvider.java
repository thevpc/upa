package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.ext.expr.CompiledDatePart;

import java.util.Map;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 mai 2003 Time: 17:26:10
 *
 */
@PortabilityHint(target = "C#", name = "suppress")
class MSSQLServerDatePartSQLProvider extends MSSQLServerFunctionSQLProvider {

    public MSSQLServerDatePartSQLProvider() {
        super(CompiledDatePart.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledDatePart d = (CompiledDatePart) oo;
        String format = null;
        String date = sqlManager.getSQL(d.getValue(), qlContext, declarations);
        switch (d.getDatePartType()) {
            case DAY:
            case DAYOFMONTH: {
                return "DAY(" + date + ")";
            }
            case YEAR: {
                return "YEAR(" + date + ")";
            }
            case MONTH: {
                return "datepart(month," + date + ")";
            }
            case HOUR: {
                return "datepart(hour," + date + ")";
            }
            case MINUTE: {
                return "datepart(minute," + date + ")";
            }
            case SECOND: {
                return "datepart(second," + date + ")";
            }
            case DAYOFWEEK: {
                return "datepart(weekday," + date + ")";
            }
            case MILLISECOND: {
                return "datepart(millisecond," + date + ")";
            }
            case DAYOFYEAR: {
                return "datepart(dayofyear," + date + ")";
            }
            case WEEK: {
                return "datepart(week," + date + ")";
            }
            case DAYOFWEEKNAME: {
                return "datename(weekday," + date + ")";
            }
            case MONTHNAME: {
                return "datename(month," + date + ")";
            }
            case DATETIME: {
                return "convert(char(19)," + date + ",120)";
            }
            case DATE: {
                return "convert(char(10)," + date + ",120)";
            }
            case TIME: {
                return "convert(char(8)," + date + ",8)";
            }
            default: {
                throw new RuntimeException("Unsupported format '" + format + "' for function " + getExpressionType().getSimpleName());
            }
        }
    }

//    @Override
//    public String simplify(String functionName, String[] params, Map<String, Object> context) {
//        checkFunctionSignature(new String[]{"format", "count"}, params);
//        String format = params[0];
//        String date = "(" + params[1] + ")";
//        if ("date_time".equals(format)) {
//            return "convert(char(19)," + date + ",120)";
//        } else if ("time".equals(format)) {
//            return "convert(char(8)," + date + ",8)";
//        } else if ("date".equals(format)) {
//            return "convert(char(10)," + date + ",120)";
//        } else if ("year".equals(format)) {
//            return "year(" + date + ")";
//        } else if ("day_of_month".equals(format)) {
//            return "day(" + date + ")";
//        } else if ("day_of_year".equals(format)) {
//            return "datepart(dayofyear," + date + ")";
//        } else if ("day_of_week".equals(format)) {
//            return "datepart(weekday," + date + ")";
//        } else if ("day_of_week_name".equals(format)) {
//            return "datename(weekday," + date + ")";
//        } else if ("month".equals(format)) {
//            return "month(" + date + ")";
//        } else if ("month_name".equals(format)) {
//            return "datename(month," + date + ")";
//        } else if ("hour".equals(format)) {
//            return "datepart(hour," + date + ")";
//        } else if ("minute".equals(format)) {
//            return "datepart(minute," + date + ")";
//        } else if ("second".equals(format)) {
//            return "datepart(second," + date + ")";
//        }
//        throw new RuntimeException("Adapter : incorrect format '" + format + "' for function 'datepart'");
//    }
//    private String sql_format_int(String expr,int width){
//        return "replace(space("+width+"-len(ltrim(str("+expr+")))),' ','0')+ltrim(str("+expr+"))";
//        //return "cast("+expr+" as varchar)";
//    }
//    private String sql_format_string(String expr,int width){
//        return "replace(space("+width+"-len("+expr+")),' ','0')+"+expr;
//    }
}
