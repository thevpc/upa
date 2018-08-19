package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.upql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
public abstract class DerbyFunctionSQLProvider extends FunctionSQLProvider {
    protected DerbyFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }

}