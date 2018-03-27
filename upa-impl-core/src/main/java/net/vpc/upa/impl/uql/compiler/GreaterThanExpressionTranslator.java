/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.GreaterThan;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledGreaterThan;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class GreaterThanExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileGreaterThan((GreaterThan) o, manager,declarations);
    }
    
    protected CompiledGreaterThan compileGreaterThan(GreaterThan v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpressionExt left = manager.translateAny(v.getLeft(), declarations);
        CompiledExpressionExt right = manager.translateAny(v.getRight(), declarations);
        CompiledGreaterThan s = new CompiledGreaterThan(left, right);
//        s.setDeclarationList(declarations);
        return s;
    }
}
