package net.thevpc.upa.impl.util;

import net.thevpc.upa.UPA;
import net.thevpc.upa.impl.util.regexp.PortablePattern;
import net.thevpc.upa.impl.util.regexp.PortablePatternMatcher;
import net.thevpc.upa.config.BoolEnum;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.expressions.ExpressionHelper;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.*;
import java.util.regex.Pattern;

/**
 * User: taha Date: 6 aout 2003 Time: 21:15:14
 */
public final class StringUtils {

    private static Pattern isWordChar_pattern = Pattern.compile("\\w");

    private StringUtils() {
    }

    public static Object valueOf(String s, Class c) {
        if (c == (String.class)) {
            return s;
        }
        if (PlatformUtils.isInt32(c)) {
            return Integer.valueOf(s);
        }
        if (PlatformUtils.isFloat32(c)) {
            return Float.valueOf(s);
        }
        if (PlatformUtils.isInt64(c)) {
            return Long.valueOf(s);
        }
        if (PlatformUtils.isInt16(c)) {
            return Short.valueOf(s);
        }
        if (PlatformUtils.isInt8(c)) {
            return Byte.valueOf(s);
        }
        if (PlatformUtils.isInt128(c)) {
            return new BigInteger(s);
        }
        if (PlatformUtils.isDecimal128(c)) {
            return new BigDecimal(s);
        }
        if (PlatformUtils.isTime(c)) {
            return DateUtils.parseUniversalTime(s);
        }
        if (PlatformUtils.isDateOnly(c)) {
            return DateUtils.parseUniversalDate(s);
        }
        if (PlatformUtils.isDateTime(c)) {
            return DateUtils.parseUniversalDateTime(s);
        }
        if (PlatformUtils.isMonth(c)) {
            return DateUtils.parseUniversalMonth(s);
        }
        if (PlatformUtils.isYear(c)) {
            return DateUtils.parseUniversalYear(s);
        }
        if (PlatformUtils.isAnyDate(c)) {
            return DateUtils.parseUniversalDateTime(s);
        }
        return null;
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
    public static String formatLeftAlign(String value, int width) {
        if (width < 0) {
            return value;
        } else {
            return new StringFormatter(width, ' ', StringFormatter.LEFT_ALIGN).format(value);
        }
    }

    public static String formatRightAlign(String value, int width) {
        if (width < 0) {
            return value;
        } else {
            return new StringFormatter(width, ' ', StringFormatter.RIGTH_ALIGN).format(value);
        }
    }

    public static String formatCenter(String value, int width) {
        if (width < 0) {
            return value;
        } else {
            return new StringFormatter(width, ' ', StringFormatter.CENTER_ALIGN).format(value);
        }
    }

    public static boolean isNullOrEmpty(String s) {
        return s == null || s.trim().length() == 0 || s.equals(UPA.UNDEFINED_STRING);
    }

    public static String escapeString(String s, boolean escapeDoubleQuote, boolean escapeSingleQuotes, boolean escapeAntiQuote) {
        return ExpressionHelper.escapeStringLiteral(s, escapeDoubleQuote, escapeSingleQuotes, escapeAntiQuote);
    }

    public static String unescapeString(String s) {
        return ExpressionHelper.unescapeString(s);
    }

    public static List<String> parseVarsList(String s) {
        List<String> vars = new ArrayList<String>();
        PortablePattern p = new PortablePattern("\\$\\{[a-zA-Z]+\\w*\\}");
        PortablePatternMatcher m = p.matcher(s);
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

    public static String valueOf(Object pattern) {
        if (pattern == null) {
            return "";
        }
        return pattern.toString();
    }

    /**
     * *
     * **
     *
     * @param pattern
     * @return
     */
    public static String simpexpToRegexp(String pattern, PatternType type) {
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
                case '$':
                case '[':
                case ']':
                case '(':
                case ')':
                case '?':
                case '^':
                case '\\': {
                    sb.append('\\').append(c);
                    break;
                }
                case '*': {
                    switch (type) {
                        case DOT_PATH: {
                            if (i + 1 < cc.length && cc[i + 1] == '*') {
                                i++;
                                sb.append("[a-zA-Z_0-9$.]*");
                            } else {
                                sb.append("[a-zA-Z_0-9$]*");
                            }
                            break;
                        }
                        case SLASH_PATH: {
                            if (i + 1 < cc.length && cc[i + 1] == '*') {
                                i++;
                                sb.append("[a-zA-Z_0-9$/]*");
                            } else {
                                sb.append("[a-zA-Z_0-9$]*");
                            }
                            break;
                        }
                        case ANY: {
                            sb.append(".*");
                            break;
                        }
                        default: {
                            throw new IllegalUPAArgumentException("Unsupported");
                        }
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

    public static boolean matchesSimpleExpression(String str, String pattern, PatternType type) {
        return new PortablePattern(simpexpToRegexp(pattern, type)).matcher(str == null ? "" : str).matches();
    }

    public static boolean isUndefined(String value) {
        return UPA.UNDEFINED_STRING.equals(value);
    }

    public static boolean isUndefined(BoolEnum value) {
        return BoolEnum.DEFAULT.equals(value);
    }

    public static boolean isUndefined(Class value) {
        return Void.class.equals(value)
                || Void.TYPE.equals(value)
                || (value != null && value.isInterface());
    }

    public static String trim(String value) {
        return StringHelper.EMPTY_STRING.format(value);
    }

    public static Map<String, String> readEscapedKeyValMap(char[] chars, String commaSep, String equalsSep) {
        return readEscapedKeyValMap(chars, commaSep, equalsSep, new Ref<Integer>(0));
    }

    public static Map<String, String> readEscapedKeyValMap(char[] chars, String commaSep, String equalsSep, Ref<Integer> pos) {
        Map<String, String> m = new LinkedHashMap<String, String>();
        while (pos.get() < chars.length) {
            String[] v = readEscapedKeyVal(chars, commaSep, equalsSep, pos);
            if (v != null) {
                m.put(v[0], v[1]);
            }
            pos.set(pos.get() + 1);
        }
        return m;
    }

    public static String[] readEscapedKeyVal(char[] chars, String commaSep, String equalsSep, Ref<Integer> pos) {
        int old = pos.get();
        String key = null;
        String value = null;
        key = readEscapedString(chars, commaSep + equalsSep, pos);
        int newPos = pos.get();
        if (newPos == old) {
            if (equalsSep.indexOf(chars[newPos]) >= 0) {
                pos.set(pos.get() + 1);
                value = readEscapedString(chars, commaSep, pos);
            } else {
                return null;
            }
        } else {
            if (newPos < chars.length && equalsSep.indexOf(chars[newPos]) >= 0) {
                pos.set(pos.get() + 1);
                value = readEscapedString(chars, commaSep, pos);
            } else {
                value = "";
            }
        }
        return new String[]{key, value};
    }

    public static String readEscapedString(char[] chars, String separators, Ref<Integer> pos) {
//        System.out.println("readEscapedString : "+pos);
        int i = pos.get();
        List<String[]> ret = new ArrayList<String[]>();
        while (i < chars.length) {
            if (separators.indexOf(chars[i]) >= 0) {
                break;
            } else if (chars[i] == '\"') {
                int k = i + 1;
                StringBuilder v = new StringBuilder();
                while (k < chars.length) {
                    if (chars[k] == '\\') {
                        k++;
                        switch (chars[k]) {
                            case '\n': {
                                v.append("\n");
                                break;
                            }
                            case '\r': {
                                v.append("\r");
                                break;
                            }
                            case '\t': {
                                v.append("\t");
                                break;
                            }
                            default: {
                                v.append(chars[k]);
                            }
                        }
                    } else if (chars[k] == '\"') {
                        break;
                    } else {
                        v.append(chars[k]);
                    }
                    k++;
                }
                i = k;
                if (v.length() > 0) {
                    ret.add(new String[]{"\"", v.toString()});
                }
            } else if (chars[i] == '\'') {
                int k = i + 1;
                StringBuilder v = new StringBuilder();
                while (k < chars.length) {
                    if (chars[k] == '\\') {
                        k++;
                        switch (chars[k]) {
                            case '\n': {
                                v.append("\n");
                                break;
                            }
                            case '\r': {
                                v.append("\r");
                                break;
                            }
                            case '\t': {
                                v.append("\t");
                                break;
                            }
                            default: {
                                v.append(chars[k]);
                            }
                        }
                    } else if (chars[k] == '\'') {
                        break;
                    } else {
                        v.append(chars[k]);
                    }
                    k++;
                }
                i = k;
                if (v.length() > 0) {
                    ret.add(new String[]{"\'", v.toString()});
                }
            } else {
                int k = i;
                StringBuilder v = new StringBuilder();
                while (k < chars.length) {
                    if (separators.indexOf(chars[k]) < 0 && chars[k] != '\'' && chars[k] != '\"') {
                        v.append(chars[k]);
                        k++;
                    } else {
                        k--;
                        break;
                    }
                }
                i = k;
                if (v.length() > 0) {
                    ret.add(new String[]{"", v.toString()});
                }
            }
            i++;
        }
        pos.set(i);

        //trim
        while (ret.size() > 0) {
            String[] s = ret.get(0);
            String[] e = ret.get(ret.size() - 1);
            if (s[0].equals("")) {
                s[1] = trim(s[1], true, false);
            }
            if (e[0].equals("")) {
                e[1] = trim(e[1], false, true);
            }
            if (s[0].equals("") && s[1].trim().isEmpty()) {
                ret.remove(0);
            } else if (e[0].equals("") && e[1].trim().isEmpty()) {
                ret.remove(ret.size() - 1);
            } else {
                break;
            }
        }
        StringBuilder sb = new StringBuilder();
        for (String[] s : ret) {
            sb.append(s[1]);
        }
        return sb.toString();
    }

    public static String trim(String str, boolean start, boolean end) {
        char[] value = str.toCharArray();
        int len = value.length;
        int st = 0;
        char[] val = value;
        if (start) {
            while ((st < len) && (val[st] <= ' ')) {
                st++;
            }
        }
        if (end) {
            while ((st < len) && (val[len - 1] <= ' ')) {
                len--;
            }
        }
        return ((st > 0) || (len < value.length)) ? str.substring(st, len) : str;
    }

    public static String replaceSingleDollarVars(String str, Converter<String, String> varConverter) {
        if (str != null) {
            if (str.startsWith("${") && str.endsWith("}")) {
                String str2 = str.substring(2, str.length() - 1);
                if (str2.indexOf('$') < 0) {
                    return varConverter.convert(str2);
                }
            }
        }
        return str;
    }

    public static String replaceDollarVars(String str, Converter<String, String> varConverter) {
        if (str == null) {
            return str;
        }
        StringBuffer sb = new StringBuffer();
        PortablePattern p = new PortablePattern("\\$\\{[^\\{\\}]*\\}");
        PortablePatternMatcher m = p.matcher(str == null ? "" : str);
        while (m.find()) {
            final String g = m.group(0);
            String v = g.substring(2, g.length() - 1);
            sb.append(m.replace(varConverter.convert(v)));
        }
        sb.append(m.tail());
        return sb.toString();
    }

    public static String replaceNoDollarVars(String str, Converter<String, String> varConverter) {
        if (str == null) {
            return str;
        }
        StringBuffer sb = new StringBuffer();
        PortablePattern p = new PortablePattern("\\{[^\\{\\}]*\\}");
        PortablePatternMatcher m = p.matcher(str == null ? "" : str);
        while (m.find()) {
            final String g = m.group(0);
            String v = g.substring(1, g.length() - 1);
            sb.append(m.replace(varConverter.convert(v)));
        }
        sb.append(m.tail());
        return sb.toString();

//        StringBuffer sb = new StringBuffer();
//
//        {
//            boolean javaExprSupported = true;
//            if (javaExprSupported) {
//                PortablePattern p = new PortablePattern("\\{[^\\{\\}]*\\}");
//                PortablePatternMatcher m = p.matcher(str == null ? "" : str);
//                while (m.find()) {
//                    final String g = m.group(0);
//                    String v = g.substring(1, g.length() - 1);
//                    sb.append(m.replace(varConverter.convert(v)));
//                }
//                sb.append(m.tail());
//                return sb.toString();
//            }
//        }
//
//        int i = 0;
//        while (i >= 0 && i < str.length()) {
//            int j = str.indexOf("{", i);
//            if (j < 0) {
//                sb.append(str.substring(i));
//                i = -1;
//            } else {
//                sb.append(str.substring(i, j));
//                int k = str.indexOf("}", j + 1);
//                if (k < 0) {
//                    sb.append(varConverter.convert(str.substring(j + 1)));
//                    i = -1;
//                } else {
//                    sb.append(varConverter.convert(str.substring(j + 1, k)));
//                    i = k + 1;
//                }
//            }
//        }
//
//        return sb.toString();
    }

//    public static void main(String[] args) {
//        System.out.println(indexOfWord("toto", "totos est toto parti stoto", 0));
//    }

    public static boolean isWordChar(char c) {
        return isWordChar_pattern.matcher(String.valueOf(c)).matches();
    }

    public static String removeSQLParsAndStrings(String inStr) {
        StringBuilder sb = new StringBuilder();
        char[] chars = inStr.toCharArray();
        boolean inQstr = false;
        int pars = 0;
        for (int i = 0; i < chars.length; i++) {
            char c = chars[i];
            switch (c) {
                case '(': {
                    if (inQstr) {
                        //ignore
                    } else {
                        sb.append(' ');// to avoid concat words
                        pars++;
                    }
                    break;
                }
                case ')': {
                    if (inQstr) {
                        //ignore
                    } else {
                        pars--;
                    }
                    break;
                }
                case '\'': {
                    if (inQstr) {
                        if (i + 1 < chars.length && chars[i + 1] == '\'') {
                            i++;
                        } else {
                            inQstr = false;
                        }
                    } else {
                        sb.append(' ');// to avoid concat words
                        inQstr = true;
                    }
                    break;
                }
                default: {
                    if (pars > 0 || inQstr) {
                        //ignore;
                    } else {
                        sb.append(c);
                    }
                }
            }
        }
        return sb.toString();
    }

    public static String extractWordAfter(String predecessorWord, String inStr, int start, boolean ignoreCase) {
        int t = 0;
        if (ignoreCase) {
            t = indexOfWord(predecessorWord.toLowerCase(), inStr.toLowerCase(), start);
        } else {
            t = indexOfWord(predecessorWord, inStr, start);
        }
        if (t >= 0) {
            return extractWordAt(inStr, t + predecessorWord.length());
        }
        return null;
    }

    public static String extractWordAt(String inStr, int start) {
        int i = start;
        while (i < inStr.length() && !isWordChar(inStr.charAt(i))) {
            i++;
        }
        if (i >= inStr.length()) {
            return null;
        }
        int s = i;
        while (i < inStr.length() && isWordChar(inStr.charAt(i))) {
            i++;
        }
        return inStr.substring(s, i);
    }

    public static int indexOfWord(String word, String inStr) {
        return indexOfWord(word, inStr, 0);
    }

    public static int indexOfWord(String word, String inStr, int start) {
        while (start >= 0 && start < inStr.length()) {
            int x = inStr.indexOf(word, start);
            if (x < 0) {
                return -1;
            }
            int y = x + word.length();
            boolean gooStart = x == 0 || !isWordChar(inStr.charAt(x - 1));
            boolean gooEnding = y >= inStr.length() || !isWordChar(inStr.charAt(y));
            if (gooStart && gooEnding) {
                return x;
            }
            start = start + word.length() + 1;
        }
        return -1;
    }

    public static Map<String,String> toStringMap(Map<CaseInsensitiveString,String> m){
        Map<String,String> r=new HashMap<>();
        for (Map.Entry<CaseInsensitiveString, String> e : m.entrySet()) {
            r.put(e.getKey().toString(), e.getValue());
        }
        return r;
    }

    public static Map<CaseInsensitiveString,String> toCaseInsensitiveStringMap(Map<String,String> m){
        Map<CaseInsensitiveString,String> r=new HashMap<>();
        for (Map.Entry<String, String> e : m.entrySet()) {
            r.put(new CaseInsensitiveString(e.getKey()), e.getValue());
        }
        return r;
    }
}
