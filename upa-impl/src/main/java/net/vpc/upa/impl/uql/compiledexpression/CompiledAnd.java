package net.vpc.upa.impl.uql.compiledexpression;

import net.vpc.upa.expressions.BinaryOperator;
import net.vpc.upa.impl.transform.IdentityDataTypeTransform;
import net.vpc.upa.types.DataTypeTransform;

public final class CompiledAnd extends CompiledBinaryOperatorExpression
        implements Cloneable {

    private static final long serialVersionUID = 1L;

    public static DefaultCompiledExpression tryAddCopies(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        if (left != null) {
            left = left.copy();
        }
        if (right != null) {
            right = right.copy();
        }
        return tryAdd(left, right);
    }

    public static DefaultCompiledExpression tryAdd(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        if (left == null) {
            return right;
        }
        if (right == null) {
            return left;
        }
        return new CompiledAnd(right, left);
    }

    public CompiledAnd(DefaultCompiledExpression left, Object right) {
        super(BinaryOperator.AND, left, right);
        Class t = left.getTypeTransform().getSourceType().getPlatformType();
        Class r = left.getTypeTransform().getSourceType().getPlatformType();
//        if(PlateformTypeUtils.isBigInt(t) || PlateformTypeUtils.isBigInt(r)){
//            setDataType(TypesFactory.BIGINT);
//        }else if(Long.class.equals(t) || PlateformTypeUtils.isInt64(r)){
//            setDataType(TypesFactory.LONG);
//        }else if(PlateformTypeUtils.isInt32(t) || PlateformTypeUtils.isInt32(r)){
//            setDataType(TypesFactory.INT);
//        }
    }

    public CompiledAnd(DefaultCompiledExpression left, DefaultCompiledExpression right) {
        super(BinaryOperator.AND, left, right);
//        Class t = left.getDataType().getPlatformType();
//        Class r = left.getDataType().getPlatformType();
//        if(BigInteger.class.equals(t) || BigInteger.class.equals(r)){
//            setDataType(TypesFactory.BIGINT);
//        }else if(Long.class.equals(t) || Long.class.equals(r)){
//            setDataType(TypesFactory.LONG);
//        }else if(Integer.class.equals(t) || Integer.class.equals(r)){
//            setDataType(TypesFactory.INT);
//        }
    }

    public DataTypeTransform getTypeTransform() {
        return IdentityDataTypeTransform.BOOLEAN;
    }

    @Override
    public boolean isValid() {
        return (getLeft() == null || getLeft().isValid()) || (getRight() == null || getRight().isValid());
    }

}
