package net.thevpc.upa.impl.upql.ext.filters;

import net.thevpc.upa.impl.upql.CompiledExpressionFilter;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledParam;

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
