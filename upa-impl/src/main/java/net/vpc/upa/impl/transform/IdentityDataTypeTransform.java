/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.DataTypeTransform;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.StringType;
import net.vpc.upa.types.TypesFactory;

/**
 *
 * @author vpc
 */
public final class IdentityDataTypeTransform implements DataTypeTransform {

    public static final DataTypeTransform VOID = new IdentityDataTypeTransform(TypesFactory.VOID);
    public static final DataTypeTransform STRING = new IdentityDataTypeTransform(TypesFactory.STRING);
    public static final DataTypeTransform STRING_UNLIMITED = new IdentityDataTypeTransform(StringType.UNLIMITED);
    public static final DataTypeTransform BOOLEAN = new IdentityDataTypeTransform(TypesFactory.BOOLEAN);
    public static final DataTypeTransform BIGINT = new IdentityDataTypeTransform(TypesFactory.BIGINT);
    public static final DataTypeTransform INT = new IdentityDataTypeTransform(TypesFactory.INT);
    public static final DataTypeTransform LONG = new IdentityDataTypeTransform(TypesFactory.LONG);
    public static final DataTypeTransform BIGDECIMAL = new IdentityDataTypeTransform(TypesFactory.BIGDECIMAL);
    public static final DataTypeTransform DOUBLE = new IdentityDataTypeTransform(TypesFactory.DOUBLE);
    public static final DataTypeTransform FLOAT = new IdentityDataTypeTransform(TypesFactory.FLOAT);
    public static final DataTypeTransform DATE = new IdentityDataTypeTransform(TypesFactory.DATE);
    public static final DataTypeTransform TIME = new IdentityDataTypeTransform(TypesFactory.TIME);
    public static final DataTypeTransform DATETIME = new IdentityDataTypeTransform(TypesFactory.DATETIME);
    public static final DataTypeTransform OBJECT = new IdentityDataTypeTransform(TypesFactory.OBJECT);
    private final DataType sourceType;

    public IdentityDataTypeTransform(DataType sourceType) {
        this.sourceType = sourceType;
    }

    public Object transformValue(Object value) {
        return value;
    }

    public Object reverseTransformValue(Object value) {
        return value;
    }

    public DataType getSourceType() {
        return sourceType;
    }

    public DataType getTargetType() {
        return sourceType;
    }

    @Override
    public String toString() {
        return String.valueOf(sourceType);
    }

    @Override
    public DataTypeTransform chain(DataTypeTransform other) {
        if (other == null) {
            return this;
        }
        return other;
    }

    public static IdentityDataTypeTransform forNativeType(Class clazz) {
        return new IdentityDataTypeTransform(TypesFactory.forPlatformType(clazz));
    }
    public static IdentityDataTypeTransform forDataType(DataType sourceType) {
        return new IdentityDataTypeTransform(sourceType);
    }
}
