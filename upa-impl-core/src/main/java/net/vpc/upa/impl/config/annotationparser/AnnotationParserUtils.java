package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.types.*;
import net.vpc.upa.impl.util.DateUtils;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Timestamp;
import java.text.ParseException;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:53 AM
 */
public class AnnotationParserUtils {
    static String validStr(String c, String oldVal) {
        if (c != null) {
            c = c.trim();
            if (c.length() > 0) {
                return c;
            }
        }
        return oldVal;
    }

    static void validInt(int c, OverriddenValue<Integer> oldVal, int nullVal, int processOrder) {
        if (c != nullVal) {
            oldVal.setBetterValue(c, processOrder);
        }
    }

    static void validStr(String c, OverriddenValue<String> oldVal, int processOrder) {
        if (c != null) {
            c = c.trim();
            if (c.length() > 0) {
                oldVal.setBetterValue(c, processOrder);
            }
        }
    }

    static Class validClass(Class c, Class oldVal, Class type) {
        if (c != null && !c.equals(void.class)) {
            if (type.isAssignableFrom(c)) {
                return c;
            } else {
                throw new IllegalUPAArgumentException("Expected type " + type);
            }
        }
        return oldVal;
    }

    static void validClass(Class c, OverriddenValue<Class> oldVal, Class type, int processOrder) {
        if (c != null && !c.equals(void.class)) {
            if (type.isAssignableFrom(c)) {
                oldVal.setBetterValue(c, processOrder);
            } else {
                throw new IllegalUPAArgumentException("Expected type " + type);
            }
        }
    }

    static int parseInt(String s, int def) {
        if (s == null) {
            s = "";
        }
        s = s.trim();
        if (s.length() != 0) {
            return Integer.parseInt(s);
        }
        return def;
    }

