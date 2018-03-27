package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
public abstract class MySQLFunctionSQLProvider extends FunctionSQLProvider {
    protected MySQLFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }
}
