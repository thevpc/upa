/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledreplacer;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ValueCompiledExpressionReplacer implements CompiledExpressionReplacer{
    private CompiledExpression value;

    public ValueCompiledExpressionReplacer(CompiledExpression value) {
        this.value = value;
    }

    public CompiledExpression update(CompiledExpression e) {
        return value;
    }
    
}
