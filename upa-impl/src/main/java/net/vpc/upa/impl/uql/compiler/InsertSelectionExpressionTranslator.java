/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.InsertSelection;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInsertSelection;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQueryStatement;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InsertSelectionExpressionTranslator implements ExpressionTranslator {
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
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
