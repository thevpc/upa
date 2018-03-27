package net.vpc.upa.impl.uql.compiledexpression;
//            BinaryExpression, Expression

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledEquals extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledEquals(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.EQ, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledEquals(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.EQ, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
