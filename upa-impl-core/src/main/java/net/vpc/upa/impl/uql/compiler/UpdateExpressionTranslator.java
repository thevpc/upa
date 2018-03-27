/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.Entity;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Update;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledUpdate;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UpdateExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileUpdate((Update) o, manager,declarations);
    }

    protected CompiledUpdate compileUpdate(Update v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledUpdate s = new CompiledUpdate();
        s.entity(v.getEntity().getName());
        Entity entity = manager.getPersistenceUnit().getEntity(v.getEntity().getName());
        for (int i = 0; i < v.countFields(); i++) {
            Var fvar = v.getField(i);
            Expression fvalue = v.getFieldValue(i);
            s.set(entity.getField(fvar.getName()), manager.translateAny(fvalue, declarations));
        }
        s.where(manager.translateAny(v.getCondition(), declarations));
        return s;
    }
    
}
