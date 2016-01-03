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
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CastExpressionTranslator implements ExpressionTranslator {

    private final ExpressionTranslationManager outer;

    public CastExpressionTranslator(final ExpressionTranslationManager outer) {
        this.outer = outer;
    }

    public DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations) {
        return compileCast((Cast) o, declarations);
    }

    protected CompiledCast compileCast(Cast v, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledCast s = new CompiledCast(outer.compileAny(v.getValue(), declarations), new IdentityDataTypeTransform(v.getDataType()));
        //        s.setDeclarationList(declarations);
        return s;
    }

}
