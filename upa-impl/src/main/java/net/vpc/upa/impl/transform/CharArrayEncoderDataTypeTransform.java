/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.ByteArrayType;
import net.vpc.upa.types.CharArrayEncoder;
import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;

/**
 *
 * @author vpc
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

}
