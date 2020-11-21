/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.types.*;
import net.thevpc.upa.types.*;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class StringEncoderDataTypeTransform implements DataTypeTransform {

//    private SecretType targetType;
    private StringEncoder stringEncoder;
    private ByteArrayEncoder serializer;
    private DataType sourceType;
    private DataType targetType;

    public StringEncoderDataTypeTransform(StringEncoder stringEncoder, DataType sourceType, Integer max, ByteArrayEncoder serializer) {
        this.serializer = serializer;
        this.stringEncoder = stringEncoder;
        this.sourceType = sourceType;
        this.targetType = new StringType(null, 0,max == null ? 255 : max, sourceType.isNullable());
    }

    public Object transformValue(Object value) {
        StringEncoder ss = stringEncoder;
        String bytes = ss.encode(serializer.encode(value));
        return bytes;
    }

    public Object reverseTransformValue(Object value) {
        byte[] bytes = stringEncoder.decode((String) value);
        return serializer.decode(bytes);
    }

    public DataType getSourceType() {
        return sourceType;
    }

    public DataType getTargetType() {
        return targetType;
    }

    @Override
    public String toString() {
        return "StringEncoder{" + "stringEncoder=" + stringEncoder + ", serializer=" + serializer + ", sourceType=" + sourceType + ", targetType=" + targetType + '}';
    }

   

    @Override
    public DataTypeTransform chain(DataTypeTransform other) {
        return DataTypeTransformList.chain(this, other);
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        StringEncoderDataTypeTransform that = (StringEncoderDataTypeTransform) o;

        if (stringEncoder != null ? !stringEncoder.equals(that.stringEncoder) : that.stringEncoder != null)
            return false;
        if (serializer != null ? !serializer.equals(that.serializer) : that.serializer != null) return false;
        if (sourceType != null ? !sourceType.equals(that.sourceType) : that.sourceType != null) return false;
        return targetType != null ? targetType.equals(that.targetType) : that.targetType == null;
    }

    @Override
    public int hashCode() {
        int result = stringEncoder != null ? stringEncoder.hashCode() : 0;
        result = 31 * result + (serializer != null ? serializer.hashCode() : 0);
        result = 31 * result + (sourceType != null ? sourceType.hashCode() : 0);
        result = 31 * result + (targetType != null ? targetType.hashCode() : 0);
        return result;
    }
}
