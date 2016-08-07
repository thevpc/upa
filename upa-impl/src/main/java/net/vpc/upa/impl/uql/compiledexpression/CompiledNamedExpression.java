package net.vpc.upa.impl.uql.compiledexpression;

/**
 * Created with IntelliJ IDEA.
 * User: vpc
 * Date: 8/16/12
 * Time: 5:55 AM
 * To change this template use File | Settings | File Templates.
 */
public class CompiledNamedExpression {
    private String name;
    private DefaultCompiledExpression expression;

    public CompiledNamedExpression(String name, DefaultCompiledExpression expression) {
        this.name = name;
        this.expression = expression;
    }

    public String getName() {
        return name;
    }

    public DefaultCompiledExpression getExpression() {
        return expression;
    }

    public void setExpression(DefaultCompiledExpression expression) {
        this.expression = expression;
    }
}
