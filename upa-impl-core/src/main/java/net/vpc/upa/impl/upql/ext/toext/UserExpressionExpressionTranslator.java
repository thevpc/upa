/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import java.util.List;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledParam;
import net.vpc.upa.impl.upql.util.UPQLCompiledUtils;

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
