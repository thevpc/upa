package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledAvg;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class AverageSQLProvider extends AbstractSQLProvider {
    public AverageSQLProvider() {
        super(CompiledAvg.class);
    }
    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations)throws UPAException {
        CompiledAvg o=(CompiledAvg) oo;
        return "Avg(" + sqlManager.getSQL(o.getExpression(), qlContext, declarations) + ")";
    }
}
