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
 * @author vpc
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

}
