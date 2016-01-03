package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.types.TypesFactory;
import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigInteger;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;


public final class CompiledBitAnd extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledBitAnd(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.BIT_AND, left, right);
        Class t = left.getTypeTransform().getSourceType().getPlatformType();
        Class r = left.getTypeTransform().getSourceType().getPlatformType();
        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
            setDataType(IdentityDataTypeTransform.BIGINT);
        }else if(Long.class.equals(t) || Long.class.equals(r)){
            setDataType(IdentityDataTypeTransform.LONG);
        }else if(Integer.class.equals(t) || Integer.class.equals(r)){
            setDataType(IdentityDataTypeTransform.INT);
        }
    }

    public CompiledBitAnd(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.BIT_AND, left, right);
        Class t = left.getTypeTransform().getSourceType().getPlatformType();
        Class r = left.getTypeTransform().getSourceType().getPlatformType();
        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
            setDataType(IdentityDataTypeTransform.BIGINT);
        }else if(Long.class.equals(t) || Long.class.equals(r)){
            setDataType(IdentityDataTypeTransform.LONG);
        }else if(Integer.class.equals(t) || Integer.class.equals(r)){
            setDataType(IdentityDataTypeTransform.INT);
        }
    }
}
