/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.SecretStrategy;
import net.vpc.upa.types.ByteArrayType;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class SecretDataTypeTransform implements DataTypeTransform {

//    private SecretType targetType;
    private SecretStrategy secretStrategy;
    private DataType sourceType;
    private DataType targetType;

    public SecretDataTypeTransform(SecretStrategy secretStrategy, DataType source, Integer targetMax) {
        this.secretStrategy = secretStrategy;
        this.sourceType = source;
        this.targetType = new ByteArrayType(null, targetMax == null ? 255 : targetMax, source.isNullable());
    }

    public Object transformValue(Object value) {
        SecretStrategy ss = secretStrategy;
        byte[] bytes = ss.encode((byte[])value);
        return bytes;
    }

    public Object reverseTransformValue(Object value) {
        return secretStrategy.decode((byte[]) value);
    }

    public DataType getSourceType() {
        return sourceType;
    }

    public DataType getTargetType() {
        return targetType;
    }

    @Override
    public String toString() {
        return "SecretDataTypeTransform{" + secretStrategy + '}';
    }

    @Override
    public DataTypeTransform chain(DataTypeTransform other) {
        return DataTypeTransformList.chain(this, other);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        SecretDataTypeTransform that = (SecretDataTypeTransform) o;

        if (secretStrategy != null ? !secretStrategy.equals(that.secretStrategy) : that.secretStrategy != null)
            return false;
        if (sourceType != null ? !sourceType.equals(that.sourceType) : that.sourceType != null) return false;
        return targetType != null ? targetType.equals(that.targetType) : that.targetType == null;
    }

    @Override
    public int hashCode() {
        int result = secretStrategy != null ? secretStrategy.hashCode() : 0;
        result = 31 * result + (sourceType != null ? sourceType.hashCode() : 0);
        result = 31 * result + (targetType != null ? targetType.hashCode() : 0);
        return result;
    }
}
