/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.BitAnd;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledBitAnd;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class BitAndExpressionTranslator implements ExpressionTranslator {
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileBitAnd((BitAnd) o, manager,declarations);
    }

    protected CompiledBitAnd compileBitAnd(BitAnd v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = manager.translateAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = manager.translateAny(v.getRight(), declarations);
        CompiledBitAnd s = new CompiledBitAnd(left, right);
        //        s.setDeclarationList(new ExpressionDeclarationList(declarations));
        return s;
    }
    
}
