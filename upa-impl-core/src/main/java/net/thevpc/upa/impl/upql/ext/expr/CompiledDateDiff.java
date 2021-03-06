package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.expressions.DatePartType;

import java.util.Date;

import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: vpc
 * Date: 22 mai 2003
 * Time: 12:07:34
 * 
 */
public class CompiledDateDiff extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledDateDiff(DatePartType datePartType, Date date1, Date date2) {
        this(datePartType, new CompiledLiteral(date1),new CompiledLiteral(date2));
    }

    public CompiledDateDiff(DatePartType datePartType, CompiledExpressionExt startDate, CompiledExpressionExt endDate) {
        super("DateDiff");
        protectedAddArgument(new CompiledCst(datePartType));
        protectedAddArgument(startDate);
        protectedAddArgument(endDate);
    }

    public CompiledCst getDatePartTypeExpression() {
        return (CompiledCst)getArgument(0);
    }
    
    public DatePartType getDatePartType() {
        return (DatePartType)getDatePartTypeExpression().getValue();
    }

    public CompiledExpressionExt getStart() {
        return getArgument(1);
    }

    public CompiledExpressionExt getEnd() {
        return getArgument(1);
    }
    //    public String toSQL(boolean flag, PersistenceUnitFilter database) {
//        return "DateDiff("+type.getName().toLowerCase()+","+start.toSQL(true, database)+","+end.toSQL(true, database)+")";
//    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.INT;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledDateDiff o = new CompiledDateDiff(getDatePartType(),getStart().copy(),getEnd().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }
}
