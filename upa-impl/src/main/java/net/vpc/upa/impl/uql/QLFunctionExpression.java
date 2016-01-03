package net.vpc.upa.impl.uql;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Function;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/14/12 12:00 AM
 */
public class QLFunctionExpression extends Function {

    private String name;
    private Expression[] arguments;

    public QLFunctionExpression(String name, Expression[] arguments) {
        this.name = name;
        this.arguments = arguments;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public int getArgumentsCount() {
        return arguments.length;
    }

    @Override
    public Expression getArgument(int index) {
        return arguments[index];
    }

    @Override
    public Expression copy() {
        return new QLFunctionExpression(name, arguments);
    }

}
