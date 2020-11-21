/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Distinct;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledDistinct;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DistinctExpressionTranslator implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compile((Distinct) o, manager, declarations);
    }

    protected CompiledDistinct compile(Distinct v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledDistinct s = new CompiledDistinct(manager.translateArray(v.getArguments(), declarations));
        //        s.setDeclarationList(declarations);
        return s;
    }

}
