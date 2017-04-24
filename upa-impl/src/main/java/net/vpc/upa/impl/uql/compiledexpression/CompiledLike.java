package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledLike extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledLike(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.LIKE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledLike(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.LIKE, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
