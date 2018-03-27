package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigDecimal;
import java.math.BigInteger;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledMinus extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledMinus(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.MINUS, left, right);
    }

    public CompiledMinus(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.MINUS, left, right);
    }
}
