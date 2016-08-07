/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.LessEqualThan;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLessEqualThan;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class LessEqualThanExpressionTranslator implements ExpressionTranslator {

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileLessEqualThan((LessEqualThan) o, manager,declarations);
    }

    protected CompiledLessEqualThan compileLessEqualThan(LessEqualThan v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        DefaultCompiledExpression left = manager.translateAny(v.getLeft(), declarations);
        DefaultCompiledExpression right = manager.translateAny(v.getRight(), declarations);
        CompiledLessEqualThan s = new CompiledLessEqualThan(left, right);
//        s.setDeclarationList(declarations);
        return s;
    }
}
