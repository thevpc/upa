/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Cast;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledCast;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CastExpressionTranslator implements ExpressionTranslator {


    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileCast((Cast) o, manager,declarations);
    }

    protected CompiledCast compileCast(Cast v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCast s = new CompiledCast(manager.translateAny(v.getValue(), declarations), IdentityDataTypeTransform.ofType(v.getDataType()));
        //        s.setDeclarationList(declarations);
        return s;
    }

}
