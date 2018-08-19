package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/16/12
 * Time: 5:55 AM
 * To change this template use File | Settings | File Templates.
 */
public class CompiledNamedExpression {
    private String name;
    private CompiledExpressionExt expression;


    public CompiledNamedExpression(String name, CompiledExpressionExt expression) {
        this.name = name;
        this.expression = expression;
    }

    public String getName() {
        return name;
    }

    public CompiledExpressionExt getExpression() {
        return expression;
    }

    public void setExpression(CompiledExpressionExt expression) {
        this.expression = expression;
    }
}
