package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.impl.persistence.specific.derby.*;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDateDiff;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
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