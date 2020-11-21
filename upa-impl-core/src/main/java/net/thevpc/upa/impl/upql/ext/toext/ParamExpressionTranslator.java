/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Param;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledParam;

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
