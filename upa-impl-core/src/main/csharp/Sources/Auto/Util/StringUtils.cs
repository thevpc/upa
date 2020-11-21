/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     * User: taha Date: 6 aout 2003 Time: 21:15:14
     */
    public sealed class StringUtils {

        public static object ValueOf(string s, System.Type c) {
            if (c == (typeof(string))) {
                return s;
            }
            if (c == (typeof(int?))) {
                return System.Convert.ToInt32(s);
            }
            if (c == typeof(float?)) {
                return System.Convert.ToSingle(s);
            }
            if (c == (typeof(long?))) {
                return System.Convert.ToInt64(s);
            }
            if (c == typeof(short?)) {
                return System.Convert.ToInt16(s);
            }
            if (c == typeof(byte?)) {
                return System.Convert.ToByte(s);
            }
            if (c.Equals(typeof(System.Numerics.BigInteger?))) {
                return Net.TheVpc.Upa.Impl.FwkConvertUtils.CreateBigInteger(s);
            }
            if (c.Equals(typeof(Net.TheVpc.Upa.Types.Time))) {
                return Net.TheVpc.Upa.Impl.Util.DateUtils.ParseUniversalTime(s);
            }
            if (c.Equals(typeof(Net.TheVpc.Upa.Types.Date))) {
                return Net.TheVpc.Upa.Impl.Util.DateUtils.ParseUniversalDate(s);
            }
            if (c.Equals(typeof(Net.TheVpc.Upa.Types.Temporal))) {
                return Net.TheVpc.Upa.Impl.Util.DateUtils.ParseUniversalDateTime(s);
            }
            return null;
        }

        private StringUtils() {
        }

        public static string Substring(string @string, int start) {
            if (@string == null) {
                return "";
            } else {
                return Substring(@string, start, (@string).Length);
            }
        }

        public static string Substring(string @string, int start, int end) {
            if (@string == null || (@string).Length == 0) {
                return "";
            }
            if (start < 0) {
                start = 0;
            }
            if (end > (@string).Length) {
                end = (@string).Length;
            }
            if (end <= start) {
                return "";
            } else {
                return @string.Substring(start, end);
            }
        }

        public static string[] Split(string @string, char separator, bool first) {
            if (@string == null || (@string).Length == 0) {
                return null;
            }
            int i = first ? @string.IndexOf(separator) : @string.LastIndexOf(separator);
            if (i < 0) {
                return null;
            } else {
                string[] r = new string[2];
                r[0] = Substring(@string, 0, i);
                r[1] = Substring(@string, i + 1);
                return r;
            }
        }

        public static string Left(string @string, char separator, bool first) {
            string[] s = Split(@string, separator, first);
            return s != null ? s[1] : null;
        }

        public static string Right(string @string, char separator, bool first) {
            string[] s = Split(@string, separator, first);
            return s != null ? s[0] : null;
        }

        public static string Replace(string @string, string olds, string news) {
            string ret;
            int j;
            ret = @string;
            while ((j = ret.IndexOf(olds)) >= 0) {
                ret = Substring(ret, 0, j) + news + Substring(ret, j + (olds).Length);
            }
            return ret;
        }

        public static string Replace(string @string, int startOffset, int endOffset, string olds, string news) {
            string ret = Substring(@string, startOffset, endOffset);
            return Substring(@string, 0, startOffset) + Replace(ret, olds, news) + Substring(@string, endOffset);
        }

        public static bool StartsWith(string @string, string other, int offset) {
            if ((@string).Length - offset < (other).Length) {
                return false;
            }
            for (int i = 0; i < (other).Length; i++) {
                if (@string[i + offset] != other[i]) {
                    return false;
                }
            }
            return true;
        }

        private static bool Split_allzero(int[] arr) {
            foreach (int anArr in arr) {
                if (anArr > 0) {
                    return false;
                }
            }
            return true;
        }

        public static string[] Split(string str, string splitters, string cotes, string pars, char escapeChar, bool includeSeparators) {
            System.Text.StringBuilder current = new System.Text.StringBuilder();
            System.Collections.Generic.List<string> tokens = new System.Collections.Generic.List<string>(3);
            int i = 0;
            int[] parsCount = new int[(pars).Length / 2];
            while (i < (str).Length) {
                char c = str[i];
                if (cotes.IndexOf(c) >= 0) {
                    current.Append(c);
                    i++;
                    while (i < (str).Length) {
                        char c2 = str[i];
                        if (c2 == escapeChar) {
                            current.Append(str[i + 1]);
                            i = i + 2;
                        } else if (c == c2) {
                            current.Append(str[i]);
                            i++;
                            break;
                        } else {
                            current.Append(str[i]);
                            i++;
                        }
                    }
                } else if (splitters.IndexOf(c) >= 0) {
                    if (Split_allzero(parsCount)) {
                        tokens.Add(current.ToString());
                        current = new System.Text.StringBuilder();
                        if (includeSeparators) {
                            tokens.Add(System.Convert.ToString(c));
                        }
                    } else {
                        current.Append(str[i]);
                    }
                    i++;
                } else if (c == escapeChar) {
                    current.Append(str[i + 1]);
                    i = i + 2;
                } else if (pars.IndexOf(c) >= 0) {
                    int parIndex = pars.IndexOf(c);
                    if (parIndex % 2 == 0 && pars[parIndex] == pars[parIndex + 1]) {
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
                        }
                    }
                    // end
                    current.Append(str[i]);
                    i++;
                } else {
                    current.Append(str[i]);
                    i++;
                }
            }
            if ((current).Length > 0) {
                tokens.Add(current.ToString());
            }
            return tokens.ToArray();
        }

        public static string Format(long[] @value) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{long:");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    sb.Append(',');
                }
                sb.Append(@value[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string Format(int[] @value) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{int:");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    sb.Append(',');
                }
                sb.Append(@value[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string Format(short[] @value) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{short:");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    sb.Append(',');
                }
                sb.Append(@value[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string Format(double[] @value) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{double:");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    sb.Append(',');
                }
                sb.Append(@value[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string Format(char[] @value) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{char:");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    sb.Append(',');
                }
                sb.Append(@value[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string Format(byte[] @value) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("{byte:");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    sb.Append(',');
                }
                sb.Append(@value[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string Format(double @value) {
            //return UserFormats.getDecimalFormat().format(value);
            return System.Convert.ToString(@value);
        }

        public static string Format(object @value) {
            if (@value == null) {
                return "null";
            }
            if ((@value.GetType()).IsArray) {
                if (typeof(object[]).IsAssignableFrom(@value.GetType())) {
                    return Format((object[]) @value);
                } else {
                    return System.Convert.ToString(@value);
                }
            }
            if (@value is Net.TheVpc.Upa.Types.Temporal) {
                return Format((Net.TheVpc.Upa.Types.Temporal) @value);
            }
            if ((@value is float?) || (@value is double?)) {
                //            return UserFormats.getDecimalFormat().format(((Number) value).doubleValue());
                return System.Convert.ToString(@value);
            } else {
                return @value.ToString();
            }
        }

        public static string Format(Net.TheVpc.Upa.Types.Temporal @value) {
            //        return UserFormats.getShortDateTimeFormat().format(value);
            return System.Convert.ToString(@value);
        }

        public static string Format(object[] @value) {
            if (@value == null) {
                return null;
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder("{");
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    s.Append(",");
                }
                s.Append(Format(@value[i]));
            }
            s.Append("}");
            return s.ToString();
        }

        public static string Format(object[] @value, string begin, string separator, string end, string nullValue) {
            if (@value == null) {
                return nullValue;
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder(begin);
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    s.Append(separator);
                }
                s.Append(Format(@value[i]));
            }
            s.Append(end);
            return s.ToString();
        }

        public static string Format(long @value) {
            return "" + @value;
        }

        public static string Format(string @value) {
            return @value;
        }

        public static string Format(string @value, int width, int align) {
            if (width < 0) {
                return @value;
            } else {
                return new Net.TheVpc.Upa.Impl.Util.StringFormatter(width, ' ', align).Format(@value);
            }
        }

        public static bool IsNullOrEmpty(string s) {
            return s == null || (s.Trim()).Length == 0 || s.Equals(Net.TheVpc.Upa.UPA.UNDEFINED_STRING);
        }

        public static string EscapeString(string s, bool escapeDoubleQuote, bool escapeSingleQuotes, bool escapeAntiQuote) {
            return Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeStringLiteral(s, escapeDoubleQuote, escapeSingleQuotes, escapeAntiQuote);
        }

        public static string UnescapeString(string s) {
            return Net.TheVpc.Upa.Expressions.ExpressionHelper.UnescapeString(s);
        }

        public static System.Collections.Generic.IList<string> ParseVarsList(string s) {
            System.Collections.Generic.IList<string> vars = new System.Collections.Generic.List<string>();
            Net.TheVpc.Upa.Impl.Util.Regexp.PortablePattern p = new Net.TheVpc.Upa.Impl.Util.Regexp.PortablePattern("\\$\\{[a-zA-Z]+\\w*\\}");
            Net.TheVpc.Upa.Impl.Util.Regexp.PortablePatternMatcher m = p.Matcher(s);
            while (m.Find()) {
                int n = 0;
                for (int i = m.Start() - 1; i >= 0 && s[i] == '\\'; i--) {
                    n++;
                }
                if (n % 2 != 0) {
                    continue;
                }
                string var = s.Substring(m.Start() + 2, m.End() - 1);
                //            if (!vars.contains(var)) {
                vars.Add(var);
            }
            //            }
            //        if (!vars.isEmpty()) {
            //            return vars;
            //        }
            return vars;
        }

        public static string ToHexString(byte[] bytes) {
            System.Text.StringBuilder hexString = new System.Text.StringBuilder();
            for (int i = 0; i < bytes.Length; i++) {
                string hex = ((int)(((byte)0xff) & bytes[i])).ToString("X");
                if ((hex).Length == 1) {
                    hexString.Append('0');
                }
                hexString.Append(hex);
            }
            return hexString.ToString();
        }

        public static byte[] ParseHexString(string str) {
            byte[] values = new byte[(str).Length / 2];
            for (int i = 0; i < values.Length; i++) {
                values[i] = (byte) System.Convert.ToInt32(str.Substring(2 * i, 2 * i + 2), 16);
            }
            return values;
        }

        public static bool IsValue(string s) {
            return !IsNullOrEmpty(s) && !IsSimpleExpression(s);
        }

        public static bool IsSimpleExpression(string s) {
            if (s == null) {
                return false;
            }
            int i = 0;
            char[] cc = s.ToCharArray();
            while (i < cc.Length) {
                char c = cc[i];
                switch(c) {
                    case '.':
                    case '!':
                    case '$':
                        {
                            //ignore
                            break;
                        }
                    case '*':
                        {
                            return true;
                        }
                    default:
                        {
                        }
                        break;
                }
                //
                i++;
            }
            return false;
        }

        public static string ValueOf(object pattern) {
            if (pattern == null) {
                return "";
            }
            return pattern.ToString();
        }

        /**
             * *
             * **
             *
             * @param pattern
             * @return
             */
        public static string SimpexpToRegexp(string pattern, Net.TheVpc.Upa.Impl.Util.PatternType type) {
            if (pattern == null) {
                pattern = "*";
            }
            int i = 0;
            char[] cc = pattern.ToCharArray();
            System.Text.StringBuilder sb = new System.Text.StringBuilder("^");
            while (i < cc.Length) {
                char c = cc[i];
                switch(c) {
                    case '.':
                    case '!':
                    case '$':
                    case '[':
                    case ']':
                    case '(':
                    case ')':
                    case '?':
                    case '^':
                    case '\\':
                        {
                            sb.Append('\\').Append(c);
                            break;
                        }
                    case '*':
                        {
                            switch(type) {
                                case Net.TheVpc.Upa.Impl.Util.PatternType.DOT_PATH:
                                    {
                                        if (i + 1 < cc.Length && cc[i + 1] == '*') {
                                            i++;
                                            sb.Append("[a-zA-Z_0-9$.]*");
                                        } else {
                                            sb.Append("[a-zA-Z_0-9$]*");
                                        }
                                        break;
                                    }
                                case Net.TheVpc.Upa.Impl.Util.PatternType.SLASH_PATH:
                                    {
                                        if (i + 1 < cc.Length && cc[i + 1] == '*') {
                                            i++;
                                            sb.Append("[a-zA-Z_0-9$/]*");
                                        } else {
                                            sb.Append("[a-zA-Z_0-9$]*");
                                        }
                                        break;
                                    }
                                case Net.TheVpc.Upa.Impl.Util.PatternType.ANY:
                                    {
                                        sb.Append(".*");
                                        break;
                                    }
                                default:
                                    {
                                        throw new System.ArgumentException ("Unsupported");
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            sb.Append(c);
                        }
                        break;
                }
                i++;
            }
            sb.Append('$');
            return sb.ToString();
        }

        public static bool MatchesSimpleExpression(string str, string pattern, Net.TheVpc.Upa.Impl.Util.PatternType type) {
            return new Net.TheVpc.Upa.Impl.Util.Regexp.PortablePattern(SimpexpToRegexp(pattern, type)).Matcher(str == null ? "" : str).Matches();
        }

        public static bool IsUndefined(string @value) {
            return Net.TheVpc.Upa.UPA.UNDEFINED_STRING.Equals(@value);
        }

        public static bool IsUndefined(Net.TheVpc.Upa.Config.BoolEnum @value) {
            return Net.TheVpc.Upa.Config.BoolEnum.UNDEFINED.Equals(@value);
        }

        public static bool IsUndefined(System.Type @value) {
            return typeof(void).Equals(@value) || typeof(void).Equals(@value) || (@value != null && (@value).IsInterface);
        }

        public static string Trim(string @value) {
            return Net.TheVpc.Upa.Impl.Util.StringHelper.EMPTY_STRING.Format(@value);
        }
    }
}
