package net.thevpc.upa.impl.upql.ext.toext;

import net.thevpc.upa.impl.upql.ExpressionTranslator;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.upql.ExpressionTranslationManager;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:13 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledExpressionToExpressionTranslator implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return (CompiledExpressionExt) o;
    }
}
