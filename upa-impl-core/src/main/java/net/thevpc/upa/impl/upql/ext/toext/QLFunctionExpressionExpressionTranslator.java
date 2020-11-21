/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.FunctionDefinition;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.QLFunctionExpression;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledQLFunctionExpression;

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
