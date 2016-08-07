package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledStrLen;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleStrLenSQLProvider extends OracleFunctionSQLProvider {
    public OracleStrLenSQLProvider() {
        super(CompiledStrLen.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
//        System.out.println("StrLen : " + functionName+ Arrays.asList(params));
        if (params.length != 1) {
            return error("requieres at least 2 arguments", params);
        } else {
            return "length(" + params[0] + ")";
        }
    }
}
