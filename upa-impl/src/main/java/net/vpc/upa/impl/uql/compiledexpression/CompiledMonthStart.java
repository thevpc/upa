package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            Expression
/**
 * the date at the start of the next "count" month of the given "date"
 * <pre>
 * monthstart()
 *      params
 *          N/A
 *      Synopsis :
 *          the date at the end of the current month
 *          equivalent to : monthstart(CurrentTimestamp(),0) : the date at the end of the month
 *
 * monthstart(count)
 *      params
 *          count : integer expression
 *      Synopsis :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 *          equivalent to : monthend(CurrentTimestamp(),count)
 * monthstart(date,count)
 *      params
 *          date  : date expression
 *          count : integer expression
 *      Synopsis  :
 *          the date at the end of the next "count" month. when count=0, the end of the current month
 * </pre>
 */
public class CompiledMonthStart extends CompiledFunction {

    private static final long serialVersionUID = 1L;

    public CompiledMonthStart() {
        super("MonthStart");
    }

    public CompiledMonthStart(DefaultCompiledExpression date, DefaultCompiledExpression count) {
        this();
        protectedAddArgument(date);
        protectedAddArgument(count);
    }

    public CompiledMonthStart(DefaultCompiledExpression count) {
        this();
        protectedAddArgument(count);
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledMonthStart o = new CompiledMonthStart();
        for (DefaultCompiledExpression expression : getArguments()) {
            o.protectedAddArgument(expression.copy());
        }
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
