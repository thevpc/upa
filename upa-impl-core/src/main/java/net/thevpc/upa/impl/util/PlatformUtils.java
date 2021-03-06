package net.thevpc.upa.impl.util;

import net.thevpc.upa.Document;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.UPA;
import net.thevpc.upa.config.*;
import net.thevpc.upa.impl.config.decorations.AnnotationDecoration;
import net.thevpc.upa.impl.config.decorations.DecorationPrimitiveValue;
import net.thevpc.upa.impl.config.decorations.DecorationRepository;
import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.util.classpath.ClassFileIterator;
import net.thevpc.upa.impl.util.classpath.ClassFileIteratorFactory;
import net.thevpc.upa.impl.util.classpath.ClassFilter;
import net.thevpc.upa.impl.util.classpath.ClassPathFilter;
import net.thevpc.upa.types.*;
import net.thevpc.upa.types.Date;
import net.thevpc.upa.types.Temporal;

import net.thevpc.upa.Entity;
import net.thevpc.upa.config.*;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.filters.ObjectFilter;
import net.thevpc.upa.types.*;

import java.io.IOException;
import java.io.InputStream;
import java.lang.annotation.Annotation;
import java.lang.reflect.Array;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.net.URL;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:29 PM
 */
@PortabilityHint(target = "C#", name = "partial")
public class PlatformUtils {

    public final static Map<Class, Object> DEFAULT_VALUES_BY_TYPE = new HashMap<Class, Object>();
    public final static Map<Class, Integer> TYPE_TO_INT_FLAGS = new HashMap<Class, Integer>(20);
    public final static Map<Class, Class> PRIMITIVE_TO_REF_TYPES = new HashMap<Class, Class>();
    public final static Map<Class, Class> REF_TO_PRIMITIVE_TYPES = new HashMap<Class, Class>();
    public final static java.util.Date MIN_DATE = new java.util.Date(0);
    public static final String METHOD_GET_PREFIX = "get";
    public static final String METHOD_SET_PREFIX = "set";
    public static final String METHOD_IS_PREFIX = "is";

    public static final int TYPE_MASK_FLAGS = ((1 << 4) - 1);
    public static final int TYPE_FLAGS_NULLABLE = 1;
    public static final int TYPE_FLAGS_ARRAY = 2;

    public static final int TYPE_MASK_MAJOR = ((1 << 3) - 1) << 4;
    public static final int TYPE_MAJOR_BOOLEAN = 1 << 4;
    public static final int TYPE_MAJOR_NUMBER = 2 << 4;
    public static final int TYPE_MAJOR_STRING = 3 << 4;
    public static final int TYPE_MAJOR_TEMPORAL = 4 << 4;
    public static final int TYPE_MAJOR_OTHER = 5 << 4;

    public static final int TYPE_MASK_MINOR = (((1 << 4) - 1) << 7);
    public static final int TYPE_MINOR_INT = (1 << 7);
    public static final int TYPE_MINOR_FLOAT = (2 << 7);
    public static final int TYPE_MINOR_DECIMAL = (3 << 7);

    public static final int TYPE_MINOR_CHAR = (1 << 7);
    public static final int TYPE_MINOR_CHARS = (2 << 7);

    public static final int TYPE_MINOR_TIME = (1 << 7);
    public static final int TYPE_MINOR_DATE = (2 << 7);
    public static final int TYPE_MINOR_DATETIME = (3 << 7);
    public static final int TYPE_MINOR_TIMESTAMP = (4 << 7);
    public static final int TYPE_MINOR_MONTH = (5 << 7);
    public static final int TYPE_MINOR_YEAR = (6 << 7);

    public static final int TYPE_MASK_SIZE = (((1 << 3) - 1) << 11);
    public static final int TYPE_SIZE_1 = (1 << 11);
    public static final int TYPE_SIZE_8 = (2 << 11);
    public static final int TYPE_SIZE_16 = (3 << 11);
    public static final int TYPE_SIZE_32 = (4 << 11);
    public static final int TYPE_SIZE_64 = (5 << 11);
    public static final int TYPE_SIZE_128 = (6 << 11);
    public static final int TYPE_SIZE_BIG = (7 << 11);

    private static final Logger log = Logger.getLogger(PlatformUtils.class.getName());
    private static final Map<Class, String> typeNames = new HashMap<Class, String>();
    private static PlatformTypeProxy proxyFactory;
    private static ClassFileIteratorFactory[] classFileIteratorFactories = null;
    private static final Map<Class, PlatformBeanTypeCache> classBeanTypeReflectorMap = new HashMap<Class, PlatformBeanTypeCache>();

