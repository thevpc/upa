/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.InCollection;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInCollection;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInSelection;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InCollectionExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public InCollectionExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileInCollection((InCollection) o, declarations);
    }

    protected CompiledInCollection compileInCollection(InCollection v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        return new CompiledInCollection(
                outer.compileAny(v.getLeft(), declarations), 
                outer.compileArray(v.getRight(), declarations)
        );
    }
    
}
