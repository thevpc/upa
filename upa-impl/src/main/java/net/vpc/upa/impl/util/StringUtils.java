package net.vpc.upa.impl.util;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.sql.Time;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import net.vpc.upa.config.BoolEnum;
import net.vpc.upa.expressions.ExpressionHelper;

/**
 * User: taha Date: 6 aout 2003 Time: 21:15:14
 */
public final class StringUtils {

    public static Object valueOf(String s, Class c) {
        if (c == (String.class)) {
            return s;
        }
        if (c == (Integer.class)) {
            return Integer.valueOf(s);
        }
        if (c == Float.class) {
            return Float.valueOf(s);
        }
        if (c == (Long.class)) {
            return Long.valueOf(s);
        }
        if (c == Short.class) {
            return Short.valueOf(s);
        }
        if (c == Byte.class) {
            return Byte.valueOf(s);
        }
        if (c.equals(BigInteger.class)) {
            return new BigInteger(s);
        }
        /**
         * @PortabilityHint(target="C#",name="suppress")
         */
        if (c.equals(BigDecimal.class)) {
            return new BigDecimal(s);
        }
        if (c.equals(Time.class)) {
            return DateUtils.parseUniversalTime(s);
        }
        if (c.equals(java.sql.Date.class)) {
            return DateUtils.parseUniversalDate(s);
        }
        if (c.equals(java.util.Date.class)) {
            return DateUtils.parseUniversalDateTime(s);
        }
        return null;
    }

    private StringUtils() {
    }

    public static String substring(String string, int start) {
        if (string == null) {
            return "";
        } else {
            return substring(string, start, string.length());
        }
    }

    public static String substring(String string, int start, int end) {
        if (string == null || string.length() == 0) {
            return "";
        }
        if (start < 0) {
            start = 0;
        }
        if (end > string.length()) {
            end = string.length();
        }
        if (end <= start) {
            return "";
        } else {
            return string.substring(start, end);
        }
    }

    public static String[] split(String string, char separator, boolean first) {
        if (string == null || string.length() == 0) {
            return null;
        }
        int i = first ? string.indexOf(separator) : string.lastIndexOf(separator);
        if (i < 0) {
            return null;
        } else {
            String[] r = new String[2];
            r[0] = substring(string, 0, i);
            r[1] = substring(string, i + 1);
            return r;
        }
    }

    public static String left(String string, char separator, boolean first) {
        String[] s = split(string, separator, first);
        return s != null ? s[1] : null;
    }

    public static String right(String string, char separator, boolean first) {
        String[] s = split(string, separator, first);
        return s != null ? s[0] : null;
    }

    public static String replace(String string, String olds, String news) {
        String ret;
        int j;
        ret = string;
        while ((j = ret.indexOf(olds)) >= 0) {
            ret = substring(ret, 0, j) + news + substring(ret, j + olds.length());
        }
        return ret;
    }

    public static String replace(String string, int startOffset, int endOffset, String olds, String news) {
        String ret = substring(string, startOffset, endOffset);
        return substring(string, 0, startOffset) + replace(ret, olds, news) + substring(string, endOffset);
    }

    public static boolean startsWith(String string, String other, int offset) {
        if (string.length() - offset < other.length()) {
            return false;
        }
        for (int i = 0; i < other.length(); i++) {
            if (string.charAt(i + offset) != other.charAt(i)) {
                return false;
            }
        }

        return true;
    }

//    public static void clear(StringBuffer sb) {
//        sb.remove(0, sb.length());
//    }
    private static boolean split_allzero(int[] arr) {
        for (int anArr : arr) {
            if (anArr > 0) {
                return false;
            }
        }
        return true;
    }

