package net.vpc.upa.impl.persistence.specific.mysql;

import net.vpc.upa.impl.persistence.specific.derby.*;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.uql.compiledexpression.CompiledConcat;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class MySQLConcatSQLProvider extends DerbyFunctionSQLProvider {
    MySQLConcatSQLProvider() {
        super(CompiledConcat.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 2) {
            return error("requires at least 2 arguments", params);
        } else {
            StringBuilder sb = new StringBuilder("CONCAT(");
            for (int i = 0; i < params.length; i++) {
                if (i > 0) {
                    sb.append(" , ");
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