package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigInteger;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledXOr extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledXOr(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.XOR, left, right);
    }

    public CompiledXOr(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.XOR, left, right);
    }
}
