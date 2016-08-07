package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.PersistenceUnit;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/16/12
 * Time: 11:47 PM
 * To change this template use File | Settings | File Templates.
 */
public interface CompiledExpandableExpression extends DefaultCompiledExpression {
    public DefaultCompiledExpression expand(PersistenceUnit persistenceUnit);
}
