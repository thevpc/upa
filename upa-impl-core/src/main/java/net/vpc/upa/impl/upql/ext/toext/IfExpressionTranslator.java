/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.expressions.And;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.If;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.upql.ext.expr.CompiledAnd;
import net.vpc.upa.impl.upql.ext.expr.CompiledIf;

import java.util.Arrays;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IfExpressionTranslator implements ExpressionTranslator {

    public IfExpressionTranslator() {
    }

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileAnd((If) o, manager,declarations);
    }

    public CompiledIf compileAnd(If v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledExpressionExt[] argumentsExt = manager.translateArray(v.getArguments(), declarations);
        return new CompiledIf(Arrays.asList(argumentsExt));
    }
}
