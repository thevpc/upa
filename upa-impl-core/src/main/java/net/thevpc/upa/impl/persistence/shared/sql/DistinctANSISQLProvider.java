package net.thevpc.upa.impl.persistence.shared.sql;


import java.util.Map;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDistinct;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 mai 2003 Time: 17:17:34
 *
 */
public class DistinctANSISQLProvider extends ANSIFunctionSQLProvider {

    public DistinctANSISQLProvider() {
        super(CompiledDistinct.class);
    }

    @Override
    public String simplify(String functionName, String[] params, Map<String, Object> context) {
//        if (params.length != 1) {
            StringBuilder sb = new StringBuilder("Distinct");
            for (int i = 0; i < params.length; i++) {
                if (i > 0) {
                    sb.append(" ,");
                }else{
                    sb.append(" ");
                }
                sb.append(params[i]);
            }
            return sb.toString();
//        } else {
//            StringBuilder sb = new StringBuilder("Distinct(");
//            sb.append(params[0]);
//            sb.append(")");
//            return sb.toString();
//        }
    }
}
