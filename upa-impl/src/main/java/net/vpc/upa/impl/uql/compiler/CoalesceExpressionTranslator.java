/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Coalesce;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCoalesce;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CoalesceExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public CoalesceExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileCoalesce((Coalesce) o, declarations);
    }

    protected CompiledCoalesce compileCoalesce(Coalesce v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCoalesce s = new CompiledCoalesce(outer.compileArray(v.getArguments(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
