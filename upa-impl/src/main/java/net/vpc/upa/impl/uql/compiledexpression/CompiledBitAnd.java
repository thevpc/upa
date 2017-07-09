package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;

import java.math.BigInteger;

import net.vpc.upa.impl.ext.expressions.CompiledExpressionExt;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;


public final class CompiledBitAnd extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public CompiledBitAnd(CompiledExpressionExt left, Object right) {
        super(BinaryOperator.BIT_AND, left, right);
        Class t = left.getTypeTransform().getSourceType().getPlatformType();
        Class r = left.getTypeTransform().getSourceType().getPlatformType();
        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
            setTypeTransform(IdentityDataTypeTransform.BIGINT);
        }else if(Long.class.equals(t) || Long.class.equals(r)){
            setTypeTransform(IdentityDataTypeTransform.LONG);
        }else if(Integer.class.equals(t) || Integer.class.equals(r)){
            setTypeTransform(IdentityDataTypeTransform.INT);
        }
    }

    public CompiledBitAnd(CompiledExpressionExt left, CompiledExpressionExt right) {
        super(BinaryOperator.BIT_AND, left, right);
        Class t = left.getTypeTransform().getSourceType().getPlatformType();
        Class r = left.getTypeTransform().getSourceType().getPlatformType();
        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
            setTypeTransform(IdentityDataTypeTransform.BIGINT);
        }else if(Long.class.equals(t) || Long.class.equals(r)){
            setTypeTransform(IdentityDataTypeTransform.LONG);
        }else if(Integer.class.equals(t) || Integer.class.equals(r)){
            setTypeTransform(IdentityDataTypeTransform.INT);
        }
    }
}
