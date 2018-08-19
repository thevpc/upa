package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigInteger;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;


public final class CompiledBitOr extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledBitOr(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.BIT_OR, left, right);
    }

    public CompiledBitOr(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.BIT_OR, left, right);
    }
}
