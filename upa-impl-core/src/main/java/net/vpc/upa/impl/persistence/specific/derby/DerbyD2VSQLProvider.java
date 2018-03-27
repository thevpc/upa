package net.vpc.upa.impl.persistence.specific.derby;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.uql.compiledexpression.CompiledD2V;
import net.vpc.upa.impl.util.StringUtils;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyD2VSQLProvider extends DerbyFunctionSQLProvider {
    DerbyD2VSQLProvider() {
        super(CompiledD2V.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length != 1) {
            throw new UPAIllegalArgumentException("bad number of params for function '" + functionName + "' .\n Error near " + functionName + "(" + StringUtils.format(params) + ")");
        }
        return "TRIM(CAST(CAST(" + params[0] + " AS CHAR(30)) AS VARCHAR(30)))";
    }
}
