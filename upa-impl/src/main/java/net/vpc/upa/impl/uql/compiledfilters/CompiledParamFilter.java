package net.vpc.upa.impl.uql.compiledfilters;

import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/10/13 11:22 PM
*/
public class CompiledParamFilter implements CompiledExpressionFilter {
    private final String name;

    public CompiledParamFilter(String name) {
        this.name = name;
    }

    @Override
    public boolean accept(CompiledExpressionExt e) {
        return (e instanceof CompiledParam) && name.equals(((CompiledParam) e).getName());
    }
}
