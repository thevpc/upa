package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.*;
import net.vpc.upa.expressions.IdEnumerationExpression;

import java.util.List;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;

public class IdEnumerationExpressionTranslator implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object x, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        IdEnumerationExpression o = (IdEnumerationExpression) x;
        List<Object> keys = o.getIds();
        Var tableAlias = o.getAlias();
        return new CompiledIdEnumerationExpression(keys, (CompiledVar) manager.translateAny(tableAlias, declarations));
    }
}
