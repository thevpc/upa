package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
 */
public abstract class MSSQLServerFunctionSQLProvider extends FunctionSQLProvider {
    protected MSSQLServerFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }
}