    static BigInteger parseBigInteger(OverriddenValue<String> val, BigInteger def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                return new BigInteger(s);
            }
        }
        return def;
    }

    @PortabilityHint(target = "C#",name = "suppress")
    static BigDecimal parseBigDecimal(OverriddenValue<String> val, BigDecimal def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                return new BigDecimal(s);
            }
        }
        return def;
    }

    static Integer parseInt(OverriddenValue<String> val, Integer def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                if(Character.isLetter(s.charAt(0))){
                    if("max".equalsIgnoreCase(s) || "maximum".equals(s) || "max_value".equals(s)){
                        return Integer.MAX_VALUE;
                    }
                    if("min".equalsIgnoreCase(s) || "min".equals(s) || "min_value".equals(s)){
                        return Integer.MIN_VALUE;
                    }
                }
                return Integer.parseInt(s);
            }
        }
        return def;
    }

    static Byte parseByte(OverriddenValue<String> val, Byte def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                return Byte.parseByte(s);
            }
        }
        return def;
    }

    static Short parseShort(OverriddenValue<String> val, Short def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                if(Character.isLetter(s.charAt(0))){
                    if("max".equalsIgnoreCase(s) || "maximum".equals(s) || "max_value".equals(s)){
                        return Short.MAX_VALUE;
                    }
                    if("min".equalsIgnoreCase(s) || "min".equals(s) || "min_value".equals(s)){
                        return Short.MIN_VALUE;
                    }
                }
                return Short.parseShort(s);
            }
        }
        return def;
    }

    static Long parseLong(OverriddenValue<String> val, Long def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                if(Character.isLetter(s.charAt(0))){
                    if("max".equalsIgnoreCase(s) || "maximum".equals(s) || "max_value".equals(s)){
                        return Long.MAX_VALUE;
                    }
                    if("min".equalsIgnoreCase(s) || "min".equals(s) || "min_value".equals(s)){
                        return Long.MIN_VALUE;
                    }
                }
                return Long.parseLong(s);
            }
        }
        return def;
    }

    static Double parseDouble(OverriddenValue<String> val, Double def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                if(Character.isLetter(s.charAt(0))){
                    if("max".equalsIgnoreCase(s) || "maximum".equals(s) || "max_value".equals(s)){
                        return Double.MAX_VALUE;
                    }
                    if("min".equalsIgnoreCase(s) || "min".equals(s) || "min_value".equals(s)){
                        return Double.MIN_VALUE;
                    }
                }
                return Double.parseDouble(s);
            }
        }
        return def;
    }

    static Float parseFloat(OverriddenValue<String> val, Float def) {
        if (val.specified) {
            String s = val.value;
            if (s == null) {
                s = "";
            }
            s = s.trim();
            if (s.length() != 0) {
                if(Character.isLetter(s.charAt(0))){
                    if("max".equalsIgnoreCase(s) || "maximum".equals(s) || "max_value".equals(s)){
                        return Float.MAX_VALUE;
                    }
                    if("min".equalsIgnoreCase(s) || "min".equals(s) || "min_value".equals(s)){
                        return Float.MIN_VALUE;
                    }
                }
                return Float.parseFloat(s);
            }
        }
        return def;
    }

    static String createDateFormatString(Class type1) {
        if (Date.class.equals(type1)) {
            return "yyyy-MM-dd HH:mm:ss.SSS";
        } else if (java.sql.Date.class.equals(type1)) {
            return "yyyy-MM-dd HH:mm:ss.SSS";
        } else if (Time.class.equals(type1)) {
            return "HH:mm:ss.SSS";
        } else if (java.sql.Time.class.equals(type1)) {
            return "HH:mm:ss.SSS";
        } else if (DateTime.class.equals(type1)) {
            return "yyyy-MM-dd HH:mm:ss.SSS";
        } else if (Date.class.equals(type1)) {
            return "yyyy-MM-dd";
        } else if (Month.class.equals(type1)) {
            return "yyyy-MM";
        } else if (Year.class.equals(type1)) {
            return "yyyy";
        } else if (Timestamp.class.equals(type1)) {
            return "yyyy-MM-dd HH:mm:ss.SSS";
        } else {
            return "yyyy-MM-dd HH:mm:ss.SSS";
        }
    }

    static java.util.Date parseDate(Class type1, OverriddenValue<String> value, OverriddenValue<String> format) throws ParseException {
        return parseDate(type1, value, format, false);
    }

    static java.util.Date parseDate(Class type1, OverriddenValue<String> value, OverriddenValue<String> format, boolean end) throws ParseException {
        String svalue = value.specified ? value.value : null;
        if (svalue == null) {
            svalue = "";
        }
        svalue = svalue.trim();
        if (svalue.length() == 0) {
            return null;
        }
        String sformat = format.specified ? format.value : null;
        if (sformat == null || sformat.trim().length() == 0) {
            sformat = createDateFormatString(type1);
        }
        java.util.Date s = DateUtils.parseDateTime(svalue, sformat);
        if (type1.equals(Date.class)) {
            return new Date(s.getTime());
        } else if (type1.equals(java.sql.Date.class)) {
            return new java.sql.Date(s.getTime());
        } else if (type1.equals(Time.class)) {
            return new Time(s);
        } else if (type1.equals(java.sql.Time.class)) {
            return new java.sql.Time(s.getTime());
        } else if (type1.equals(DateTime.class)) {
            return new DateTime(s);
        } else if (type1.equals(java.sql.Timestamp.class)) {
            return new java.sql.Timestamp(s.getTime());
        } else if (type1.equals(net.vpc.upa.types.Timestamp.class)) {
            return new net.vpc.upa.types.Timestamp(s.getTime());
        } else if (type1.equals(Month.class)) {
            return new Month(s.getTime());
        } else if (type1.equals(Year.class)) {
            return new Year(s.getTime());
        } else {
            return s;
        }
    }

    public static Object parseStringValue(String s, DataType dataType, Object defaultValue) throws ParseException {
        if (s == null || s.length() == 0) {
            return defaultValue;
        }
        Class c = dataType.getPlatformType();
        if (String.class.equals(c)) {
            return s;
        } else if (Character.class.equals(c)) {
            return s.charAt(0);
        } else if (PlatformUtils.isInt32(c)) {
            return Integer.parseInt(s);
        } else if (PlatformUtils.isInt64(c)) {
            return Long.parseLong(s);
        } else if (PlatformUtils.isInt16(c)) {
            return Short.parseShort(s);
        } else if (PlatformUtils.isInt8(c)) {
            return Byte.parseByte(s);
        } else if (PlatformUtils.isFloat64(c)) {
            return Double.parseDouble(s);
        } else if (PlatformUtils.isFloat32(c)) {
            return Float.parseFloat(s);
        } else if (PlatformUtils.isBigInt(c)) {
            return new BigInteger(s);
        } else if (PlatformUtils.isAnyDate(c)) {
            OverriddenValue<String> vv = new OverriddenValue<String>();
            vv.setValue(s);
            return parseDate(c, vv, new OverriddenValue<String>(), false);
        } else if(PlatformUtils.isBool(c)){
            return Boolean.parseBoolean(s);
        }

        /**@PortabilityHint(target="C#",name="suppress")*/
        if (PlatformUtils.isBigFloat(c)) {
            return new BigDecimal(s);
        }

        return null;
    }

    public static boolean isEmptyString(String s) {
        return s == null || s.trim().length() == 0;
    }


    public static boolean isAnnotationNullTypeProperty(Class found, Class expectedInterface) {
        if(found==null || found.equals(expectedInterface)){
            return true;
        }
        if(found.equals(Object.class)){
            return true;
        }
        if(found.equals(Void.class) || found.equals(Void.TYPE)){
            return true;
        }
        return false;
    }
}
