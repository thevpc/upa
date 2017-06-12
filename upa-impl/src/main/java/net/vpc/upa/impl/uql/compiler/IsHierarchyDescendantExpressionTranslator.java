/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.IsHierarchyDescendant;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledEntityName;
import net.vpc.upa.impl.uql.compiledexpression.IsHierarchyDescendantCompiled;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IsHierarchyDescendantExpressionTranslator implements ExpressionTranslator {
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        IsHierarchyDescendant v = (IsHierarchyDescendant) o;
        return new IsHierarchyDescendantCompiled(
                manager.translateAny(v.getAncestorExpression(), declarations),
                manager.translateAny(v.getChildExpression(), declarations),
                (CompiledEntityName) manager.translateAny(v.getEntityName(), declarations)
        );
    }

}
