package net.thevpc.upa.impl.persistence.specific.mysql;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.expressions.DatePartType;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDatePart;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 mai 2003 Time: 17:26:10
 *
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLDatePartSQLProvider extends MySQLFunctionSQLProvider {

    MySQLDatePartSQLProvider() {
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
                return "MONTH(" + date + ")";
            }
            case HOUR: {
                return "HOUR(" + date + ")";
            }
            case MINUTE: {
                return "MINUTE(" + date + ")";
            }
            case SECOND: {
                return "SECOND(" + date + ")";
            }
            case DAYOFWEEK: {
                return "DAYOFWEEK(" + date + ")";
            }
            case MILLISECOND:{
                return "(MICROSECOND(" + date + ")/1000)";
            }
            case DAYOFYEAR:{
                return "(DAYOFYEAR(" + date + ")/1000)";
            }
            case WEEK:{
                return "WEEK(" + date + ")";
            }
            case DAYOFWEEKNAME:{
                return "DAYNAME(" + date + ")";
            }
            case MONTHNAME:{
                return "MONTHNAME(" + date + ")";
            }
            case DATETIME: {
                return "DATE_FORMAT(" + date + ",'%Y-%m-%d %H-%i-%S')";
            }
            case DATE: {
                return "DATE_FORMAT(" + date + ",'%Y-%m-%d')";
            }
            case TIME: {
                return "DATE_FORMAT(" + date + ",'%H-%i-%S')";
            }
            default: {
                throw new RuntimeException("Unsupported format '" + format + "' for function " + getExpressionType().getSimpleName());
            }
        }
    }
}
