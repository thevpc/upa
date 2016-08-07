package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.impl.persistence.shared.sql.ANSIFunctionSQLProvider;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCast;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
public class CastANSISQLProvider extends ANSIFunctionSQLProvider {
    public CastANSISQLProvider() {
        super(CompiledCast.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        checkFunctionSignature(new String[]{"value", "type"}, params);
        return "Cast((" + params[0] + ") As " + params[1] + ")";
    }
}