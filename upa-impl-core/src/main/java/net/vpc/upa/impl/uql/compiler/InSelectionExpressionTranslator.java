/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.InSelection;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInSelection;
import net.vpc.upa.impl.uql.compiledexpression.CompiledSelect;

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
