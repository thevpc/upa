/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.FunctionDefinition;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.upql.QLFunctionExpression;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ext.expr.CompiledQLFunctionExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class QLFunctionExpressionExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileQLFunctionExpression((QLFunctionExpression) o,manager, declarations);
    }

    protected CompiledQLFunctionExpression compileQLFunctionExpression(QLFunctionExpression v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        FunctionDefinition h = manager.getPersistenceUnit().getExpressionManager().getFunction(v.getName());
        CompiledQLFunctionExpression s = new CompiledQLFunctionExpression(v.getName(), manager.translateArray(v.getArguments(), declarations)
                , IdentityDataTypeTransform.ofType(h.getDataType()), h.getFunction());
        //        s.setDeclarationList(declarations);
        return s;
    }

}
