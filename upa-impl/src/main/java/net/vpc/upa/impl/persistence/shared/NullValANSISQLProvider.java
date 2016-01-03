package net.vpc.upa.impl.persistence.shared;


import net.vpc.upa.impl.uql.compiledexpression.CompiledNullVal;
import net.vpc.upa.impl.util.Strings;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:26:10
 * To change this template use Options | File Templates.
 */
public class NullValANSISQLProvider extends ANSIFunctionSQLProvider {
    public NullValANSISQLProvider() {
        super(CompiledNullVal.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length != 1) {
            throw new IllegalArgumentException("bad number of params for function '" + functionName + "' .\n Error near " + functionName + "(" + Strings.format(params) + ")");
        }
        return "Null";
    }
}