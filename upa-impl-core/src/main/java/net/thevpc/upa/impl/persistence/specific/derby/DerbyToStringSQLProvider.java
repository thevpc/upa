package net.thevpc.upa.impl.persistence.specific.derby;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.upql.ext.expr.CompiledToString;
import net.thevpc.upa.impl.util.StringUtils;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA. User: vpc Date: 22 mai 2003 Time: 17:26:10
 *
 */
@PortabilityHint(target = "C#", name = "suppress")
class DerbyToStringSQLProvider extends DerbyFunctionSQLProvider {

    DerbyToStringSQLProvider() {
        super(CompiledToString.class);
    }

    public String simplify(EntityExecutionContext ctx, SQLManager sqlManager, ExpressionDeclarationList declarations, CompiledExpressionExt... params) throws UPAException {
        if (params.length != 1) {
            throw new IllegalUPAArgumentException("bad number of params for function '" + getExpressionType().getSimpleName() + "' .\n Error near " + getExpressionType().getSimpleName() + "(" + StringUtils.format(params) + ")");
        }
        DataTypeTransform t = params[0].getTypeTransform();
        int len = 255;
        if (PlatformUtils.isIntAny(t.getTargetType().getPlatformType())) {
            len = 30;
        } else if (PlatformUtils.isFloatAny(t.getTargetType().getPlatformType())) {
            len = 30;
        }
        String s = sqlManager.getSQL(params[0], ctx, declarations);
        return "TRIM(CAST(CAST(" + s + " AS CHAR(" + len + ")) AS VARCHAR(" + len + ")))";
    }
}
