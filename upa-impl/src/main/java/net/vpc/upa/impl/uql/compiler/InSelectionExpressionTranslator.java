/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.InSelection;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInSelection;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InSelectionExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public InSelectionExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileInSelection((InSelection) o, declarations);
    }

    protected CompiledInSelection compileInSelection(InSelection v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        return new CompiledInSelection(outer.compileArray(v.getLeft(), declarations), (CompiledSelect)outer.compileAny(v.getSelection(), declarations));
    }
    
}
