/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.PasswordStrategy;
import net.vpc.upa.PasswordTransformConfig;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.StringType;

/**
 *
 * @author vpc
 */
public class PasswordDataTypeTransform implements DataTypeTransform {

//    public static final Object NO_VALUE = new Object();
    private Object cipherValue;
    //cipherValue as seen by the preceding chained Transform if any
    private PasswordStrategy passwordStrategy;
    private DataType sourceType;
    private DataType targetType;

    public PasswordDataTypeTransform(PasswordStrategy passwordStrategy, Object cipherValue, DataType sourceType) {
        this.passwordStrategy = passwordStrategy;
        this.cipherValue = cipherValue;
        this.sourceType = sourceType;
        int max = passwordStrategy.getMaxSize();
        this.targetType = new StringType(null, 0, (max <= 0) ? 255 : max, sourceType.isNullable());
    }

    public Object transformValue(Object value) {
//        if (UPAUtils.equals(value, cipherValue)) {
//            return PasswordTransformConfig.NO_VALUE;
//        }
        return value == null ? null : passwordStrategy.encode((String) value);
    }

    public Object reverseTransformValue(Object value) {
        return cipherValue;
    }

    public DataType getSourceType() {
        return sourceType;
    }

    public DataType getTargetType() {
        return targetType;
    }

    public Object getCipherValue() {
        return cipherValue;
    }
    

    @Override
    public String toString() {
        return "PasswordDataTypeTransform{" + targetType + '}';
    }

    @Override
    public DataTypeTransform chain(DataTypeTransform other) {
        return DataTypeTransformList.chain(this, other);
    }

}
