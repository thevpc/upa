package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:00:10
 * To change this template use Options | File Templates.
 */
public class CompiledCurrentTimestamp extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledCurrentTimestamp() {
        super("CurrentTimestamp");
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.DATE;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledCurrentTimestamp o = new CompiledCurrentTimestamp();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
