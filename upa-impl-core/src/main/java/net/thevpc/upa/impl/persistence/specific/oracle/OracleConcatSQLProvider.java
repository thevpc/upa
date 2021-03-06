package net.thevpc.upa.impl.persistence.specific.oracle;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ext.expr.CompiledConcat;
import net.thevpc.upa.impl.upql.ext.expr.CompiledToString;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.DataTypeTransform;

import java.util.Map;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 17:17:34
 * 
 */
@PortabilityHint(target = "C#", name = "suppress")
class OracleConcatSQLProvider extends OracleFunctionSQLProvider {
    public OracleConcatSQLProvider() {
        super(CompiledConcat.class);
    }

    @Override
    public String simplify(EntityExecutionContext ctx, SQLManager sqlManager, ExpressionDeclarationList declarations, CompiledExpressionExt... params) throws UPAException {
        String[] p = new String[params.length];
        for (int i = 0; i < p.length; i++) {
            DataTypeTransform t = params[i].getTypeTransform();
            if (PlatformUtils.isString(t.getTargetType().getPlatformType())) {
                p[i] = sqlManager.getSQL(params[i], ctx, declarations);
            } else {
                p[i] = sqlManager.getSQL(new CompiledToString(params[i].copy()), ctx, declarations);
            }
        }
        return simplify(getExpressionType().getSimpleName(), p, null);
    }

    public String simplify(String functionName, String[] params, Map<String, Object> context) {
        if (params.length < 2) {
            return error("requieres at least 2 arguments", params);
        } else {
            StringBuilder sb = new StringBuilder("(");
            for (int i = 0; i < params.length; i++) {
                if (i > 0) {
                    sb.append(" || ");
                }
                sb.append(params[i]);
            }
            sb.append(")");
            return sb.toString();
        }
    }
}
