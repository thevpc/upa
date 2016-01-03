package net.vpc.upa.impl.uql.compiledexpression;


import net.vpc.upa.types.TypesFactory;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledOr extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledOr(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.OR, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledOr(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.OR, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }

    @Override
    public boolean isValid() {
        return (getLeft() == null || getLeft().isValid()) || (getRight() == null || getRight().isValid());
    }
}
