package net.vpc.upa.impl.uql.compiler;

import net.vpc.upa.impl.uql.ExpressionTranslator;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.ExpressionTranslationManager;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:13 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledExpressionToExpressionCompiler implements ExpressionTranslator {

    @Override
    public CompiledExpressionExt translateExpression(Object o, ExpressionTranslationManager manager, ExpressionDeclarationList declarations) {
        return (CompiledExpressionExt) o;
    }
}
