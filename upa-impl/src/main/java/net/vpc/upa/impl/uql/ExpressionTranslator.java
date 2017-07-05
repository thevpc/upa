package net.vpc.upa.impl.uql;

import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/15/12
 * Time: 11:08 PM
 * To change this template use File | Settings | File Templates.
 */
public interface ExpressionTranslator {
    DefaultCompiledExpression translateExpression(Object o, ExpressionTranslationManager expressionTranslationManager, ExpressionDeclarationList declarations);
}
