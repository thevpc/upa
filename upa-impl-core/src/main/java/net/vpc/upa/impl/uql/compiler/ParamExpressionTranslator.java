/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Param;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ParamExpressionTranslator implements ExpressionTranslator {
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileVal((Param) o, manager,declarations);
    }

    protected CompiledParam compileVal(Param v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledParam s = new CompiledParam(v.isUnspecified() ? null : v.getValue(), v.getName(), null, v.isUnspecified());
        //        s.setDeclarationList(declarations);
        return s;
    }
    
}
