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
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        IsHierarchyDescendent v = (IsHierarchyDescendent) o;
        return new IsHierarchyDescendentCompiled(
                manager.translateAny(v.getAncestorExpression(), declarations),
                manager.translateAny(v.getChildExpression(), declarations),
                (CompiledEntityName) manager.translateAny(v.getEntityName(), declarations)
        );
    }

}
