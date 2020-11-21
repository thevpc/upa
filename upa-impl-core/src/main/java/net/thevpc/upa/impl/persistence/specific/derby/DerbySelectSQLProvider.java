package net.thevpc.upa.impl.persistence.specific.derby;

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
@PortabilityHint(target = "C#", name = "suppress")
public class DerbySelectSQLProvider extends SelectSQLProvider {

    public DerbySelectSQLProvider() {
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledSelect o = (CompiledSelect) oo;
            String t = super.getSQL(oo, context, sqlManager, declarations);
        if (o.getTop() > 0) {
            return t+" FETCH FIRST "+o.getTop()+" ROWS ONLY";
        } else {
            return t;
        }
    }

    @Override
    public String getFromNullString() {
        return "FROM SYSIBM.SYSDUMMY1";
    }
}
