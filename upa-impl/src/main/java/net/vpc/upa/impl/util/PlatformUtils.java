package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.filters.ObjectFilter;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.types.Date;
import net.vpc.upa.types.*;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:29 PM
 */
@PortabilityHint(target = "C#", name = "partial")
public class PlatformUtils {

    private static final Logger log = Logger.getLogger(PlatformUtils.class.getName());
    public final static Map<Class, Object> DEFAULT_VALUES_BY_TYPE = new HashMap<Class, Object>();
    public final static Map<Class, Class> PRIMITIVE_TO_REF_TYPES = new HashMap<Class, Class>();
    public final static Map<Class, Class> REF_TO_PRIMITIVE_TYPES = new HashMap<Class, Class>();
    public final static java.util.Date MIN_DATE = new java.util.Date(0);

    private static final Map<Class, String> typeNames = new HashMap<Class, String>();
    private static PlatformTypeProxy proxyFactory;

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
        throw new IllegalArgumentException("Invalid Number Expr " + numberClass1 + " , " + numberClass2);
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
        if (isInt64(clazz)) {
            return pos;
        }

        pos++;
        if (isBigInt(clazz)) {
            return pos;
        }

        throw new IllegalArgumentException("Not an integer");
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
        throw new IllegalArgumentException("Not an integer");
    }

    public static boolean isTime(Class clazz) {
        return java.sql.Time.class.isAssignableFrom(clazz) || net.vpc.upa.types.Time.class.isAssignableFrom(clazz);
    }

    public static boolean isDateOnly(Class clazz) {
        return java.sql.Date.class.isAssignableFrom(clazz) || net.vpc.upa.types.Date.class.isAssignableFrom(clazz);
    }

    public static boolean isDateTime(Class clazz) {
        return java.util.Date.class.equals(clazz)
                || net.vpc.upa.types.DateTime.class.isAssignableFrom(clazz);
    }

    public static boolean isTimestamp(Class clazz) {
        return java.sql.Timestamp.class.isAssignableFrom(clazz)
                || net.vpc.upa.types.Timestamp.class.isAssignableFrom(clazz);
    }

    public static boolean isMonth(Class clazz) {
        return net.vpc.upa.types.Month.class.isAssignableFrom(clazz);
    }

    public static boolean isYear(Class clazz) {
        return net.vpc.upa.types.Year.class.isAssignableFrom(clazz);
    }

    public static boolean isAnyDate(Class clazz) {
        return java.util.Date.class.isAssignableFrom(clazz);
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

    public static boolean isAnyNumber(Class clazz) {
        return Number.class.isAssignableFrom(clazz);
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

    public static boolean isNumber(Class clazz) {
        return (Number.class).isAssignableFrom(clazz);
    }

    public static Class forName(String name) throws ClassNotFoundException {
        ClassLoader contextClassLoader = Thread.currentThread().getContextClassLoader();
        return Class.forName(name, true, contextClassLoader);
    }

    public static <T> T convert(Object value, Class<T> to) {
        if (value == null || to.isInstance(value)) {
            return (T) value;
        }

        if (to.isEnum()) {
            if (value instanceof String) {
                return (T) Enum.valueOf((Class) to, (String) value);
            } else if (value instanceof Integer) {
                return to.getEnumConstants()[(Integer) value];
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

    public static Class toTemporalType(TemporalOption option, Class baseType) {
        Class upaBaseType = net.vpc.upa.types.Temporal.class;
        Class osBaseType = java.util.Date.class;
        Class upaType = null;
        Class osType = null;
        switch (option) {
            case TIME: {
                upaType = net.vpc.upa.types.Time.class;
                osType = java.sql.Time.class;
                break;
            }
            case DATE: {
                upaType = net.vpc.upa.types.Date.class;
                osType = java.sql.Date.class;
                break;
            }
            case DATETIME: {
                upaType = net.vpc.upa.types.DateTime.class;
                osType = java.sql.Timestamp.class;
                break;
            }
            case TIMESTAMP: {
                upaType = net.vpc.upa.types.Timestamp.class;
                osType = java.sql.Timestamp.class;
                break;
            }
            case MONTH: {
                upaType = net.vpc.upa.types.Month.class;
                osType = java.sql.Date.class;
                break;
            }
            case YEAR: {
                upaType = net.vpc.upa.types.Year.class;
                osType = java.sql.Date.class;
                break;
            }
            case DEFAULT: {
                upaType = net.vpc.upa.types.DateTime.class;
                osType = java.sql.Timestamp.class;
                break;
            }
            default: {
                throw new IllegalArgumentException("Unsupported Temperal " + option);
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
            return clazz.newInstance();
        } catch (Exception ex) {
            log.log(Level.SEVERE, null, ex);
            throw new UPAException(ex, new I18NString("InstantationError"));
        }
    }

    public static Object[] getEnumValues(Class enumType) {
        /**
         * @PortabilityHint(target = "C#", name = "replace")
         * return (Object[])Enum.GetValues(enumType);
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
        if (configObject instanceof Decoration) {
            Decoration c = (Decoration) configObject;
            String v = Strings.trim(c.getString("persistenceGroup"));
            if (!Strings.matchesSimpleExpression(persistenceGroup, v)) {
                return false;
            }
            v = Strings.trim(c.getString("persistenceUnit"));
            if (!Strings.matchesSimpleExpression(persistenceUnit, v)) {
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
        List<Field> all=new ArrayList<Field>();
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
        if (Boolean.TYPE.equals(type)) {
            return "is" + suffix(name);
        }
        return "get" + suffix(name);
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

    public static String setterName(String name) {
        //Class<?> type = field.getDataType();
        return "set" + suffix(name);
    }

    private static String suffix(String s) {
        char[] chars = s.toCharArray();
        chars[0] = Character.toUpperCase(chars[0]);
        return new String(chars);
    }

    public static boolean isStatic(Method method) {
        return Modifier.isStatic(method.getModifiers());
    }

    public static boolean isAbstract(Method method) {
        return Modifier.isAbstract(method.getModifiers());
    }

    public static boolean isAbstract(Class type) {
        return Modifier.isStatic(type.getModifiers());
    }

    public static boolean isInterface(Class type) {
        return type.isInterface();
//        return Modifier.isInterface(m.getModifiers());
    }

    public static boolean isStatic(Field m) {
        return Modifier.isStatic(m.getModifiers());
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
         * @PortabilityHint(target = "C#", name = "replace")
         * return type.IsSerializable;
         */
        return java.io.Serializable.class.isAssignableFrom(type);
    }

    public static String getSystemLineSeparator() {
        /**
         * @PortabilityHint(target = "C#", name = "replace")
         * return "\r\n";
         *
         */
        return System.getProperty("line.separator");
    }

    public static Map<String, String> getSystemProperties() {
        Map<String, String> m = new HashMap<String, String>();
        /**@PortabilityHint(target = "C#", name = "ignore")*/
        m.putAll((Map) System.getProperties());
        return m;
    }

    public static int hashCode(Object a[]) {
        if (a == null)
            return 0;

        int result = 1;

        for (Object element : a)
            result = 31 * result + (element == null ? 0 : element.hashCode());

        return result;
    }

    public static <T> boolean isUndefinedValue(Class<T> type, T value) {
        /**@PortabilityHint(target = "C#", name = "replace")
         * return value == default(T);
         */
        {
            if(value==null){
                return true;
            }
            Object v = getEnumValues(type)[0];
            if(value==v){
                String n = ((Enum)v).name();
                if("DEFAULT".equals(n) || "UNKNOWN".equals(n)){
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
        /**@PortabilityHint(target = "C#", name = "replace")
         * return default(T);
         */
        return null;
    }

    public static PlatformTypeProxy getProxyFactory() {
        if (proxyFactory == null) {
            /**@PortabilityHint(target = "C#", name = "replace")
             * return new Net.Vpc.Upa.Impl.Util.PlatformTypeProxyCsharp();
             */
            proxyFactory = new PlatformTypeProxyJavaCGLib();
        }
        return proxyFactory;
    }

    public static <T> T createObjectInterceptor(Class<T> type, final PlatformMethodProxy<T> methodProxy) {
        return getProxyFactory().create(type, methodProxy);
    }

    public static String replaceNoDollarVars(String str, Converter<String, String> varConverter) {
        StringBuffer sb = new StringBuffer();

        /**@PortabilityHint(target = "C#", name = "suppress")
         */
        {
            boolean javaExprSupported = false;
            if (javaExprSupported) {
                Pattern p = Pattern.compile("\\{[^\\{\\}]*\\}");
                final Matcher m = p.matcher(str == null ? "" : str);
                while (m.find()) {
                    final String g = m.group();
                    String v = g.substring(1, g.length() - 1);
                    m.appendReplacement(sb, varConverter.convert(v));
                }
                return sb.toString();
            }
        }

        int i = 0;
        while (i >= 0 && i < str.length()) {
            int j = str.indexOf("{", i);
            if (j < 0) {
                sb.append(str.substring(i));
                i = -1;
            } else {
                sb.append(str.substring(i, j));
                int k = str.indexOf("}", j + 1);
                if (k < 0) {
                    sb.append(varConverter.convert(str.substring(j + 1)));
                    i = -1;
                } else {
                    sb.append(varConverter.convert(str.substring(j + 1, k)));
                    i = k + 1;
                }
            }
        }

        return sb.toString();
    }

    public static boolean isInt32(String s) {
        try {
            Integer.parseInt(s);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

}
