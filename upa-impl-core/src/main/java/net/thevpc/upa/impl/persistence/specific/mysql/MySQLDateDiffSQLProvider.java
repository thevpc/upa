package net.thevpc.upa.impl.persistence.specific.mysql;

import net.thevpc.upa.impl.persistence.specific.derby.DerbyFunctionSQLProvider;
import net.thevpc.upa.impl.persistence.specific.derby.*;
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
class MySQLDateDiffSQLProvider extends DerbyFunctionSQLProvider {
    MySQLDateDiffSQLProvider() {
        super(CompiledDateDiff.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledDateDiff d=(CompiledDateDiff) oo;
        String format = null;
        int divider=0;
        switch (d.getDatePartType()) {
            case WEEK: {
                format = "WEEK";
                break;
            }
            case DAY: {
                format = "DAY";
                break;
            }
            case YEAR: {
                format = "YEAR";
                break;
            }
            case DAYOFYEAR: {
                format = "DAY";
                break;
            }
            case MONTH: {
                format = "MONTH";
                break;
            }
            case HOUR: {
                format = "HOUR";
                break;
            }
            case MINUTE: {
                format = "MINUTE";
                break;
            }
            case MILLISECOND: {
                format = "MICROSECOND";
                divider=1000;
                break;
            }
            case SECOND: {
                throw new RuntimeException("Unsupported format '" + format + "' for function "+getExpressionType().getSimpleName());
            }
        }
        if(divider>0){
        return "({fn TIMESTAMPDIFF(" + format + "," + sqlManager.getSQL(d.getStart(), qlContext, declarations) + "," + sqlManager.getSQL(d.getEnd(), qlContext, declarations) + ")})/"+divider;
            
        }
        return "{fn TIMESTAMPDIFF(" + format + "," + sqlManager.getSQL(d.getStart(), qlContext, declarations) + "," + sqlManager.getSQL(d.getEnd(), qlContext, declarations) + ")}";
    }

}