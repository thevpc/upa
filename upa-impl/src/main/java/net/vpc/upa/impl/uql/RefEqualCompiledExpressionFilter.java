/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class RefEqualCompiledExpressionFilter implements CompiledExpressionFilter{
    private CompiledExpression value;

    public RefEqualCompiledExpressionFilter(CompiledExpression value) {
        this.value = value;
    }

    public boolean accept(DefaultCompiledExpression e) {
        return e==value;
    }
    
}
