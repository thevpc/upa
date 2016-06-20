/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql;

import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author vpc
 */
public class CompiledExpressionFilterLeafVar implements CompiledExpressionFilter {
    public static final CompiledExpressionFilter INSTANCE=new CompiledExpressionFilterLeafVar(); 
    public boolean accept(DefaultCompiledExpression e) {
        if (!(e != null && CompiledVar.class.isInstance(e))) {
            return false;
        }
        CompiledVar v = (CompiledVar) e;
        return v.getChild() == null;

    }
}
