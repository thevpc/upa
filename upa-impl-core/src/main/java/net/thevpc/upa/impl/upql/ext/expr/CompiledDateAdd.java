package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.DatePartType;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 12:07:34
 * 
 */
public class CompiledDateAdd extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledDateAdd(DatePartType type, CompiledExpressionExt count, CompiledExpressionExt date) {
        super("DateAdd");
        protectedAddArgument(new CompiledCst(type));
        protectedAddArgument(count);
        protectedAddArgument(date);
    }

    public DatePartType getDatePartType() {
        return (DatePartType) getDatePartTypeExpression().getValue();
    }
    
    public CompiledCst getDatePartTypeExpression() {
        return (CompiledCst)getArgument(0);
    }

    public CompiledExpressionExt getCount() {
        return getArgument(1);
    }

    public CompiledExpressionExt getDate() {
        return getArgument(2);
    }
    
    


    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.DATE;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledDateAdd o=new CompiledDateAdd(getDatePartType(),getCount().copy(),getDate().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }


}
