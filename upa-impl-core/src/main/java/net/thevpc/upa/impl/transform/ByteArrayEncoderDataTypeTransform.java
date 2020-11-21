/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.types.ByteArrayEncoder;
import net.thevpc.upa.types.ByteArrayType;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.*;

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

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ByteArrayEncoderDataTypeTransform that = (ByteArrayEncoderDataTypeTransform) o;

        if (byteArrayEncoder != null ? !byteArrayEncoder.equals(that.byteArrayEncoder) : that.byteArrayEncoder != null)
            return false;
        if (sourceType != null ? !sourceType.equals(that.sourceType) : that.sourceType != null) return false;
        return targetType != null ? targetType.equals(that.targetType) : that.targetType == null;
    }

    @Override
    public int hashCode() {
        int result = byteArrayEncoder != null ? byteArrayEncoder.hashCode() : 0;
        result = 31 * result + (sourceType != null ? sourceType.hashCode() : 0);
        result = 31 * result + (targetType != null ? targetType.hashCode() : 0);
        return result;
    }
}
