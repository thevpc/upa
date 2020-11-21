package net.thevpc.upa.impl.persistence.specific.derby;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDateDiff;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyDateDiffSQLProvider extends DerbyFunctionSQLProvider {
    DerbyDateDiffSQLProvider() {
        super(CompiledDateDiff.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledDateDiff d=(CompiledDateDiff) oo;
        String format = null;
        switch (d.getDatePartType()) {
            case WEEK: {
                format = "SQL_TSI_WEEK";
                break;
            }
            case DAY: {
                format = "SQL_TSI_DAY";
                break;
            }
            case YEAR: {
                format = "SQL_TSI_YEAR";
                break;
            }
            case DAYOFYEAR: {
                format = "SQL_TSI_DAY";
                break;
            }
            case MONTH: {
                format = "SQL_TSI_MONTH";
                break;
            }
            case HOUR: {
                format = "SQL_TSI_HOUR";
                break;
            }
            case MINUTE: {
                format = "SQL_TSI_MINUTE";
                break;
            }
            case MILLISECOND: {
                format = "SQL_TSI_FRAC_SECOND";
                break;
            }
            case SECOND: {
                throw new RuntimeException("Unsupported format '" + format + "' for function "+getExpressionType().getSimpleName());
            }
        }
        return "{fn TIMESTAMPDIFF(" + format + "," + sqlManager.getSQL(d.getStart(), qlContext, declarations) + "," + sqlManager.getSQL(d.getEnd(), qlContext, declarations) + ")}";
    }

}