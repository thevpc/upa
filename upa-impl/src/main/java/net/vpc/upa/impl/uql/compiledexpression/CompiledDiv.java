package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigDecimal;
import java.math.BigInteger;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;

public final class CompiledDiv extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledDiv(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.DIV, left, right);
        Class t = left.getTypeTransform().getTargetType().getPlatformType();
        Class r = left.getTypeTransform().getTargetType().getPlatformType();
        /**@PortabilityHint(target="C#",name="suppress")*/
        if (BigDecimal.class.equals(t) || BigDecimal.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.BIGDECIMAL);
        }
        if (BigInteger.class.equals(t) || BigInteger.class.equals(r)) {
            if (Double.class.equals(t) || Double.class.equals(r)) {
                /**@PortabilityHint(target="C#",name="replace")
                 * SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                 **/
                setDataType(IdentityDataTypeTransform.BIGDECIMAL);
            } else if (Float.class.equals(t) || Float.class.equals(r)) {
                /**@PortabilityHint(target="C#",name="replace")
                 * SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                 **/
                setDataType(IdentityDataTypeTransform.BIGDECIMAL);
            } else {
                setDataType(IdentityDataTypeTransform.BIGINT);
            }
        } else if (Double.class.equals(t) || Double.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.DOUBLE);
        } else if (Float.class.equals(t) || Float.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.FLOAT);
        } else if (Long.class.equals(t) || Long.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.LONG);
        } else if (Integer.class.equals(t) || Integer.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.INT);
        } else {
            throw new IllegalArgumentException("Unsupported types");
        }
    }

    public CompiledDiv(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.DIV, left, right);
        Class t = left.getTypeTransform().getTargetType().getPlatformType();
        Class r = left.getTypeTransform().getTargetType().getPlatformType();
        /**@PortabilityHint(target="C#",name="suppress")*/
        if (BigDecimal.class.equals(t) || BigDecimal.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.BIGDECIMAL);
        }
        if (BigInteger.class.equals(t) || BigInteger.class.equals(r)) {
            if (Double.class.equals(t) || Double.class.equals(r)) {
                /**@PortabilityHint(target="C#",name="replace")
                 * SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                 * */
                setDataType(IdentityDataTypeTransform.BIGDECIMAL);
            } else if (Float.class.equals(t) || Float.class.equals(r)) {
                /**@PortabilityHint(target="C#",name="replace")
                 * SetDataType(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.DOUBLE);
                 * */
                setDataType(IdentityDataTypeTransform.BIGDECIMAL);
            } else {
                setDataType(IdentityDataTypeTransform.BIGINT);
            }
        } else if (Double.class.equals(t) || Double.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.DOUBLE);
        } else if (Float.class.equals(t) || Float.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.FLOAT);
        } else if (Long.class.equals(t) || Long.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.LONG);
        } else if (Integer.class.equals(t) || Integer.class.equals(r)) {
            setDataType(IdentityDataTypeTransform.INT);
        } else {
            throw new IllegalArgumentException("Unsupported types");
        }
    }
}
