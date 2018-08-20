package net.vpc.upa.impl.upql.filters;

import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.ExpressionFilter;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 2/3/13 9:16 PM
 */
public class TypeExpressionFilter implements ExpressionFilter {
    private final Class platformType;

    public TypeExpressionFilter(Class type) {
        this.platformType = type;
    }

    @Override
    public boolean accept(Expression e) {
        return e !=null && platformType.isInstance(e);
    }
}
