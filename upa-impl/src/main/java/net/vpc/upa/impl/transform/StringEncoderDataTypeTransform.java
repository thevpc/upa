/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.*;

/**
 *
 * @author vpc
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

}
