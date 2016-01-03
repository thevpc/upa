/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.EntityName;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityNameExpressionTranslator implements ExpressionTranslator {
    private final ExpressionTranslationManager outer;

    public EntityNameExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileEntityName((EntityName) o, declarations);
    }

    protected CompiledEntityName compileEntityName(EntityName v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledEntityName s = new CompiledEntityName(v.getName());
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
