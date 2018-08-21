package net.vpc.upa.impl.persistence.shared.sql;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.impl.persistence.shared.sql.ANSIFunctionSQLProvider;
import net.vpc.upa.impl.upql.ext.expr.CompiledMax;
import net.vpc.upa.impl.util.StringUtils;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
public class MaxANSISQLProvider extends ANSIFunctionSQLProvider {
    public MaxANSISQLProvider() {
        super(CompiledMax.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length != 1) {
            throw new IllegalUPAArgumentException("function '" + functionName + "' requieres 1 argument.\n Error near " + functionName + "(" + StringUtils.format(params) + ")");
        } else {
            StringBuilder sb = new StringBuilder("Max(");
            sb.append(params[0]);
            sb.append(")");
            return sb.toString();
        }
    }
}
