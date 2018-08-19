/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.filters;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.upql.CompiledExpressionFilter;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class RefEqualCompiledExpressionFilter implements CompiledExpressionFilter {
    private CompiledExpression value;

    public RefEqualCompiledExpressionFilter(CompiledExpression value) {
        this.value = value;
    }

    public boolean accept(CompiledExpressionExt e) {
        return e==value;
    }
    
}
