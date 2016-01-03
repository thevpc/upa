/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Literal;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class LiteralExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public LiteralExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileLiteral((Literal) o, declarations);
    }

    protected CompiledLiteral compileLiteral(Literal v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledLiteral s = new CompiledLiteral(v.getValue(), null);
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
