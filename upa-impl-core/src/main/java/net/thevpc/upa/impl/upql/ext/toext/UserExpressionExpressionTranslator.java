/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import java.util.List;

import net.thevpc.upa.impl.upql.util.UPQLCompiledUtils;
import net.thevpc.upa.expressions.UserExpression;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledParam;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UserExpressionExpressionTranslator implements ExpressionTranslator {

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        UserExpression v = (UserExpression) o;
        if (v == null) {
            return null;
        }
        CompiledExpressionExt compiledExpression = manager.translateAny(manager.getExpressionManager().parseExpression(v), declarations);
        List<CompiledParam> cvalues = compiledExpression.findExpressionsList(UPQLCompiledUtils.PARAM_FILTER);
        for (CompiledParam e : cvalues) {
            if (v.containsParameter(e.getName())) {
                e.setValue(v.getParameter(e.getName()));
                e.setUnspecified(false);
            }
        }
        return compiledExpression;
    }
}
