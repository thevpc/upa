package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#",name = "suppress")
public abstract class MSSQLServerFunctionSQLProvider extends FunctionSQLProvider {
    protected MSSQLServerFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }
}
