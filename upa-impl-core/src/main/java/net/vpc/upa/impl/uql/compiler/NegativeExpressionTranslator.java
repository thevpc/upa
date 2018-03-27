/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Negative;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledNegative;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class NegativeExpressionTranslator implements ExpressionTranslator {

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        Negative v = (Negative) o;
        if (v == null) {
            return null;
        }
        return new CompiledNegative(manager.translateAny(v.getExpression(), declarations));
    }
}
