/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.expressions.Union;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledSelect;
import net.thevpc.upa.impl.upql.ext.expr.CompiledUnion;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class UnionExpressionTranslator implements ExpressionTranslator {

    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return compileUnion((Union) o, manager, declarations);
    }

    protected CompiledUnion compileUnion(Union v, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        if (v == null) {
            return null;
        }
        CompiledSelect[] selects = new CompiledSelect[v.getQueryStatements().size()];
        for (int i = 0; i < selects.length; i++) {
            selects[i] = (CompiledSelect) manager.translateAny(v.getQueryStatements().get(i), declarations);
        }
        return new CompiledUnion(selects);
    }

}
