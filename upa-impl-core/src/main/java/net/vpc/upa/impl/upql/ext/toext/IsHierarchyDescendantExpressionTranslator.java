/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.IsHierarchyDescendant;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.upql.ext.expr.CompiledEntityName;
import net.vpc.upa.impl.upql.ext.expr.IsHierarchyDescendantCompiled;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IsHierarchyDescendantExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        IsHierarchyDescendant v = (IsHierarchyDescendant) o;
        return new IsHierarchyDescendantCompiled(
                manager.translateAny(v.getAncestorExpression(), declarations),
                manager.translateAny(v.getChildExpression(), declarations),
                (CompiledEntityName) manager.translateAny(v.getEntityName(), declarations)
        );
    }

}
