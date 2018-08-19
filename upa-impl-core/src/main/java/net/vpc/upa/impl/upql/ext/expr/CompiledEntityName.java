package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.expressions.ExpressionHelper;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

/**
 * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:12 PM To change
 * this template use File | Settings | File Templates.
 */
public class CompiledEntityName extends DefaultCompiledExpressionImpl implements CompiledNameOrSelect {

    private String name;
    private boolean isUseView;

    public CompiledEntityName(String name, boolean isUseView) {
        this.name = name;
        this.isUseView = isUseView;
    }

    public CompiledEntityName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public boolean isValid() {
        return true;
    }

//    @Override
//    public String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        throw new UPAIllegalArgumentException("Not supported");
//    }
    @Override
    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.VOID;
    }

    public boolean isUseView() {
        return isUseView;
    }

    public void setUseView(boolean useView) {
        isUseView = useView;
    }

    @Override
    public CompiledExpressionExt copy() {
        CompiledEntityName o = new CompiledEntityName(name);
        o.setDescription(getDescription());
        o.getClientParameters().setAll(getClientParameters());
        o.setUseView(isUseView);
        return o;
    }

    @Override
    public String toString() {
        return ExpressionHelper.escapeIdentifier(name);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return null;
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        throw new UnsupportedOperationException("Not supported.");
    }
}
