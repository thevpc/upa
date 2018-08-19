package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledDatePart;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyDatePartSQLProvider extends DerbyFunctionSQLProvider {
    DerbyDatePartSQLProvider() {
        super(CompiledDatePart.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledDatePart d=(CompiledDatePart) oo;
        String format = null;
        switch (d.getDatePartType()) {
            case DAY: {
                return "DAY("+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case YEAR: {
                return "YEAR("+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case MONTH: {
                return "MONTH("+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case HOUR: {
                return "HOUR("+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case MINUTE: {
                return "MINUTE("+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case SECOND: {
                return "SECOND("+sqlManager.getSQL(d.getValue(), qlContext, declarations)+")";
            }
            case MILLISECOND:
            case WEEK:
            case DAYOFYEAR:
            default: {
                throw new RuntimeException("Unsupported format '" + format + "' for function "+getExpressionType().getSimpleName());
            }
        }
    }

}