    public static String[] split(String str, String splitters, String cotes, String pars, char escapeChar, boolean includeSeparators) {
        StringBuilder current = new StringBuilder();
        ArrayList<String> tokens = new ArrayList<String>(3);
        int i = 0;
        int[] parsCount = new int[pars.length() / 2];
        while (i < str.length()) {
            char c = str.charAt(i);
            if (cotes.indexOf(c) >= 0) {
                current.append(c);
                i++;
                while (i < str.length()) {
                    char c2 = str.charAt(i);
                    if (c2 == escapeChar) {
                        current.append(str.charAt(i + 1));
                        i = i + 2;
                    } else if (c == c2) {
                        current.append(str.charAt(i));
                        i++;
                        break;
                    } else {
                        current.append(str.charAt(i));
                        i++;
                    }
                }
            } else if (splitters.indexOf(c) >= 0) {
                if (split_allzero(parsCount)) {
                    tokens.add(current.toString());
                    current = new StringBuilder();
                    if (includeSeparators) {
                        tokens.add(String.valueOf(c));
                    }
                } else {
                    current.append(str.charAt(i));
                }
                i++;
            } else if (c == escapeChar) {
                current.append(str.charAt(i + 1));
                i = i + 2;
            } else if (pars.indexOf(c) >= 0) {
                int parIndex = pars.indexOf(c);
                if (parIndex % 2 == 0 && pars.charAt(parIndex) == pars.charAt(parIndex + 1)) {
                    if (parsCount[parIndex / 2] == 0) {
                        parsCount[parIndex / 2] = 1;
                    } else {
                        parsCount[parIndex / 2] = 0;
                    }
                } else {
                    if (parIndex % 2 == 0) {
                        // staring
                        parsCount[parIndex / 2] = parsCount[parIndex / 2] + 1;
                    } else {
                        parsCount[parIndex / 2] = parsCount[parIndex / 2] - 1;
                        // end
                    }
                }
                current.append(str.charAt(i));
                i++;
            } else {
                current.append(str.charAt(i));
                i++;
            }
        }
        if (current.length() > 0) {
            tokens.add(current.toString());
        }
        return tokens.toArray(new String[tokens.size()]);
    }

