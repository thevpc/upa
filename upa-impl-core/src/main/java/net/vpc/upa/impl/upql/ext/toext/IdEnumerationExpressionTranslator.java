package net.vpc.upa.impl.upql.ext.toext;

import net.vpc.upa.impl.upql.ext.expr.CompiledIdEnumerationExpression;
import net.vpc.upa.impl.upql.ext.expr.CompiledVar;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.ExpressionTranslator;
import net.vpc.upa.impl.upql.ExpressionDeclarationList;
import net.vpc.upa.expressions.IdEnumerationExpression;

import java.util.List;
import net.vpc.upa.impl.upql.ExpressionTranslationManager;

public class IdEnumerationExpressionTranslator implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object x, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        IdEnumerationExpression o = (IdEnumerationExpression) x;
        List<Object> keys = o.getIds();
        Var tableAlias = o.getAlias();
        return new CompiledIdEnumerationExpression(keys, (CompiledVar) manager.translateAny(tableAlias, declarations));
    }
}
