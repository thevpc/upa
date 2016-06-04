package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

// Referenced classes of package net.vpc.lib.pheromone.ariana.database.sql:
//            BinaryExpression, Expression
public final class CompiledDifferent extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDifferent(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.DIFF, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }

    public CompiledDifferent(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.DIFF, left, right);
        setTypeTransform(IdentityDataTypeTransform.BOOLEAN);
    }
}
