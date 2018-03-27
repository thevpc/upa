package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.sql.SelectSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#",name = "suppress")
public class MSSQLServerSelectSQLProvider extends SelectSQLProvider {

    public MSSQLServerSelectSQLProvider() {
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledSelect o = (CompiledSelect) oo;
        StringBuilder sb = new StringBuilder("Select ");
        if (o.getTop() > 0) {
            sb.append(" TOP ").append(o.getTop());
        }
        appendDistinct(o, sb, context, sqlManager, declarations);
        appendFields(o, sb, context, sqlManager, declarations);
        appendFrom(o, sb, context, sqlManager, declarations);
        appendJoins(o, sb, context, sqlManager, declarations);
        appendWhere(o, sb, context, sqlManager, declarations);
        appendGroupBy(o, sb, context, sqlManager, declarations);

        appendHaving(o, sb, context, sqlManager, declarations);
        appendOrderBy(o, sb, context, sqlManager, declarations);
        return sb.toString();
    }

    @Override
    public String getFromNullString() {
        return null;
    }
}
