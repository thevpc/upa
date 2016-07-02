/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledfilters;

import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author vpc
 */
public class CompiledExpressionFilterThisVar implements CompiledExpressionFilter {

    public CompiledExpressionFilterThisVar() {
    }

    public boolean accept(DefaultCompiledExpression e) {
        if (e instanceof CompiledVar) {
            CompiledVar c = (CompiledVar) e;
            if (c.getName().equals("this")) {
                return true;
            }
        }
        return false;
    }
    
}
