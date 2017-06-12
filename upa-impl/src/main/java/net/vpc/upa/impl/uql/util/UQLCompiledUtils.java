package net.vpc.upa.impl.uql.util;

import net.vpc.upa.expressions.CompiledExpression;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.uql.CompiledExpressionReplacer;
import net.vpc.upa.impl.uql.CompiledExpressionThisReplacer;
import net.vpc.upa.impl.uql.CompiledExpressionThisReplacer2;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVar;
import net.vpc.upa.impl.uql.compiledexpression.CompiledVarOrMethod;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledfilters.CompiledExpressionHelper;

/**
 * Created by vpc on 6/9/17.
 */
public class UQLCompiledUtils {
    private UQLCompiledUtils() {
    }

    public static DefaultCompiledExpression cast(CompiledExpression expression) {
        return (DefaultCompiledExpression) expression;
    }

    public static DefaultCompiledExpression replaceThisVar(CompiledExpression expression, String newName) {
        return cast(expression).replaceExpressions(CompiledExpressionHelper.THIS_VAR_FILTER, new CompiledExpressionThisReplacer(newName));
    }

    public static DefaultCompiledExpression replaceThisVar(CompiledExpression expression, CompiledVarOrMethod newExpr) {
        return cast(expression).replaceExpressions(CompiledExpressionHelper.THIS_VAR_FILTER, new CompiledExpressionThisReplacer2(newExpr));
    }

    public static DefaultCompiledExpression removeThisVar(CompiledExpression expression) {
        return cast(expression).replaceExpressions(CompiledExpressionHelper.THIS_VAR_FILTER, new CompiledExpressionReplacer() {
            @Override
            public CompiledExpression update(CompiledExpression e) {
                CompiledVarOrMethod child = ((CompiledVar) e).getChild();
                if(child!=null) {
                    child.setParentExpression(null);
                }
                return child;
            }
        });
    }
}
