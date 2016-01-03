/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.uql.compiledreplacer;

import net.vpc.upa.EvalContext;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.compiledexpression.CompiledLiteral;
import net.vpc.upa.impl.uql.compiledexpression.CompiledParam;
import net.vpc.upa.impl.uql.compiledexpression.CompiledQLFunctionExpression;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class CompiledQLFunctionExpressionSimplifier implements CompiledExpressionReplacer {

    private PersistenceUnit persistenceUnit;

    public CompiledQLFunctionExpressionSimplifier(PersistenceUnit persistenceUnit) {
        this.persistenceUnit = persistenceUnit;
    }

    public CompiledExpression update(CompiledExpression e) {
        CompiledQLFunctionExpression o = (CompiledQLFunctionExpression) e;
        int argumentsCount = o.getArgumentsCount();
        Object[] args = new Object[argumentsCount];
        for (int i = 0; i < args.length; i++) {
            args[i] = eval(o.getArgument(i));
        }
        Object v = o.getHandler().eval(new EvalContext(o.getName(), args, persistenceUnit));
        if (v != null) {
            if (v instanceof CompiledExpression) {
                return (CompiledExpression) v;
            }
            if (v instanceof Expression) {
                throw new IllegalArgumentException("Function should return literals of compiled expressions (CompiledExpression type)");
            }
            return new CompiledParam(v, null, o.getTypeTransform(), false);
        } else {
            return new CompiledLiteral(null, null);
        }
    }

    protected Object eval(DefaultCompiledExpression o) {
        if (o == null) {
            return null;
        }
        if (o instanceof CompiledQLFunctionExpression) {
            CompiledQLFunctionExpression s = (CompiledQLFunctionExpression) o;
            int argumentsCount = s.getArgumentsCount();
            Object[] args = new Object[argumentsCount];
            for (int i = 0; i < args.length; i++) {
                args[i] = eval(s.getArgument(i));
            }
            return (s.getHandler().eval(new EvalContext(s.getName(), args, persistenceUnit)));
        }
        if (o instanceof CompiledLiteral) {
            return ((CompiledLiteral) o).getValue();
        }
        if (o instanceof CompiledParam) {
            return ((CompiledParam) o).getObject();
        }
        return o;
    }
}
