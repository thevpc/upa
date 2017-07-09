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
public class CharArrayEncoderDataTypeTransform implements DataTypeTransform {

//    private SecretType targetType;
    private CharArrayEncoder charArrayEncoder;
    private DataType sourceType;
    private DataType targetType;

    public CharArrayEncoderDataTypeTransform(CharArrayEncoder byteArrayEncoder, DataType sourceType, Integer max) {
        this.charArrayEncoder = byteArrayEncoder;
        this.sourceType = sourceType;
        this.targetType = new ByteArrayType(null, max == null ? 255 : max, sourceType.isNullable());
    }

    public Object transformValue(Object value) {
        CharArrayEncoder ss = charArrayEncoder;
        return ss.encode(value);
    }

    public Object reverseTransformValue(Object value) {
        return charArrayEncoder.decode((char[]) value);
    }

    public DataType getSourceType() {
        return sourceType;
    }

    public DataType getTargetType() {
        return targetType;
    }

    @Override
    public String toString() {
        return "CharArrayEncoder{" + charArrayEncoder + '}';
    }

    @Override
    public DataTypeTransform chain(DataTypeTransform other) {
        return DataTypeTransformList.chain(this, other);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        CharArrayEncoderDataTypeTransform that = (CharArrayEncoderDataTypeTransform) o;

        if (charArrayEncoder != null ? !charArrayEncoder.equals(that.charArrayEncoder) : that.charArrayEncoder != null)
            return false;
        if (sourceType != null ? !sourceType.equals(that.sourceType) : that.sourceType != null) return false;
        return targetType != null ? targetType.equals(that.targetType) : that.targetType == null;
    }

    @Override
    public int hashCode() {
        int result = charArrayEncoder != null ? charArrayEncoder.hashCode() : 0;
        result = 31 * result + (sourceType != null ? sourceType.hashCode() : 0);
        result = 31 * result + (targetType != null ? targetType.hashCode() : 0);
        return result;
    }
}
