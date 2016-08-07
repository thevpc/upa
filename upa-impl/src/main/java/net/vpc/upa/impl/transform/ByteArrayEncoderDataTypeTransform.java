/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.*;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ByteArrayEncoderDataTypeTransform implements DataTypeTransform {

//    private SecretType targetType;
    private ByteArrayEncoder byteArrayEncoder;
    private DataType sourceType;
    private DataType targetType;

    public ByteArrayEncoderDataTypeTransform(ByteArrayEncoder byteArrayEncoder, DataType sourceType, Integer max) {
        this.byteArrayEncoder = byteArrayEncoder;
        this.sourceType = sourceType;
        this.targetType = new ByteArrayType(null, max == null ? 255 : max, sourceType.isNullable());
    }

    public Object transformValue(Object value) {
        ByteArrayEncoder ss = byteArrayEncoder;
        return ss.encode(value);
    }

    public Object reverseTransformValue(Object value) {
        return byteArrayEncoder.decode((byte[]) value);
    }

    public DataType getSourceType() {
        return sourceType;
    }

    public DataType getTargetType() {
        return targetType;
    }

    @Override
    public String toString() {
        return "StringEncoder{" + byteArrayEncoder + '}';
    }

    @Override
    public DataTypeTransform chain(DataTypeTransform other) {
        return DataTypeTransformList.chain(this, other);
    }

}
