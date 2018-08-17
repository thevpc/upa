package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDatePart;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleDatePartSQLProvider extends OracleFunctionSQLProvider {
    public OracleDatePartSQLProvider() {
        super(CompiledDatePart.class);
    }

    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledDatePart d=(CompiledDatePart) oo;
        String format = null;
        switch (d.getDatePartType()) {
            case DAY: {
                return "EXTRACT(DAY FROM "+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case YEAR: {
                return "EXTRACT(YEAR FROM "+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case MONTH: {
                return "EXTRACT(MONTH FROM "+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case HOUR: {
                return "EXTRACT(HOUR FROM "+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case MINUTE: {
                return "EXTRACT(MINUTE FROM "+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case SECOND: {
                return "EXTRACT(SECOND FROM "+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case MILLISECOND:
            case WEEK:
            case DAYOFYEAR:
            default: {
                throw new RuntimeException("Unsupported format '" + format + "' for function "+getExpressionType().getSimpleName());
            }
        }
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"format", "count"}, params);
        String format = params[0];
        String date = params[1];
        if ("date_time".equals(format)) {
            return "TO_CHAR(date, 'YYYY-MM-DD HH24:MI:SS')".replaceAll("date", date);
        } else if ("time".equals(format)) {
            return "TO_CHAR(date, 'HH24:MI:SS')".replaceAll("date", date);
        } else if ("date".equals(format)) {
            return "TO_CHAR(date, 'YYYY-MM-DD')".replaceAll("date", date);
        } else if ("year".equals(format)) {
            return "YEAR(date)".replaceAll("date", date);
        } else if ("day_of_month".equals(format)) {
            return "TO_CHAR(date, 'DD')".replaceAll("date", date);
        } else if ("day_of_year".equals(format)) {
            return "TO_CHAR(date, 'DDD')".replaceAll("date", date);
        } else if ("day_of_week".equals(format)) {
            return "TO_CHAR(date, 'DAY')".replaceAll("date", date);
        } else if ("day_of_week_name".equals(format)) {
            return "TO_CHAR(date, 'DY')".replaceAll("date", date);
        } else if ("month".equals(format)) {
            return "MONTH(date)".replaceAll("date", date);
        } else if ("month_name".equals(format)) {
            return "TO_CHAR(date, 'MONTH')".replaceAll("date", date);
        } else if ("hour".equals(format)) {
            return "HOUR(date)".replaceAll("date", date);
        } else if ("minute".equals(format)) {
            return "MINUTE(date)".replaceAll("date", date);
        } else if ("second".equals(format)) {
            return "SECOND(date)".replaceAll("date", date);
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
