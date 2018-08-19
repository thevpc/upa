package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:26:10
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
public abstract class MySQLFunctionSQLProvider extends FunctionSQLProvider {
    protected MySQLFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }
}
