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



namespace Net.Vpc.Upa.Expressions
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class ExpressionHelper {

        private static readonly System.Collections.Generic.ISet<string> RESERVED_WORDS = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(new[]{"select", "update", "remove", "insert", "set", "from", "where", "and", "or", "if", "then", "switch", "case", "else", "elseif", "end", "true", "false", "null", "order", "group", "by", "desc", "asc", "inner", "left", "right", "full", "cross", "join", "having", "on", "not", "like"}));

        public static bool IsReservedWord(string s) {
            return s != null && RESERVED_WORDS.Contains(s.ToLower());
        }

        public static bool IsIdentifierStart(char s) {
            return (s >= 'a' && s <= 'z') || (s >= 'A' && s <= 'Z');
        }

        public static bool IsIdentifierPart(char s) {
            return (s >= 'a' && s <= 'z') || (s >= 'A' && s <= 'Z') || (s >= '0' && s <= '9') || (s == '_');
        }

        public static bool IsEscapeIdentifier(string s) {
            if (IsReservedWord(s)) {
                return true;
            }
            if (s == null) {
                s = "";
            }
            if ((s).Length == 0) {
                return true;
            }
            if (!IsIdentifierStart(s[0])) {
                return true;
            }
            foreach (char c in s.Substring(1).ToCharArray()) {
                if (!IsIdentifierPart(c)) {
                    return true;
                }
            }
            return false;
        }

        public static string EscapeIdentifier(string s) {
            if (IsEscapeIdentifier(s)) {
                return "`" + EscapeStringLiteral(s, false, false, true) + "`";
            }
            return s;
        }

        public static string EscapeSimpleQuoteStringLiteral(string s) {
            if (s == null) {
                return "null";
            }
            return "\'" + EscapeStringLiteral(s, false, true, false) + "\'";
        }

        public static string EscapeDoubleQuoteStringLiteral(string s) {
            if (s == null) {
                return "null";
            }
            return "\'" + EscapeStringLiteral(s, false, true, false) + "\'";
        }

        public static string EscapeStringLiteral(string str, bool escapeDoubleQuote, bool escapeSingleQuote, bool escapeAntiQuote) {
            System.Text.StringBuilder outString = new System.Text.StringBuilder();
            if (str == null) {
                return null;
            }
            int sz;
            sz = (str).Length;
            for (int i = 0; i < sz; i++) {
                char ch = str[i];
                // handle unicode
                if (ch > 0xfff) {
                    outString.Append("\\u").Append(Hex(ch));
                } else if (ch > 0xff) {
                    outString.Append("\\u0").Append(Hex(ch));
                } else if (ch > 0x7f) {
                    outString.Append("\\u00").Append(Hex(ch));
                } else if (ch < 32) {
                    switch(ch) {
                        case '\b':
                            outString.Append('\\');
                            outString.Append('b');
                            break;
                        case '\n':
                            outString.Append('\\');
                            outString.Append('n');
                            break;
                        case '\t':
                            outString.Append('\\');
                            outString.Append('t');
                            break;
                        case '\f':
                            outString.Append('\\');
                            outString.Append('f');
                            break;
                        case '\r':
                            outString.Append('\\');
                            outString.Append('r');
                            break;
                        default:
                            if (ch > 0xf) {
                                outString.Append("\\u00").Append(Hex(ch));
                            } else {
                                outString.Append("\\u000").Append(Hex(ch));
                            }
                            break;
                    }
                } else {
                    switch(ch) {
                        case '\'':
                            if (escapeSingleQuote) {
                                outString.Append('\\');
                            }
                            outString.Append('\'');
                            break;
                        case '`':
                            if (escapeAntiQuote) {
                                outString.Append('\\');
                            }
                            outString.Append('`');
                            break;
                        case '"':
                            if (escapeDoubleQuote) {
                                outString.Append('\\');
                            }
                            outString.Append('"');
                            break;
                        case '\\':
                            outString.Append('\\');
                            outString.Append('\\');
                            break;
                        default:
                            outString.Append(ch);
                            break;
                    }
                }
            }
            return outString.ToString();
        }

        private static string Hex(char ch) {
            return ((int)(ch)).ToString("X").ToUpper();
        }

        public static string UnescapeString(string str) {
            if (str == null) {
                return null;
            }
            System.Text.StringBuilder outStr = new System.Text.StringBuilder();
            int sz = (str).Length;
            System.Text.StringBuilder unicode = new System.Text.StringBuilder(4);
            bool encountredSlash = false;
            bool unicodeStr = false;
            for (int i = 0; i < sz; i++) {
                char ch = str[i];
                if (unicodeStr) {
                    unicode.Append(ch);
                    if ((unicode).Length == 4) {
                        try {
                            int @value = System.Convert.ToInt32(unicode.ToString(), 16);
                            outStr.Append((char) @value);
                            unicode.Remove(0, (unicode).Length);
                            unicodeStr = false;
                            encountredSlash = false;
                        } catch (System.Exception nfe) {
                            throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Unable to parse unicode value: " + unicode, nfe);
                        }
                    }
                    continue;
                }
                if (encountredSlash) {
                    encountredSlash = false;
                    switch(ch) {
                        case '\\':
                            outStr.Append('\\');
                            break;
                        case '\'':
                            outStr.Append('\'');
                            break;
                        case '\"':
                            outStr.Append('"');
                            break;
                        case 'r':
                            outStr.Append('\r');
                            break;
                        case 'f':
                            outStr.Append('\f');
                            break;
                        case 't':
                            outStr.Append('\t');
                            break;
                        case 'n':
                            outStr.Append('\n');
                            break;
                        case 'b':
                            outStr.Append('\b');
                            break;
                        case 'u':
                            {
                                unicodeStr = true;
                                break;
                            }
                        default:
                            outStr.Append(ch);
                            break;
                    }
                    continue;
                } else if (ch == '\\') {
                    encountredSlash = true;
                    continue;
                }
                outStr.Append(ch);
            }
            if (encountredSlash) {
                outStr.Append('\\');
            }
            return outStr.ToString();
        }
    }
}
