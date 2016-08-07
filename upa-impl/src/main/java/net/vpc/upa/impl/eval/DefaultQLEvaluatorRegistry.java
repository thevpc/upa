package net.vpc.upa.impl.eval;

import net.vpc.upa.QLEvaluatorRegistry;
import net.vpc.upa.QLTypeEvaluator;
import net.vpc.upa.expressions.*;
import net.vpc.upa.impl.eval.functions.*;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by vpc on 7/3/16.
 */
public class DefaultQLEvaluatorRegistry implements QLEvaluatorRegistry{
    private Map<Class, QLTypeEvaluator> typeEvaluators = new HashMap<Class, QLTypeEvaluator>();
    private Map<String, QLTypeEvaluator> functionsEvaluators = new HashMap<String, QLTypeEvaluator>();
    private QLTypeEvaluator nullEvaluator = new NullQLTypeEvaluator();
    private QLTypeEvaluator notFoundEvaluator = new NotFoundEvaluatorQLTypeEvaluator();

    private QLTypeEvaluator functionDispatchEvaluator;

    public DefaultQLEvaluatorRegistry() {
        functionDispatchEvaluator = new FunctionDispatchEvaluatorQLTypeEvaluator(functionsEvaluators);
        registerTypeEvaluator(null, nullEvaluator);
        registerTypeEvaluator(FunctionExpression.class, functionDispatchEvaluator);
        registerTypeEvaluator(Literal.class, LiteralTypeEvaluator.INSTANCE);
        registerTypeEvaluator(UnaryOperatorExpression.class, UnaryOperatorExpressionEvaluator.INSTANCE);
        registerTypeEvaluator(If.class, IfExpressionEvaluator.INSTANCE);
        registerTypeEvaluator(BinaryOperatorExpression.class, BinaryOperatorExpressionEvaluator.INSTANCE);
        registerFunctionEvaluator("file_exists", FileExistsEvaluator.INSTANCE);
        registerFunctionEvaluator("coalesce", CoalesceEvaluator.INSTANCE);
        registerFunctionEvaluator("concat", ConcatEvaluator.INSTANCE);
        registerFunctionEvaluator("currentDate", CurrentDateEvaluator.INSTANCE);
        registerFunctionEvaluator("currentTime", CurrentTimeEvaluator.INSTANCE);
        registerFunctionEvaluator("currentTimestamp", CurrentTimestampEvaluator.INSTANCE);
        registerFunctionEvaluator("currentUser", CurrentUserEvaluator.INSTANCE);
        registerFunctionEvaluator("d2v", D2VEvaluator.INSTANCE);
        registerFunctionEvaluator("dateAdd", DateAddEvaluator.INSTANCE);
        registerFunctionEvaluator("datePart", DatePartEvaluator.INSTANCE);
        registerFunctionEvaluator("decode", DecodeEvaluator.INSTANCE);
//        registerFunctionEvaluator("if", new IfEvaluator()); //already added as special evaluator
        registerFunctionEvaluator("i2v", D2VEvaluator.INSTANCE);
        registerFunctionEvaluator("sign", SignEvaluator.INSTANCE);
        registerFunctionEvaluator("strlen", StrLenEvaluator.INSTANCE);
    }

    @Override
    public void unregisterTypeEvaluator(Class type) {
        typeEvaluators.remove(type);
    }

    @Override
    public void unregisterFunctionEvaluator(String name) {
        functionsEvaluators.remove(name.toLowerCase());
    }

    public void registerFunctionEvaluator(String name, QLTypeEvaluator t) {
        functionsEvaluators.put(name, t);
    }
    public void registerFunctionEvaluator(String name, net.vpc.upa.Function t) {
        functionsEvaluators.put(name.toLowerCase(), new DefaultFunctionEvaluator(t));
    }

    public void registerTypeEvaluator(Class type, QLTypeEvaluator t) {
        typeEvaluators.put(type, t);
    }

    public QLTypeEvaluator getTypeEvaluator(Class type) {
        QLTypeEvaluator y = typeEvaluators.get(type);
        if (y != null) {
            return y;
        }
        if (type == null) {
            return nullEvaluator;
        }
        for (Map.Entry<Class, QLTypeEvaluator> en : typeEvaluators.entrySet()) {
            if (en.getKey() != null && en.getKey().isAssignableFrom(type)) {
                return en.getValue();
            }
        }
        return notFoundEvaluator;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof DefaultQLEvaluatorRegistry)) return false;

        DefaultQLEvaluatorRegistry that = (DefaultQLEvaluatorRegistry) o;

        if (typeEvaluators != null ? !typeEvaluators.equals(that.typeEvaluators) : that.typeEvaluators != null) return false;
        if (functionsEvaluators != null ? !functionsEvaluators.equals(that.functionsEvaluators) : that.functionsEvaluators != null)
            return false;
        if (nullEvaluator != null ? !nullEvaluator.equals(that.nullEvaluator) : that.nullEvaluator != null)
            return false;
        if (notFoundEvaluator != null ? !notFoundEvaluator.equals(that.notFoundEvaluator) : that.notFoundEvaluator != null)
            return false;
        return !(functionDispatchEvaluator != null ? !functionDispatchEvaluator.equals(that.functionDispatchEvaluator) : that.functionDispatchEvaluator != null);

    }

    @Override
    public int hashCode() {
        int result = typeEvaluators != null ? typeEvaluators.hashCode() : 0;
        result = 31 * result + (functionsEvaluators != null ? functionsEvaluators.hashCode() : 0);
        result = 31 * result + (nullEvaluator != null ? nullEvaluator.hashCode() : 0);
        result = 31 * result + (notFoundEvaluator != null ? notFoundEvaluator.hashCode() : 0);
        result = 31 * result + (functionDispatchEvaluator != null ? functionDispatchEvaluator.hashCode() : 0);
        return result;
    }
}
