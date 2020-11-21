package net.thevpc.upa.impl.persistence.specific.mckoi;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.upql.parser.FunctionSQLProvider;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
abstract class McKoiFunction extends FunctionSQLProvider {
    protected McKoiFunction(Class expressionType) {
        super(expressionType);
    }
}
