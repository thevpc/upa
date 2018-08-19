/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.upql.ext.expr;

import java.util.ArrayList;
import java.util.List;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.upql.CompiledExpressionFilter;
import net.vpc.upa.impl.upql.CompiledExpressionVisitor;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CompiledExpressionVisitorCollector implements CompiledExpressionVisitor {

    private CompiledExpressionFilter filter;
    private List<CompiledExpressionExt> expressions = new ArrayList<CompiledExpressionExt>();

    public CompiledExpressionVisitorCollector(CompiledExpressionFilter filter) {
        this.filter = filter;
    }

    public boolean visit(CompiledExpressionExt e) {
        if (filter == null || filter.accept(e)) {
            expressions.add(e);
        }
        return true;
    }

    public List<CompiledExpressionExt> getExpressions() {
        return expressions;
    }
}
