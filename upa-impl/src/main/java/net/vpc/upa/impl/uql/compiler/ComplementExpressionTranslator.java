/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Complement;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledComplement;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ComplementExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public ComplementExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileComplement((Complement) o, declarations);
    }

    protected CompiledComplement compileComplement(Complement v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledComplement s = new CompiledComplement(outer.compileAny(v.getExpression(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
