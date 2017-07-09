/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.D2V;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledD2V;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class D2VExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileD2V((D2V) o, manager,declarations);
    }

    protected CompiledD2V compileD2V(D2V v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledD2V s = new CompiledD2V(manager.translateAny(v.getExpression(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