    public static String format(long[] value) {
        StringBuilder sb = new StringBuilder("{long:");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append(value[i]);
        }
        sb.append("}");
        return sb.toString();
    }

    public static String format(int[] value) {
        StringBuilder sb = new StringBuilder("{int:");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append(value[i]);
        }
        sb.append("}");
        return sb.toString();
    }

    public static String format(short[] value) {
        StringBuilder sb = new StringBuilder("{short:");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append(value[i]);
        }
        sb.append("}");
        return sb.toString();
    }

    public static String format(double[] value) {
        StringBuilder sb = new StringBuilder("{double:");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append(value[i]);
        }
        sb.append("}");
        return sb.toString();
    }

    public static String format(char[] value) {
        StringBuilder sb = new StringBuilder("{char:");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append(value[i]);
        }
        sb.append("}");
        return sb.toString();
    }

    public static String format(byte[] value) {
        StringBuilder sb = new StringBuilder("{byte:");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                sb.append(',');
            }
            sb.append(value[i]);
        }
        sb.append("}");
        return sb.toString();
    }

    public static String format(double value) {
        //return UserFormats.getDecimalFormat().format(value);
        return String.valueOf(value);
    }

    public static String format(Object value) {
        if (value == null) {
            return "null";
        }
        if (value.getClass().isArray()) {
            if (Object[].class.isAssignableFrom(value.getClass())) {
                return format((Object[]) value);
            } else {
                return String.valueOf(value);
            }
        }
        if (value instanceof Date) {
            return format((Date) value);
        }
        if ((value instanceof Float) || (value instanceof Double)) {
//            return UserFormats.getDecimalFormat().format(((Number) value).doubleValue());
            return String.valueOf(value);
        } else {
            return value.toString();
        }
    }

    public static String format(Date value) {
//        return UserFormats.getShortDateTimeFormat().format(value);
        return String.valueOf(value);
    }

    public static String format(Object[] value) {
        if (value == null) {
            return null;
        }
        StringBuilder s = new StringBuilder("{");
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                s.append(",");
            }
            s.append(format(value[i]));
        }
        s.append("}");
        return s.toString();
    }

    public static String format(Object[] value, String begin, String separator, String end, String nullValue) {
        if (value == null) {
            return nullValue;
        }
        StringBuilder s = new StringBuilder(begin);
        for (int i = 0; i < value.length; i++) {
            if (i > 0) {
                s.append(separator);
            }
            s.append(format(value[i]));
        }
        s.append(end);
        return s.toString();
    }

    public static String format(long value) {
        return "" + value;
    }

    public static String format(String value) {
        return value;
    }

    public static String format(String value, int width, int align) {
        if (width < 0) {
            return value;
        } else {
            return new StringFormatter(width, ' ', align).format(value);
        }
    }

    public static boolean isNullOrEmpty(String s) {
        return s == null || s.trim().length() == 0 || s.equals(net.vpc.upa.UPA.UNDEFINED_STRING);
    }

    public static String escapeString(String s, boolean escapeDoubleQuote, boolean escapeSingleQuotes, boolean escapeAntiQuote) {
        return ExpressionHelper.escapeStringLiteral(s, escapeDoubleQuote, escapeSingleQuotes, escapeAntiQuote);
    }

    public static String unescapeString(String s) {
        return ExpressionHelper.unescapeString(s);
    }

    public static List<String> parseVarsList(String s) {
        List<String> vars = new ArrayList<String>();
        Pattern p = Pattern.compile("\\$\\{[a-zA-Z]+\\w*\\}");
        Matcher m = p.matcher(s);
        while (m.find()) {
            int n = 0;
            for (int i = m.start() - 1; i >= 0 && s.charAt(i) == '\\'; i--) {
                n++;
            }
            if (n % 2 != 0) {
                continue;
            }
            String var = s.substring(m.start() + 2, m.end() - 1);
//            if (!vars.contains(var)) {
            vars.add(var);
//            }
        }
//        if (!vars.isEmpty()) {
//            return vars;
//        }
        return vars;
    }

    public static String toHexString(byte[] bytes) {
        StringBuilder hexString = new StringBuilder();

        for (int i = 0; i < bytes.length; i++) {
            String hex = Integer.toHexString(0xff & bytes[i]);
            if (hex.length() == 1) {
                hexString.append('0');
            }
            hexString.append(hex);
        }

        return hexString.toString();
    }

    public static byte[] parseHexString(String str) {
        byte[] values = new byte[str.length() / 2];
        for (int i = 0; i < values.length; i++) {
            values[i] = (byte) Integer.parseInt(str.substring(2 * i, 2 * i + 2), 16);
        }
        return values;
    }

    public static boolean isValue(String s) {
        return !isNullOrEmpty(s) && !isSimpleExpression(s);
    }

    public static boolean isSimpleExpression(String s) {
        if (s == null) {
            return false;
        }
        int i = 0;
        char[] cc = s.toCharArray();
        while (i < cc.length) {
            char c = cc[i];
            switch (c) {
                case '.':
                case '!':
                case '$': {
                    //ignore
                    break;
                }
                case '*': {
                    return true;
                }
                default: {
                    //
                }
            }
            i++;
        }
        return false;
    }

    public static String simpexpToRegexp(String pattern) {
        if (pattern == null) {
            pattern = "*";
        }
        int i = 0;
        char[] cc = pattern.toCharArray();
        StringBuilder sb = new StringBuilder("^");
        while (i < cc.length) {
            char c = cc[i];
            switch (c) {
                case '.':
                case '!':
                case '$': {
                    sb.append('\\').append(c);
                    break;
                }
                case '*': {
                    if (i + 1 < cc.length && cc[i + 1] == '*') {
                        i++;
                        sb.append("[a-zA-Z_0-9$.]*");
                    } else {
                        sb.append("[a-zA-Z_0-9$]*");
                    }
                    break;
                }
                default: {
                    sb.append(c);
                }
            }
            i++;
        }
        sb.append('$');
        return sb.toString();
    }
    
    public static boolean matchesSimpleExpression(String str, String pattern) {
        return Pattern.compile(simpexpToRegexp(pattern)).matcher(str == null ? "" : str).matches();
    }

    public static boolean isUndefined(String value) {
        return net.vpc.upa.UPA.UNDEFINED_STRING.equals(value);
    }

    public static boolean isUndefined(BoolEnum value) {
        return BoolEnum.UNDEFINED.equals(value);
    }

    public static boolean isUndefined(Class value) {
        return Void.class.equals(value)
                || Void.TYPE.equals(value)
                || (value != null && value.isInterface());
    }

    public static String trim(String value) {
        return StringHelper.EMPTY_STRING.format(value);
    }
}
