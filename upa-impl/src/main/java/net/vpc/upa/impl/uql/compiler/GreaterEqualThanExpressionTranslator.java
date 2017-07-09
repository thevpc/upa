/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.GreaterEqualThan;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledGreaterEqualThan;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class GreaterEqualThanExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileGreaterEqualThan((GreaterEqualThan) o, manager,declarations);
    }

    protected CompiledGreaterEqualThan compileGreaterEqualThan(GreaterEqualThan v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpressionExt left = manager.translateAny(v.getLeft(), declarations);
        CompiledExpressionExt right = manager.translateAny(v.getRight(), declarations);
        CompiledGreaterEqualThan s = new CompiledGreaterEqualThan(left, right);
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
