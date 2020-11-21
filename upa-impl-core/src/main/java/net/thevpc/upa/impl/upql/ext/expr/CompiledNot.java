package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.thevpc.upa.types.DataTypeTransform;

public final class CompiledNot extends CompiledUnaryOperator
        implements Cloneable {
    //    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        return "Not(" + expression.toSQL(database) + ")";
    private static final long serialVersionUID = 1L;

    public CompiledNot(CompiledExpressionExt expression) {
        super("not", expression);
    }
    
    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }


    
    @Override
    public CompiledExpressionExt copy() {
        CompiledNot o=new CompiledNot(getExpression().copy());
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

    //    }
}
