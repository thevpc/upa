package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.upql.ext.expr.CompiledCount;
import net.thevpc.upa.impl.util.StringUtils;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
public class CountANSISQLProvider extends ANSIFunctionSQLProvider {
    public CountANSISQLProvider() {
        super(CompiledCount.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length != 1) {
            throw new IllegalUPAArgumentException("function '" + functionName + "' requieres 1 argument.\n Error near " + functionName + "(" + StringUtils.format(params) + ")");
        } else {
            StringBuilder sb = new StringBuilder("Count(");
            sb.append(params[0]);
            sb.append(")");
            return sb.toString();
        }
    }
}
