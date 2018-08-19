/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.Exp;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.upql.ext.expr.CompiledDateTrunc;
import net.vpc.upa.impl.upql.ext.expr.CompiledExp;

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
