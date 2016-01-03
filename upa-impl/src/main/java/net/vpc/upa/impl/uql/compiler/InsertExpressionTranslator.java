/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Insert;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledInsert;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class InsertExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public InsertExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileInsert((Insert) o, declarations);
    }

    protected CompiledInsert compileInsert(Insert v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledInsert s = new CompiledInsert();
        s.into(v.getEntity().getName());
        for (int i = 0; i < v.countFields(); i++) {
            Var fvar = v.getField(i);
            Expression fvalue = v.getFieldValue(i);
            DefaultCompiledExpression vv = outer.compileAny(fvalue, declarations);
            s.set(fvar.getName(), vv);
        }
        return s;
    }
    
}
