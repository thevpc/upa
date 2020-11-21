/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.InsertSelection;
import net.thevpc.upa.expressions.Var;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledInsertSelection;
import net.thevpc.upa.impl.upql.ext.expr.CompiledQueryStatement;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InsertSelectionExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileInsertSelection((InsertSelection) o, manager,declarations);
    }

    protected CompiledInsertSelection compileInsertSelection(InsertSelection v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledInsertSelection s = new CompiledInsertSelection();
        s.into(v.getEntity().getName());
        for (int i = 0; i < v.countFields(); i++) {
            Var fvar = v.getField(i);
            s.field(fvar.getName());
        }
        s.from((CompiledQueryStatement) manager.translateAny(v.getSelection(), declarations));
        return s;
    }
    
}
