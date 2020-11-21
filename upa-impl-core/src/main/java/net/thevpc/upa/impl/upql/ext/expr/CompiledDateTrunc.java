package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.DatePartType;

import java.util.Date;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 12:07:34
 * 
 */
public class CompiledDateTrunc extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledDateTrunc(DatePartType type, Date date) {
        this(type, new CompiledLiteral(date));
    }

    public CompiledDateTrunc(DatePartType type, String varDate) {
        this(type, new UserCompiledExpression(varDate, IdentityDataTypeTransform.DATETIME));
    }

    public CompiledDateTrunc(DatePartType type, CompiledExpressionExt val) {
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

    public CompiledExpressionExt getValue() {
        return getArgument(1);
    }
    
   @Override
    public CompiledExpressionExt copy() {
        CompiledDateTrunc o = new CompiledDateTrunc(getDatePartType(),getValue().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
