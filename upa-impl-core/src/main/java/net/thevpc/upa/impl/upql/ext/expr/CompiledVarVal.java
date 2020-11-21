package net.thevpc.upa.impl.upql.ext.expr;

import net.thevpc.upa.exceptions.UnsupportedUPAFeatureException;
import net.thevpc.upa.impl.ext.expressions.CompiledExpressionExt;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 12/29/12 5:52 PM
 */
public class CompiledVarVal extends DefaultCompiledExpressionImpl {

    private CompiledVar var;
    private CompiledExpressionExt val;

    public CompiledVarVal(CompiledVar var, CompiledExpressionExt val) {
        this.var = var;
        this.val = val;
        bindChildren(var, val);
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return new CompiledExpressionExt[]{var, val};
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        switch (index) {
            case 0: {
                unbindChildren(this.val);
                var = (CompiledVar) expression;
                bindChildren(expression);
                return;
            }
            case 1: {
                unbindChildren(this.val);
                val = expression;
                bindChildren(expression);
                return;
            }
        }
        throw new UnsupportedUPAFeatureException("Invalid index");
    }

    public CompiledExpressionExt copy() {
        CompiledVarVal compiledVarVal = new CompiledVarVal(var == null ? null : ((CompiledVar) var.copy()), val == null ? null : val.copy());
        return compiledVarVal;
    }

    public CompiledVar getVar() {
        return var;
    }

    public CompiledExpressionExt getVal() {
        return val;
    }

    public void setVal(CompiledExpressionExt val) {
        this.val = val;
    }
}
