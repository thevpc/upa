/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import java.util.List;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.util.UQLCompiledUtils;

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
        List<CompiledParam> cvalues = compiledExpression.findExpressionsList(UQLCompiledUtils.PARAM_FILTER);
        for (CompiledParam e : cvalues) {
            if (v.containsParameter(e.getName())) {
                e.setValue(v.getParameter(e.getName()));
                e.setUnspecified(false);
            }
        }
        return compiledExpression;
    }
}
