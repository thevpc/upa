/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.impl.cache.LRUMap;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.DataTypeFactory;
import net.thevpc.upa.types.DataTypeTransform;
import net.thevpc.upa.types.StringType;
import net.thevpc.upa.types.*;

import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public final class IdentityDataTypeTransform implements DataTypeTransform {
    private static final Map<Class,IdentityDataTypeTransform> mapByType=new HashMap<Class,IdentityDataTypeTransform>();
    private static final Map<DataType,IdentityDataTypeTransform> mapByDataType=new HashMap<DataType,IdentityDataTypeTransform>();
    private static final Map<DataType,IdentityDataTypeTransform> mapByDataTypeCache=new LRUMap<DataType, IdentityDataTypeTransform>(100);

    public static final DataTypeTransform VOID = register(DataTypeFactory.VOID);
    public static final DataTypeTransform STRING = register(DataTypeFactory.STRING);
    public static final DataTypeTransform STRING_UNLIMITED = register(StringType.UNLIMITED);
    public static final DataTypeTransform BOOLEAN = register(DataTypeFactory.BOOLEAN);
    public static final DataTypeTransform BIGINT = register(DataTypeFactory.BIGINT);
    public static final DataTypeTransform INT = register(DataTypeFactory.INT);
    public static final DataTypeTransform LONG = register(DataTypeFactory.LONG);
    @PortabilityHint(target = "C#", name = "suppress") //no supported
    public static final DataTypeTransform BIGDECIMAL = register(DataTypeFactory.BIGDECIMAL);
    public static final DataTypeTransform DOUBLE = register(DataTypeFactory.DOUBLE);
    public static final DataTypeTransform FLOAT = register(DataTypeFactory.FLOAT);
    public static final DataTypeTransform DATE = register(DataTypeFactory.DATE);
    public static final DataTypeTransform TIME = register(DataTypeFactory.TIME);
    public static final DataTypeTransform DATETIME = register(DataTypeFactory.DATETIME);
    public static final DataTypeTransform OBJECT = register(DataTypeFactory.OBJECT);

    private final DataType sourceType;

    public static IdentityDataTypeTransform ofType(Class sourceType) {
        IdentityDataTypeTransform found = mapByType.get(sourceType);
        if(found==null){
            found=new IdentityDataTypeTransform(DataTypeFactory.forPlatformType(sourceType));
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
        mapByDataType.put(DataTypeFactory.forPlatformType(sourceType), value);
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
