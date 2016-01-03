package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.shared.SelectSQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
 * this template use File | Settings | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class MySQLSelectSQLProvider extends SelectSQLProvider {

    public MySQLSelectSQLProvider() {
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext context, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledSelect o = (CompiledSelect) oo;
        String t = super.getSQL(oo, context, sqlManager, declarations);
        if (o.getTop() > 0) {
            return t + " LIMIT " + o.getTop();
        } else {
            return t;
        }
    }

    @Override
    public String getFromNullString() {
        return "FROM DUAL";
    }
}
