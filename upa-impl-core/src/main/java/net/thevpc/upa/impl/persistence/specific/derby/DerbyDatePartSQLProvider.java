package net.thevpc.upa.impl.persistence.specific.derby;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDatePart;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 mai 2003 Time: 17:26:10
 *
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyDatePartSQLProvider extends DerbyFunctionSQLProvider {

    DerbyDatePartSQLProvider() {
        super(CompiledDatePart.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledDatePart d = (CompiledDatePart) oo;
        String format = null;
        String date = sqlManager.getSQL(d.getValue(), qlContext, declarations);
        switch (d.getDatePartType()) {
            case DAY: {
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
            case DATETIME: {
                return "(cast(year(" + date + ") as char(4)) || '-' ||cast(month(" + date + ") as char(2)) || '-' ||cast(day(" + date + ") as char(2)) || "
                        + "' ' || cast(HOUR(" + date + ") as char(2)) || ':' ||cast(MINUTE(" + date + ") as char(2)) || ':' ||cast(SECOND(" + date + ") as char(2)))";
            }
            case DATE: {
                return "(cast(year(" + date + ") as char(4)) || '-' ||cast(month(" + date + ") as char(2)) || '-' ||cast(day(" + date + ") as char(2)))";
            }
            case TIME: {
                return "(cast(HOUR(" + date + ") as char(2)) || ':' ||cast(MINUTE(" + date + ") as char(2)) || ':' ||cast(SECOND(" + date + ") as char(2)))";
            }
            default: {
                throw new RuntimeException("Unsupported format '" + format + "' for function " + getExpressionType().getSimpleName());
            }
        }
    }

}
