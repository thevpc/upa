package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUnaryOperator;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class UnaryOperatorSQLProvider extends AbstractSQLProvider {
    public UnaryOperatorSQLProvider() {
        super(CompiledUnaryOperator.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledUnaryOperator o=(CompiledUnaryOperator) oo;
        return o.getOperator() + sqlManager.getSQL(o.getExpression(), qlContext, declarations);
    }
}
