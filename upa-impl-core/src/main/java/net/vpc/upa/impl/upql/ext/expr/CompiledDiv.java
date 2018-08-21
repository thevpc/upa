package net.vpc.upa.impl.upql.ext.expr;

import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigDecimal;
import java.math.BigInteger;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledDiv extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDiv(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.DIV, left, right);
    }

    public CompiledDiv(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.DIV, left, right);
    }
}