    static {
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Short.TYPE, (short) 0);
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Long.TYPE, 0L);
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Integer.TYPE, 0);
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Double.TYPE, 0.0);
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Float.TYPE, 0.0f);
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Byte.TYPE, (byte) 0);
        PlatformUtils.DEFAULT_VALUES_BY_TYPE.put(Character.TYPE, (char) 0);

        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Short.TYPE, Short.class);
        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Long.TYPE, Long.class);
        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Integer.TYPE, Integer.class);
        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Double.TYPE, Double.class);
        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Float.TYPE, Float.class);
        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Byte.TYPE, Byte.class);
        PlatformUtils.PRIMITIVE_TO_REF_TYPES.put(Character.TYPE, Character.class);

        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Short.class, Short.TYPE);
        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Long.class, Long.TYPE);
        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Integer.class, Integer.TYPE);
        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Double.class, Double.TYPE);
        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Float.class, Float.TYPE);
        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Byte.class, Byte.TYPE);
        PlatformUtils.REF_TO_PRIMITIVE_TYPES.put(Character.class, Character.TYPE);

        typeNames.put(String.class, "string");
        typeNames.put(Integer.class, "int");
        typeNames.put(Integer.TYPE, "int");
        typeNames.put(Short.class, "short");
        typeNames.put(Short.TYPE, "short");
        typeNames.put(Byte.class, "byte");
        typeNames.put(Byte.TYPE, "byte");
        typeNames.put(Long.class, "long");
        typeNames.put(Long.TYPE, "long");
        typeNames.put(Float.class, "float");
        typeNames.put(Float.TYPE, "float");
        typeNames.put(Double.class, "double");
        typeNames.put(Double.TYPE, "double");
        typeNames.put(Boolean.class, "boolean");
        typeNames.put(Boolean.TYPE, "boolean");
        typeNames.put(java.util.Date.class, "datetime");
        typeNames.put(java.sql.Date.class, "date");
        typeNames.put(java.sql.Time.class, "time");
        typeNames.put(java.sql.Timestamp.class, "timestamp");
        typeNames.put(DateTime.class, "datetime");
        typeNames.put(Date.class, "date");
        typeNames.put(Time.class, "time");
        typeNames.put(Timestamp.class, "timestamp");
        typeNames.put(Year.class, "year");
        typeNames.put(Month.class, "month");
        typeNames.put(BigInteger.class, "bigint");
        /**
         * @PortabilityHint(target="C#",name="suppress")
         */
        typeNames.put(BigDecimal.class, "bigdecimal");
        typeNames.put(Object.class, "object");
        typeNames.put(byte[].class, "blob");
        typeNames.put(Byte[].class, "rblob");
        typeNames.put(char[].class, "clob");
        typeNames.put(Character[].class, "rclob");
    }

    public static Class toRefType(Class type) {
        Class t = PRIMITIVE_TO_REF_TYPES.get(type);
        if (t != null) {
            return t;
        }
        return type;
    }

    public static Class toPrimitiveType(Class type) {
        Class t = REF_TO_PRIMITIVE_TYPES.get(type);
        if (t != null) {
            return t;
        }
        return type;
    }

    public static Class getExprNumberType(Class numberClass1, Class numberClass2) {
        boolean nullable = !numberClass1.isPrimitive() || !numberClass2.isPrimitive();
        if (isAnyInteger(numberClass1) && isAnyInteger(numberClass2)) {
            int w1 = getIntWeight(numberClass1);
            int w2 = getIntWeight(numberClass2);
            Class t = (w1 >= w2) ? numberClass1 : numberClass2;
            return nullable ? toRefType(t) : toPrimitiveType(t);
        } else if (isAnyInteger(numberClass1) && isAnyFloat(numberClass2)) {
            numberClass1
                    = isInt8(numberClass1) ? Float.class
                    : isInt16(numberClass1) ? Float.class
                    : isInt32(numberClass1) ? Float.class
                    : isInt64(numberClass1) ? Double.class
                    : isBigInt(numberClass1) ? BigDecimal.class
                    : BigDecimal.class;
            return getExprNumberType(numberClass1, numberClass2);
        } else if (isAnyFloat(numberClass1) && isAnyInteger(numberClass2)) {
            return getExprNumberType(numberClass2, numberClass1);
        } else if (isAnyFloat(numberClass1) && isAnyFloat(numberClass2)) {
            int w1 = getFloatWeight(numberClass1);
            int w2 = getFloatWeight(numberClass2);
            Class t = (w1 >= w2) ? numberClass1 : numberClass2;
            return nullable ? toRefType(t) : toPrimitiveType(t);
        }
        throw new IllegalUPAArgumentException("Invalid Number Expr " + numberClass1 + " , " + numberClass2);
    }

    public static int getIntWeight(Class clazz) {
        int pos = 0;

        pos++;
        if (isInt8(clazz)) {
            return pos;
        }

        pos++;
        if (isInt16(clazz)) {
            return pos;
        }

        pos++;
        if (isInt32(clazz)) {
            return pos;
        }

        pos++;
        if (isInt64(clazz)) {
            return pos;
        }

        pos++;
        if (isInt128(clazz)) {
            return pos;
        }

        pos++;
        if (isBigInt(clazz)) {
            return pos;
        }

        throw new IllegalUPAArgumentException("Not an integer");
    }

    public static int getFloatWeight(Class clazz) {
        int pos = 0;
        pos++;
        if (isFloat32(clazz)) {
            return pos;
        }

        pos++;
        if (isFloat64(clazz)) {
            return pos;
        }
        pos++;
        if (isBigFloat(clazz)) {
            return pos;
        }
        throw new IllegalUPAArgumentException("Not an integer");
    }

    public static boolean isTime(Class clazz) {
        return java.sql.Time.class.isAssignableFrom(clazz) || Time.class.isAssignableFrom(clazz);
    }

    public static boolean isDateOnly(Class clazz) {
        return java.sql.Date.class.isAssignableFrom(clazz) || Date.class.isAssignableFrom(clazz);
    }

    public static boolean isDateTime(Class clazz) {
        return java.util.Date.class.equals(clazz)
                || DateTime.class.isAssignableFrom(clazz);
    }

    public static boolean isTimestamp(Class clazz) {
        return java.sql.Timestamp.class.isAssignableFrom(clazz)
                || Timestamp.class.isAssignableFrom(clazz);
    }

    public static boolean isMonth(Class clazz) {
        return Month.class.isAssignableFrom(clazz);
    }

    public static boolean isYear(Class clazz) {
        return Year.class.isAssignableFrom(clazz);
    }

    public static boolean isAnyDate(Class clazz) {
        return java.util.Date.class.isAssignableFrom(clazz);
    }

    public static boolean isIntAny(Class clazz) {
        return clazz.equals(Byte.class)
                || clazz.equals(Byte.TYPE)
                || clazz.equals(Short.class)
                || clazz.equals(Short.TYPE)
                || clazz.equals(Integer.class)
                || clazz.equals(Integer.TYPE)
                || clazz.equals(Long.class)
                || clazz.equals(Long.TYPE)
                || clazz.equals(BigInteger.class);
    }

    public static boolean isFloatAny(Class clazz) {
        return clazz.equals(Float.class)
                || clazz.equals(Float.TYPE)
                || clazz.equals(Double.class)
                || clazz.equals(Double.TYPE)
                || clazz.equals(BigDecimal.class);
    }

    public static boolean isString(Class clazz) {
        return clazz.equals(String.class)
                || clazz.equals(Character.class)
                || clazz.equals(Character.TYPE);
    }

    public static boolean isDecimal128(Class clazz) {
        return BigDecimal.class.equals(clazz);
    }

    public static boolean isInt128(Class clazz) {
        return BigInteger.class.equals(clazz);
    }

    public static boolean isInt64(Class clazz) {
        return Long.class.equals(clazz)
                || Long.TYPE.equals(clazz);
    }

    public static boolean isInt32(Class clazz) {
        return Integer.class.equals(clazz)
                || Integer.TYPE.equals(clazz);
    }

    public static boolean isInt16(Class clazz) {
        return Short.class.equals(clazz)
                || Short.TYPE.equals(clazz);
    }

    public static boolean isInt8(Class clazz) {
        return Byte.class.equals(clazz)
                || Byte.TYPE.equals(clazz);
    }

    public static boolean isEnum(Class clazz) {
        return Enum.class.isInstance(clazz);
    }

    public static DataTypeTransform getDataTypeTransformAfterImplicitConversion(DataTypeTransform cls1, DataTypeTransform cls2) {
        Class platformTypeAfterImplicitConversion = getPlatformTypeAfterImplicitConversion(cls1.getTargetType().getPlatformType(), cls2.getTargetType().getPlatformType());
        return IdentityDataTypeTransform.ofType(platformTypeAfterImplicitConversion);
    }

    public static DataTypeTransform getDataTypeTransformAfterImplicitConversionPlus(DataTypeTransform cls1, DataTypeTransform cls2) {
        Class platformTypeAfterImplicitConversion = getPlatformTypeAfterImplicitConversionPlus(cls1.getTargetType().getPlatformType(), cls2.getTargetType().getPlatformType());
        return IdentityDataTypeTransform.ofType(platformTypeAfterImplicitConversion);
    }

    public static Class getPlatformTypeAfterImplicitConversion(Class cls1, Class cls2) {
        if (cls1.equals(cls2)) {
            return cls1;
        }
        int t1 = getPlatformType(cls1);
        int t2 = getPlatformType(cls2);
        boolean nullable = ((t1 & TYPE_FLAGS_NULLABLE) == TYPE_FLAGS_NULLABLE) || ((t2 & TYPE_FLAGS_NULLABLE) == TYPE_FLAGS_NULLABLE);
        if ((t1 & TYPE_MAJOR_NUMBER) == TYPE_MAJOR_NUMBER && (t1 & TYPE_MAJOR_NUMBER) == TYPE_MAJOR_NUMBER) {
            if ((t1 & TYPE_MINOR_FLOAT) == TYPE_MINOR_FLOAT || (t1 & TYPE_MINOR_FLOAT) == TYPE_MINOR_FLOAT) {
                if ((t1 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG || (t2 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_128) == TYPE_SIZE_128 || (t2 & TYPE_SIZE_128) == TYPE_SIZE_128) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_64) == TYPE_SIZE_64 || (t2 & TYPE_SIZE_64) == TYPE_SIZE_64) {
                    return nullable ? Double.class : Double.TYPE;
                } else if ((t1 & TYPE_SIZE_32) == TYPE_SIZE_32 || (t2 & TYPE_SIZE_32) == TYPE_SIZE_32) {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                } else {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                }
            } else if ((t1 & TYPE_MINOR_DECIMAL) == TYPE_MINOR_DECIMAL || (t1 & TYPE_MINOR_DECIMAL) == TYPE_MINOR_DECIMAL) {
                if ((t1 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG || (t2 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_128) == TYPE_SIZE_128 || (t2 & TYPE_SIZE_128) == TYPE_SIZE_128) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_64) == TYPE_SIZE_64 || (t2 & TYPE_SIZE_64) == TYPE_SIZE_64) {
                    return nullable ? Double.class : Double.TYPE;
                } else if ((t1 & TYPE_SIZE_32) == TYPE_SIZE_32 || (t2 & TYPE_SIZE_32) == TYPE_SIZE_32) {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                } else {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                }
            } else if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                if ((t1 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG || (t2 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG) {
                    return BigInteger.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_128) == TYPE_SIZE_128 || (t2 & TYPE_SIZE_128) == TYPE_SIZE_128) {
                    return BigInteger.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_64) == TYPE_SIZE_64 || (t2 & TYPE_SIZE_64) == TYPE_SIZE_64) {
                    return nullable ? Long.class : Long.TYPE;
                } else if ((t1 & TYPE_SIZE_32) == TYPE_SIZE_32 || (t2 & TYPE_SIZE_32) == TYPE_SIZE_32) {
                    return nullable ? Integer.class : Integer.TYPE;
                } else if ((t1 & TYPE_SIZE_16) == TYPE_SIZE_16 || (t2 & TYPE_SIZE_16) == TYPE_SIZE_16) {
                    return nullable ? Short.class : Short.TYPE;
                } else if ((t1 & TYPE_SIZE_8) == TYPE_SIZE_8 || (t2 & TYPE_SIZE_8) == TYPE_SIZE_8) {
                    return nullable ? Byte.class : Byte.TYPE;
                } else {
                    throw new IllegalUPAArgumentException("UnsupportedImplicitConversion", cls1, cls2);
                }
            } else {
                throw new IllegalUPAArgumentException("UnsupportedImplicitConversion", cls1, cls2);
            }
        } else {
            throw new IllegalUPAArgumentException("UnsupportedImplicitConversion", cls1, cls2);
        }
    }

    public static Class getPlatformTypeAfterImplicitConversionPlus(Class cls1, Class cls2) {
        if (cls1.equals(cls2)) {
            return cls1;
        }
        int t1 = getPlatformType(cls1);
        int t2 = getPlatformType(cls2);
        boolean nullable = ((t1 & TYPE_FLAGS_NULLABLE) == TYPE_FLAGS_NULLABLE) || ((t2 & TYPE_FLAGS_NULLABLE) == TYPE_FLAGS_NULLABLE);
        if ((t1 & TYPE_MAJOR_NUMBER) == TYPE_MAJOR_NUMBER && (t1 & TYPE_MAJOR_NUMBER) == TYPE_MAJOR_NUMBER) {
            if ((t1 & TYPE_MINOR_FLOAT) == TYPE_MINOR_FLOAT || (t1 & TYPE_MINOR_FLOAT) == TYPE_MINOR_FLOAT) {
                if ((t1 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG || (t2 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_128) == TYPE_SIZE_128 || (t2 & TYPE_SIZE_128) == TYPE_SIZE_128) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_64) == TYPE_SIZE_64 || (t2 & TYPE_SIZE_64) == TYPE_SIZE_64) {
                    return nullable ? Double.class : Double.TYPE;
                } else if ((t1 & TYPE_SIZE_32) == TYPE_SIZE_32 || (t2 & TYPE_SIZE_32) == TYPE_SIZE_32) {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                } else {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                }
            } else if ((t1 & TYPE_MINOR_DECIMAL) == TYPE_MINOR_DECIMAL || (t1 & TYPE_MINOR_DECIMAL) == TYPE_MINOR_DECIMAL) {
                if ((t1 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG || (t2 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_128) == TYPE_SIZE_128 || (t2 & TYPE_SIZE_128) == TYPE_SIZE_128) {
                    return BigDecimal.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_64) == TYPE_SIZE_64 || (t2 & TYPE_SIZE_64) == TYPE_SIZE_64) {
                    return nullable ? Double.class : Double.TYPE;
                } else if ((t1 & TYPE_SIZE_32) == TYPE_SIZE_32 || (t2 & TYPE_SIZE_32) == TYPE_SIZE_32) {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                } else {
                    if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t2 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                        return nullable ? Double.class : Double.TYPE;
                    } else {
                        return nullable ? Float.class : Float.TYPE;
                    }
                }
            } else if ((t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT || (t1 & TYPE_MINOR_INT) == TYPE_MINOR_INT) {
                if ((t1 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG || (t2 & TYPE_SIZE_BIG) == TYPE_SIZE_BIG) {
                    return BigInteger.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_128) == TYPE_SIZE_128 || (t2 & TYPE_SIZE_128) == TYPE_SIZE_128) {
                    return BigInteger.class;//no other possibilities
                } else if ((t1 & TYPE_SIZE_64) == TYPE_SIZE_64 || (t2 & TYPE_SIZE_64) == TYPE_SIZE_64) {
                    return nullable ? Long.class : Long.TYPE;
                } else if ((t1 & TYPE_SIZE_32) == TYPE_SIZE_32 || (t2 & TYPE_SIZE_32) == TYPE_SIZE_32) {
                    return nullable ? Integer.class : Integer.TYPE;
                } else if ((t1 & TYPE_SIZE_16) == TYPE_SIZE_16 || (t2 & TYPE_SIZE_16) == TYPE_SIZE_16) {
                    return nullable ? Short.class : Short.TYPE;
                } else if ((t1 & TYPE_SIZE_8) == TYPE_SIZE_8 || (t2 & TYPE_SIZE_8) == TYPE_SIZE_8) {
                    return nullable ? Byte.class : Byte.TYPE;
                } else {
                    throw new IllegalUPAArgumentException("UnsupportedImplicitConversion", cls1, cls2);
                }
            } else {
                throw new IllegalUPAArgumentException("UnsupportedImplicitConversion", cls1, cls2);
            }
        } else if ((t1 & TYPE_MAJOR_NUMBER) == TYPE_MAJOR_NUMBER && (t1 & TYPE_MAJOR_STRING) == TYPE_MAJOR_STRING) {
            return String.class;
        } else if ((t1 & TYPE_MAJOR_STRING) == TYPE_MAJOR_STRING && (t1 & TYPE_MAJOR_NUMBER) == TYPE_MAJOR_NUMBER) {
            return String.class;
        } else if ((t1 & TYPE_MAJOR_STRING) == TYPE_MAJOR_STRING && (t1 & TYPE_MAJOR_STRING) == TYPE_MAJOR_STRING) {
            return String.class;
        } else {
            throw new IllegalUPAArgumentException("UnsupportedImplicitConversion", cls1, cls2);
        }
    }

    public static int getPlatformType(Class cls) {
        Integer value = TYPE_TO_INT_FLAGS.get(cls);
        if (value == null) {
            final String clsName = cls.getName();
            if (null == clsName) {
                value = TYPE_MAJOR_OTHER | TYPE_FLAGS_NULLABLE;
            } else switch (clsName) {
                case "java.lang.Boolean":
                    value = TYPE_MAJOR_BOOLEAN | TYPE_FLAGS_NULLABLE;
                    break;
                case "boolean":
                    value = TYPE_MAJOR_BOOLEAN;
                    break;
                case "java.lang.Byte":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_8 | TYPE_FLAGS_NULLABLE;
                    break;
                case "byte":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_8;
                    break;
                case "java.lang.Short":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_16 | TYPE_FLAGS_NULLABLE;
                    break;
                case "short":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_16;
                    break;
                case "java.lang.Integer":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_32 | TYPE_FLAGS_NULLABLE;
                    break;
                case "int":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_32;
                    break;
                case "java.lang.Long":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_64 | TYPE_FLAGS_NULLABLE;
                    break;
                case "long":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_64;
                    break;
                case "java.math.BigInteger":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_BIG | TYPE_FLAGS_NULLABLE;
                    break;
                case "java.lang.Float":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_FLOAT | TYPE_SIZE_32 | TYPE_FLAGS_NULLABLE;
                    break;
                case "float":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_FLOAT | TYPE_SIZE_32;
                    break;
                case "java.lang.Double":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_FLOAT | TYPE_SIZE_64 | TYPE_FLAGS_NULLABLE;
                    break;
                case "double":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_FLOAT | TYPE_SIZE_64;
                    break;
                case "java.math.BigDecimal":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_DECIMAL | TYPE_SIZE_BIG | TYPE_FLAGS_NULLABLE;
                    break;
                case "java.lang.String":
                    value = TYPE_MAJOR_STRING | TYPE_FLAGS_NULLABLE | TYPE_SIZE_BIG | TYPE_MINOR_CHARS;
                    break;
                case "java.lang.Character":
                    value = TYPE_MAJOR_STRING | TYPE_FLAGS_NULLABLE | TYPE_SIZE_16 | TYPE_MINOR_CHAR;
                    break;
                case "char":
                    value = TYPE_MAJOR_STRING | TYPE_SIZE_16 | TYPE_MINOR_CHAR;
                    break;
                case "[C":
                    value = TYPE_MAJOR_STRING | TYPE_SIZE_16 | TYPE_MINOR_CHAR | TYPE_FLAGS_ARRAY | TYPE_FLAGS_NULLABLE;
                    break;
                case "[Ljava.lang.Character;":
                    value = TYPE_MAJOR_STRING | TYPE_SIZE_16 | TYPE_MINOR_CHAR | TYPE_FLAGS_ARRAY | TYPE_FLAGS_NULLABLE;
                    break;
                case "[B":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_8 | TYPE_FLAGS_ARRAY | TYPE_FLAGS_NULLABLE;
                    break;
                case "[Ljava.lang.Byte;":
                    value = TYPE_MAJOR_NUMBER | TYPE_MINOR_INT | TYPE_SIZE_8 | TYPE_FLAGS_ARRAY | TYPE_FLAGS_NULLABLE;
                    break;
                default:
                    value = TYPE_MAJOR_OTHER | TYPE_FLAGS_NULLABLE;
                    break;
            }

            TYPE_TO_INT_FLAGS.put(cls, value);
        }
        return value.intValue();
    }

    public static boolean isBigInt(Class clazz) {
        return BigInteger.class.equals(clazz);
    }

    public static boolean isBigFloat(Class clazz) {
        return BigDecimal.class.equals(clazz);
    }

    public static boolean isFloat32(Class clazz) {
        return Float.class.equals(clazz)
                || Float.TYPE.equals(clazz);
    }

    public static boolean isFloat64(Class clazz) {
        return Double.class.equals(clazz)
                || Double.TYPE.equals(clazz);
    }

    public static boolean isBool(Class clazz) {
        return Boolean.class.equals(clazz)
                || Boolean.TYPE.equals(clazz);
    }

    public static boolean isAnyInteger(Class clazz) {
        return Integer.class.equals(clazz)
                || Integer.TYPE.equals(clazz)
                || Long.class.equals(clazz)
                || Long.TYPE.equals(clazz)
                || Short.class.equals(clazz)
                || Short.TYPE.equals(clazz)
                || Byte.class.equals(clazz)
                || Byte.TYPE.equals(clazz)
                || BigInteger.class.equals(clazz);
    }

    public static boolean isAnyFloat(Class clazz) {
        return Float.class.equals(clazz)
                || Float.TYPE.equals(clazz)
                || Double.class.equals(clazz)
                || Double.TYPE.equals(clazz)
                || BigDecimal.class.equals(clazz);
    }

    public static boolean isAnyNumber(Class clazz) {
        return Number.class.isAssignableFrom(clazz);
    }

    public static ClassLoader getContextClassLoader() {
        return Thread.currentThread().getContextClassLoader();
    }

    public static boolean isSystemClassLoader() {
        return Thread.currentThread().getContextClassLoader() == ClassLoader.getSystemClassLoader();
    }

    public static Class forName(String name, boolean initialize, ClassLoader classLoader) throws ClassNotFoundException {
        return Class.forName(name, initialize, classLoader);
    }

    public static Class forName(String name) throws ClassNotFoundException {
        /**
         * @PortabilityHint(target = "C#", name = "replace") return
         * System.Type.GetType (name, true);
         */
        {
            ClassLoader contextClassLoader = Thread.currentThread().getContextClassLoader();
            return Class.forName(name, true, contextClassLoader);
        }
    }

    public static <T> T convert(Object value, Class<T> to) {
        if (value == null || isInstance(to, value)) {
            return (T) value;
        }

        if (to.isEnum()) {
            if (value instanceof String) {
                return (T) Enum.valueOf((Class) to, (String) value);
            } else if (value instanceof Integer) {
                return (T) getEnumValues(to)[(Integer) value];
            }
        }
        return to.cast(value);
    }

    public static boolean isNullableType(Class type) {
        return !type.isPrimitive();
    }

    public static boolean isPrimitiveType(Class type) {
        return type.isPrimitive();
    }

    public static Class toTemporalType(TemporalOption temporalOption, Class baseType) {
        Class upaBaseType = Temporal.class;
        Class osBaseType = java.util.Date.class;
        Class upaType = null;
        Class osType = null;
        switch (temporalOption) {
            case TIME: {
                upaType = Time.class;
                osType = java.sql.Time.class;
                break;
            }
            case DATE: {
                upaType = Date.class;
                osType = java.sql.Date.class;
                break;
            }
            case DATETIME: {
                upaType = DateTime.class;
                osType = java.sql.Timestamp.class;
                break;
            }
            case TIMESTAMP: {
                upaType = Timestamp.class;
                osType = java.sql.Timestamp.class;
                break;
            }
            case MONTH: {
                upaType = Month.class;
                osType = java.sql.Date.class;
                break;
            }
            case YEAR: {
                upaType = Year.class;
                osType = java.sql.Date.class;
                break;
            }
            case DEFAULT: {
                upaType = DateTime.class;
                osType = java.sql.Timestamp.class;
                break;
            }
            default: {
                throw new IllegalUPAArgumentException("Unsupported Temperal " + temporalOption);
            }
        }
        if (baseType == null) {
            return upaType;
        }
        if (osType.isAssignableFrom(baseType)) {
            return osType;
        }
        if (osBaseType.equals(baseType)) {
            return upaType;
        }
        if (upaBaseType.equals(baseType)) {
            return upaType;
        }
        return upaType;
    }

    public static String getTypeName(Class clazz) {
        return typeNames.get(clazz);
    }

    public static boolean isVoid(Class c) {
        return c.equals(Void.TYPE) || c.equals(Void.class);
    }

    public static <T> List<T> emptyList() {
        return Collections.EMPTY_LIST;
    }

    public static <T> List<Object> typedListToObjectList(List<T> anyList) {
        if (anyList == null) {
            return null;
        }
        ArrayList<Object> list = new ArrayList<Object>();
        for (T i : anyList) {
            list.add(i);
        }
        return list;
    }

    public static List<Object> anyObjectToObjectList(Object anyList) {
        if (anyList == null) {
            return null;
        }
        ArrayList<Object> list = new ArrayList<Object>();
        for (Object i : (List<Object>) anyList) {
            list.add(i);
        }
        return list;
    }

    @PortabilityHint(target = "C#", name = "ignore")
    public static <T> List<Object> anyListToObjectList(List anyList) {
        if (anyList == null) {
            return null;
        }
        ArrayList<Object> list = new ArrayList<Object>();
        for (Object i : anyList) {
            list.add(i);
        }
        return list;
    }

    public static <T> List<T> unmodifiableList(List<T> list) {
        return new ArrayList<T>(list);
    }

    public static <K, T> Map<K, T> unmodifiableMap(Map<K, T> map) {
        return new HashMap<K, T>(map);
    }

    public static <T> void addAll(List<T> list, T[] arr) {
        list.addAll(Arrays.asList(arr));
    }

    public static String arrayToString(Object[] arr) {
        if (arr == null) {
            return "null";
        }
        StringBuilder sb = new StringBuilder("[");
        for (int i = 0; i < arr.length; i++) {
            if (i > 0) {
                sb.append(", ");
            }
            sb.append(String.valueOf(arr[i]));
        }
        sb.append("]");
        return sb.toString();
    }

    public static Object newInstance(Class clazz) {
        try {
            return clazz.getDeclaredConstructor().newInstance();
        } catch (Exception ex) {
            log.log(Level.SEVERE, null, ex);
            throw new UPAException(ex, new I18NString("InstantationError"));
        }
    }

    public static Object[] getEnumValues(Class enumType) {
        /**
         * @PortabilityHint(target = "C#", name = "replace") return
         * (object[])System.Enum.GetValues(enumType);
         */
        try {
            return ((Object[]) enumType.getEnumConstants());
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static Decoration getDecoration(Class type, Class annotationClass, String persistenceGroup, String persistenceUnit, DecorationRepository repository) {
        Decoration a = repository.getTypeDecoration(type, annotationClass);
        if (a != null && acceptAnnotation(a, persistenceGroup, persistenceUnit)) {
            return a;
        }
        return null;
    }

    private static boolean acceptAnnotation(Decoration a, String persistenceGroup, String persistenceUnit) {
        if (a == null) {
            return false;
        }
        Decoration configObject = a.getDecoration("config");
        if (configObject != null) {
            String v = StringUtils.trim(configObject.getString("persistenceGroup"));
            if (!StringUtils.matchesSimpleExpression(persistenceGroup, v, PatternType.DOT_PATH)) {
                return false;
            }
            v = StringUtils.trim(configObject.getString("persistenceUnit"));
            if (!StringUtils.matchesSimpleExpression(persistenceUnit, v, PatternType.DOT_PATH)) {
                return false;
            }
        }
        return true;
    }

    public static Field findField(Class clz, String name, ObjectFilter<Field> filter) {
        Class r = clz;
        while (r != null) {
            Field f = null;
            try {
                f = r.getDeclaredField(name);
            } catch (Exception ex) {
                //ignore
            }
            if (f != null && (filter == null || filter.accept(f))) {
                return f;
            }
            r = r.getSuperclass();
        }
        return null;
    }

    public static List<Field> findFields(Class clz, String name) {
        List<Field> all = new ArrayList<Field>();
        Class r = clz;
        while (r != null) {
            Field f = null;
            try {
                f = r.getDeclaredField(name);
            } catch (Exception ex) {
                //ignore
            }
            if (f != null) {
                all.add(f);
            }
            r = r.getSuperclass();
        }
        return all;
    }

    public static String getterName(String name, Class type) {
        if (Boolean.TYPE.equals(type) /*|| Boolean.class.equals(type)*/) {
            return METHOD_IS_PREFIX + adjustTypeFirstChar(name);
        }
        return METHOD_GET_PREFIX + adjustTypeFirstChar(name);
    }

    public static boolean isCamelPrefixed(String word, String prefix) {
        return word.length() > prefix.length() + 1 && word.startsWith(prefix) && Character.isUpperCase(word.charAt(prefix.length()));
    }

    public static String toCamelCase(String name) {
        return toUpperCamelCase(name, false);
    }

    public static String toUpperCamelCase(String name, boolean processWhites) {
        switch (name.length()) {
            case 0: {
                return name;
            }
            case 1: {
                return name.toUpperCase();
            }
            default: {
                char[] chars = name.toCharArray();
                StringBuilder sb = new StringBuilder();
                boolean wasSpace = true;
                int i = 0;
                while (i < chars.length) {
                    char c = chars[i];
                    boolean isSpace = (processWhites && (Character.isWhitespace(c) || c == '_'));
                    if (!isSpace) {
                        if (wasSpace) {
                            sb.append(Character.toUpperCase(c));
                        } else {
                            sb.append(c);
                        }
                    } else if (i == 0 && c == '_') {
                        sb.append(c);
                    }
                    wasSpace = isSpace;
                    i++;
                }
                return sb.toString();
            }
        }
    }

    public static String adjustTypeFirstChar(String name) {
        char[] c = name.toCharArray();
        if (c.length > 0) {
            c[0] = Character.toUpperCase(c[0]);
        }
        return new String(c);
    }

    public static String adjustVarFirstChar(String name) {
        char[] c = name.toCharArray();
        if (c.length > 0) {
            c[0] = Character.toLowerCase(c[0]);
        }
        return new String(c);
    }

    public static String toUpperCamelCase(String name) {
        return toUpperCamelCase(name, false);
    }

    public static String toLowerCamelCase(String name) {
        return toLowerCamelCase(name, false);
    }

    public static String toLowerCamelCase(String name, boolean processWhites) {
        switch (name.length()) {
            case 0: {
                return name;
            }
            case 1: {
                return name.toUpperCase();
            }
            default: {
                char[] chars = name.toCharArray();
                StringBuilder sb = new StringBuilder();
                boolean wasSpace = true;
                int i = 0;
                while (i < chars.length) {
                    char c = chars[i];
                    boolean isSpace = (processWhites && (Character.isWhitespace(c) || c == '_'));
                    if (!isSpace) {
                        if (wasSpace) {
                            if (Character.isUpperCase(c) && i + 1 < chars.length && Character.isUpperCase(chars[i + 1])) {
                                sb.append(c);
                            } else if (i == 0) {
                                sb.append(Character.toLowerCase(c));
                            } else {
                                sb.append(Character.toUpperCase(c));
                            }
                        } else {
                            sb.append(c);
                        }
                    } else if (i == 0 && c == '_') {
                        sb.append(c);
                    }
                    wasSpace = isSpace;
                    i++;
                }
                return sb.toString();
            }
        }

    }

    public static PlatformMethodInfo getMethodInfo(Method m) {
        String name = m.getName();
        if (isCamelPrefixed(name, METHOD_SET_PREFIX)) {
            if (m.getParameterTypes().length == 1) {
                return new PlatformMethodInfo(
                        m,
                        PlatformMethodType.SETTER,
                        adjustVarFirstChar(name.substring(METHOD_SET_PREFIX.length())),
                        m.getParameterTypes()[0]
                );
            }
        } else if (isCamelPrefixed(name, METHOD_GET_PREFIX)) {
            if (m.getParameterTypes().length == 0 && m.getReturnType().equals(Void.TYPE)) {
                return new PlatformMethodInfo(
                        m,
                        PlatformMethodType.GETTER,
                        adjustVarFirstChar(name.substring(METHOD_GET_PREFIX.length())),
                        m.getReturnType()
                );
            }
        } else if (isCamelPrefixed(name, METHOD_IS_PREFIX)) {
            if (m.getParameterTypes().length == 0 && (m.getReturnType().equals(Boolean.TYPE) || m.getReturnType().equals(Boolean.class))) {
                return new PlatformMethodInfo(
                        m,
                        PlatformMethodType.GETTER,
                        adjustVarFirstChar(name.substring(METHOD_IS_PREFIX.length())),
                        m.getReturnType()
                );
            }
        }
        return new PlatformMethodInfo(
                m, PlatformMethodType.METHOD, null, null
        );
    }

    public static boolean isSetterMethod(Method m) {
        return isCamelPrefixed(m.getName(), METHOD_SET_PREFIX);
    }

    public static boolean isGetterMethod(Method m) {
        return isCamelPrefixed(m.getName(), METHOD_GET_PREFIX) || isCamelPrefixed(m.getName(), METHOD_IS_PREFIX);
    }

    public static String setterName(String name) {
        //Class<?> type = field.getDataType();
        return METHOD_SET_PREFIX + adjustTypeFirstChar(name);
    }

    public static boolean isStatic(Method method) {
        return Modifier.isStatic(method.getModifiers());
    }

    public static boolean isAbstract(Method method) {
        return Modifier.isAbstract(method.getModifiers());
    }

    public static boolean isAbstract(Class type) {
        return Modifier.isAbstract(type.getModifiers());
    }

    public static boolean isInterface(Class type) {
        return type.isInterface();
//        return Modifier.isInterface(m.getModifiers());
    }

    public static boolean isStatic(Field m) {
        return Modifier.isStatic(m.getModifiers());
    }

    public static boolean isFinal(Field m) {
        return Modifier.isFinal(m.getModifiers());
    }

    public static boolean isTransient(Field m) {
        return Modifier.isTransient(m.getModifiers());
    }

    public static Method[] getConcreteMethods(Class clz) {
        return getDeclaredMethods(clz, false, false);
    }

    public static Method[] getAllConcreteMethods(Class clz) {
        return getDeclaredMethods(clz, true, false);
    }

    public static Method[] getDeclaredMethods(Class clz, boolean includeInherited, boolean includeAbstract) {
        if (!includeInherited) {
            Method[] declaredMethods = clz.getDeclaredMethods();
            if (includeAbstract) {
                return declaredMethods;
            }
            ArrayList<Method> m = new ArrayList<Method>();
            for (Method m1 : declaredMethods) {
                if (!isAbstract(m1)) {
                    m.add(m1);
                }
            }
            return m.toArray(new Method[m.size()]);
        } else {
            ArrayList<Method> curr = new ArrayList<Method>();
            curr.addAll(Arrays.asList(getDeclaredMethods(clz, false, includeAbstract)));
            Class sc = clz.getSuperclass();
            if (sc != null) {
                curr.addAll(Arrays.asList(getDeclaredMethods(sc, includeInherited, includeAbstract)));
            }
            if (includeAbstract) {
                for (Class aInterface : clz.getInterfaces()) {
                    curr.addAll(Arrays.asList(getDeclaredMethods(aInterface, includeInherited, includeAbstract)));
                }
                //now remove duplicates
                LinkedHashMap<String, Method> noDuplicates = new LinkedHashMap<String, Method>();
                for (Method c : curr) {
                    String ms = getMethodSignature(c);
                    Method old = noDuplicates.get(ms);
                    if (old == null || isAbstract(c)) {
                        noDuplicates.put(ms, c);
                    }
                }
                return noDuplicates.values().toArray(new Method[noDuplicates.size()]);
            }
            return curr.toArray(new Method[curr.size()]);
        }
    }

    public static String getMethodSignature(Method method) {
        StringBuilder types = new StringBuilder();
        for (Class<?> parameterType : method.getParameterTypes()) {
            if (types.length() > 0) {
                types.append(",");
            }
            types.append(parameterType.getName());
        }
        return method.getName() + "(" + types + ")";
    }

    public static boolean isSerializable(Class type) {
        /**
         * @PortabilityHint(target = "C#", name = "replace") return
         * type.IsSerializable;
         */
        return java.io.Serializable.class.isAssignableFrom(type);
    }

    public static String getSystemLineSeparator() {
        /**
         * @PortabilityHint(target = "C#", name = "replace") return "\r\n";
         *
         */
        return System.getProperty("line.separator");
    }

    public static Map<String, String> getSystemProperties() {
        Map<String, String> m = new HashMap<String, String>();
        /**
         * @PortabilityHint(target = "C#", name = "ignore")
         */
        m.putAll((Map) System.getProperties());
        return m;
    }

    public static int hashCode(Object[] a) {
        if (a == null) {
            return 0;
        }

        int result = 1;

        for (Object element : a) {
            result = 31 * result + (element == null ? 0 : element.hashCode());
        }

        return result;
    }

    public static <T> boolean isUndefinedEnumValue(Class<T> type, T value) {
        /**
         * @PortabilityHint(target = "C#", name = "replace") return value ==
         * default(T);
         */
        {
            if (value == null) {
                return true;
            }
            Object v = getEnumValues(type)[0];
            if (value == v) {
                String n = ((Enum) v).name();
                if ("DEFAULT".equals(n) || "UNDEFINED".equals(n)) {
                    return true;
                }
                //type.getDeclaredField(n).getAnnotation(type)
                return false;
            }
            return false;//value==null || value == getUndefinedValue(type);
        }
    }

    public static <T> T getUndefinedValue(Class<T> type) {
        return resolveUndefinedValue(type);
    }

    public static <T> T resolveUndefinedValue(Class<T> type) {
        /**
         * @PortabilityHint(target = "C#", name = "replace") return default(T);
         */
        return null;
    }

    public static PlatformTypeProxy getProxyFactory() {
        if (proxyFactory == null) {
            proxyFactory = UPA.getBootstrapFactory().createObject(PlatformTypeProxy.class);
        }
        return proxyFactory;
    }

    public static <T> T createObjectInterceptor(Class<T> type, final PlatformMethodProxy<T> methodProxy) {
        return getProxyFactory().create(type, null, methodProxy);
    }

    public static boolean isInt32(String s) {
        try {
            Integer.parseInt(s);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    public static <X> X[] addToArray(X[] arr, X x) {
        X[] arr2 = null;
        /**
         * @PortabilityHint(target = "C#", name = "replace") arr2 = new X[arr.Length + 1];
         */
        arr2 = (X[]) Array.newInstance(arr.getClass().getComponentType(), arr.length + 1);

        System.arraycopy(arr, 0, arr2, 0, arr.length);
        arr2[arr.length] = x;
        return arr2;
    }

    public static RuntimeException createRuntimeException(Throwable t) {
        if (t.getCause() != null) {
            return createRuntimeException(t.getCause());
        }
        if (t instanceof RuntimeException) {
            return (RuntimeException) t;
        }
        return new RuntimeException(t);
    }

    //    @Deprecated
//    public static PlatformBeanProperty findPlatformBeanProperty(String field, Class platformType) {
//        String g1 = PlatformUtils.getterName(field, Object.class);
//        String g2 = PlatformUtils.getterName(field, Boolean.TYPE);
//        String s = PlatformUtils.setterName(field);
//        Class<?> x = platformType;
//        Method getter = null;
//        Method setter = null;
//        Class propertyType = null;
//        LinkedHashMap<Class, Method> setters = new LinkedHashMap<Class, Method>();
//        while (x != null) {
//            for (Method m : x.getDeclaredMethods()) {
//                if (!PlatformUtils.isStatic(m)) {
//                    String mn = m.getName();
//                    if (getter == null) {
//                        if (g1.equals(mn) || g2.equals(mn)) {
//                            if (m.getParameterTypes().length == 0 && !Void.TYPE.equals(m.getReturnType())) {
//                                getter = m;
//                                Class<?> ftype = getter.getReturnType();
//                                for (Class key : new HashSet<Class>(setters.keySet())) {
//                                    if (!key.equals(ftype)) {
//                                        setters.remove(key);
//                                    }
//                                }
//                                if (setter == null) {
//                                    setter = setters.get(ftype);
//                                }
//                            }
//                        }
//                    }
//                    if (setter == null) {
//                        if (s.equals(mn)) {
//                            if (m.getParameterTypes().length == 1) {
//                                Class<?> stype = m.getParameterTypes()[0];
//                                if (getter != null) {
//                                    Class<?> gtype = getter.getReturnType();
//                                    if (gtype.equals(stype)) {
//                                        if (!setters.containsKey(stype)) {
//                                            setters.put(stype, m);
//                                        }
//                                        if (setter == null) {
//                                            setter = m;
//                                        }
//                                    }
//                                } else {
//                                    if (!setters.containsKey(stype)) {
//                                        setters.put(stype, m);
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    if (getter != null && setter != null) {
//                        break;
//                    }
//                }
//            }
//            if (getter != null && setter != null) {
//                break;
//            }
//            x = x.getSuperclass();
//        }
//        if (getter != null) {
//            propertyType = getter.getReturnType();
//        }
//        if (getter == null && setter == null && setters.size() > 0) {
//            Method[] settersArray = setters.values().toArray(new Method[setters.size()]);
//            setter = settersArray[0];
//            if (settersArray.length > 1) {
//                //TODO log?
//            }
//        }
//        if (getter == null && setter != null && propertyType == null) {
//            propertyType = setter.getParameterTypes()[0];
//        }
//        if (getter != null || setter != null) {
//            return new DefaultPlatformBeanProperty(field, propertyType, getter, setter);
//        }
//        return null;
//    }
//    public static Method findPlatformMethod(Class type, String name, Class ret, Class... args) {
//        return PlatformUtils.getBeanType(type).getMethod(type, name, ret, args);
//    }
    public static <T> List<T> trimToSize(List<T> list) {
        if (list instanceof ArrayList) {
            ((ArrayList<T>) list).trimToSize();
            return list;
        }
        if (list.isEmpty()) {
            return new ArrayList<T>(1);
        }
        return new ArrayList<T>(list);
    }

    public static InputStream loadResourceAsStream(String resourcePath) throws IOException {
        /**
         * @PortabilityHint(target="C#",name="replace") return
         * System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
         */
        {
            ClassLoader contextClassLoader = Thread.currentThread().getContextClassLoader();
            URL resource = contextClassLoader.getResource(resourcePath);
            if (resource == null) {
                resource = UPAUtils.class.getResource(resourcePath);
            }
            return resource.openStream();
        }
    }

    public static List<URL> listURLs(String resource) throws IOException {
        return Collections.list(Thread.currentThread().getContextClassLoader().getResources(resource));
    }

    public static <T> T lcast(Object o, Class<T> type) {
        if (isInstance(type, o)) {
            return (T) o;
        }
        return null;
    }

    public static boolean isInstance(Class type, Object obj) {
        if (type.isPrimitive()) {
            return toRefType(type).isInstance(obj);
        } else {
            return type.isInstance(obj);
        }
    }

    public static ClassFileIterator createClassFileIterator(URL url, ClassPathFilter configFilter, ClassFilter classFilter, ClassLoader contextClassLoader) {
        if (classFileIteratorFactories == null) {
            List<ClassFileIteratorFactory> all = new ArrayList<>();
            all.add(new JarAndFolderClassFileIteratorFactory());
            for (Class cls : UPA.getBootstrapFactory().getAlternatives(ClassFileIteratorFactory.class)) {
                all.add((ClassFileIteratorFactory) UPA.getBootstrapFactory().createObject(cls));
            }
            classFileIteratorFactories = all.toArray(new ClassFileIteratorFactory[all.size()]);
        }
        int bestIndex = Integer.MIN_VALUE;
        ClassFileIteratorFactory bestFact = null;
        for (ClassFileIteratorFactory classFileIteratorFactory : classFileIteratorFactories) {
            int i = classFileIteratorFactory.accept(url);
            if (i > bestIndex || bestFact == null) {
                bestFact = classFileIteratorFactory;
                bestIndex = i;
            }
        }
        return bestFact.createClassPathFilter(url, configFilter, classFilter, contextClassLoader);
    }

    public static Boolean toBool(BoolEnum b, Boolean defaultValue) {
        if (b == null || b == BoolEnum.DEFAULT) {
            return defaultValue;
        }
        return b == BoolEnum.TRUE;
    }

    public static boolean isDefaultTypeValue(Object fieldValue, Class type) {
        Object fieldDefaultValue = PlatformUtils.DEFAULT_VALUES_BY_TYPE.get(type);
        if (fieldDefaultValue == null) {
            return fieldValue == null;
        } else {
            return fieldDefaultValue.equals(fieldValue);
        }
    }

    public static PlatformBeanTypeCache getBeanType(Class cls) {
        PlatformBeanTypeCache platformBeanType = classBeanTypeReflectorMap.get(cls);
        if (platformBeanType == null) {
            synchronized (classBeanTypeReflectorMap) {
                platformBeanType = classBeanTypeReflectorMap.get(cls);
                if (platformBeanType == null) {
                    platformBeanType = new PlatformBeanTypeCache(cls);
                    classBeanTypeReflectorMap.put(cls, platformBeanType);
                    platformBeanType.getPropertyNames();// just to build the type
                }
            }
        }
        return platformBeanType;
    }

    public static Map<String, DecorationValue> getAnnotationDefaultDecorationValues(Class annotationClass) {
        Map<String, DecorationValue> a = new HashMap<>();
        for (Method method : annotationClass.getDeclaredMethods()) {
            if (method.getParameterTypes().length == 0) {
                a.put(method.getName(), getAnnotationDefaultDecorationValue(annotationClass, method.getName()));
            }
        }
        return a;
    }

    @SuppressWarnings("unchecked")
    public static DecorationValue getAnnotationDefaultDecorationValue(Class annotationClass, String element) {
        Object annotationDefault = getAnnotationDefault(annotationClass, element);
        if (annotationDefault instanceof Annotation) {
            return new AnnotationDecoration((Annotation) annotationDefault, DecorationSourceType.TYPE, null, null, null, -1);
        }
        return new DecorationPrimitiveValue(annotationDefault, ConfigInfo.DEFAULT);
    }

    @SuppressWarnings("unchecked")
    public static <T> T getAnnotationDefault(Class annotationClass, String element) {
        Method method = null;
        try {
            method = annotationClass.getMethod(element, (Class[]) null);
        } catch (NoSuchMethodException e) {
            throw new RuntimeException(e);
        }
        return ((T) method.getDefaultValue());
    }

    public static boolean equals(Object a, Object b) {
        return (a == b) || (a != null && a.equals(b));
    }

    public static int getPlatformType(int flags, int type, int subType, int size) {
        int x = flags & PlatformUtils.TYPE_MASK_FLAGS;
        x |= (size & PlatformUtils.TYPE_MASK_SIZE);
        x |= (type & PlatformUtils.TYPE_MASK_MAJOR);
        x |= (subType & PlatformUtils.TYPE_MASK_MINOR);
        return x;
    }

    public static boolean isPlatformType(int id, int flags, int type, int subType, int size) {
        return getPlatformType(flags, type, subType, size) == id;
    }

    public static String getPlatformTypeName(int id) {
        Set<String> all = new TreeSet<>();
//        int type = id & PlatformUtils.TYPE_MASK_MAJOR;
//        int subtype = id & PlatformUtils.TYPE_MASK_MINOR;
//        int size = id & PlatformUtils.TYPE_MASK_SIZE;
        if (isSet(id, PlatformUtils.TYPE_SIZE_128, PlatformUtils.TYPE_MASK_SIZE)) {
            all.add("SIZE_128");
        }
        if (isSet(id, PlatformUtils.TYPE_SIZE_64, PlatformUtils.TYPE_MASK_SIZE)) {
            all.add("SIZE_64");
        }
        if (isSet(id, PlatformUtils.TYPE_SIZE_32, PlatformUtils.TYPE_MASK_SIZE)) {
            all.add("SIZE_32");
        }
        if (isSet(id, PlatformUtils.TYPE_SIZE_16, PlatformUtils.TYPE_MASK_SIZE)) {
            all.add("SIZE_16");
        }
        if (isSet(id, PlatformUtils.TYPE_SIZE_8, PlatformUtils.TYPE_MASK_SIZE)) {
            all.add("SIZE_8");
        }
        if (isSet(id, PlatformUtils.TYPE_SIZE_BIG, PlatformUtils.TYPE_MASK_SIZE)) {
            all.add("SIZE_BIG");
        }
        if (isSet(id, PlatformUtils.TYPE_MAJOR_BOOLEAN, PlatformUtils.TYPE_MASK_MAJOR)) {
            all.add("BOOLEAN");
        }
        if (isSet(id, PlatformUtils.TYPE_FLAGS_NULLABLE, PlatformUtils.TYPE_FLAGS_NULLABLE)) {
            all.add("NULLABLE");
        }
        if (isSet(id, PlatformUtils.TYPE_MAJOR_NUMBER, PlatformUtils.TYPE_MASK_MAJOR)) {
            all.add("NUMBER");
            if (isSet(id, PlatformUtils.TYPE_MINOR_DECIMAL, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("DECIMAL");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_FLOAT, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("FLOAT");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_INT, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("INT");
            }
        }
        if (isSet(id, PlatformUtils.TYPE_MAJOR_STRING, PlatformUtils.TYPE_MASK_MAJOR)) {
            all.add("STRING");
            if (isSet(id, PlatformUtils.TYPE_MINOR_CHAR, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("CHAR");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_CHARS, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("CHARS");
            }
        }
        if (isSet(id, PlatformUtils.TYPE_MAJOR_TEMPORAL, PlatformUtils.TYPE_MASK_MAJOR)) {
            all.add("TEMPORAL");
            if (isSet(id, PlatformUtils.TYPE_MINOR_DATE, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("DATE");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_DATETIME, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("DATETIME");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_MONTH, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("MONTH");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_TIME, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("TIME");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_TIMESTAMP, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("TIMESTAMP");
            }
            if (isSet(id, PlatformUtils.TYPE_MINOR_YEAR, PlatformUtils.TYPE_MASK_MINOR)) {
                all.add("YEAR");
            }
        }
        if (isSet(id, PlatformUtils.TYPE_MAJOR_OTHER, PlatformUtils.TYPE_MASK_MAJOR)) {
            all.add("OTHER");
        }
        if (all.isEmpty()) {
            all.add("?");
        }
        StringBuilder sb = new StringBuilder();
        for (String string : all) {
            if (sb.length() > 0) {
                sb.append("|");
            }
            sb.append(string);
        }
        return sb.toString();
    }

    private static boolean isSet(int id, int portion, int mask) {
        return (id & mask) == portion;
    }

    public static <T> T createEntityBeanForDocument(final Class<T> type, final Document document, final Entity entity) {
        return (T) getProxyFactory().create(
                type, new Class[]{DocumentHolder.class},
                new BeanForDocumentPlatformMethodProxy(document, entity)
        );
    }

}
