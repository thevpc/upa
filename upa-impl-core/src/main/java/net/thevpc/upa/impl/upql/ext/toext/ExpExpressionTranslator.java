/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Exp;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ext.expr.CompiledExp;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ExpExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileExp((Exp) o, manager,declarations);
    }

    protected CompiledExp compileExp(Exp v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
         return new CompiledExp(manager.translateAny(v.getArgument(), declarations));
    }
    
}
