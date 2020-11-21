package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeFactory;

import java.util.List;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 10:07:06
 * 
 */
public class CompiledIf extends CompiledFunction implements Cloneable {
    private static final long serialVersionUID = 1L;
    private final int EXPECT_CONDITION=0;
    private final int EXPECT_VALUE=1;
    private final int VALID=2;
    private int state=0;

    private CompiledIf() {
        super("If");
    }
    
    public CompiledIf(List<CompiledExpressionExt> expressions) {
        this();
        for (CompiledExpressionExt expr : expressions) {
            protectedAddArgument(expr);
        }
        state=VALID;
    }
    
    public CompiledIf(CompiledExpressionExt condition) {
        this();
        condition.getTypeTransform().getSourceType().cast(DataTypeFactory.BOOLEAN);
        add(condition);
        state=EXPECT_VALUE;
    }

//    public If Then(Object value){
//        return Then(Litteral.toExpression(value));
//    }

    public CompiledIf Then(CompiledExpressionExt value){
        if(state==EXPECT_VALUE){
            add(value);
            state=EXPECT_CONDITION;
            return this;
        }else if(state==VALID){
            throw new IllegalUPAArgumentException("No more tokens are expected");
        }else{
            throw new IllegalUPAArgumentException("Expected a value");
        }
    }

//    public If Else(Object value){
//        return Else(Litteral.toExpression(value));
//    }

    public CompiledIf Else(CompiledExpressionExt value){
        if(state==EXPECT_CONDITION){
            add(value);
            state=VALID;
            return this;
        }else if(state==VALID){
            throw new IllegalUPAArgumentException("No more tokens are expected");
        }else{
            throw new IllegalUPAArgumentException("Expected a value");
        }
    }

//    public If ElseIf(String condition){
//        return ElseIf(new UserExpression(condition));
//    }

    public CompiledIf ElseIf(CompiledExpressionExt condition){
        if(state==EXPECT_CONDITION){
            condition.getTypeTransform().getSourceType().cast(DataTypeFactory.BOOLEAN);
            add(condition);
            state=EXPECT_VALUE;
            return this;
        }else if(state==VALID){
            throw new IllegalUPAArgumentException("No more tokens are expected");
        }else{
            throw new IllegalUPAArgumentException("Expected a condition");
        }
    }

    private void add(CompiledExpressionExt expression){
        protectedAddArgument(expression);
    }

    public boolean isValid() {
        return state==VALID;
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
        CompiledIf o=new CompiledIf();
        o.state=state;
        for (CompiledExpressionExt param : getArguments()) {
            o.protectedAddArgument(param.copy());
        }
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
    //if (0) then 1 end
    //if (0) then 1 else 2 end
    //if (0) then 1 elseif 2 then 3 else 4 end
    @Override
    public String toString() {
        StringBuilder s=new StringBuilder();
        int i=0;
        for (CompiledExpressionExt expression : getArguments()) {
            if(i%2==0){
                if(i==0){
                    s.append("if (").append(expression).append(") then ");
                }else if(i<getArgumentsCount()-1){
                    s.append(" elseif (").append(expression).append(") then ");
                }else {
                    s.append(" else (");
                    s.append(expression);
                    s.append(")");
                }
            }else{
                s.append(" (").append(expression).append(")");
            }
            i++;
        }
        s.append(" end");
        return s.toString();
    }
    
}
