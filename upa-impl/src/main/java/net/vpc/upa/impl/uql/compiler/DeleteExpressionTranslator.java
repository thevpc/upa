/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Delete;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledDelete;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DeleteExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public DeleteExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileDelete((Delete) o, declarations);
    }

    protected CompiledDelete compileDelete(Delete v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDelete s = new CompiledDelete();
        s.from(v.getEntity().getName());
        s.where(outer.compileAny(v.getCondition(), declarations));
        return s;
    }
    
}
