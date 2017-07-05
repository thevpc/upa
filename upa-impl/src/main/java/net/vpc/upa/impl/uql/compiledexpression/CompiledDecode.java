package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.DataTypeTransform;


/**
 * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 10:07:06 To
 * change this template use Options | File Templates.
 */
public class CompiledDecode extends CompiledFunction implements Cloneable {

    private static final long serialVersionUID = 1L;
    private final int EXPECT_CONDITION = 0;
    private final int VALID = 2;
    private int state = 0;

    private CompiledDecode() {
        super("Decode");
    }

//    public CompiledDecode(List<DefaultCompiledExpression> expressions) {
//        params=new ArrayList<DefaultCompiledExpression>(expressions);
//        state=VALID;
//        bindChildren(params);
//    }
    public CompiledDecode(DefaultCompiledExpression expression) {
        super("Decode");
        add(expression);
        state = EXPECT_CONDITION;
        bindChildren(expression);
    }

//    public If Then(Object value){
//        return Then(Litteral.toExpression(value));
//    }
    public CompiledDecode map(DefaultCompiledExpression oldValue, DefaultCompiledExpression newValue) {
        if (state != VALID) {
            add(oldValue);
            add(newValue);
            return this;
        } else {
            throw new IllegalArgumentException("No more tokens are expected");
        }
    }

//    public If Else(Object value){
//        return Else(Litteral.toExpression(value));
//    }
    public CompiledDecode otherwise(DefaultCompiledExpression value) {
        if (state != VALID) {
            add(value);
            state = VALID;
            return this;
        } else {
            throw new IllegalArgumentException("Expected a value");
        }
    }

    private void add(DefaultCompiledExpression expression) {
        protectedAddArgument(expression);
    }

    @Override
    public boolean isValid() {
        return state == VALID;
    }

    /**
     *
     * @return type of first value expression
     */
    @Override
    public DataTypeTransform getTypeTransform() {
        return getArgument(1).getTypeTransform();
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledDecode o = new CompiledDecode();
        for (DefaultCompiledExpression param : getArguments()) {
            o.protectedAddArgument(param.copy());
        }
        o.state = state;
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
