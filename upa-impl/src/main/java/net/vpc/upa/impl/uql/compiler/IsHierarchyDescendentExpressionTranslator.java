/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.IsHierarchyDescendent;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.IsHierarchyDescendentCompiled;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IsHierarchyDescendentExpressionTranslator implements ExpressionTranslator {

    private final ExpressionTranslationManager outer;

    public IsHierarchyDescendentExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        IsHierarchyDescendent v = (IsHierarchyDescendent) o;
        return new IsHierarchyDescendentCompiled(
                expressionTranslationManager.compileAny(v.getAncestorExpression(), declarations),
                expressionTranslationManager.compileAny(v.getChildExpression(), declarations),
                (CompiledEntityName)expressionTranslationManager.compileAny(v.getEntityName(), declarations)
        );
    }

}
