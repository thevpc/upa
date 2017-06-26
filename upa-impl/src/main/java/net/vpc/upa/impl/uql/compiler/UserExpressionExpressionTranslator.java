/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import java.util.List;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionUtils;
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

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        UserExpression v = (UserExpression) o;
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression compiledExpression = manager.translateAny(manager.getExpressionManager().parseExpression(v), declarations);
        List<CompiledParam> cvalues = compiledExpression.findExpressionsList(CompiledExpressionUtils.PARAM_FILTER);
        for (CompiledParam e : cvalues) {
            if (v.containsParameter(e.getName())) {
                e.setValue(v.getParameter(e.getName()));
                e.setUnspecified(false);
            }
        }
        return compiledExpression;
    }
}
