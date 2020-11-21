package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * the date at the end of the next "count" month of the given "date"
 * <pre>
 * monthend()
 *      params
 *          N/A
 *      Synopsis :
 *          the date at the end of the current month
 *          equivalent to : monthend(CurrentTimestamp(),0) : the date at the end of the month
 *
 * monthend(count)
 *      params
 *          count : integer expression
 *      Synopsis :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 *          equivalent to : monthend(CurrentTimestamp(),count)
 * monthend(date,count)
 *      params
 *          date  : date expression
 *          count : integer expression
 *      Synopsis  :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 * </pre>
 */
public class CompiledMonthEnd extends CompiledFunction {

    private static final long serialVersionUID = 1L;

    public CompiledMonthEnd() {
        super("MonthEnd");
    }

    public CompiledMonthEnd(CompiledExpressionExt date, CompiledExpressionExt count) {
        this();
        protectedAddArgument(date);
        protectedAddArgument(count);
    }

    public CompiledMonthEnd(CompiledExpressionExt count) {
        this();
        protectedAddArgument(count);
        bindChildren(count);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledMonthEnd o = new CompiledMonthEnd();
        for (CompiledExpressionExt expression : getArguments()) {
            o.protectedAddArgument(expression.copy());
        }
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
