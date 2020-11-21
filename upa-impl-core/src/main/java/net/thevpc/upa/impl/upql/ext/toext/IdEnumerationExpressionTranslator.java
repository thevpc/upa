package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.impl.upql.ext.expr.CompiledIdEnumerationExpression;
import net.thevpc.upa.impl.upql.ext.expr.CompiledVar;
import net.thevpc.upa.expressions.Var;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.expressions.IdEnumerationExpression;

import java.util.List;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;

public class IdEnumerationExpressionTranslator implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object x, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        IdEnumerationExpression o = (IdEnumerationExpression) x;
        List<Object> keys = o.getIds();
        Var tableAlias = o.getAlias();
        return new CompiledIdEnumerationExpression(keys, (CompiledVar) manager.translateAny(tableAlias, declarations));
    }
}
