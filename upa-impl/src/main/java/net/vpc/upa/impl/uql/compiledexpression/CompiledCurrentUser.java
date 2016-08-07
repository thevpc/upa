package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created by IntelliJ IDEA.
 * User: root
 * Date: 22 mai 2003
 * Time: 17:00:10
 * To change this template use Options | File Templates.
 */
public class CompiledCurrentUser extends CompiledFunction {
    private static final long serialVersionUID = 1L;

    public CompiledCurrentUser() {
        super("CurrentUser");
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.DATE;
    }

    @Override
    public DefaultCompiledExpression copy() {
        CompiledCurrentUser o = new CompiledCurrentUser();
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        return o;
    }

}
