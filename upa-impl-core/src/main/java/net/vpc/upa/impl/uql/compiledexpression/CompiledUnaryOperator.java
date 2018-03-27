package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.types.DataTypeTransform;

public abstract class CompiledUnaryOperator extends DefaultCompiledExpressionImpl
        implements Cloneable {

    private static final long serialVersionUID = 1L;
    private String operator;
    private CompiledExpressionExt expression;

    public CompiledUnaryOperator(String operator, CompiledExpressionExt expression) {
        this.operator = operator;
        this.expression = expression;
        bindChildren(expression);
    }

    public int size() {
        return 1;
    }

    @Override
    public DataTypeTransform getTypeTransform() {
        return expression.getTypeTransform();
    }

    @Override
    public boolean isValid() {
        return expression.isValid();
    }

    @Override
    public void setSubExpression(int index, CompiledExpressionExt expression) {
        if (index == 0) {
            unbindChildren(this.expression);
            this.expression = expression;
            bindChildren(expression);
        } else {
            throw new UPAIllegalArgumentException("Invalid Index");
        }
    }

    @Override
    public CompiledExpressionExt[] getSubExpressions() {
        return new CompiledExpressionExt[]{expression};
    }

//    public synchronized String toSQL(boolean integrated, PersistenceUnitFilter database) {
//        return operator + expression.toSQL(true, database);
//    }
    public CompiledExpressionExt getExpression() {
        return expression;
    }

    public String getOperator() {
        return operator;
    }
}
