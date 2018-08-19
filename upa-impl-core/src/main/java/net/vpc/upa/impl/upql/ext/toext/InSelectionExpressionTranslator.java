/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.InSelection;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledInSelection;
import net.vpc.upa.impl.upql.ext.expr.CompiledSelect;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InSelectionExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileInSelection((InSelection) o, manager,declarations);
    }

    protected CompiledInSelection compileInSelection(InSelection v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        return new CompiledInSelection(manager.translateArray(v.getLeft(), declarations)
                , (CompiledSelect)manager.translateAny(v.getSelection(), declarations));
    }
    
}
