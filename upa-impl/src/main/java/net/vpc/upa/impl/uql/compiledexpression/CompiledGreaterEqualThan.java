package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.TypesFactory;
import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledGreaterEqualThan extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledGreaterEqualThan(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.GE, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledGreaterEqualThan(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.GE, left, right);
        setDataType(IdentityDataTypeTransform.BOOLEAN);
    }
}
