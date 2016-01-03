package net.vpc.upa.impl.persistence.specific.mssqlserver;

import net.vpc.upa.impl.uql.compiledexpression.CompiledConcat;

import java.util.Map;


/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:17:34
 * To change this template use Options | File Templates.
 */
public class MSSQLServerConcatSQLProvider extends MSSQLServerFunctionSQLProvider {
    public MSSQLServerConcatSQLProvider() {
        super(CompiledConcat.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 2) {
            return error("requieres at least 2 arguments", params);
        } else {
            StringBuilder sb = new StringBuilder("(");
            for (int i = 0; i < params.length; i++) {
                if (i > 0) {
                    sb.append('+');
                }
                sb.append("convert(varchar(8000),").append("(").append(params[i]).append(")").append(",120)");
            }
            sb.append(")");
            return sb.toString();
        }
    }
}
