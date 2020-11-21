package net.thevpc.upa.impl.upql.filters;

import net.thevpc.upa.expressions.Expression;
import net.thevpc.upa.expressions.ExpressionFilter;
import net.thevpc.upa.expressions.Param;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/10/13 11:22 PM
*/
public class ParamFilter implements ExpressionFilter {
    private final String name;

    public ParamFilter(String name) {
        this.name = name;
    }

    @Override
    public boolean accept(Expression e) {
        return (e instanceof Param) && name.equals(((Param) e).getName());
    }
}
