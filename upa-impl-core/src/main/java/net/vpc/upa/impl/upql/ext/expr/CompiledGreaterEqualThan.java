package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledGreaterEqualThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledGreaterEqualThan(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.GE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledGreaterEqualThan(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.GE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
