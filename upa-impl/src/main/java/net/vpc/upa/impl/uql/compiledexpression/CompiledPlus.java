package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigDecimal;
import java.math.BigInteger;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledPlus extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledPlus(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.PLUS, left, right);
        buildDataType();
    }

    public CompiledPlus(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.PLUS, left, right);
        buildDataType();
    }

    protected void buildDataType() {
        Class t = getLeft().getTypeTransform().getTargetType().getPlatformType();
        Class r = getRight().getTypeTransform().getTargetType().getPlatformType();

        if (String.class.equals(t) || String.class.equals(r)) {
            //
            setTypeTransform(IdentityDataTypeTransform.STRING);
        } else {

            /**
             * @PortabilityHint(target="C#",name="suppress")
             */
            if (BigDecimal.class.equals(t) || BigDecimal.class.equals(r)) {
                setTypeTransform(IdentityDataTypeTransform.BIGDECIMAL);
            }
            if (BigInteger.class.equals(t) || BigInteger.class.equals(r)) {
                if (Double.class.equals(t) || Double.class.equals(r)) {
                    /**
                     * @PortabilityHint(target="C#",name="replace")
                     * SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                     *
                     */
                    setTypeTransform(IdentityDataTypeTransform.BIGDECIMAL);
                } else if (Float.class.equals(t) || Float.class.equals(r)) {
                    /**
                     * @PortabilityHint(target="C#",name="replace")
                     * SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                     *
                     */
                    setTypeTransform(IdentityDataTypeTransform.BIGDECIMAL);
                } else {
                    setTypeTransform(IdentityDataTypeTransform.BIGINT);
                }
            } else if (Double.class.equals(t) || Double.class.equals(r)) {
                setTypeTransform(IdentityDataTypeTransform.DOUBLE);
            } else if (Float.class.equals(t) || Float.class.equals(r)) {
                setTypeTransform(IdentityDataTypeTransform.FLOAT);
            } else if (Long.class.equals(t) || Long.class.equals(r)) {
                setTypeTransform(IdentityDataTypeTransform.LONG);
            } else if (Integer.class.equals(t) || Integer.class.equals(r)) {
                setTypeTransform(IdentityDataTypeTransform.INT);
            } else {
                throw new IllegalArgumentException("Unsupported types");
            }
        }
    }
}
