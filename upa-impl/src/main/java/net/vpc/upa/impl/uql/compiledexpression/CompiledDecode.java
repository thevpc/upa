package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
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

//    public CompiledDecode(List<CompiledExpressionExt> expressions) {
//        params=new ArrayList<CompiledExpressionExt>(expressions);
//        state=VALID;
//        bindChildren(params);
//    }
    public CompiledDecode(CompiledExpressionExt expression) {
        super("Decode");
        add(expression);
        state = EXPECT_CONDITION;
        bindChildren(expression);
    }

//    public If Then(Object value){
//        return Then(Litteral.toExpression(value));
//    }
    public CompiledDecode map(CompiledExpressionExt oldValue, CompiledExpressionExt newValue) {
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
    public CompiledDecode otherwise(CompiledExpressionExt value) {
        if (state != VALID) {
            add(value);
            state = VALID;
            return this;
        } else {
            throw new IllegalArgumentException("Expected a value");
        }
    }

    private void add(CompiledExpressionExt expression) {
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
    public CompiledExpressionExt copy() {
        CompiledDecode o = new CompiledDecode();
        for (CompiledExpressionExt param : getArguments()) {
            o.protectedAddArgument(param.copy());
        }
        o.state = state;
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
