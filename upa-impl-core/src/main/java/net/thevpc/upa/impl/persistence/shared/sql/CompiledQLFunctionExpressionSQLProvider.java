package net.thevpc.upa.impl.persistence.shared.sql;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.persistence.SQLManager;
import net.thevpc.upa.impl.persistence.SQLProvider;
import net.thevpc.upa.impl.upql.ExpressionDeclarationList;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.impl.upql.ext.expr.CompiledLiteral;
import net.thevpc.upa.impl.upql.ext.expr.CompiledParam;
import net.thevpc.upa.impl.upql.ext.expr.CompiledQLFunctionExpression;
import net.thevpc.upa.persistence.EntityExecutionContext;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/14/12 12:28 AM
 */
public class CompiledQLFunctionExpressionSQLProvider implements SQLProvider {

    @Override
    public String getSQL(Object oo, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException {
        CompiledQLFunctionExpression o = (CompiledQLFunctionExpression) oo;
        int argumentsCount = o.getArgumentsCount();
        Object[] args = new Object[argumentsCount];
        for (int i = 0; i < args.length; i++) {
            args[i] = eval(o.getArgument(i), qlContext);
        }
        //no compiler context
        return sqlManager.getMarshallManager().formatSqlValue(o.getHandler().eval(new FunctionEvalContext(o.getName(), args, qlContext.getPersistenceUnit(),null)));
    }

    protected Object eval(CompiledExpressionExt o, EntityExecutionContext qlContext) {
        if (o == null) {
            return null;
        }
        if (o instanceof CompiledQLFunctionExpression) {
            CompiledQLFunctionExpression s = (CompiledQLFunctionExpression) o;
            int argumentsCount = s.getArgumentsCount();
            Object[] args = new Object[argumentsCount];
            for (int i = 0; i < args.length; i++) {
                args[i] = eval(s.getArgument(i), qlContext);
            }
            //no compiler context
            return (s.getHandler().eval(new FunctionEvalContext(s.getName(), args, qlContext.getPersistenceUnit(),null)));
        }
        if (o instanceof CompiledLiteral) {
            return ((CompiledLiteral) o).getValue();
        }
        if (o instanceof CompiledParam) {
            return ((CompiledParam) o).getValue();
        }
        throw new IllegalUPAArgumentException("Unable to evaluate type " + o.getClass() + " :: " + o);
    }

    @Override
    public Class<CompiledQLFunctionExpression> getExpressionType() {
        return CompiledQLFunctionExpression.class;
    }
}
