/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.If;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ext.expr.CompiledIf;

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
