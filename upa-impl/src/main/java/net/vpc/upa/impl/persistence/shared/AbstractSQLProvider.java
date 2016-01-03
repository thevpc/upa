package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.persistence.SQLProvider;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/16/12
 * Time: 10:20 PM
 * To change this template use File | Settings | File Templates.
 */
public abstract class AbstractSQLProvider implements SQLProvider {
    private Class type;

    public AbstractSQLProvider(Class type) {
        this.type = type;
    }

    @Override
    public Class getExpressionType() {
        return type;
    }
}
