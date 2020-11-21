package net.thevpc.upa.impl.persistence.specific.mssqlserver;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.persistence.shared.sql.SelectSQLProvider;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.persistence.EntityExecutionContext;

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
