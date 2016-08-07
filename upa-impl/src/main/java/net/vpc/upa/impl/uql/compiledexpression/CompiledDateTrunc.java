package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.DatePartType;

import java.util.Date;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 12:07:34
 * To change this template use Options | File Templates.
 */
public class CompiledDateTrunc extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledDateTrunc(DatePartType type, Date date) {
        this(type, new CompiledLiteral(date));
    }

    public CompiledDateTrunc(DatePartType type, String varDate) {
        this(type, new UserCompiledExpression(varDate,IdentityDataTypeTransform.DATETIME));
    }

    public CompiledDateTrunc(DatePartType type, DefaultCompiledExpression val) {
        super("Datetrunc");
        protectedAddArgument(new CompiledCst(type));
        protectedAddArgument(val);
    }

    public CompiledCst getDatePartTypeExpression() {
        return (CompiledCst)getArgument(0);
    }
    
    public DatePartType getDatePartType() {
        return (DatePartType)getDatePartTypeExpression().getValue();
    }

    public DefaultCompiledExpression getValue() {
        return getArgument(1);
    }
    
   @Override
    public DefaultCompiledExpression copy() {
        CompiledDateTrunc o = new CompiledDateTrunc(getDatePartType(),getValue().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
