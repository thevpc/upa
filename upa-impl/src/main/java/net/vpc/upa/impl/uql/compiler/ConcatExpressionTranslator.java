/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Concat;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledConcat;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ConcatExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public ConcatExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileConcat((Concat) o, declarations);
    }

    protected CompiledConcat compileConcat(Concat v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledConcat s = new CompiledConcat(outer.compileArray(v.getArguments(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
