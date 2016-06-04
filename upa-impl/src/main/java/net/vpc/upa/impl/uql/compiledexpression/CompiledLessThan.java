package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledLessThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLessThan(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.LT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLessThan(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.LT, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
