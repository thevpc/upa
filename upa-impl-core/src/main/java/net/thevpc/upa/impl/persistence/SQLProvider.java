package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:14 PM
 * To change this template use File | Settings | File Templates.
 */
public interface SQLProvider {
    String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations)throws UPAException;

    Class getExpressionType();
}
