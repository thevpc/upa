/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.PasswordStrategy;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.StringType;

/**
 *
 * @author taha.bensalah@gmail.com
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

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        PasswordDataTypeTransform that = (PasswordDataTypeTransform) o;

        if (cipherValue != null ? !cipherValue.equals(that.cipherValue) : that.cipherValue != null) return false;
        if (passwordStrategy != null ? !passwordStrategy.equals(that.passwordStrategy) : that.passwordStrategy != null)
            return false;
        if (sourceType != null ? !sourceType.equals(that.sourceType) : that.sourceType != null) return false;
        return targetType != null ? targetType.equals(that.targetType) : that.targetType == null;
    }

    @Override
    public int hashCode() {
        int result = cipherValue != null ? cipherValue.hashCode() : 0;
        result = 31 * result + (passwordStrategy != null ? passwordStrategy.hashCode() : 0);
        result = 31 * result + (sourceType != null ? sourceType.hashCode() : 0);
        result = 31 * result + (targetType != null ? targetType.hashCode() : 0);
        return result;
    }
}
