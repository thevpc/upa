/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.upql.ext.filters;

import net.thevpc.upa.expressions.CompiledExpression;
import net.thevpc.upa.impl.upql.CompiledExpressionFilter;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

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
