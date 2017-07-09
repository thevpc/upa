/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Uplet;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUplet;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UpletExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileUplet((Uplet) o, manager,declarations);
    }

    protected CompiledUplet compileUplet(Uplet v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledUplet s = new CompiledUplet(manager.translateArray(v.getExpressions(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
