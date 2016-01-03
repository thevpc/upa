/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Uplet;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUplet;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UpletExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public UpletExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileUplet((Uplet) o, declarations);
    }

    protected CompiledUplet compileUplet(Uplet v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledUplet s = new CompiledUplet(outer.compileArray(v.getExpressions(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
