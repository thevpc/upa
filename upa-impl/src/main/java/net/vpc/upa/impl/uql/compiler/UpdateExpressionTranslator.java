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
import net.vpc.upa.impl.uql.compiledexpression.CompiledUpdate;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UpdateExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public UpdateExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileUpdate((Update) o, declarations);
    }

    protected CompiledUpdate compileUpdate(Update v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledUpdate s = new CompiledUpdate();
        s.entity(v.getEntity().getName());
        Entity entity = outer.getPersistenceUnit().getEntity(v.getEntity().getName());
        for (int i = 0; i < v.countFields(); i++) {
            Var fvar = v.getField(i);
            Expression fvalue = v.getFieldValue(i);
            s.set(entity.getField(fvar.getName()), outer.compileAny(fvalue, declarations));
        }
        s.where(outer.compileAny(v.getCondition(), declarations));
        return s;
    }
    
}
