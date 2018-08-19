/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.Sum;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledSum;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SumExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileSum((Sum) o, manager,declarations);
    }

    protected CompiledSum compileSum(Sum v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledSum s = new CompiledSum(manager.translateAny(v.getArgument(0), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
