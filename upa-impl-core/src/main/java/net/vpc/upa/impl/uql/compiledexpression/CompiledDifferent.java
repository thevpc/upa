package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledDifferent extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDifferent(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.DIFF, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledDifferent(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.DIFF, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
