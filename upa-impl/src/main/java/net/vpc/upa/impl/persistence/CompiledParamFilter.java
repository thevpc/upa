package net.vpc.upa.impl.persistence;

import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/10/13 11:22 PM
*/
class CompiledParamFilter implements CompiledExpressionFilter {
    private final String name;

    public CompiledParamFilter(String name) {
        this.name = name;
    }

    @Override
    public boolean accept(DefaultCompiledExpression e) {
        return (e instanceof CompiledParam) && name.equals(((CompiledParam) e).getName());
    }
}
