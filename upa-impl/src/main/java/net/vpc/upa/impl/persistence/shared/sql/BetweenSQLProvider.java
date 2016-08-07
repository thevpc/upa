package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.CompiledBetween;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class BetweenSQLProvider extends AbstractSQLProvider {

    public BetweenSQLProvider() {
        super(CompiledBetween.class);
    }

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledBetween o=(CompiledBetween) oo;
        String s = sqlManager.getSQL(o.getLeft(), qlContext, declarations) + " Between " +
                sqlManager.getSQL(o.getMin(), qlContext, declarations) +" And "+
                sqlManager.getSQL(o.getMax(), qlContext, declarations);
        return "(" + s + ")" ;
    }
}
