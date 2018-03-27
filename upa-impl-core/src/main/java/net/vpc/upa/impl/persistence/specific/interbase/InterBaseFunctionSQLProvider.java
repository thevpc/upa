package net.vpc.upa.impl.persistence.specific.interbase;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
abstract class InterBaseFunctionSQLProvider extends FunctionSQLProvider {
    protected InterBaseFunctionSQLProvider(Class expressionType) {
        super(expressionType);
    }
}
