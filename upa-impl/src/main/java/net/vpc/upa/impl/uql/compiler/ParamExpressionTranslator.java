/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Param;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ParamExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public ParamExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileVal((Param) o, declarations);
    }

    protected CompiledParam compileVal(Param v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledParam s = new CompiledParam(v.isUnspecified() ? null : v.getObject(), v.getName(), null, v.isUnspecified());
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
