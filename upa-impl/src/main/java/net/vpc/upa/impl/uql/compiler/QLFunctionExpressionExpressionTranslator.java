/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.FunctionDefinition;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.QLFunctionExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQLFunctionExpression;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class QLFunctionExpressionExpressionTranslator implements ExpressionTranslator {
    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileQLFunctionExpression((QLFunctionExpression) o,manager, declarations);
    }

    protected CompiledQLFunctionExpression compileQLFunctionExpression(QLFunctionExpression v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        FunctionDefinition h = manager.getPersistenceUnit().getExpressionManager().getFunction(v.getName());
        CompiledQLFunctionExpression s = new CompiledQLFunctionExpression(v.getName(), manager.translateArray(v.getArguments(), declarations)
                , new IdentityDataTypeTransform(h.getDataType()), h.getFunction());
        //        s.setDeclarationList(declarations);
        return s;
    }

}
