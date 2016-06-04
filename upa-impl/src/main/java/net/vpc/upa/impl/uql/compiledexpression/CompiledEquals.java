package net.vpc.upa.impl.uql.compiledexpression;
//            BinaryExpression, Expression

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledEquals extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledEquals(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.EQ, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledEquals(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.EQ, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
