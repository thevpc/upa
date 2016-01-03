package net.vpc.upa.impl.uql.parser;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.SQLManager;
import net.vpc.upa.impl.persistence.SQLProvider;
import net.vpc.upa.impl.uql.ExpressionDeclarationList;
import net.vpc.upa.impl.uql.compiledexpression.DefaultCompiledExpression;
import net.vpc.upa.impl.uql.compiledexpression.CompiledFunction;
import net.vpc.upa.persistence.EntityExecutionContext;

import java.util.Arrays;
import java.util.Map;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 8/26/12 3:13 PM
 */
public abstract class FunctionSQLProvider implements SQLProvider {
    private Class expressionType;

    protected FunctionSQLProvider(Class expressionType) {
        this.expressionType = expressionType;
    }

    @Override
    public String getSQL(Object o, EntityExecutionContext qlContext, SQLManager sqlManager, ExpressionDeclarationList declarations) throws UPAException{
        CompiledFunction cc = (CompiledFunction) o;
        return simplify(qlContext, sqlManager,declarations,cc.getArguments());
    }

    public String simplify(EntityExecutionContext ctx, SQLManager sqlManager, ExpressionDeclarationList declarations,DefaultCompiledExpression... params) throws UPAException{
        String[] p = new String[params.length];
        for (int i = 0; i < p.length; i++) {
            p[i] = sqlManager.getSQL(params[i], ctx, declarations);

        }
        return simplify(getExpressionType().getSimpleName(), p, null);
    }

    @Override
    public Class getExpressionType() {
        return expressionType;
    }

    public void checkFunctionSignature(int requiredCount, String[] params) throws IllegalArgumentException {
        if (requiredCount != params.length) {
            error("requires " + requiredCount + " params", params);
        }
    }

    public void checkFunctionSignature(String[] paramNames, String[] params) throws IllegalArgumentException {
        checkFunctionSignature(paramNames.length, params);
    }

    public String error(String msg, String[] params) throws IllegalArgumentException {
        throw new IllegalArgumentException("Error in function '" + getExpressionType().getSimpleName() + "' params\n" + msg + "\n.Error near " + getExpressionType().getSimpleName() + "(" + Arrays.toString(params) + ")");
    }

    /**
     * @param functionName
     * @param params       may be null if function was called without parentheses
     * @param context
     * @return
     */
    public String simplify(String functionName, String[] params, Map<String, Object> context){
        throw new IllegalArgumentException("Never");
    }


    private static String format(Object[] value, String begin, String separator, String end, String nullValue) {
        if (value == null) {
            return nullValue;
        }
        StringBuilder s = new StringBuilder(begin);
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                s.append(separator);
            }
            s.append(String.valueOf(value[i]));
        }
        s.append(end);
        return s.toString();
    }

}
