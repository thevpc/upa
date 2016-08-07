/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.util.DateUtils;
import net.vpc.upa.types.*;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class ValueParser {

    public static Object parse(Object value, DataType type) {
        if(type.getPlatformType().isInstance(value)){
            type.check(value, null, null);
            return value;
        }
        if (type instanceof StringType) {
            StringType t = (StringType) type;
            if (value != null) {
                value = String.valueOf(value);
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof EnumType) {
            EnumType t = (EnumType) type;
            if (value != null) {
                value=Enum.valueOf(t.getPlatformType(), String.valueOf(value));
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof IntType) {
            IntType t = (IntType) type;
            if (value != null) {
                if (!(value instanceof Integer)) {
                    if (value instanceof String) {
                        value = Integer.parseInt(String.valueOf(value).trim());
                    } else if (Number.class.isAssignableFrom(value.getClass())) {
                        value = (((Number) (value)).intValue());
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof LongType) {
            LongType t = (LongType) type;
            if (value != null) {
                if (!(value instanceof Long)) {
                    if (value instanceof String) {
                        value = Long.parseLong(String.valueOf(value).trim());
                    } else if (Number.class.isAssignableFrom(value.getClass())) {
                        value = (((Number) (value)).longValue());
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof ShortType) {
            ShortType t = (ShortType) type;
            if (value != null) {
                if (!(value instanceof Short)) {
                    if (value instanceof String) {
                        value = Short.parseShort(String.valueOf(value).trim());
                    } else if (Number.class.isAssignableFrom(value.getClass())) {
                        value = (((Number) (value)).shortValue());
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof ByteType) {
            ByteType t = (ByteType) type;
            if (value != null) {
                if (!(value instanceof Byte)) {
                    if (value instanceof String) {
                        value = Byte.parseByte(String.valueOf(value).trim());
                    } else if (Number.class.isAssignableFrom(value.getClass())) {
                        value = (((Number) (value)).byteValue());
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof FloatType) {
            FloatType t = (FloatType) type;
            if (value != null) {
                if (!(value instanceof Float)) {
                    if (value instanceof String) {
                        value = Float.parseFloat(String.valueOf(value).trim());
                    } else if (Number.class.isAssignableFrom(value.getClass())) {
                        value = (((Number) (value)).floatValue());
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof DoubleType) {
            DoubleType t = (DoubleType) type;
            if (value != null) {
                if (!(value instanceof Double)) {
                    if (value instanceof String) {
                        value = Double.parseDouble(String.valueOf(value).trim());
                    } else if (Number.class.isAssignableFrom(value.getClass())) {
                        value = (((Number) (value)).floatValue());
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof TemporalType) {
            TemporalType t = (TemporalType) type;
            if (value != null) {
                if (!(value instanceof java.util.Date)) {
                    if (value instanceof String) {
                        if(t instanceof DateType){
                            value = DateUtils.parseUniversalDate(String.valueOf(value).trim());
                        }else if (t instanceof DateTimeType){
                            value = DateUtils.parseUniversalDateTime(String.valueOf(value).trim());
                        }else if (t instanceof TimeType){
                            value = DateUtils.parseUniversalTime(String.valueOf(value).trim());
                        }else if (t instanceof TimestampType){
                            value = DateUtils.parseUniversalTimestamp(String.valueOf(value).trim());
                        }else if (t instanceof YearType){
                            value = DateUtils.parseUniversalYear(String.valueOf(value).trim());
                        }else if (t instanceof MonthType){
                            value = DateUtils.parseUniversalMonth(String.valueOf(value).trim());
                        }else{
                            throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                        }
                        value = type.convert(value);
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                } else {
                    value = t.convert(value);
                }
            }
            t.check(value, null, null);
            return value;
        }
        if (type instanceof BooleanType) {
            BooleanType t = (BooleanType) type;
            if (value != null) {
                if (!(value instanceof Boolean)) {
                    if (value instanceof String) {
                            value = Boolean.parseBoolean(String.valueOf(value).trim());
                    }else if (value instanceof Number) {
                            value = ((Number)value).doubleValue()!=0;
                    } else {
                        throw new IllegalArgumentException("Unsupported Convertion from " + value.getClass() + " to "+type);
                    }
                } else {
                    value = t.convert(value);
                }
            }
            t.check(value, null, null);
            return value;
        }
        throw new IllegalArgumentException("UnsupportedType from " + (value == null ? "null" : value.getClass().getName()) + " to " + type);
    }
}
