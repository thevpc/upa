package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledLessEqualThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLessEqualThan(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.LE, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLessEqualThan(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.LE, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }
}
