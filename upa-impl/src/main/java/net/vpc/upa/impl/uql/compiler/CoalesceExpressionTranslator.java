/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Coalesce;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCoalesce;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CoalesceExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileCoalesce((Coalesce) o, manager,declarations);
    }

    protected CompiledCoalesce compileCoalesce(Coalesce v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCoalesce s = new CompiledCoalesce(manager.translateArray(v.getArguments(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
