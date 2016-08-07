package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.DatePartType;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 12:07:34
 * To change this template use Options | File Templates.
 */
public class CompiledDateAdd extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledDateAdd(DatePartType type, DefaultCompiledExpression count, DefaultCompiledExpression date) {
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

    public DefaultCompiledExpression getCount() {
        return getArgument(1);
    }

    public DefaultCompiledExpression getDate() {
        return getArgument(2);
    }
    
    


    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.STRING;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledDateAdd o=new CompiledDateAdd(getDatePartType(),getCount().copy(),getDate().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }


}
