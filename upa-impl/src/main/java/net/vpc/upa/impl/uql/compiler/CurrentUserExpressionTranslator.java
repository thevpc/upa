/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.CurrentUser;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCurrentUser;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CurrentUserExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public CurrentUserExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileCurrentUser((CurrentUser) o, declarations);
    }

    protected CompiledCurrentUser compileCurrentUser(CurrentUser v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCurrentUser s = new CompiledCurrentUser();
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
