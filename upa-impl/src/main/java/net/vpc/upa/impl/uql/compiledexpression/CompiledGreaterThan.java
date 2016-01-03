package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.TypesFactory;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledGreaterThan extends CompiledBinaryOperatorExpression
        implements Cloneable {
    private static final long serialVersionUID = 1L;

    public CompiledGreaterThan(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.GT, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledGreaterThan(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.GT, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }

}
