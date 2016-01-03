package net.vpc.upa.impl.persistence;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:14 PM
 * To change this template use File | Settings | File Templates.
 */
public interface SQLProvider {
    public abstract String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations)throws UPAException;

    public Class getExpressionType();
}
