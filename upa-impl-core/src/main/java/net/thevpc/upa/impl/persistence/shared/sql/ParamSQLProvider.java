package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledParam;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/17/12
 * Time: 12:52 AM
 * To change this template use File | Settings | File Templates.
 */
public class ParamSQLProvider extends AbstractSQLProvider {
    public ParamSQLProvider() {
        super(CompiledParam.class);
    }


    @Override
    public String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) {
        return "?";
    }


}
