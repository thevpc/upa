/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.util.LRUMap;
import net.vpc.upa.types.*;

import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class IdentityDataTypeTransform implements DataTypeTransform {
    private static final Map<Class,IdentityDataTypeTransform> mapByType=new HashMap<>();
    private static final Map<DataType,IdentityDataTypeTransform> mapByDataType=new HashMap<>();
    private static final Map<DataType,IdentityDataTypeTransform> mapByDataTypeCache=new LRUMap<DataType, IdentityDataTypeTransform>(100);

    public static final DataTypeTransform VOID = register(TypesFactory.VOID);
    public static final DataTypeTransform STRING = register(TypesFactory.STRING);
    public static final DataTypeTransform STRING_UNLIMITED = register(StringType.UNLIMITED);
    public static final DataTypeTransform BOOLEAN = register(TypesFactory.BOOLEAN);
    public static final DataTypeTransform BIGINT = register(TypesFactory.BIGINT);
    public static final DataTypeTransform INT = register(TypesFactory.INT);
    public static final DataTypeTransform LONG = register(TypesFactory.LONG);
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final DataTypeTransform BIGDECIMAL = register(TypesFactory.BIGDECIMAL);
    public static final DataTypeTransform DOUBLE = register(TypesFactory.DOUBLE);
    public static final DataTypeTransform FLOAT = register(TypesFactory.FLOAT);
    public static final DataTypeTransform DATE = register(TypesFactory.DATE);
    public static final DataTypeTransform TIME = register(TypesFactory.TIME);
    public static final DataTypeTransform DATETIME = register(TypesFactory.DATETIME);
    public static final DataTypeTransform OBJECT = register(TypesFactory.OBJECT);

    private final DataType sourceType;

    public static IdentityDataTypeTransform ofType(Class sourceType) {
        IdentityDataTypeTransform found = mapByType.get(sourceType);
        if(found==null){
            found=new IdentityDataTypeTransform(TypesFactory.forPlatformType(sourceType));
            mapByType.put(sourceType,found);
        }
        return found;
    }

    public static IdentityDataTypeTransform register(DataType sourceType) {
        IdentityDataTypeTransform value = ofType(sourceType);
        mapByDataType.put(sourceType, value);
        return value;
    }

    public static IdentityDataTypeTransform register(Class sourceType) {
        IdentityDataTypeTransform value = ofType(sourceType);
        mapByDataType.put(TypesFactory.forPlatformType(sourceType), value);
        return value;
    }

    public static IdentityDataTypeTransform ofType(DataType sourceType) {
        IdentityDataTypeTransform found = mapByDataType.get(sourceType);
        if(found==null){
            found = mapByDataTypeCache.get(sourceType);
            if(found==null){
                found=new IdentityDataTypeTransform(sourceType);
                mapByDataTypeCache.put(sourceType,found);
            }
        }
        return found;
    }

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

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        IdentityDataTypeTransform that = (IdentityDataTypeTransform) o;

        return sourceType != null ? sourceType.equals(that.sourceType) : that.sourceType == null;
    }

    @Override
    public int hashCode() {
        return sourceType != null ? sourceType.hashCode() : 0;
    }
}
