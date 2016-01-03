/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledexpression;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.impl.uql.CompiledExpressionFilter;
import net.vpc.upa.impl.uql.CompiledExpressionVisitor;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CompiledExpressionVisitorCollector implements CompiledExpressionVisitor {

    private CompiledExpressionFilter filter;
    private List<DefaultCompiledExpression> expressions = new ArrayList<DefaultCompiledExpression>();

    public CompiledExpressionVisitorCollector(CompiledExpressionFilter filter) {
        this.filter = filter;
    }

    public boolean visit(DefaultCompiledExpression e) {
        if (filter == null || filter.accept(e)) {
            expressions.add(e);
        }
        return true;
    }

    public List<DefaultCompiledExpression> getExpressions() {
        return expressions;
    }
}
