/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.And;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.If;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.compiledexpression.CompiledAnd;
import net.vpc.upa.impl.uql.compiledexpression.CompiledIf;

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
