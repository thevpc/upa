/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.XOr;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledXOr;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class XOrExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public XOrExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileXOr((XOr) o, declarations);
    }

    protected CompiledXOr compileXOr(XOr v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledXOr s = new CompiledXOr(outer.compileAny(v.getLeft(), declarations), outer.compileAny(v.getRight(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
