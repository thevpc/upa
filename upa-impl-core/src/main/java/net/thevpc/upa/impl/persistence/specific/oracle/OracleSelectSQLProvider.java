package net.thevpc.upa.impl.persistence.specific.oracle;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.persistence.shared.sql.SelectSQLProvider;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledAnd;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.upql.ext.expr.UserCompiledExpression;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class OracleSelectSQLProvider extends SelectSQLProvider {

    public OracleSelectSQLProvider() {
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledSelect o = (CompiledSelect) oo;
        StringBuilder sb = new StringBuilder("Select ");
        appendDistinct(o, sb, context, sqlManager, declarations);
        appendFields(o, sb, context, sqlManager, declarations);
        appendFrom(o, sb, context, sqlManager, declarations);
        appendJoins(o, sb, context, sqlManager, declarations);
        if (o.getTop() > 0) {
            CompiledExpressionExt w = CompiledAnd.tryAddCopies(o.getWhere(),new UserCompiledExpression("ROWNUM <= " + o.getTop(), null));
            appendWhere(w, sb, context, sqlManager, declarations);
        } else {
            appendWhere(o, sb, context, sqlManager, declarations);
        }
        appendGroupBy(o, sb, context, sqlManager, declarations);

        appendHaving(o, sb, context, sqlManager, declarations);
        appendOrderBy(o, sb, context, sqlManager, declarations);
        return sb.toString();
    }

    @Override
    public String getFromNullString() {
        return "FROM DUAL";
    }
}
