package net.vpc.upa.impl.persistence.shared;

import net.vpc.upa.impl.uql.compiledexpression.CompiledCoalesce;
import net.vpc.upa.impl.util.Strings;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
 */
public class CoalesceANSISQLProvider extends ANSIFunctionSQLProvider {
    public CoalesceANSISQLProvider() {
        super(CompiledCoalesce.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 1) {
            throw new IllegalArgumentException("function '" + functionName + "' requieres at least 1 argument.\n Error near " + functionName + "(" + Strings.format(params) + ")");
        } else {
            StringBuilder sb = new StringBuilder("Coalesce(");
            for (int i = 0; i < params.length; i++) {
                if (i > 0) {
                    sb.append(',');
                }
                sb.append("(");
                sb.append(params[i]);
                sb.append(")");
            }
            sb.append(")");
            return sb.toString();
        }
    }
}