/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import java.util.List;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.impl.uql.CompiledExpressionHelper;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UserExpressionExpressionTranslator implements ExpressionTranslator {

    private final ExpressionTranslationManager outer;

    public UserExpressionExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        UserExpression v = (UserExpression) o;
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression compiledExpression = outer.compileAny(outer.getExpressionManager().parseExpression(v.getExpression()), declarations);
        List<CompiledParam> cvalues = compiledExpression.findExpressionsList(CompiledExpressionHelper.PARAM_FILTER);
        for (CompiledParam e : cvalues) {
            if (v.containsParameter(e.getName())) {
                e.setObject(v.getParameter(e.getName()));
                e.setUnspecified(false);
            }
        }
        return compiledExpression;
    }
}
