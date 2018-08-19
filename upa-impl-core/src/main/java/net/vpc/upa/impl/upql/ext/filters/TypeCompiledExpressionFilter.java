package net.vpc.upa.impl.upql.ext.filters;

import net.vpc.upa.impl.upql.CompiledExpressionFilter;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 2/3/13 9:16 PM
 */
public class TypeCompiledExpressionFilter implements CompiledExpressionFilter {
    private Class type;

    public TypeCompiledExpressionFilter(Class type) {
        this.type = type;
    }

    @Override
    public boolean accept(CompiledExpressionExt e) {
        return e !=null && type.isInstance(e);
    }
}
