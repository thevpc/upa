package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ext.expr.CompiledCst;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
 * this template use File | Settings | File Templates.
 */
public class CstSQLProvider extends AbstractSQLProvider {

    public CstSQLProvider() {
        super(CompiledCst.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        CompiledCst o = (CompiledCst) oo;
        return o.toString();
    }
}
