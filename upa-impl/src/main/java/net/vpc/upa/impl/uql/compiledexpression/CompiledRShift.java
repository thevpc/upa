package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigInteger;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;


public final class CompiledRShift extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledRShift(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.RSHIFT, left, right);
        Class t = left.getTypeTransform().getTargetType().getPlatformType();
        Class r = left.getTypeTransform().getTargetType().getPlatformType();
        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
            setDataType(IdentityDataTypeTransform.BIGINT);
        }else if(Long.class.equals(t) || Long.class.equals(r)){
            setDataType(IdentityDataTypeTransform.LONG);
        }else if(Integer.class.equals(t)|| Integer.class.equals(r)){
            setDataType(IdentityDataTypeTransform.INT);
        }
    }

    public CompiledRShift(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.RSHIFT, left, right);
        Class t = left.getTypeTransform().getTargetType().getPlatformType();
        Class r = left.getTypeTransform().getTargetType().getPlatformType();
        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
            setDataType(IdentityDataTypeTransform.BIGINT);
        }else if(Long.class.equals(t) || Long.class.equals(r)){
            setDataType(IdentityDataTypeTransform.LONG);
        }else if(Integer.class.equals(t) || Integer.class.equals(r)){
            setDataType(IdentityDataTypeTransform.INT);
        }
    }
}
