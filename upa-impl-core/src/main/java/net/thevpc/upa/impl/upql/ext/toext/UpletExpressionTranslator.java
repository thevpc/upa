/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Uplet;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUplet;

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
